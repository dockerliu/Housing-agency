using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace Housing_agency.Order
{
    public partial class FormLendSearch : CCSkinMain
    {
        public FormLendSearch()
        {
            InitializeComponent();
        }
        Database data = new Database();
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonOK_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT bianhao AS 房源编号, date AS 登记日期, zhuangtai AS 当前状态, wuye AS 物业名称, huxing AS 户型结构, mianji AS 建筑面积, area AS 所在区域, z_floor AS 总层数, n_floor AS 位于层数, guwen AS 置业顾问, yongtu AS 物业用途, chengdu AS 装修程度, fang_type AS 户型, jiancheng AS 建成年份, address AS 具体地址 FROM fangyuan where ";
            try
            {
                if (this.skinComboBoxArea.Text != "不限")
                {
                    sqlQuery += "area='" + skinComboBoxArea.Text + "' and ";
                }
                if (this.skinWaterTextBoxproportionMin.Text != "")
                {
                    sqlQuery += "mianji>='" + skinWaterTextBoxproportionMin.Text + "' and ";
                }
                if (this.skinWaterTextBoxproportionMax.Text != "")
                {
                    sqlQuery += "mianji<='" + skinWaterTextBoxproportionMax.Text + "' and ";
                }
                if (this.skinComboBoxBedroom.Text != "不限")
                {
                    sqlQuery += "huxing like '%" + skinComboBoxBedroom.Text + skinLabelBedromm.Text + "%' and ";
                }
                if (this.skinComboBoxLivingroom.Text != "不限")
                {
                    sqlQuery += "huxing like '%" + skinComboBoxLivingroom.Text + skinLabelLivingroom.Text + "%' and ";
                }

                if (this.skinComboBoxBathroom.Text != "不限")
                {
                    sqlQuery += "huxing like '%" + skinComboBoxBathroom.Text + skinLabelBathroom.Text + "%' and ";
                }
                if (this.skinComboBoxBalcony.Text != "不限")
                {
                    sqlQuery += "huxing like '%" + skinComboBoxBalcony.Text + skinLabelBalcony.Text + "%' and ";
                }
                if (skinWaterTextBoxSellpriceMin.Text != "")
                {
                    sqlQuery += "lend_price>='" + skinWaterTextBoxSellpriceMin.Text + "' and ";
                }
                if (skinWaterTextBoxSellpriceMax.Text != "")
                {
                    sqlQuery += "lend_price<='" + skinWaterTextBoxSellpriceMax.Text + "' and ";
                }
                if (skinCheckBoxGas.Checked == true)
                {
                    sqlQuery += "jichusheshi like '%" + skinCheckBoxGas.Text + "%' and ";
                }
                if (skinCheckBoxCableTV.Checked == true)
                {
                    sqlQuery += "jichusheshi like '%" + skinCheckBoxCableTV.Text + "%' and ";
                }
                if (skinCheckBoxHeating.Checked == true)
                {
                    sqlQuery += "jichusheshi like '%" + skinCheckBoxHeating.Text + "%' and ";
                }
                if (skinCheckBoxBroadband.Checked == true)
                {
                    sqlQuery += "jichusheshi like '%" + skinCheckBoxBroadband.Text + "%' and ";
                }
                if (skinWaterTextBoxWuye.Text != "")
                {
                    sqlQuery += "wuye like '%" + skinWaterTextBoxWuye.Text + "%' and ";
                }
                if (skinWaterTextBoxLocation.Text != "")
                {
                    sqlQuery += "address like '%" + skinWaterTextBoxLocation.Text + "%' and ";
                }
                if (skinComboBoxSellType.Text == "租房")
                {

                    sqlQuery += " lend=1";
                }
                else
                {
                    sqlQuery += " sell=1";
                }

                DataTable da = data.Query(sqlQuery);
                skinDataGridView.DataSource = da;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 加载区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinGroupBoxTop_Enter(object sender, EventArgs e)
        {
            string sqlarea = "select area from area";
            DataTable dare = data.Query(sqlarea);
            this.skinComboBoxArea.DataSource = dare;
            this.skinComboBoxArea.DisplayMember = "area";
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
