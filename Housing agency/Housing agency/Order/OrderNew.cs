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
using Housing_agency.Print;
using Housing_agency.Order;

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
            if (MessageBox.Show("确定要退出吗？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();

            }
        }

        private void OrderNew_Load(object sender, EventArgs e)
        {
            this.MaximumSize.Height.CompareTo(this.Height);
            string sql = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan";
            DataTable da = data.Query(sql);
            this.skinDataGridViewMain.DataSource = da;
            currentSelectIndex = this.skinDataGridViewMain.Rows[skinDataGridViewMain.SelectedRows[0].Index].Cells[0].Value.ToString();
            //MessageBox.Show(currentSelectIndex);//所有行的选中行的第一个单元格的值
        }
        /// <summary>
        /// 查询DataGridView数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = this.skinDataGridViewMain.Rows[e.RowIndex].Cells[0].Value.ToString();//取出所选行的第一个单元格的值
                                                                                                  //查询自动匹配信息
                try
                {
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
                finally { data.Close(); }
                //查询跟进人信息
                try
                {
                    string sql_genjin = "SELECT f_genjin,genjinren,genjin_time,neirong FROM f_genjin_fy WHERE bianhao='" + str + "'";
                    DataTable dd = data.Query(sql_genjin);
                    this.skinDataGridViewGenjin.DataSource = dd;
                }
                catch (Exception)
                {

                    throw;
                }
                finally { data.Close(); }
                //查询房源信息
                try
                {
                    string sql_source = "SELECT  wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan where bianhao='" + str + "'";
                    DataTable ddsource = data.Query(sql_source);
                    skinDataGridViewHouseSource.DataSource = ddsource;


                }
                catch (Exception)
                {

                    throw;
                }
                finally { data.Close(); }

                //查询房源保密信息

                try
                {
                    string sql_yezhu = "SELECT yezhu_name as 业主名字,tele AS 业主电话,MobliePhone as 业主移动电话,yezhu_address as 业主地址 FROM fangyuan WHERE bianhao='" + str + "'";
                    DataTable dd = data.Query(sql_yezhu);
                    skinDataGridViewSecrect.DataSource = dd;
                }
                catch (Exception)
                {

                    throw;
                }
                finally { data.Close(); }
            }
            catch
            {
                //不做处理
            }
        }
        /// <summary>
        /// 查询出租CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinCheckBoxRent_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBoxRent.Checked == true)
            {
                string sql_rent = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan where lend=1";
                DataTable dd_rent = data.Query(sql_rent);
                skinDataGridViewMain.DataSource = dd_rent;
                skinDataGridViewMain.Refresh();

            }
            if ((skinCheckBoxRent.Checked == true && skinCheckBoxSell.Checked == true) || (skinCheckBoxRent.Checked == false && skinCheckBoxSell.Checked == false))
            {
                string sql_rent = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan";
                DataTable dd_rent = data.Query(sql_rent);
                skinDataGridViewMain.DataSource = dd_rent;
                skinDataGridViewMain.Refresh();
            }
            if (skinCheckBoxRent.Checked == false)
            {
                string sql_rent = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan";
                DataTable dd_rent = data.Query(sql_rent);
                skinDataGridViewMain.DataSource = dd_rent;
                skinDataGridViewMain.Refresh();
            }
        }
        /// <summary>
        /// 查询出售CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinCheckBoxSell_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBoxSell.Checked == true)
            {
                string sql_rent = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan where sell=1";
                DataTable dd_rent = data.Query(sql_rent);
                skinDataGridViewMain.DataSource = dd_rent;
                skinDataGridViewMain.Refresh();
            }
            if ((skinCheckBoxRent.Checked == true && skinCheckBoxSell.Checked == true) || (skinCheckBoxRent.Checked == false && skinCheckBoxSell.Checked == false))
            {
                string sql_rent = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan";
                DataTable dd_rent = data.Query(sql_rent);
                skinDataGridViewMain.DataSource = dd_rent;
                skinDataGridViewMain.Refresh();
            }
            if (skinCheckBoxSell.Checked == false)
            {
                string sql_rent = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan";
                DataTable dd_rent = data.Query(sql_rent);
                skinDataGridViewMain.DataSource = dd_rent;
                skinDataGridViewMain.Refresh();
            }
        }
        /// <summary>
        /// 查询最近天数CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinCheckBoxLast_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBoxLast.Checked)
            {
                string sql_select = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan ";
                if (skinWaterTextBoxDay.Text != "")
                {
                    DateTime dateTime = DateTime.Now.Date.AddDays(-Convert.ToInt32(skinWaterTextBoxDay.Text));
                    sql_select += " where date<='" + DateTime.Now.AddDays(1) + "'and date>='" + dateTime + "'";
                }

                DataTable dd_day = data.Query(sql_select);
                skinDataGridViewMain.DataSource = dd_day;
                skinDataGridViewMain.Refresh();
                this.skinCheckBoxRent.Enabled = false;
                this.skinCheckBoxSell.Enabled = false;
            }
            else
            {
                //skinWaterTextBoxDay.Text = "";
                this.skinCheckBoxRent.Enabled = true;
                this.skinCheckBoxSell.Enabled = true;
                string sql_select = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan ";
                DataTable dd_day = data.Query(sql_select);
                skinDataGridViewMain.DataSource = dd_day;
                skinDataGridViewMain.Refresh();

            }
        }
        /// <summary>
        /// 最模糊查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_search = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan ";
                if (txtGoodsSearchInfo.Text == "")
                {
                    DataTable dd_search = data.Query(sql_search);
                    skinDataGridViewMain.DataSource = dd_search;
                    skinDataGridViewMain.Refresh();
                }
                else
                {
                    sql_search += "where bianhao like '%" + txtGoodsSearchInfo.Text + "%' or date like '%" + txtGoodsSearchInfo.Text + "%' or date like '%" + txtGoodsSearchInfo.Text + "%' or wuye like '%" + txtGoodsSearchInfo.Text + "%' or fang_type like '%" + txtGoodsSearchInfo.Text + "%' or area like '%" + txtGoodsSearchInfo.Text + "%' or address like '%" + txtGoodsSearchInfo.Text + "%' ";
                    DataTable dd_search = data.Query(sql_search);
                    skinDataGridViewMain.DataSource = dd_search;
                    skinDataGridViewMain.Refresh();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { data.Close(); }
        }
        /// <summary>
        /// 刷新按钮功能的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_select = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan ";
                DataTable dd_day = data.Query(sql_select);
                skinDataGridViewMain.DataSource = dd_day;
                skinDataGridViewMain.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
            finally { data.Close(); }
            this.skinCheckBoxLast.Checked = false;
            this.skinCheckBoxRent.Checked = false;
            this.skinCheckBoxSell.Checked = false;
            this.txtGoodsSearchInfo.Text = "";
            this.skinWaterTextBoxDay.Text = "";
        }
        /// <summary>
        /// 限制窗口只能输入数字框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinWaterTextBoxDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }
        /// <summary>
        /// 打印按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonPrinter_Click(object sender, EventArgs e)
        {
            FormPrint fp = new FormPrint();
            fp.id = skinDataGridViewMain.CurrentRow.Cells[0].Value.ToString();
            fp.Show();
        }
        /// <summary>
        /// 按下回车键调用查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGoodsSearchInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                skinButtonSearch.PerformClick();
            }
        }
        /// <summary>
        /// 租房查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonLendSearch_Click(object sender, EventArgs e)
        {
            FormLendSearch fls = new FormLendSearch();
            fls.ShowDialog();
        }
        /// <summary>
        /// 买房查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonSellSearch_Click(object sender, EventArgs e)
        {
            skinButtonLendSearch.PerformClick();
        }
        /// <summary>
        /// 增加房源按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonAdd_Click(object sender, EventArgs e)
        {
            FormAdd add = new FormAdd();
            add.ShowDialog();
        }
        /// <summary>
        /// 增加房源图片导航按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImgAdd_Click(object sender, EventArgs e)
        {
            this.skinButtonAdd.PerformClick();
        }
    }
}
