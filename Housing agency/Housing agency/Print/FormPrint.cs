using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using gregn6Lib;

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
            GridppReport Report = new GridppReport();
            string reportPath = Application.StartupPath + "\\Print\\simple.grf";

            //从对应文件中载入报表模板数据
            Report.LoadFromFile(reportPath);
            //根据参数名称设置参数的值，我在模板中把静态文本框绑定了这个参数，这里也就是设置了静态文本的显示值
            //Report.ParameterByName("test1").AsString = "d2322222222222222222";
            //设置模板中图片的值            
            //Report.ControlByName("PictureBox1").AsPictureBox.LoadFromFile(Application.StartupPath + "\\fileimages\\grid-2.png");

            //设置模板中富文本的值
            //Report.ControlByName("MemoBox1").AsMemoBox.Text = "asdfasfsdfsdfsdfsdfsf";

            Report.PrintPreview(true);//打印预览，或者用print打印
        }
    }
}
