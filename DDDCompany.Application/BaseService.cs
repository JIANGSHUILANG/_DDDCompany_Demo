using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDDCompany.Domain.BaseModel;
using DDDCompany.Domain.EFModel;
using DDDCompany.Domain.IRepositories.Base;
using DDDCompany.DtoModel.Base;
using DDDCompany.DtoModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Application
{
    public class BaseService
    {

        public List<Dto> GetDTOByLamda<Dto, DomainModel>(IRepository<DomainModel> oRepository, Expression<Func<Dto, bool>> selector = null)
            where DomainModel : AggregateRoot
            where Dto : DTO_BaseModel
        {
            //AutoMapper.AutoMapperMappingException”类型的未经处理的异常在 AutoMapper.dll 
            //Mapper.CreateMap<DomainModel, Dto>(); //把Domain映射为DTO  ,没有这句话将报上面的错误    

            if (selector == null)
            {
                var domain_model = oRepository.Entites.ToList();
                return Mapper.Map<List<DomainModel>, List<Dto>>(domain_model); //Lamda表达式为空直接返回转换后的DTO
            }

            //得到从Web传过来和DTOModel相关的lamaba表达式的委托

            //Mapper.CreateMap<Dto, DomainModel>(); //把DTO映射为Domain

            Func<Dto, bool> match = selector.Compile();

            //创建映射Expression的委托,selector表达式是约束于（DTO_BaseModel）不是约束于（ AggregateRoot ）
            //此委托是表示 传入 DomainModel参数，返回值是：DTO
            Func<DomainModel, Dto> mapper = Extensions.CreateMapExpression<DomainModel, Dto>(Mapper.Engine).Compile();
            
            //得到领域Model相关的lamada
            Expression<Func<DomainModel, bool>> lamada = ef_t => match(mapper(ef_t));
         
            var list = oRepository.LoadEnities(lamada).ToList();
            return Mapper.Map<List<DomainModel>, List<Dto>>(list);
        }

        /// <summary>
        /// 对应用层服务进行初始化。
        /// </summary>
        /// <remarks>包含的初始化任务有：
        /// 1. AutoMapper框架的初始化</remarks>
        public static void Initialize()
        {
            Mapper.CreateMap<User, DTO_User>()  //User映射为=>DTO_User
            .ForMember(dest => dest.Role_Name, opt => opt.MapFrom(c => c.Role.Role_Name))
            .ForMember(dest=>dest.Role_Status,opt=>opt.MapFrom(c=>c.Role.Status))
            .ForMember(dest => dest.CreateTime, opt => opt.Ignore()); //opt.Ignore  忽略CreateTime这个字段的映射

            Mapper.CreateMap<DTO_User, User>();  //DTO_User映射为=>User
        }
    }
}
