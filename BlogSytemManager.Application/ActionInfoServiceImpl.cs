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
    public partial class ActionInfoServiceImpl : ApplicationServiceImpl<ActionInfoObject, ActionInfo>, IActionInfoService
    {

        #region IActionInfoRepository CURD

        //public ActionInfoObjectList GetAllActionInfo()
        //{
        //    var temp = ActionInfoRepository.LoadEnities(c => true).ToList();
        //    return AutoMapper.Mapper.Map<ActionInfoObjectList>(temp);
        //}

        //public ActionInfoObject GetActionInfoById(object id)
        //{
        //    var temp = ActionInfoRepository.GetByKey(id);
        //    return AutoMapper.Mapper.Map<ActionInfoObject>(temp);
        //}

        //public ActionInfoObjectList GetAllActionInfoPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null)
        //{
        //    int TotalCount;

        //    var tempWhere_lamda = ExpressionXElment.DeserializeExpression<ActionInfoObject, bool>(wherelamda);
        //    var Where_lamda = base.GetDTOByLamda<ActionInfoObject, ActionInfo, bool>(tempWhere_lamda);

        //    var tempOrder_lamda = ExpressionXElment.DeserializeExpression<ActionInfoObject, int>(wherelamda);
        //    var Order_lamda = base.GetDTOByLamda<ActionInfoObject, ActionInfo, int>(tempOrder_lamda);

        //    var list = ActionInfoRepository.LoadPageEnities<int>(pageIndex, pageSize, out TotalCount, Where_lamda, Order_lamda, false).ToList();

        //    var temp = AutoMapper.Mapper.Map<ActionInfoObjectList>(list);
        //    return temp;
        //}

        //public bool DeleteActionInfoById(object id)
        //{
        //    return ActionInfoRepository.Delete(id) > 0;
        //}

        //public bool DeleteActionInfos(string[] ids)
        //{
        //    var list = new List<ActionInfo>();
        //    foreach (var item in ids)
        //    {
        //        list.Add(ActionInfoRepository.GetByKey(Convert.ToInt32(item)));
        //    }
        //    return ActionInfoRepository.Delete(list) > 0;
        //}

        //public bool UpdateActionInfo(ActionInfoObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<ActionInfo>(obj);
        //    return ActionInfoRepository.Update(temp) > 0;
        //}

        //public bool UpdateActionInfos(ActionInfoObjectList objs)
        //{
        //    bool flag = false;
        //    var temp = AutoMapper.Mapper.Map<List<ActionInfo>>(objs);
        //    foreach (var item in temp)
        //    {
        //        flag = ActionInfoRepository.Update(item) > 0;
        //        if (!flag)
        //            break;
        //    }
        //    return flag;
        //}

        //public bool CreateActionInfo(ActionInfoObject obj)
        //{
        //    var temp = AutoMapper.Mapper.Map<ActionInfo>(obj);
        //    return ActionInfoRepository.Add(temp) > 0;
        //}

        //public ActionInfoObjectPageOfItems GetActionInfopageOfitems(int pageIndex, int pageSize, ActionInfoObjectPageOfItems pageofitems)
        //{
        //    int Totalcount;
        //    var temp = ActionInfoRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
        //    pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
        //    pageofitems.PageIndex = pageIndex;
        //    pageofitems.PageSize = pageSize;
        //    pageofitems.ActionInfoObjectLists = AutoMapper.Mapper.Map<ActionInfoObjectList>(temp);
        //    return pageofitems;
        //}

        #endregion

        public ActionInfoObjectPageOfItems GetActionInfopageOfitems(int pageIndex, int pageSize, ActionInfoObjectPageOfItems pageofitems)
        {
            int Totalcount;
            var temp = actionInfoRepository.LoadPageEnities<int>(pageIndex, pageSize, out Totalcount, c => true, c => c.ID, true).ToList();
            pageofitems.TotalCount = (int)Math.Ceiling((double)Totalcount / pageSize);
            pageofitems.AllCount = Totalcount;
            pageofitems.PageIndex = pageIndex;
            pageofitems.PageSize = pageSize;
            pageofitems.ActionInfoObjectLists = AutoMapper.Mapper.Map<ActionInfoObjectList>(temp);
            return pageofitems;

        }



    }
}
