using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace Housing_agency.HouseSource
{
    public partial class FormAddHouse : CCSkinMain
    {
        public FormAddHouse()
        {
            InitializeComponent();
        }

        Database data = new Database();
        private void NToolStripButtonAdd_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonSearch_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan ";
            if (skinWaterTextBoxHouseSourceInfo.Text != "")
            {
                sqlQuery += " WHERE ( bianhao LIKE '%" + skinWaterTextBoxHouseSourceInfo.Text + "%' or huxing LIKE '%" + skinWaterTextBoxHouseSourceInfo.Text + "%')";
            }
            DataTable dd = data.Query(sqlQuery);
            skinDataGridView.DataSource = dd;
        }

        private void FormAddHouse_Load(object sender, EventArgs e)
        {
            QuerryHouseData();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        private void QuerryHouseData()
        {
            string sqlQuery = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan ";
            DataTable dd = data.Query(sqlQuery);
            skinDataGridView.DataSource = dd;
        }
        /// <summary>
        /// 导出Excel数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SToolStripButtonToExcel_Click(object sender, EventArgs e)
        {
            GridviewToExcel(this.skinDataGridView);
        }
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OToolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (skinDataGridView.SelectedRows.Count > 0)
                {


                    for (int i = skinDataGridView.SelectedRows.Count; i > 0; i--)
                    {
                        string id = skinDataGridView.SelectedRows[i - 1].Cells[0].Value.ToString();
                        if (MessageBox.Show("确定要删除信息吗？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            string sqldelte = "DELETE FROM fangyuan WHERE bianhao='"+id+"'";
                            int a = data.Runsql(sqldelte);
                            if (a>0)
                            {
                                MessageBox.Show("删除成功！");

                            }
                            else { MessageBox.Show("删除失败！"); }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                data.Close();
                QuerryHouseData();
            }
        }
        /// <summary>
        /// 从dataGridView导出到Excel表格
        /// </summary>
        /// <param name="dataGridView"></param>
        public void GridviewToExcel(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();//初始化一个保存文件
                saveFile.DefaultExt = "xls"; //保存默认格式
                saveFile.Filter = "Excel文件(*.xls)|*.xls";//保存对话框可选择的格式
                saveFile.FileName = "房源信息"; //保存默认名字
                saveFile.RestoreDirectory = true; //保存默认文件路径
                saveFile.CreatePrompt = true; //保存不存在的文件时创建文件
                saveFile.Title = "导出到Excel";
                saveFile.ShowDialog();
                if (saveFile.FileName == "")
                {
                    return;
                }
                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string str = "";
                try
                {
                    //开始写入EXcel列的标题
                    for (int i = 0; i < this.skinDataGridView.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            str += "\t";
                        }
                        str += skinDataGridView.Columns[i].HeaderText;
                    }
                    sw.WriteLine(str);

                    //开始写入EXcel行内容

                    for (int j = 0; j < this.skinDataGridView.Rows.Count; j++)
                    {
                        string temStr = "";
                        for (int k = 0; k < this.skinDataGridView.ColumnCount; k++)
                        {
                            if (k > 0)
                            {
                                temStr += "\t";
                            }
                            if (k == 0)
                            {
                                temStr += "'" + this.skinDataGridView.Rows[j].Cells[k].Value.ToString();
                            }
                            temStr += this.skinDataGridView.Rows[j].Cells[k].Value.ToString();
                        }
                        sw.WriteLine(temStr);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }

            }
        }
    }
}
