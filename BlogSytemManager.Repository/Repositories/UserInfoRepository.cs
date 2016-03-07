using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BolgSytemManager.Domain.Base;
using BolgSytemManager.Domain.IRepositories;
using BolgSytemManager.Domain.Model;
using System.Data.SqlClient;
using System.Data;
using BlogSytemManager.Repository.EFContext;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
namespace BlogSytemManager.Repository.Repositories
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CURDS"></param>
        /// <param name="MENUS"></param>
        /// <param name="ACTIONS"></param>
        /// <param name="RoleId"></param>
        /// <param name="UserID"></param>
        /// <returns>True:执行成功   False:执行失败</returns>
        public bool ForUserInfoAutor(string CURDS, string MENUS, string ACTIONS, int RoleId, int UserID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("declare @result int ");
            sql.AppendFormat("EXECUTE ForUserInfoAutor '{0}','{1}','{2}','{3}','{4}',@result output ", UserID, ACTIONS, CURDS, MENUS, RoleId);
            sql.AppendLine("select @result ");
            //返回值的类型                //返回值强转
            var reslut = db.Database.SqlQuery(typeof(int), sql.ToString()).Cast<int>().First();
            return reslut == 0 ? true : false;
        }

        /// <summary>
        /// 判断存储过程是否存在
        /// </summary>
        /// <param name="procedurename"></param>
        /// <returns>1：存在 0:不存在</returns>
        public bool IsexsitsProcedure(string procedurename)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
if exists(select * from sysobjects where id=OBJECT_ID(N'[{0}]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
  select 1
else
  select 0", procedurename);
            var temp = base.db.Database.SqlQuery<int>(sb.ToString()).FirstOrDefault();
            return temp > 0;
        }

        public bool IsexsitsFunction(string functionname)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
if exists(select * from sysobjects where id=OBJECT_ID(N'[{0}]'))
 select 1 
else
 select 0", functionname);
            var temp = base.db.Database.SqlQuery<int>(sb.ToString()).FirstOrDefault();
            return temp > 0; //大于0 表示存在此函数
        }
    }
}
