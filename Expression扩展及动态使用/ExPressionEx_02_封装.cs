using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Expression扩展及动态使用
{
    class ExPressionEx_02_封装
    {
        static void Main()
        {

            #region 数据库中的数据
            List<Student> list = new List<Student>() 
            {
            new Student(){ID=1,Name="张三",Sbject="语文",CreateTime=DateTime.Now},
            new Student(){ID=2,Name="李四",Sbject="数学",CreateTime=DateTime.Now.AddDays(1)},
            new Student(){ID=3,Name="王五",Sbject="英语",CreateTime=DateTime.Now.AddDays(2)},
            new Student(){ID=4,Name="赵六",Sbject="语文",CreateTime=DateTime.Now.AddDays(3)},
            };
            #endregion
            //1.定义对象，传入泛型
            var oLamadaExtention = new LamadaExtention<Student>();
            //用户传入的数据
            string sbject = "语文";
            string time = "2015-11-06";
            if (!string.IsNullOrWhiteSpace(sbject))
            {
                oLamadaExtention.GetExpression("Sbject", sbject, ExpressionType.Equal);
            }
            if (!string.IsNullOrWhiteSpace(time))
            {
                oLamadaExtention.GetExpression("CreateTime", Convert.ToDateTime(time), ExpressionType.Contains);
            }

            var wherelamda = oLamadaExtention.GetLambda();
            var vs = list.AsQueryable().Where(wherelamda);
            Console.WriteLine(vs.Count());



            var lamdas = new List<Expression>();
            Expression<Func<Student, bool>> n1 = c => c.ID == 1;

            Expression<Func<Student, bool>> n3 = c => c.Sbject == "语文";
            lamdas.Add(n1);
            lamdas.Add(n3);


            Expression expres = null;
            foreach (Expression item in lamdas)
            {
                if (expres != null)
                    expres = Expression.And(expres, item, typeof(String).GetMethod("CompareTo", new Type[] { typeof(String) }));
                else
                    expres = item;
            }
            int a = 0;
            var ccccc = Expression.Lambda<Func<Student, bool>>(expres);
            Console.ReadKey();
        }

    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sbject { get; set; }
        public DateTime CreateTime { get; set; }
    }

    public class LamadaExtention<Dto> where Dto : new()
    {
        private List<Expression> m_lstExpression = null;
        private ParameterExpression m_Parameter = null;

        public LamadaExtention()
        {
            m_lstExpression = new List<Expression>();
            m_Parameter = Expression.Parameter(typeof(Dto), "x");
        }

        //构造表达式，存放到m_lstExpression集合里面
        public void GetExpression(string strPropertyName, object strValue, ExpressionType expressType)
        {
            Expression expRes = null;
            MemberExpression member = Expression.PropertyOrField(m_Parameter, strPropertyName);
            if (expressType == ExpressionType.Contains)
            {
                expRes = Expression.Call(member, typeof(string).GetMethod("Contains"), Expression.Constant(strValue));
            }
            else if (expressType == ExpressionType.Equal)
            {
                expRes = Expression.Equal(member, Expression.Constant(strValue, member.Type));
            }
            else if (expressType == ExpressionType.LessThan)
            {
                expRes = Expression.LessThan(member, Expression.Constant(strValue, member.Type));
            }
            else if (expressType == ExpressionType.LessThanOrEqual)
            {
                expRes = Expression.LessThanOrEqual(member, Expression.Constant(strValue, member.Type));
            }
            else if (expressType == ExpressionType.GreaterThan)
            {
                expRes = Expression.GreaterThan(member, Expression.Constant(strValue, member.Type));
            }
            else if (expressType == ExpressionType.GreaterThanOrEqual)
            {
                expRes = Expression.GreaterThanOrEqual(member, Expression.Constant(strValue, member.Type));
            }
            //return expRes;
            m_lstExpression.Add(expRes);
        }

        //针对Or条件的表达式
        public void GetExpression(string strPropertyName, List<object> lstValue)
        {
            Expression expRes = null;
            MemberExpression member = Expression.PropertyOrField(m_Parameter, strPropertyName);
            foreach (var oValue in lstValue)
            {
                if (expRes == null)
                {
                    expRes = Expression.Equal(member, Expression.Constant(oValue, member.Type));
                }
                else
                {
                    expRes = Expression.Or(expRes, Expression.Equal(member, Expression.Constant(oValue, member.Type)));
                }
            }


            m_lstExpression.Add(expRes);
        }

        //得到Lamada表达式的Expression对象
        public Expression<Func<Dto, bool>> GetLambda()
        {
            Expression whereExpr = null;
            foreach (var expr in this.m_lstExpression)
            {
                if (whereExpr == null) whereExpr = expr;
                else whereExpr = Expression.And(whereExpr, expr);
            }
            if (whereExpr == null)
                return null;
            return Expression.Lambda<Func<Dto, Boolean>>(whereExpr, m_Parameter);
        }
    }

    //用于区分操作的枚举
    public enum ExpressionType
    {
        Contains,//like
        Equal,//等于
        LessThan,//小于
        LessThanOrEqual,//小于等于
        GreaterThan,//大于
        GreaterThanOrEqual//大于等于
    }
}
