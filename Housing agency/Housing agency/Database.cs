using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Housing_agency
{
    public class Database
    {

        /// <summary>
        /// 返回连接字符串
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection("server=192.168.1.95;Database=build;User Id=build;Password=111111;CharSet=utf8;port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");
        }

        /// <summary>
        /// 定义空白连接
        /// </summary>
        MySqlConnection con = null;

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <returns>返回一个具体值</returns>
        public object QueryScalar(string sql)
        {
            Open();
            object result = null;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    result = cmd.ExecuteScalar();
                    return result;
                }

            }
            catch { return null; }

        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="prams">Sql语句参数</param>
        /// <returns>返回一个具体值</returns>
        public object QueryScalar(string sql, MySqlParameter[] prams)
        {
            Open();
            object result = null;
            try
            {
                using (MySqlCommand cmd = CreateCommandSql(sql, prams))
                {
                    result = cmd.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// 创建一个sqlcommand对象，用来构建Sql语句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="prams">Sql语句所需的参数</param>
        /// <returns></returns>
        MySqlCommand CreateCommandSql(string sql, MySqlParameter[] prams)
        {
            Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            if (prams != null)
            {
                foreach (MySqlParameter item in prams)
                {
                    cmd.Parameters.Add(item);
                }
            }
            return cmd;
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        private void Open()
        {
            if (con == null)
            {
                con = new MySqlConnection("server=192.168.1.95;Database=build;User Id=build;Password=111111;CharSet=utf8;port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");

            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }
        /// <summary>
        ///  关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (con.State!=ConnectionState.Closed)
            {
                con.Close();
            }
        }
        /// <summary>
        /// 要执行SQL语句，该方法返回一个DataTable数据
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>DataTable数据</returns>
        public DataTable Query(string sql)
        {
            Open();
            using (MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, con))
            {
                using (DataTable dt = new DataTable())
                {
                    sqlda.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// 要执行SQL语句，该方法返回一个DataTable数据
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="prams">要执行的SQL语句的参数</param>
        /// <returns>DataTable数据</returns>
        public DataTable Query(string sql,MySqlParameter[] prams)
        {
            MySqlCommand cmd = CreateCommandSql(sql, prams);
            using (MySqlDataAdapter sqldata=new MySqlDataAdapter(cmd))
            {
                using (DataTable dt=new DataTable())
                {
                    sqldata.Fill(dt);
                    return dt;
                }
            }
        }
        /// <summary>
        /// 执行sql语句，返回受影响的记录行数
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>返回受影响的记录行数</returns>
        public int Runsql(string sql)
        {
            int result = -1;
            try
            {
            Open();
                using (MySqlCommand cmd=new MySqlCommand(sql,con))
                {
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }

            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 执行sql语句，返回受影响的记录行数
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="prams">要执行的SQL语句参数</param>
        /// <returns>返回受影响的记录行数</returns>
        public int Runsql(string sql,MySqlParameter[] prams)
        {
            int result = -1;
            MySqlCommand cmd = CreateCommandSql(sql, prams);
            try
            {
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 要执行的SQL语句，返回一个MysqlDataReader
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="dataReader">返回一个MysqlDataReader</param>
        public void Runsql(string sql,out MySqlDataReader dataReader)
        {
            MySqlCommand cmd = CreateCommandSql(sql, null);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public void Runsql(string sql,MySqlParameter[]prams,out MySqlDataReader dataReader)
        {
            MySqlCommand cmd = CreateCommandSql(sql, prams);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//CommandBehavior.CloseConnection使用完成后会自动关闭数据库连接

        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="ProcName">存储过程的名字</param>
        /// <returns></returns>
        public int Runproc(string ProcName) {
            MySqlCommand cmd = CreateCommand(ProcName,null);
            cmd.ExecuteNonQuery();
            con.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>
        /// 创建一个sqlCommand对象，用来执行存储过程
        /// </summary>
        /// <param name="ProcName">存储过程名</param>
        /// <param name="prams">构建存储过程所需的参数</param>
        /// <returns></returns>
        private MySqlCommand CreateCommand(string ProcName, MySqlParameter[] prams)
        {
            Open();
            MySqlCommand cmd = new MySqlCommand(ProcName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (prams != null)
            {
                foreach (MySqlParameter item in prams)
                {
                    cmd.Parameters.Add(item);
                }
            }
            cmd.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return cmd;
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="ProcName">存储过程的名字</param>
        /// <param name="prams">构建存储过程所需要的参数</param>
        /// <returns></returns>
        public int RunProc(string ProcName, MySqlParameter[] prams) {
            MySqlCommand cmd = CreateCommand(ProcName, prams);
            cmd.ExecuteNonQuery();
            con.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>
        /// 执行存储过程，返回SqlDataReader
        /// </summary>
        /// <param name="ProcName">存储过程的名字</param>
        /// <param name="dataReader">要返回的MySqlDataReader</param>
        public void RunProc(string ProcName,out MySqlDataReader dataReader)
        {
            MySqlCommand cmd = CreateCommand(ProcName, null);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }
        /// <summary>
        /// 执行存储过程，返回SqlDataReader
        /// </summary>
        /// <param name="ProcName">存储过程的名字</param>
        /// <param name="prams">构建存储过程所需要的参数</param>
        /// <param name="dataReader">要返回的MySqlDataReader</param>
        public void RunProc(string ProcName,MySqlParameter[]prams, out MySqlDataReader dataReader)
        {
            MySqlCommand cmd = CreateCommand(ProcName, prams);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 对DataTime类型数据做限制
        /// </summary>
        /// <returns></returns>
        public MySqlParameter MakeInParamDate(string paramName,MySqlDbType Dbtype,int size,DateTime value) {
            if (value.ToShortDateString()=="0001-1-1")
            {
                return MakeParam(paramName, Dbtype, size, ParameterDirection.Input, System.DBNull.Value);
            }
            else
            {
                return MakeParam(paramName, Dbtype, size, ParameterDirection.Input,value);
            }
        }

        private MySqlParameter MakeParam(string paramName, MySqlDbType dbtype, int size, ParameterDirection Direction, object value)
        {
            MySqlParameter param;
            if (size>0)
            {
                param = new MySqlParameter(paramName, dbtype,size);
            }
            else
            {
                param = new MySqlParameter(paramName, dbtype);
            }
            param.Direction = Direction;
            if (!(Direction==ParameterDirection.Output&&value==null))
            {
                param.Value = value;
            }
            return param;
        }
        /// <summary>
        /// 对String类型数据的限制
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MySqlParameter MakeInParamStr(string ParamName,MySqlDbType dbType,int size,string value)
        {
            if (value==null)
            {
                return MakeParam(ParamName, dbType, size, ParameterDirection.Input, System.DBNull.Value);
            }
            else
            {
                return MakeParam(ParamName, dbType, size, ParameterDirection.Input, value);
            }
        }
        /// <summary>
        /// 对Int,float类型数据的限制
        /// </summary>
        /// <returns></returns>
        public MySqlParameter MakeInParamInt(string ParamName,MySqlDbType dbType,int size,object value)
        {
            if (float.Parse(value.ToString())==0)
            {
                return MakeParam(ParamName, dbType, size, ParameterDirection.Input, System.DBNull.Value);
            }
            else
            {
                return MakeParam(ParamName, dbType, size, ParameterDirection.Input, value);
            }
        }


        /// <summary>
        /// 传入参数无大小
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MySqlParameter MakeInParam(string paramName,MySqlDbType dbType,object value)
        {
            return MakeParam(paramName, dbType, 0, ParameterDirection.Input, value);
        }
        /// <summary>
        /// 传入参数有大小
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MySqlParameter MakeInParam(string ParamName,MySqlDbType dbType,int size,object value)
        {
            return MakeParam(ParamName, dbType, size, ParameterDirection.Input, value);
        }
        /// <summary>
        /// 输出参数的值
        /// </summary>
        /// <returns></returns>
        public MySqlParameter MakeOutParam(string paramName,MySqlDbType dbType,int size) {
            return MakeParam(paramName, dbType, size, ParameterDirection.Output, null)
            ;
        }
        /// <summary>
        /// 输出参数的值
        /// </summary>
        /// <returns></returns>
        public MySqlParameter MakeReturnParam(string paramName,MySqlDbType dbType,int size)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.ReturnValue,null);
        }
    }
}

    

