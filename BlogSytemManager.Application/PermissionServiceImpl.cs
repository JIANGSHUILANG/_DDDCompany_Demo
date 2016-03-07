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
    public partial class PermissionServiceImpl : ApplicationServiceImpl<PermissionObject, Permission>, IPermissionService
    {

        #region IPermissionRepository CURD

        //public PermissionObjectList GetAllPermission()
        //{
        //    var temp = PermissionRepository.LoadEnities(c => true).ToList();
        //    return AutoMapper.Mapper.Map<PermissionObjectList>(temp);
        //}

        //public PermissionObject GetPermissionById(object id)
        //{
        //    var temp = PermissionRepository.GetByKey(id);
        //    return AutoMapper.Mapper.Map<PermissionObject>(temp);
        //}

        //public PermissionObjectList GetAllPermissionPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null)
        //{
        //    int TotalCount;

        //    var tempWhere_lamda = ExpressionXElment.DeserializeExpression<PermissionObject, bool>(wherelamda);
        //    var Where_lamda = base.GetDTOByLamda<PermissionObject, Permission, bool>(tempWhere_lamda);

        //    var tempOrder_lamda = ExpressionXElment.DeserializeExpression<PermissionObject, int>(wherelamda);
        //    var Order_lamda = base.GetDTOByLamda<PermissionObject, Permission, int>(tempOrder_lamda);

        //    var list = PermissionRepository.LoadPageEnities<int>(pageIndex, pageSize, out TotalCount, Where_lamda, Order_lamda, false).ToList();

        //    var temp = AutoMapper.Mapper.Map<PermissionObjectList>(list);
        //    return temp;
        //}

        //public bool DeletePermissionById(object id)
        //{
        //    return PermissionRepository.Delete(id) > 0;
        //}

        //public bool DeletePermissions(string[] ids)
        //{
        //    var list = new List<Permission>();
        //    foreach (var item in ids)
        //    {
        //        list.Add(PermissionRepository.GetByKey(Convert.ToInt32(item)));
        //    }
        //    return PermissionRepository.Delete(list) > 0;
        //}

        //public bool UpdatePermission(PermissionObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<Permission>(obj);
        //    return PermissionRepository.Update(temp) > 0;
        //}

        //public bool UpdatePermissions(PermissionObjectList objs)
        //{
        //    bool flag = false;
        //    var temp = AutoMapper.Mapper.Map<List<Permission>>(objs);
        //    foreach (var item in temp)
        //    {
        //        flag = PermissionRepository.Update(item) > 0;
        //        if (!flag)
        //            break;
        //    }
        //    return flag;
        //}

        //public bool CreatePermission(PermissionObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<Permission>(obj);
        //    return PermissionRepository.Add(temp) > 0;
        //}

        //public PermissionObjectPageOfItems GetPermissionpageOfitems(int pageIndex, int pageSize, PermissionObjectPageOfItems pageofitems)
        //{
        //    int Totalcount;
        //    var temp = PermissionRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
        //    pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
        //    pageofitems.PageIndex = pageIndex;
        //    pageofitems.PageSize = pageSize;
        //    pageofitems.PermissionObjectLists = AutoMapper.Mapper.Map<PermissionObjectList>(temp);
        //    return pageofitems;
        //}

        #endregion

        public PermissionObjectPageOfItems GetPermissionpageOfitems(int pageIndex, int pageSize, PermissionObjectPageOfItems pageofitems)
        {
            int Totalcount;
            var temp = permissionRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c=>c.ID, true).ToList();
            pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
            pageofitems.AllCount = Totalcount;
            pageofitems.PageIndex = pageIndex;
            pageofitems.PageSize = pageSize;
            pageofitems.PermissionObjectLists = AutoMapper.Mapper.Map<PermissionObjectList>(temp);
            return pageofitems;
        }



    }
}
