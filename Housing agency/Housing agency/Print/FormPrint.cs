using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using grproLib;

namespace Housing_agency.Print
{
    public partial class FormPrint : CCSkinMain
    {
        public FormPrint()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 需要显示报表所要查询的ID
        /// </summary>
        public string id;

        private void FormPrint_Load(object sender, EventArgs e)
        {
            GridppReport gr = new GridppReport();//报表对象
            //建议不要在报表中存储连接字符串字符串
            //如果不设置ConnectionString或QuerySQL属性，则会使用报表内的连接字符串和SQL语句
            gr.ConnectionString = "";//连接字符串
            gr.QuerySQL = "";//SQL语句
            gr.LoadFromFile("Print\\simple.grf");//本地报表路径
            gr.ParameterByName("Name").AsString = "古河渚";//主报表传参
            gr.Print(true);//不预览打印
        }
    }
}
