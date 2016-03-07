using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
namespace Expression扩展及动态使用
{
    class ExpressionEx
    {
        static void CCC()
        {
            #region 转换为IQueryable类型

            //var Pers = new List<Person>();
            //IQueryable<Person> iqs = Pers.AsQueryable<Person>();

            #endregion

            #region  合并 Expression 表达式

            ParameterExpression exp1 = Expression.Parameter(typeof(int), "A");

            ParameterExpression exp2 = Expression.Parameter(typeof(int), "B");

            BinaryExpression binary = Expression.Multiply(exp1, exp2);//创建一个表示不进行溢出检查的算术乘法运算的表达式

            var lamtemp = Expression.Lambda<Func<int, int, int>>(binary, new ParameterExpression[] { exp1, exp2 }); 

            #endregion


            string sss = "11111";
            sss.ToLower();
            Console.ReadKey();

       
            
        }

        static string[] SplitCamelCase(string input)
        {
            return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim().Split(' ');
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public static class Operator<T>
    {
        private static readonly Func<T, T> ShallowClone;

        public static T ShallowCopy(T sourcObj)
        {
            return ShallowClone.Invoke(sourcObj);
        }

        static Operator()
        {
            var origParam = Expression.Parameter(typeof(T), "orig");

            // for each read/write property on T, create a  new binding 
            // (for the object initializer) that copies the original's value into the new object 
            var setProps = from prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                           where prop.CanRead && prop.CanWrite
                           select (MemberBinding)Expression.Bind(prop, Expression.Property(origParam, prop));

            var body = Expression.MemberInit( // object initializer 
                Expression.New(typeof(T)), // ctor 
                setProps // property assignments 
            );

            ShallowClone = Expression.Lambda<Func<T, T>>(body, origParam).Compile();
        }
    }

}
