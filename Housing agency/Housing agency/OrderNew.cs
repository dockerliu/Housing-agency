using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CCWin;

namespace Housing_agency
{
    public partial class OrderNew : CCSkinMain
    {
        public OrderNew()
        {
            InitializeComponent();
        }
        Database data = new Database();
        public string currentSelectIndex;
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderNew_Load(object sender, EventArgs e)
        {
            this.MaximumSize.Height.CompareTo(this.Height);
            string sql = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan";
            DataTable da = data.Query(sql);
            this.skinDataGridView1.DataSource = da;
            currentSelectIndex = this.skinDataGridView1.Rows[skinDataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
            //MessageBox.Show(currentSelectIndex);//所有行的选中行的第一个单元格的值
        }

        private void skinDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = this.skinDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//取出所选行的第一个单元格的值
                string strsql = "select * from fangyuan where bianhao='" + str + "'";
           
                DataTable dt = data.Query(strsql);
                //skinDataGridView2.DataSource = dt;
                foreach (DataRow dr1 in dt.Rows)
                {
                    string area = dr1["area"].ToString();
                    string address = dr1["address"].ToString();                    
                    string sql_a = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan where (area=?area or address=?address) and bianhao!='" + str + "'";
                    MySqlParameter[] par = {
                        data.MakeInParam( "?area",MySqlDbType.VarChar,area),
                        data.MakeInParam( "?address",MySqlDbType.VarChar,address),//在使用MySQL的时候使用mysqlparameters需要将@变成？号
                    };
                    DataTable dtb = data.Query(sql_a, par);
                    this.skinDataGridViewHoseAuto.DataSource = dtb;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
