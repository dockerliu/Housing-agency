using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace Housing_agency
{
    public partial class mainForm :CCSkinMain
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize.Height.CompareTo(this.Height);

            #region 用户权限

            if (login._RCGL == true)
            {
                this.skinTabPageOrder.Enabled = true;
            }
            else
            {
               // this.skinTabPageOrder.Enabled = false;
            } 
            #endregion

        }
        /// <summary>
        /// 新订单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            OrderNew orderNew = new OrderNew();
            orderNew.Show();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("你确定要退出该系统吗？","提示：",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
