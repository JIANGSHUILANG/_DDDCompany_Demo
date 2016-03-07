﻿// ******************************************************
// DO NOT CHANGE THE CONTENT OF THIS FILE
// This file was generated by the T4 engine and the 
// contents of this source code will be changed after
// the custom tool was run.
// ******************************************************
using BlogSytemManager.Application;
using BlogSytemManager.DomainObject;
using BlogSytemManager.DomainObject._PageOfItems;
using BlogSytemManager.IService;
using BolgSytemManager.Domain.Model;
using BlogSytemManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;


namespace BlogSytemManager.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。

    //WCF服务实现代码修改如下，为了在客户端显示服务端发生的异常信息，在服务实现类添加[ServiceBehavior(IncludeExceptionDetailInFaults = true)]特性：
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,IncludeExceptionDetailInFaults = true)]

public partial class MenuChildenService : IMenuChildenService
   {
		  private readonly IMenuChildenService menuChildenserviceImpl = new MenuChildenServiceImpl();
				public MenuChildenObject[] GetAllMenuChilden()
		{
		return menuChildenserviceImpl.GetAllMenuChilden();
		}
		public MenuChildenObject GetMenuChildenById(Object id)
		{
		return menuChildenserviceImpl.GetMenuChildenById(id);
		}
		public MenuChildenObjectPageOfItems GetMenuChildenpageOfitems(Int32 pageIndex, Int32 pageSize, MenuChildenObjectPageOfItems pageofitems)
		{
		return menuChildenserviceImpl.GetMenuChildenpageOfitems(pageIndex, pageSize, pageofitems);
		}
		public Boolean DeleteMenuChildenById(Object id)
		{
		return menuChildenserviceImpl.DeleteMenuChildenById(id);
		}
		public Boolean DeleteMenuChildens(String[] ids)
		{
		return menuChildenserviceImpl.DeleteMenuChildens(ids);
		}
		public Boolean UpdateMenuChilden(MenuChildenObject obj)
		{
		return menuChildenserviceImpl.UpdateMenuChilden(obj);
		}
		public Boolean UpdateMenuChildens(MenuChildenObject[] objs)
		{
		return menuChildenserviceImpl.UpdateMenuChildens(objs);
		}
        public MenuChildenObject CreateMenuChilden(MenuChildenObject obj)
		{
		return menuChildenserviceImpl.CreateMenuChilden(obj);
		}
		public void Dispose() { menuChildenserviceImpl.Dispose(); }
	}
}


