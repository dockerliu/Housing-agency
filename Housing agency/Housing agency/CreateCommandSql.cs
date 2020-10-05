using MySql.Data.MySqlClient;

namespace Housing_agency
{
    internal class CreateCommandSql
    {
        private string sql;
        private MySqlParameter[] prams;

        public CreateCommandSql(string sql, MySqlParameter[] prams)
        {
            this.sql = sql;
            this.prams = prams;
        }
    }
}