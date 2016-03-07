namespace BlogSytemManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddFnIsPaid : DbMigration
    {
        public override void Up()
        {
            Sql(splits);
            Sql(foruserautor);
        }
        public override void Down()
        {
            Sql(remvoesplits);
            Sql(removeforuserautor);
        }
        #region Create Splits

        private string splits = @"
create FUNCTION [dbo].[split] (
    @String VARCHAR(MAX),
    @Delimiter VARCHAR(MAX)
) RETURNS @temptable TABLE (items VARCHAR(MAX)) AS
BEGIN
    DECLARE @idx INT=1
    DECLARE @slice VARCHAR(MAX) 
    IF LEN(@String) < 1 OR LEN(ISNULL(@String,'')) = 0
        RETURN
    WHILE @idx != 0
    BEGIN
        SET @idx = CHARINDEX(@Delimiter,@String)
        IF @idx != 0
            SET @slice = LEFT(@String,@idx - 1)
        ELSE
            SET @slice = @String
        IF LEN(@slice) > 0
            INSERT INTO @temptable(items) VALUES(@slice)
        SET @String = RIGHT (@String, LEN(@String) - @idx)
        IF LEN(@String) = 0
            BREAK
    END
    RETURN
END";
        #endregion

        #region Drop Splits

        private const string remvoesplits = @"DROP FUNCTION [dbo].[split]";
        #endregion

        #region  Create Procedure ForUserAutor

        private const string foruserautor = @"CREATE proc [dbo].[ForUserInfoAutor]
  @userinfo_id int,
  @actioninfos nvarchar(50),
  @permissions nvarchar(10),
  @menus nvarchar(10),
  @result int output
  -- @result int output
  as 
    begin
		declare @error int
		set @error=0
		   begin transaction
		      declare @numbers_m int
		  select @numbers_m=COUNT(*) from split(@menus,'|')   --切割菜单权限
		           while(@numbers_m>0)
						begin
						declare @tempmenus int
						set @tempmenus=0
						 select @tempmenus=TEMP.items from( select  ROW_NUMBER() over(order by items)as OrderBy,items from split(@menus,'|')) TEMP  where TEMP.OrderBy=@numbers_m
						set @numbers_m=@numbers_m-1
							insert into UserInfoMenus(UserInfo_ID,Menu_ID)values(@userinfo_id,@tempmenus)
							set @error=@@ERROR+@error
						end

		    select @numbers_m=COUNT(*) from split(@actioninfos,'|') --切割访问权限菜单
                   while(@numbers_m>0)
				        begin
						declare @tempactioninfos int
						set @tempactioninfos=0
						 select @tempactioninfos=TEMP.items from( select  ROW_NUMBER() over(order by items)as OrderBy,items from split(@actioninfos,'|')) TEMP  where TEMP.OrderBy=@numbers_m
						set @numbers_m=@numbers_m-1
							insert into UserInfoActionInfoes(UserInfo_ID,ActionInfo_ID)values(@userinfo_id,@tempactioninfos)
							set @error=@@ERROR+@error
						end

			select @numbers_m=COUNT(*) from split(@permissions,'|') --切割增删改查权限
                   while(@numbers_m>0)
				        begin
						declare @temppermissions int
						set @temppermissions=0
						 select @temppermissions=TEMP.items from( select  ROW_NUMBER() over(order by items)as OrderBy,items from split(@permissions,'|')) TEMP  where TEMP.OrderBy=@numbers_m
						set @numbers_m=@numbers_m-1
							insert into PermissionUserInfoes(UserInfo_ID,Permission_ID)values(@userinfo_id,@temppermissions)
							set @error=@@ERROR+@error
						end
						
		  if @error>0
			begin
			set @result=@error
			rollback transaction
			end				
          else
		    begin
			set @result=@error
			commit transaction
			end

		  return @result
	end";

        #endregion

        #region Drop Procedure ForUserAutor

        private const string removeforuserautor = "Drop proc [dbo].[ForUserInfoAutor]";

        #endregion

    }
}
