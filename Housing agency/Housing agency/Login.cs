using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Data;

namespace Housing_agency
{
    public partial class login : CCSkinMain //还可以继承的主题 Skin_Color，Skin_DevExpress，Skin_Mac，Skin_Metro，Skin_VS
    {
        public login()
        {
            InitializeComponent();
        }

        #region 定义常用变量
        /// <summary>
        /// 定义常用变量
        /// </summary>
        bool t = false;
        public static string _UserName;
        public static string _PassWord;
        public static bool _RCGL;
        public static bool _FYGL;
        public static bool _KHGL;
        public static bool _NBGL;
        public static bool _XTSZ; 
        #endregion
        /// <summary>
        /// 数据库初始化
        /// </summary>
        Database data = new Database();
        Dl dl = new Dl();

        public login(bool bb) { t = bb; }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM login_user";
            try
            {
                DataTable dt = data.Query(sql);
                this.cboUser.DataSource = dt;
                this.cboUser.DisplayMember = "_name";
            }
            catch //(Exception ex)
            {

                //throw ;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                sysHandleInfo handleInfo = new sysHandleInfo();
                bool b = false;
                int jiebie_Id = 0;
                string sql= "SELECT * FROM login_user";
                DataTable dt = data.Query(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (this.cboUser.Text == dr["_name"].ToString() && this.txtPassWord.Text == dr["_pass"].ToString())
                    {
                        b = true;
                        _UserName = dr["_name"].ToString();
                        _PassWord = dr["_pass"].ToString();
                        jiebie_Id = Convert.ToInt32(dr["_jibieid"]);
                        string sql_id = "SELECT * FROM jibie where id='"+jiebie_Id+"'";
                        DataTable dt1 = data.Query(sql_id);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            _RCGL = Convert.ToBoolean(dr1["_richang"]);     
                            _FYGL = Convert.ToBoolean(dr1["_fangyuan"]);     
                            _KHGL = Convert.ToBoolean(dr1["_kehu"]);     
                            _NBGL = Convert.ToBoolean(dr1["_neibu"]);     
                            _XTSZ = Convert.ToBoolean(dr1["_xitong"]);     
                        }

                    }
                }
                if (b==true)
                {
                    handleInfo.HandlePerson = this.cboUser.Text;
                    handleInfo.HandleContent =  "操作登陆成功";
                    handleInfo.HandleRemark= this.cboUser.Text + "登陆";
                    dl.InserHandle(handleInfo);
                    if (t!=true)
                    {
                        mainForm main = new mainForm();
                        main.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        this.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("用户名或者密码不正确！","Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
