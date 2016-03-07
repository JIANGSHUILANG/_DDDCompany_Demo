using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogSytemManager.DomainObject;
using BlogSytemManager.DomainObject._PageOfItems;
using BlogSytemManager.Infrastructure;
using BlogSytemManager.Infrastructure.ExpressionHelper;
using BolgSytemManager.Domain.Base;
using BolgSytemManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogSytemManager.Application
{
    public class ApplicationServiceImpl<DTO, Entity> : DisposableObject
        where Entity : AggregateRoot
        where DTO : BaseObject
    {
        #region Expresson

        //public Expression<Func<DOMAIN, S>> GetDTOByLamda<DTO, DOMAIN, S>(Expression<Func<DTO, S>> lamda = null)
        //    where DOMAIN : AggregateRoot
        //    where DTO : BaseObject
        //{
        //    //AutoMapper.AutoMapperMappingException”类型的未经处理的异常在 AutoMapper.dll 
        //    //Mapper.CreateMap<DomainModel, Dto>(); //把Domain映射为DTO  ,没有这句话将报上面的错误    
        //    if (lamda == null)
        //    {
        //        return default(Expression<Func<DOMAIN, S>>); //Lamda表达式为空直接返回转换后的DTO
        //    }

        //    //得到从Web传过来和DTOModel相关的lamaba表达式的委托

        //    //Mapper.CreateMap<Dto, DomainModel>(); //把DTO映射为Domain

        //    Func<DTO, S> match = lamda.Compile();

        //    //创建映射Expression的委托,selector表达式是约束于（DTO_BaseModel）不是约束于（ AggregateRoot ）
        //    //此委托是表示 传入 DomainModel参数，返回值是：DTO
        //    Func<DOMAIN, DTO> mapper = Extensions.CreateMapExpression<DOMAIN, DTO>(Mapper.Engine).Compile();

        //    //得到领域Model相关的lamada
        //    Expression<Func<DOMAIN, S>> temp = ef_t => match(mapper(ef_t));
        //    return temp;
        //}


        //public PageOfItems<OBJ> PageOfItemBySelfModel<OBJ, OrderByType>(int pageIndex, int pageSize, IQueryable<OBJ> list, System.Linq.Expressions.Expression<Func<OBJ, bool>> whereLambda, System.Linq.Expressions.Expression<Func<OBJ, OrderByType>> orderbyLambad = null, bool isAsc = true)
        //{
        //    var info = list.Where<OBJ>(whereLambda);

        //    var list_return = new PageOfItems<OBJ>()
        //    {
        //        PageNumber = pageIndex,
        //        PageSize = pageSize,
        //        TotalItemCount = info.Count()
        //    };
        //    IQueryable<OBJ> orderList = null;
        //    if (orderbyLambad != null)
        //    {
        //        if (isAsc)
        //        {
        //            orderList = info.OrderBy<OBJ, OrderByType>(orderbyLambad).Skip<OBJ>((pageIndex - 1) * pageSize).Take<OBJ>(pageSize);
        //        }
        //        else
        //        {
        //            orderList = info.OrderByDescending<OBJ, OrderByType>(orderbyLambad).Skip<OBJ>((pageIndex - 1) * pageSize).Take<OBJ>(pageSize);
        //        }
        //    }
        //    else
        //    {
        //        orderList = info.Skip<OBJ>((pageIndex - 1) * pageSize).Take<OBJ>(pageSize);
        //    }
        //    list_return.AddRange(orderList.ToList());
        //    return list_return;
        //}

        #endregion

        public IBaseRepository<Entity> repository { get; set; }

        public ApplicationServiceImpl() { }

        public ApplicationServiceImpl(IBaseRepository<Entity> repository)
        {    
            this.repository = repository;
            Mapper.CreateMap<Entity, DTO>();
        }

        #region IBaseRepository CURD

        protected DTO[] GetAllDataObject()
        {
            var temp = repository.LoadEnities(c => true);
           
            return AutoMapper.Mapper.Map<DTO[]>(temp);
        }

        protected DTO GetDataObjectById(object id)
        {
            var temp = repository.GetByKey(id);
            return AutoMapper.Mapper.Map<DTO>(temp);
        }

        //public UserInfoObjectList GetAllUserInfoPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null)
        //{
        //    int TotalCount;

        //    var tempWhere_lamda = ExpressionXElment.DeserializeExpression<UserInfoObject, bool>(wherelamda);
        //    var Where_lamda = base.GetDTOByLamda<UserInfoObject, UserInfo, bool>(tempWhere_lamda);

        //    var tempOrder_lamda = ExpressionXElment.DeserializeExpression<UserInfoObject, int>(wherelamda);
        //    var Order_lamda = base.GetDTOByLamda<UserInfoObject, UserInfo, int>(tempOrder_lamda);

        //    var list = userInfoRepository.LoadPageEnities<int>(pageIndex, pageSize, out TotalCount, Where_lamda, Order_lamda, false).ToList();

        //    var temp = AutoMapper.Mapper.Map<UserInfoObjectList>(list);
        //    return temp;
        //}

        protected bool DeleteDataObjectById(object id)
        {
            return repository.Delete(id) > 0;
        }

        protected bool DeleteDataObjects(string[] ids)
        {
            var list = new List<Entity>();
            foreach (var item in ids)
            {
                list.Add(repository.GetByKey(Convert.ToInt32(item)));
            }
            return repository.Delete(list) > 0;
        }

        protected bool UpdateDataObject(DTO obj)
        {
            var temp = AutoMapper.Mapper.Map<Entity>(obj);
            return repository.Update(temp) > 0;
        }

        protected bool UpdateDataObjects(DTO[] objs)
        {
            bool flag = false;
            var temp = AutoMapper.Mapper.Map<List<Entity>>(objs);
            foreach (var item in temp)
            {
                flag = repository.Update(item) > 0;
                if (!flag)
                    break;
            }
            return flag;
        }

        protected DTO CreateDataObject(DTO obj)
        {
            var temp = AutoMapper.Mapper.Map<Entity>(obj);
            Entity entity = repository.Add(temp);
            return AutoMapper.Mapper.Map<DTO>(entity);
        }

        #endregion

        protected override void Dispose(bool disposing) { }
    }

    public class ApplicationInitalze
    {
        public static void InitializeAutoMapper()
        {
            AutoMapper.Mapper.CreateMap<UserInfo, UserInfoObject>();
            AutoMapper.Mapper.CreateMap<UserInfoObject, UserInfo>();

            AutoMapper.Mapper.CreateMap<Role, RoleObject>();
            AutoMapper.Mapper.CreateMap<RoleObject, Role>();

            AutoMapper.Mapper.CreateMap<ActionInfo, ActionInfoObject>();
            AutoMapper.Mapper.CreateMap<ActionInfoObject, ActionInfo>();

            AutoMapper.Mapper.CreateMap<Menu, MenuObject>();
            AutoMapper.Mapper.CreateMap<MenuObject, Menu>();

            AutoMapper.Mapper.CreateMap<MenuChilden, MenuChildenObject>();
            AutoMapper.Mapper.CreateMap<MenuChildenObject, MenuChilden>();
        }
    }
}
