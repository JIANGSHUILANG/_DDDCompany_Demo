using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 消息队列
{
    public interface IMessageQueueHandler
    { 
    
    }

    public abstract class MessageQueueConcurrentHandlerBase<T> : IMessageQueueHandler
    {
        public MessageQueueConcurrentHandlerBase(string queueName, int maxConcurrency = 5, Action<string> logDelegate = null)
        {
            if (!MessageQueue.Exists(queueName))
                throw new Exception(string.Format("No such a queue: {0}", queueName));
            if (maxConcurrency < 1)
                throw new ArgumentOutOfRangeException("maxConcurrency");

            this._queueName = queueName;
            this._poolForConsumer = new Semaphore(0, maxConcurrency);
            this._producerAutoResetEvent = new AutoResetEvent(false);
            this._maxConcurrency = maxConcurrency;
            this._logDelegate = logDelegate;
        }

        public void StartRead()
        {
            this._queue = new MessageQueue(this._queueName) { Formatter = new XmlMessageFormatter(new Type[] { typeof(long) }) };
            this._queue.PeekCompleted += new PeekCompletedEventHandler(Produce);
            this._producerAutoResetEvent.Set();
            this._poolForConsumer.Release(this._maxConcurrency);

            this._queue.BeginPeek();
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this.HandlerName, this._queueName);
        }

        public long CurrentWorkerCount { get { return Interlocked.Read(ref this._currentWorkerCount); } }

        public int MaxConcurrency { get { return _maxConcurrency; } }

        protected abstract string HandlerName { get; }

        protected abstract void MainProcess(T messageItem, string consumerName);

        protected void LogInfo(string msg)
        {
            if (_logDelegate != null)
            {
                this._logDelegate(msg);
            }
        }

        #region private
        private void Produce(object sender, PeekCompletedEventArgs e)
        {
            this._producerAutoResetEvent.WaitOne();

            var message = this._queue.EndPeek(e.AsyncResult);

            long consumerIndex = Interlocked.Increment(ref this._consumerIndex);
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Consume), consumerIndex);
            this._queue.BeginPeek();
        }

        private void Consume(object stateInfo)
        {
            long consumerIndex = (long)stateInfo;
            string consumerName = string.Format("{0}-{1}", this.HandlerName, consumerIndex);

            this._poolForConsumer.WaitOne();

            var message = this._queue.Receive();
            this._producerAutoResetEvent.Set();

            T messageItem = (T)message.Body;

            this.LogInfo(string.Format("{0} Received a message, MessageItem = {1}", consumerName, messageItem));
            Interlocked.Increment(ref this._currentWorkerCount);

            try
            {
                this.LogInfo(string.Format("{0} will run MainProcess, MessageItem = {1}, CurrentWorkerCount = {2}", consumerName, messageItem, this.CurrentWorkerCount));
                MainProcess(messageItem, consumerName);
            }
            catch (Exception ex)
            {
                this.HandleException(ex, messageItem);
            }
            finally
            {
                Interlocked.Decrement(ref this._currentWorkerCount);

                this.LogInfo(string.Format("{0} run over, messageItem = {1}, CurrentWorkerCount = {2}", consumerName, messageItem, this.CurrentWorkerCount));
            }

            this._poolForConsumer.Release();
        }

        private void HandleException(Exception ex, T messageItem)
        {
            this.LogInfo(string.Format("Exception in {0}:[Message]={1},[StackTrace]={2},[Type]={3},[CurrentWorkerCount]={4},[messageItem]={5}", this.HandlerName, ex.GetBaseException().Message, ex.StackTrace, ex.GetType(), this.CurrentWorkerCount, messageItem));
        }

        private readonly string _queueName;
        private MessageQueue _queue;
        private long _currentWorkerCount;
        private Semaphore _poolForConsumer;
        private AutoResetEvent _producerAutoResetEvent;
        private int _maxConcurrency;
        private Action<string> _logDelegate;
        private long _consumerIndex = 0;
        #endregion
    }
}
