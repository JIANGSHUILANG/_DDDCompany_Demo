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

    public partial class PermissionServiceImpl : ApplicationServiceImpl<PermissionObject, Permission>, IPermissionService
    {
        private static IPermissionRepository permissionRepository = new PermissionRepository();

        public PermissionServiceImpl()
            : base(permissionRepository)
        {

        }

        public PermissionObject[] GetAllPermission()
        {
            return base.GetAllDataObject();
        }
        public PermissionObject GetPermissionById(Object id)
        {
            return base.GetDataObjectById(id);
        }

        public Boolean DeletePermissionById(Object id)
        {
            return base.DeleteDataObjectById(id);
        }
        public Boolean DeletePermissions(String[] ids)
        {
            return base.DeleteDataObjects(ids);
        }
        public Boolean UpdatePermission(PermissionObject obj)
        {
            return base.UpdateDataObject(obj);
        }
        public Boolean UpdatePermissions(PermissionObject[] objs)
        {
            return base.UpdateDataObjects(objs);
        }
        public PermissionObject CreatePermission(PermissionObject obj)
        {
            return base.CreateDataObject(obj);
        }
    }
}


