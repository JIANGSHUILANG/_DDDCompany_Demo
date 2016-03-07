using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expression扩展及动态使用
{
    class ExPressionEx_01
    {
        static void Main1()
        {
            //初级进化（最原始的匿名委托形式）：
            Func<string, bool> lamda = delegate(string x) { return x.Contains("_"); };

            //高级进化（高级的匿名委托形式）：
            Func<string, bool> lamda_high = (string x) => { return x.Contains("_"); };

            //究极进化（完完全全的Lamada）
            Func<string, bool> lamda_fast = x => x.Contains("_");

            List<string> list = new List<string>() 
            {
                "_zangsan",
                "_lisi",
                "wangwu"
            };
            list.Where(lamda_fast); //结果  _zangsan  ，_lisi



            //--------------------动态Lamda----------------------

            //1.定义lamada的参数，型如我们常写的“x=>”
            ParameterExpression m_Parameter = Expression.Parameter(typeof(DTO_ORDER), "x");

            //2.定义要使用lamada的属性成员（比如我们这里要对DTO_ORDER对象的ORDER_NO属性做筛选）
            MemberExpression member = Expression.PropertyOrField(m_Parameter, "ORDER_NO");

            //3.定义筛选的操作（是大于、等于、小于、like等）
            Expression expRes = Expression.Equal(member, Expression.Constant("aaaa", member.Type));

            //4.将表达式转换为Lamada的表达式
            Expression<Func<DTO_ORDER, bool>> exprelamada = Expression.Lambda<Func<DTO_ORDER, bool>>(expRes, m_Parameter);

            //如上就是拼接Lamda表达式
            //所拼接出来是这样的：  x=>x.ORDER_NO=="aaaa"


            var lstRes = new List<DTO_ORDER>();
            for (var i = 0; i < 10; i++)
            {
                var oModel = new DTO_ORDER();
                oModel.ORDER_NO = i % 2 == 0 ? "aaaa" : "bbbb";
                oModel.ID = i;
                lstRes.Add(oModel);
            }
          

            //5.将Expression表达式转换为Func委托，用于Where里面的参数
            var lamada = exprelamada.Compile();
            lstRes = lstRes.Where(lamada).ToList();
            foreach (var item in lstRes)
            {
                Console.WriteLine(item.ORDER_NO);
            }
            Console.WriteLine(lstRes.Count());
            Console.ReadKey();

        }
    }
    public class DTO_ORDER
    {
        public string TO_ORDER_ID { get; set; }
        public string ORDER_NO { get; set; }
        public string ORDER_NAME { get; set; }
        public int ID { get; set; }
    }
}
