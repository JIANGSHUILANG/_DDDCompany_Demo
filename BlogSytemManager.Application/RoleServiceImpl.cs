using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogSytemManager.DomainObject;
using BlogSytemManager.DomainObject._PageOfItems;
using BlogSytemManager.Infrastructure.ExpressionHelper;
using BlogSytemManager.IService;
using BlogSytemManager.Repository.Repositories;
using BolgSytemManager.Domain.IRepositories;
using BolgSytemManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogSytemManager.Application
{
    /// <summary>
    /// 用户权限管理
    /// </summary>
    public partial class RoleServiceImpl : ApplicationServiceImpl<RoleObject, Role>, IRoleService
    {

        #region IRoleRepository CURD

        //public RoleObjectList GetAllRole()
        //{
        //    var temp = RoleRepository.LoadEnities(c => true).ToList();
        //    return AutoMapper.Mapper.Map<RoleObjectList>(temp);
        //}

        //public RoleObject GetRoleById(object id)
        //{
        //    var temp = RoleRepository.GetByKey(id);
        //    return AutoMapper.Mapper.Map<RoleObject>(temp);
        //}

        //public RoleObjectList GetAllRolePageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null)
        //{
        //    int TotalCount;

        //    var tempWhere_lamda = ExpressionXElment.DeserializeExpression<RoleObject, bool>(wherelamda);
        //    var Where_lamda = base.GetDTOByLamda<RoleObject, Role, bool>(tempWhere_lamda);

        //    var tempOrder_lamda = ExpressionXElment.DeserializeExpression<RoleObject, int>(wherelamda);
        //    var Order_lamda = base.GetDTOByLamda<RoleObject, Role, int>(tempOrder_lamda);

        //    var list = RoleRepository.LoadPageEnities<int>(pageIndex, pageSize, out TotalCount, Where_lamda, Order_lamda, false).ToList();

        //    var temp = AutoMapper.Mapper.Map<RoleObjectList>(list);
        //    return temp;
        //}

        //public bool DeleteRoleById(object id)
        //{
        //    return RoleRepository.Delete(id) > 0;
        //}

        //public bool DeleteRoles(string[] ids)
        //{
        //    var list = new List<Role>();
        //    foreach (var item in ids)
        //    {
        //        list.Add(RoleRepository.GetByKey(Convert.ToInt32(item)));
        //    }
        //    return RoleRepository.Delete(list) > 0;
        //}

        //public bool UpdateRole(RoleObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<Role>(obj);
        //    return RoleRepository.Update(temp) > 0;
        //}

        //public bool UpdateRoles(RoleObjectList objs)
        //{
        //    bool flag = false;
        //    var temp = AutoMapper.Mapper.Map<List<Role>>(objs);
        //    foreach (var item in temp)
        //    {
        //        flag = RoleRepository.Update(item) > 0;
        //        if (!flag)
        //            break;
        //    }
        //    return flag;
        //}

        //public bool CreateRole(RoleObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<Role>(obj);
        //    return RoleRepository.Add(temp) > 0;
        //}

        //public RoleObjectPageOfItems GetRolepageOfitems(int pageIndex, int pageSize, RoleObjectPageOfItems pageofitems)
        //{
        //    int Totalcount;
        //    var temp = RoleRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
        //    pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
        //    pageofitems.PageIndex = pageIndex;
        //    pageofitems.PageSize = pageSize;
        //    pageofitems.RoleObjectLists = AutoMapper.Mapper.Map<RoleObjectList>(temp);
        //    return pageofitems;
        //}

        #endregion

        public RoleObjectPageOfItems GetRolepageOfitems(int pageIndex, int pageSize, RoleObjectPageOfItems pageofitems)
        {
            int Totalcount;
            var temp = roleRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
            pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
            pageofitems.AllCount = Totalcount;
            pageofitems.PageIndex = pageIndex;
            pageofitems.PageSize = pageSize;
            pageofitems.RoleObjectLists = AutoMapper.Mapper.Map<RoleObjectList>(temp);
            return pageofitems;
        }
    }
}
