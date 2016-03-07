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
    public partial class _AggregatUserAuthorServiceImpl : ApplicationServiceImpl<UserInfoObject, UserInfo>, I_AggregatUserAuthorService
    {
        IUserInfoRepository userrepository = new UserInfoRepository();



        public void PublicSearch(string controllname, string wherename, string wherevalue)
        {

        }


        public bool ForUserInfoAuthor(int userinfo_ID, int[] ActionInfos, int[] Menu, int[] Permission, int role)
        {
            #region Sqlserver Split 方法

            //            create FUNCTION dbo.split (
            //    @String VARCHAR(MAX),
            //    @Delimiter VARCHAR(MAX)
            //) RETURNS @temptable TABLE (items VARCHAR(MAX)) AS
            //BEGIN
            //    DECLARE @idx INT=1
            //    DECLARE @slice VARCHAR(MAX) 
            //    IF LEN(@String) < 1 OR LEN(ISNULL(@String,'')) = 0
            //        RETURN
            //    WHILE @idx != 0
            //    BEGIN
            //        SET @idx = CHARINDEX(@Delimiter,@String)
            //        IF @idx != 0
            //            SET @slice = LEFT(@String,@idx - 1)
            //        ELSE
            //            SET @slice = @String
            //        IF LEN(@slice) > 0
            //            INSERT INTO @temptable(items) VALUES(@slice)
            //        SET @String = RIGHT (@String, LEN(@String) - @idx)
            //        IF LEN(@String) = 0
            //            BREAK
            //    END
            //    RETURN
            //END

            #endregion


            StringBuilder sb = new StringBuilder();
            //sb.Append();
            foreach (var item in Menu)
            {
                sb.AppendFormat(@"insert into UserInfoMenus(UserInfo_ID,Menu_ID)values({0},{1})", userinfo_ID, item);
            }

            foreach (var item in Permission)
            {
                sb.AppendFormat(@"insert into PermissionUserInfoes(UserInfo_ID,Permission_ID)values({0},{1})", userinfo_ID, item);
            }

            //base.repository.db.Database.SqlQuery<int>();
            return default(bool);
        }
    }
}
