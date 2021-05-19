using LINQtoSQL;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace L2SApp
{
    public class PlayerDataContext : DataContext
    {
        public PlayerDataContext(string connectionString): base(connectionString)
        {

        }
        public Table<Players> Users { get { return this.GetTable<Players>(); } }

        [Function(Name = "sp_GetAgeRange")]
        [return: Parameter(DbType = "Int")]
        public int GetAgeRange([Parameter(Name = "name", DbType = "NVarChar(50)")] string name,
            [Parameter(Name = "minAge", DbType = "Int")] ref int minAge,
            [Parameter(Name = "maxAge", DbType = "Int")] ref int maxAge)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, minAge, maxAge);
            minAge = ((int)(result.GetParameterValue(1)));
            maxAge = ((int)(result.GetParameterValue(2)));
            return ((int)(result.ReturnValue));
        }
    }
}