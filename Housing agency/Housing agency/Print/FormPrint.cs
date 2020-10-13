using System;
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
        /// <summary>
        ///  需要显示报表所要连接字符串
        /// </summary>
        public string reportStr = @"Driver={MySQL ODBC 3.51 Driver};Server=192.168.1.95;Port=3306;Database=build;User=build;CHARSET=GBK; Password=111111;Option=3;";
            GridppReport Report = new GridppReport();
        private void FormPrint_Load(object sender, EventArgs e)
        {
            //载入报表模板数据
            string reportPath = Application.StartupPath + "\\Print\\simple.grf";
            //从对应文件中载入报表模板数据
            Report.LoadFromFile(reportPath);
            //设置与数据源的连接串，因为在设计时指定的数据库路径是绝对路径。
            Report.DetailGrid.Recordset.ConnectionString = reportStr;
            //设置新的查询语句，减少数据量，便于查看补充的数据项目
            Report.DetailGrid.Recordset.QuerySQL= "select * from fangyuan WHERE bianhao='"+id+"'";

            //连接报表事件
            //Report.ProcessBegin += new _IGridppReportEvents_ProcessBeginEventHandler(ReportProcessBegin);


            //根据参数名称设置参数的值，我在模板中把静态文本框绑定了这个参数，这里也就是设置了静态文本的显示值
            //Report.ParameterByName("test1").AsString = "d2322222222222222222";
            //设置模板中图片的值            
            //Report.ControlByName("PictureBox1").AsPictureBox.LoadFromFile(Application.StartupPath + "\\fileimages\\grid-2.png");

            //设置模板中富文本的值
            //Report.ControlByName("MemoBox1").AsMemoBox.Text = "asdfasfsdfsdfsdfsdfsf";


            //设置报表查询显示器控件的关联报表对象
            axGRDisplayViewer1.Report = Report;
            //启动报表运行
            axGRDisplayViewer1.Start();
        }

        private void skinButtonPrint_Click(object sender, EventArgs e)
        {
            Report.Print(true);//打印预览，或者用print打印
        }

        private void skinButtonPrintPreview_Click(object sender, EventArgs e)
        {
            Report.PrintPreview(true);//打印预览，或者用print打印
        }
    }
}
