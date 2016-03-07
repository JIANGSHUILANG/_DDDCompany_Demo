using ExpressionSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WCF不支持Expression解决方案
{
    public class Class1
    {
        public static List<Person> listTemp
        {
            get
            {
                List<Person> str = new List<Person>();
                for (int i = 0; i < 10; i++)
                {
                    str.Add(new Person() { ID = i, Name = "zhangsan" + i });
                }
                return str;
            }
        }

        static void Main()
        {

            //var Test1 = typeof(Person).Assembly; //当前程序集
            //var Test2 = typeof(ExpressionType).Assembly; //ExpressionType的程序集
            //var Test3 = typeof(IQueryable).Assembly;//IQueryable的程序集



            //http://blog.csdn.net/heshengfen123/article/details/17301071
            //项目 Lib 中 有 ExpressionSerialization.dll
            //WCF 不支持 Expression ,可以使用XElment     只需要使用 ExpressionSerialization.dll


            //1.将ExpressionSerialization工程的ExpressionSerializer(Deserialize).cs 文件中的“if (xml.IsEmpty)”语句替换为“if (xml.IsEmpty || !xml.Elements().Any())”，共有3处，然后重新编译ExpressionSerialization，添加引用

            //2.把客户端传过去的 lamda数据转为XElement的XML数据


          




            /**************************************客户端*************************************/

           //Dynamic Expression API
            var input = "zhangsan1";  //  还有有错误哦，当参数动态时候就报错
            Expression<Func<Person, bool>> exp = c => c.Name == input;
            Console.WriteLine(exp);

            var assemblies = new List<Assembly> { typeof(Person).Assembly, typeof(ExpressionType).Assembly, typeof(IQueryable).Assembly };

            TypeResolver resolver = new TypeResolver(assemblies, new[] { typeof(Person) });

            var knownTypeConverter = new KnownTypeExpressionXmlConverter(resolver);
            var serializer = new ExpressionSerializer(resolver, new CustomExpressionXmlConverter[] { knownTypeConverter });

            XElement element = serializer.Serialize(exp);


            //调用服务端：
            var temp = Get(element);



            Console.WriteLine(exp);
            Console.ReadKey();
        }

        /**************************************服务端*************************************/
        public static Person Get(XElement element)
        {
            var assemblies = new List<Assembly> { typeof(Person).Assembly, typeof(ExpressionType).Assembly, typeof(IQueryable).Assembly };
            var resolver = new TypeResolver(assemblies, new[] { typeof(Person) });
            var knownTypeConverter = new KnownTypeExpressionXmlConverter(resolver);
            var serializer = new ExpressionSerializer(resolver, new CustomExpressionXmlConverter[] { knownTypeConverter });
            var predicate = serializer.Deserialize<Func<Person, bool>>(element);
            return listTemp.Where(predicate.Compile()).FirstOrDefault();
        }

    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
