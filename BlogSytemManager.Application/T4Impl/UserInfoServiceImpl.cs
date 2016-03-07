﻿// ******************************************************
// DO NOT CHANGE THE CONTENT OF THIS FILE
// This file was generated by the T4 engine and the 
// contents of this source code will be changed after
// the custom tool was run.
// ******************************************************
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

    public partial class UserInfoServiceImpl : ApplicationServiceImpl<UserInfoObject, UserInfo>, IUserInfoService
    {
        private static IUserInfoRepository userInfoRepository = new UserInfoRepository();

        public UserInfoServiceImpl()
            : base(userInfoRepository)
        {

        }

        public UserInfoObject[] GetAllUserInfo()
        {
            return base.GetAllDataObject();
        }
        public UserInfoObject GetUserInfoById(Object id)
        {
            return base.GetDataObjectById(id);
        }
        public Boolean DeleteUserInfoById(Object id)
        {
            return base.DeleteDataObjectById(id);
        }
        public Boolean DeleteUserInfos(String[] ids)
        {
            return base.DeleteDataObjects(ids);
        }
        public Boolean UpdateUserInfo(UserInfoObject obj)
        {
            return base.UpdateDataObject(obj);
        }
        public Boolean UpdateUserInfos(UserInfoObject[] objs)
        {
            return base.UpdateDataObjects(objs);
        }
        public UserInfoObject CreateUserInfo(UserInfoObject obj)
        {
            return base.CreateDataObject(obj);
        }
    }
}


