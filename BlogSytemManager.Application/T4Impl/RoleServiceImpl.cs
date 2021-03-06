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

    public partial class RoleServiceImpl : ApplicationServiceImpl<RoleObject, Role>, IRoleService
    {
        private static IRoleRepository roleRepository = new RoleRepository();

        public RoleServiceImpl()
            : base(roleRepository)
        {

        }

        public RoleObject[] GetAllRole()
        {
            return base.GetAllDataObject();
        }
        public RoleObject GetRoleById(Object id)
        {
            return base.GetDataObjectById(id);
        }
        public Boolean DeleteRoleById(Object id)
        {
            return base.DeleteDataObjectById(id);
        }
        public Boolean DeleteRoles(String[] ids)
        {
            return base.DeleteDataObjects(ids);
        }
        public Boolean UpdateRole(RoleObject obj)
        {
            return base.UpdateDataObject(obj);
        }
        public Boolean UpdateRoles(RoleObject[] objs)
        {
            return base.UpdateDataObjects(objs);
        }
        public RoleObject CreateRole(RoleObject obj)
        {
            return base.CreateDataObject(obj);
        }
    }
}


