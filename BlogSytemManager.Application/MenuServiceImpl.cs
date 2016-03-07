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
    public partial class MenuServiceImpl : ApplicationServiceImpl<MenuObject, Menu>, IMenuService
    {

        #region IMenuRepository CURD

        //public MenuObjectList GetAllMenu()
        //{
        //    var temp = MenuRepository.LoadEnities(c => true).ToList();
        //    return AutoMapper.Mapper.Map<MenuObjectList>(temp);
        //}

        //public MenuObject GetMenuById(object id)
        //{
        //    var temp = MenuRepository.GetByKey(id);
        //    return AutoMapper.Mapper.Map<MenuObject>(temp);
        //}

        //public MenuObjectList GetAllMenuPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null)
        //{
        //    int TotalCount;

        //    var tempWhere_lamda = ExpressionXElment.DeserializeExpression<MenuObject, bool>(wherelamda);
        //    var Where_lamda = base.GetDTOByLamda<MenuObject, Menu, bool>(tempWhere_lamda);

        //    var tempOrder_lamda = ExpressionXElment.DeserializeExpression<MenuObject, int>(wherelamda);
        //    var Order_lamda = base.GetDTOByLamda<MenuObject, Menu, int>(tempOrder_lamda);

        //    var list = MenuRepository.LoadPageEnities<int>(pageIndex, pageSize, out TotalCount, Where_lamda, Order_lamda, false).ToList();

        //    var temp = AutoMapper.Mapper.Map<MenuObjectList>(list);
        //    return temp;
        //}

        //public bool DeleteMenuById(object id)
        //{
        //    return MenuRepository.Delete(id) > 0;
        //}

        //public bool DeleteMenus(string[] ids)
        //{
        //    var list = new List<Menu>();
        //    foreach (var item in ids)
        //    {
        //        list.Add(MenuRepository.GetByKey(Convert.ToInt32(item)));
        //    }
        //    return MenuRepository.Delete(list) > 0;
        //}

        //public bool UpdateMenu(MenuObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<Menu>(obj);
        //    return MenuRepository.Update(temp) > 0;
        //}

        //public bool UpdateMenus(MenuObjectList objs)
        //{
        //    bool flag = false;
        //    var temp = AutoMapper.Mapper.Map<List<Menu>>(objs);
        //    foreach (var item in temp)
        //    {
        //        flag = MenuRepository.Update(item) > 0;
        //        if (!flag)
        //            break;
        //    }
        //    return flag;
        //}

        //public bool CreateMenu(MenuObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<Menu>(obj);
        //    return MenuRepository.Add(temp) > 0;
        //}

        //public MenuObjectPageOfItems GetMenupageOfitems(int pageIndex, int pageSize, MenuObjectPageOfItems pageofitems)
        //{
        //    int Totalcount;
        //    var temp = MenuRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
        //    pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
        //    pageofitems.PageIndex = pageIndex;
        //    pageofitems.PageSize = pageSize;
        //    pageofitems.MenuObjectLists = AutoMapper.Mapper.Map<MenuObjectList>(temp);
        //    return pageofitems;
        //}

        #endregion

        public MenuObjectPageOfItems GetMenupageOfitems(int pageIndex, int pageSize, MenuObjectPageOfItems pageofitems)
        {
            int Totalcount;
            var temp = menuRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.shot, true).ToList();
            pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
            pageofitems.AllCount = Totalcount;
            pageofitems.PageIndex = pageIndex;
            pageofitems.PageSize = pageSize;
            pageofitems.MenuObjectLists = AutoMapper.Mapper.Map<MenuObjectList>(temp);
            return pageofitems;
        }
    }
}
