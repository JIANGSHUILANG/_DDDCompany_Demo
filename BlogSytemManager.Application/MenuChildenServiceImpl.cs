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
    public partial class MenuChildenServiceImpl : ApplicationServiceImpl<MenuChildenObject, MenuChilden>, IMenuChildenService
    {

        #region IMenuChildenRepository CURD

        //public MenuChildenObjectList GetAllMenuChilden()
        //{
        //    var temp = MenuChildenRepository.LoadEnities(c => true).ToList();
        //    return AutoMapper.Mapper.Map<MenuChildenObjectList>(temp);
        //}

        //public MenuChildenObject GetMenuChildenById(object id)
        //{
        //    var temp = MenuChildenRepository.GetByKey(id);
        //    return AutoMapper.Mapper.Map<MenuChildenObject>(temp);
        //}

        //public MenuChildenObjectList GetAllMenuChildenPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null)
        //{
        //    int TotalCount;

        //    var tempWhere_lamda = ExpressionXElment.DeserializeExpression<MenuChildenObject, bool>(wherelamda);
        //    var Where_lamda = base.GetDTOByLamda<MenuChildenObject, MenuChilden, bool>(tempWhere_lamda);

        //    var tempOrder_lamda = ExpressionXElment.DeserializeExpression<MenuChildenObject, int>(wherelamda);
        //    var Order_lamda = base.GetDTOByLamda<MenuChildenObject, MenuChilden, int>(tempOrder_lamda);

        //    var list = MenuChildenRepository.LoadPageEnities<int>(pageIndex, pageSize, out TotalCount, Where_lamda, Order_lamda, false).ToList();

        //    var temp = AutoMapper.Mapper.Map<MenuChildenObjectList>(list);
        //    return temp;
        //}

        //public bool DeleteMenuChildenById(object id)
        //{
        //    return MenuChildenRepository.Delete(id) > 0;
        //}

        //public bool DeleteMenuChildens(string[] ids)
        //{
        //    var list = new List<MenuChilden>();
        //    foreach (var item in ids)
        //    {
        //        list.Add(MenuChildenRepository.GetByKey(Convert.ToInt32(item)));
        //    }
        //    return MenuChildenRepository.Delete(list) > 0;
        //}

        //public bool UpdateMenuChilden(MenuChildenObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<MenuChilden>(obj);
        //    return MenuChildenRepository.Update(temp) > 0;
        //}

        //public bool UpdateMenuChildens(MenuChildenObjectList objs)
        //{
        //    bool flag = false;
        //    var temp = AutoMapper.Mapper.Map<List<MenuChilden>>(objs);
        //    foreach (var item in temp)
        //    {
        //        flag = MenuChildenRepository.Update(item) > 0;
        //        if (!flag)
        //            break;
        //    }
        //    return flag;
        //}

        //public bool CreateMenuChilden(MenuChildenObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<MenuChilden>(obj);
        //    return MenuChildenRepository.Add(temp) > 0;
        //}

        //public MenuChildenObjectPageOfItems GetMenuChildenpageOfitems(int pageIndex, int pageSize, MenuChildenObjectPageOfItems pageofitems)
        //{
        //    int Totalcount;
        //    var temp = MenuChildenRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
        //    pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
        //    pageofitems.PageIndex = pageIndex;
        //    pageofitems.PageSize = pageSize;
        //    pageofitems.MenuChildenObjectLists = AutoMapper.Mapper.Map<MenuChildenObjectList>(temp);
        //    return pageofitems;
        //}

        #endregion

        public MenuChildenObjectPageOfItems GetMenuChildenpageOfitems(int pageIndex, int pageSize, MenuChildenObjectPageOfItems pageofitems)
        {
            int Totalcount;
            var temp = menuChildenRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c=>c.ID, true).ToList();
            pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
            pageofitems.AllCount = Totalcount;
            pageofitems.PageIndex = pageIndex;
            pageofitems.PageSize = pageSize;
            pageofitems.MenuChildenObjectLists = AutoMapper.Mapper.Map<MenuChildenObjectList>(temp);
            return pageofitems;

        }



    }
}
