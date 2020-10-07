using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Housing_agency
{
    public class Dl
    {
        Database data = new Database();
        public int InserHandle(sysHandleInfo syshandleInfo)
        {
            string date = DateTime.Now.ToString();
            MySqlParameter[] para = { data.MakeInParam("@HandlePerson",MySqlDbType.VarChar,syshandleInfo.HandlePerson),
                data.MakeInParam("@HandleContent",MySqlDbType.VarChar,syshandleInfo.HandleContent),
            data.MakeInParam("@HandleRemark",MySqlDbType.VarChar,syshandleInfo.HandleRemark),
            data.MakeInParam("@date",MySqlDbType.Datetime,date)};
            string strsql = "INSERT INTO rizhi ( time, person, concent, remark, ) VALUES (@date,@HandlePerson,@HandleContent,@HandleRemark)";
            return data.Runsql(strsql, para);
        }
    }
}
