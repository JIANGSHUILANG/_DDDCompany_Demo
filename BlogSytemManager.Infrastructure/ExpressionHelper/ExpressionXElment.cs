using ExpressionSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogSytemManager.Infrastructure.ExpressionHelper
{
    /// <summary>
    ///  解决 WCF 传递参数不能使用 Expression 问题
    /// </summary>
    public static class ExpressionXElment
     {
 
         public static Expression<Func<T, TS>> CreateExpression<T, TS>(string expression, params object[] values)
         {
             if (expression == null)
             {
                 throw new ArgumentNullException("expression");
             }
             return System.Linq.Dynamic.DynamicExpression.ParseLambda<T, TS>(expression, values);
         }
 
         public static XElement SerializeExpression(Expression predicate, IEnumerable<Type> knownTypes = null)
         {
             if (predicate == null)
             {
                 throw new ArgumentNullException("predicate");
             }
             var serializer = CreateSerializer(knownTypes);
             return serializer.Serialize(predicate);
         }
 
         public static XElement SerializeExpression<T, TS>(Expression<Func<T, TS>> predicate)
         {
             if (predicate == null)
             {
                 throw new ArgumentNullException("predicate");
             }
             var knownTypes = new List<Type> { typeof(T) };
             var serializer = CreateSerializer(knownTypes);
             return serializer.Serialize(predicate);
         }
 
         public static Expression DeserializeExpression(XElement xmlExpression)
         {
             if (xmlExpression == null)
             {
                 throw new ArgumentNullException("xmlExpression");
             }
             var serializer = CreateSerializer();
             return serializer.Deserialize(xmlExpression);
         }
 
         public static Expression<Func<T, TS>> DeserializeExpression<T, TS>(XElement xmlExpression)
         {
             if (xmlExpression == null)
             {
                 throw new ArgumentNullException("xmlExpression");
             }
             var knownTypes = new List<Type> { typeof(T) };
             var serializer = CreateSerializer(knownTypes);
             return serializer.Deserialize<Func<T, TS>>(xmlExpression);
         }
 
         public static Expression<Func<T, TS>> DeserializeExpression<T, TS>(XElement xmlExpression, IEnumerable<Type> knownTypes)
         {
             if (xmlExpression == null)
             {
                 throw new ArgumentNullException("xmlExpression");
             }
             var serializer = CreateSerializer(knownTypes);
             return serializer.Deserialize<Func<T, TS>>(xmlExpression);
         }
 
         private static ExpressionSerializer CreateSerializer(IEnumerable<Type> knownTypes = null)
         {
             if (knownTypes == null || !knownTypes.Any())
             {
                 return new ExpressionSerializer();
             }
             var assemblies = new List<Assembly> { typeof(ExpressionType).Assembly, typeof(IQueryable).Assembly };
             knownTypes.ToList().ForEach(type => assemblies.Add(type.Assembly));
             var resolver = new TypeResolver(assemblies, knownTypes);
             var knownTypeConverter = new KnownTypeExpressionXmlConverter(resolver);
             var serializer = new ExpressionSerializer(resolver, new CustomExpressionXmlConverter[] { knownTypeConverter });
             return serializer;
    
     }
 }
}
