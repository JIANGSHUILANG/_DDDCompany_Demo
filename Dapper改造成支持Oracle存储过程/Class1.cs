using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper改造成支持Oracle存储过程
{
    public class Class1
    {
        static void Main()
        {
            //Dapper确实是支持Oracle的，但是对于调用Oracle存储过程的内容却没有

            //以前定义参数和返回值是如下：
            DynamicParameters paramter = new DynamicParameters();
            paramter.Add("Name", "张三");
            paramter.Add("RoleName", "", DbType.String, ParameterDirection.Output);

            //调用Oracle存储过程参数类型重新写个类继承SqlMapper.IDynamicParameters即可。
        }
    }

    public class OracleParameter
    { 
    
    }

    public class OracleDynamicParameters : Dapper.SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();


        public void Add(string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null)
        {
            //dynamicParameters.Add();
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            throw new NotImplementedException();
        }
    }

}














