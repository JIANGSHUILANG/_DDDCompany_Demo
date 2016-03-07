using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Infrastructure.Helper
{
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  单个对象映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            Mapper.CreateMap(obj.GetType(), typeof(T));
            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map<List<TDestination>>(source);
        }
    }
}
