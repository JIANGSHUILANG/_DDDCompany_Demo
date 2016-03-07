WCF传递参数不支持 Expression ：

Expression Tree Serializer 提供的解决方案是 把Expression表达式树转换为XElement类型的XML数据，传输到服务端，再反转换还原成原来的Expression表达式

所以，客户端与服务端之间传送的数据是XElement类型的数据了，从而避开了Expression类型不能序列化的问题

只用到ExpressionSerialization.dll