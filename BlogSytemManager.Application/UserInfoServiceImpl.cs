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
using BlogSytemManager.Common;
namespace BlogSytemManager.Application
{
    /// <summary>
    /// 用户权限管理
    /// </summary>
    public partial class UserInfoServiceImpl : ApplicationServiceImpl<UserInfoObject, UserInfo>, IUserInfoService
    {

        #region IUserInfoRepository CURD

        //public UserInfoObjectList GetAllUserInfo()
        //{
        //    var temp = userInfoRepository.LoadEnities(c => true).ToList();
        //    return AutoMapper.Mapper.Map<UserInfoObjectList>(temp);
        //}

        //public UserInfoObject GetUserInfoById(object id)
        //{
        //    var temp = userInfoRepository.GetByKey(id);
        //    return AutoMapper.Mapper.Map<UserInfoObject>(temp);
        //}

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

        //public bool DeleteUserInfoById(object id)
        //{
        //    return userInfoRepository.Delete(id) > 0;
        //}

        //public bool DeleteUserInfos(string[] ids)
        //{
        //    var list = new List<UserInfo>();
        //    foreach (var item in ids)
        //    {
        //        list.Add(userInfoRepository.GetByKey(Convert.ToInt32(item)));
        //    }
        //    return userInfoRepository.Delete(list) > 0;
        //}

        //public bool UpdateUserInfo(UserInfoObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<UserInfo>(obj);
        //    return userInfoRepository.Update(temp) > 0;
        //}

        //public bool UpdateUserInfos(UserInfoObjectList objs)
        //{
        //    bool flag = false;
        //    var temp = AutoMapper.Mapper.Map<List<UserInfo>>(objs);
        //    foreach (var item in temp)
        //    {
        //        flag = userInfoRepository.Update(item) > 0;
        //        if (!flag)
        //            break;
        //    }
        //    return flag;
        //}

        //public bool CreateUserInfo(UserInfoObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<UserInfo>(obj);
        //    return userInfoRepository.Add(temp) > 0;
        //}

        //public UserInfoObjectPageOfItems GetUserInfopageOfitems(int pageIndex, int pageSize, UserInfoObjectPageOfItems pageofitems)
        //{
        //    int Totalcount;
        //    var temp = userInfoRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
        //    pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
        //    pageofitems.PageIndex = pageIndex;
        //    pageofitems.PageSize = pageSize;
        //    pageofitems.UserInfoObjectLists = AutoMapper.Mapper.Map<UserInfoObjectList>(temp);
        //    return pageofitems;
        //}

        #endregion

        public UserInfoObjectPageOfItems GetUserInfopageOfitems(int pageIndex, int pageSize, UserInfoObjectPageOfItems pageofitems)
        {
            int Totalcount;
            var temp = userInfoRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c=>c.ID, true).ToList();
            
            pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
            pageofitems.AllCount = Totalcount;
            pageofitems.PageIndex = pageIndex;
            pageofitems.PageSize = pageSize;
            pageofitems.UserInfoObjectLists = AutoMapper.Mapper.Map<UserInfoObjectList>(temp);
            return pageofitems;

        }

        //位用户分配角色，CURD权限，查看控制器权限，查看菜单权限
        public bool ForUserInfoAutor(string CURDS, string MENUS, string ACTIONS, int RoleId,int UserID)
        {
           return userInfoRepository.ForUserInfoAutor(CURDS, MENUS, ACTIONS, RoleId, UserID);
        }
    }
}
