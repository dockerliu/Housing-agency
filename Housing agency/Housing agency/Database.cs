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
            return new MySqlConnection("server=192.168.1.95;;User Id=txgl;Password=111111;CharSet=utf8;port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");
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
        public object QueryScalar(string sql,MySqlParameter[] prams) {
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
        private MySqlCommand CreateCommandSql(string sql, MySqlParameter[] prams)
        {
            Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            if (prams!=null)
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
                con = new MySqlConnection("server=192.168.1.95;;User Id=txgl;Password=111111;CharSet=utf8;port=3306;Convert Zero Datetime=True;Allow Zero Datetime=True");

            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
    }
}
