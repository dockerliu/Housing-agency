using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using MySql.Data.MySqlClient;

namespace Housing_agency.Order
{
    public partial class FormAdd : CCSkinMain
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        Database data = new Database();
        string sd = "yyyyMMddHHmmss";
        FnewsInfo Finfo = new FnewsInfo();
        public FormAdd(FnewsInfo fnews)
        {
            Finfo = fnews;
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            //查询顾问值
            string sqlGuwen = "SELECT _name FROM empl_info";
            DataTable dt = data.Query(sqlGuwen);
            this.skinComboBoxGuwen.DataSource = dt;
            this.skinComboBoxGuwen.DisplayMember = "_name";
            //查询区域值
            string sqlArea = "select area from area";
            dt = data.Query(sqlArea);
            this.skinComboBoxArea.DataSource = dt;
            this.skinComboBoxArea.DisplayMember = "area";
            //查询来源
            string sqlLaiyuan = "SELECT * FROM f_laiyuan";
            dt = data.Query(sqlLaiyuan);
            this.skinComboBoxLaiyuan.DataSource = dt;
            this.skinComboBoxLaiyuan.DisplayMember = "f_laiyuan";
            //查询当前状态
            string sqlSta = "SELECT * FROM f_sta";
            dt = data.Query(sqlSta);
            this.skinComboBoxSta.DataSource = dt;
            this.skinComboBoxSta.DisplayMember = "f_sta";
            //查询物业用途
            string sqlYt = "SELECT * FROM f_yongtu";
            dt = data.Query(sqlYt);
            this.skinComboBoxYongtu.DataSource = dt;
            this.skinComboBoxYongtu.DisplayMember = "f_yongtu";
            //查询物业类别
            string sqlWuye = "SELECT * FROM f_wuye";
            dt = data.Query(sqlWuye);
            this.skinComboBoxWuye.DataSource = dt;
            this.skinComboBoxWuye.DisplayMember = "f_wuye";
            //查询装修程序
            string sqlZx = "SELECT * FROM f_zhuangxiu";
            dt = data.Query(sqlZx);
            this.skinComboBoxZhuangxiu.DataSource = dt;
            this.skinComboBoxZhuangxiu.DisplayMember = "f_zhuangxiu";

            //查询房型
            string sqlLx = "SELECT * FROM f_leixing";
            dt = data.Query(sqlLx);
            this.skinComboBoxLeixing.DataSource = dt;
            this.skinComboBoxLeixing.DisplayMember = "f_leixing";

            //房屋编号
            this.skinWaterTextBoxBianhao.Text = "YM" + DateTime.Now.ToString(sd);
            if (Finfo.Bianhao != null)
            {
                this.skinWaterTextBoxBianhao.Enabled = false;
                this.skinWaterTextBoxBianhao.Text = Finfo.Bianhao;
                this.skinComboBoxLaiyuan.Text = Finfo.Laiyuan;
                this.skinComboBoxSta.Text = Finfo.Wuye_type;
                this.skinComboBoxWuye.Text = Finfo.Wuye;
                this.skinComboBoxYongtu.Text = Finfo.Yongtu;
                this.skinWaterTextBoxJiancheng.Text = Finfo.Jiancheng;
                this.skinComboBoxGuwen.Text = Finfo.Guwen;
                this.skinComboBoxArea.Text = Finfo.Area;
                this.skinWaterTextBoxMianji.Text = Finfo.Mianji.ToString();
                this.skinWaterTextBoxYezhu.Text = Finfo.Yezhu_name;
                this.skinWaterTextBoxAdress.Text = Finfo.Yezhu_address;
                this.skinWaterTextBoxTel.Text = Finfo.Tele;
                this.skinWaterTextBoxMobile.Text = Finfo.MobliePhone;
                this.skinWaterTextBox1Shuoming.Text = Finfo.Beizhu;
                this.skinWaterTextBoxZ_floor.Text = Finfo.Z_floor.ToString();
                this.skinWaterTextBoxN_floor.Text = Finfo.N_floor.ToString();
                this.skinWaterTextBoxXiangxi.Text = Finfo.Xiangxi;

                if (Finfo.Lend == true)
                {
                    this.skinCheckBoxLend.Checked = true;
                    this.skinCheckBoxSell.Checked = false;
                    this.skinWaterTextBoxLendPrice.Text = Finfo.Lend_price;
                    this.skinWaterTextBoxLendShuoming.Text = Finfo.Lend_shuoming;
                }
                else if (Finfo.Sell == true)
                {
                    this.skinCheckBoxSell.Checked = true;
                    this.skinCheckBoxLend.Checked = false;
                    this.skinWaterTextBoxSellPrice.Text = Finfo.Sell_price;
                    this.skinWaterTextBoxSellShuoming.Text = Finfo.Sell_shuoming;
                }
                else if (Finfo.Lend == true && Finfo.Sell)
                {
                    this.skinCheckBoxLend.Checked = true;
                    this.skinCheckBoxSell.Checked = true;
                }
            }
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
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButtonSave_Click(object sender, EventArgs e)
        {
            if (this.skinComboBoxWuye.Text == "")
            {
                MessageBox.Show("物业名字不能为空");
                return;
            }
            Finfo.Bianhao = this.skinWaterTextBoxBianhao.Text;
            Finfo.Zhuangtai = this.skinComboBoxSta.Text;
            string date = DateTime.Now.ToString();
            Finfo.Laiyuan = this.skinComboBoxLaiyuan.Text;
            Finfo.Wuye = this.skinComboBoxWuye.Text;
            Finfo.Huxing = this.skinWaterTextBoxBedroom.Text + this.skinLabelBedroom.Text + this.skinWaterTextBoxLivingroom.Text + this.skinLabelLivingroom.Text + this.skinWaterTextBoxBathroom.Text + this.skinLabelBathRoom.Text + this.skinWaterTextBoxbalcony.Text + this.skinLabelbalcony.Text;
            Finfo.Mianji = Convert.ToInt32(this.skinWaterTextBoxMianji.Text);
            Finfo.Area = this.skinComboBoxArea.Text;
            Finfo.Z_floor = Convert.ToInt32(this.skinWaterTextBoxZ_floor.Text);
            Finfo.N_floor = Convert.ToInt32(this.skinWaterTextBoxN_floor.Text);
            Finfo.Yongtu = this.skinComboBoxYongtu.Text;
            Finfo.Wuye_type = this.skinComboBoxLeixing.Text;
            Finfo.Jiancheng = this.skinWaterTextBoxJiancheng.Text;
            Finfo.Yezhu_name = this.skinWaterTextBoxYezhu.Text;
            Finfo.Address = this.skinWaterTextBoxAdress.Text;
            Finfo.Tele = this.skinWaterTextBoxTel.Text;
            Finfo.MobliePhone = this.skinWaterTextBoxMobile.Text;
            Finfo.Xiangxi = this.skinWaterTextBoxXiangxi.Text;




            Finfo.Jichusheshi = "";
            if (this.skinCheckBoxGas.Checked == true)
            {
                Finfo.Jichusheshi += this.skinCheckBoxGas.Text + ",";
            }
            if (this.skinCheckBoxHeating.Checked == true)
            {
                Finfo.Jichusheshi += this.skinCheckBoxHeating.Text + ",";
            }
            if (this.skinCheckBoxCableTV.Checked == true)
            {
                Finfo.Jichusheshi += this.skinCheckBoxCableTV.Text + ",";
            }
            if (this.skinCheckBoxBroadband.Checked == true)
            {
                Finfo.Jichusheshi += this.skinCheckBoxBroadband.Text + ",";
            }

            Finfo.Peitaosheshi = "";
            if (this.skinCheckBoxTV.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxCableTV.Text + ",";
            }
            if (this.skinCheckBoxPC.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxPC.Text + ",";
            }
            if (this.skinCheckBoxKongtiao.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxKongtiao.Text + ",";
            }
            if (this.skinCheckBoxReshuiqi.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxReshuiqi.Text + ",";
            }
            if (this.skinCheckBoxBingXiang.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxBingXiang.Text + ",";
            }
            if (this.skinCheckBoxChuangshangyongping.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxChuangshangyongping.Text + ",";
            }
            if (this.skinCheckBoxSafa.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxSafa.Text + ",";
            }
            if (this.skinCheckBoxChuju.Checked == true)
            {
                Finfo.Peitaosheshi += this.skinCheckBoxChuju.Text + ",";
            }

            if (this.skinCheckBoxLend.Checked == true)
            {
                Finfo.Lend = true;
                Finfo.Sell = false;
                Finfo.Lend_price = this.skinWaterTextBoxLendPrice.Text;
                Finfo.Lend_shuoming = this.skinWaterTextBoxLendShuoming.Text;
            }
            if (this.skinCheckBoxSell.Checked == true)
            {
                Finfo.Sell = true;
                Finfo.Lend = false;
                Finfo.Sell_price = this.skinWaterTextBoxSellPrice.Text;
                Finfo.Sell_shuoming = this.skinWaterTextBoxSellShuoming.Text;
            }
            if (this.skinCheckBoxLend.Checked == true && this.skinCheckBoxSell.Checked == true)
            {
                Finfo.Lend = true;
                Finfo.Sell = true;
                Finfo.Lend_price = this.skinWaterTextBoxLendPrice.Text;
                Finfo.Lend_shuoming = this.skinWaterTextBoxLendShuoming.Text;
                Finfo.Sell_price = this.skinWaterTextBoxSellPrice.Text;
                Finfo.Sell_shuoming = this.skinWaterTextBoxSellShuoming.Text;
            }

            if (Finfo.N_floor > Finfo.Z_floor)
            {
                MessageBox.Show("楼层数不能大于总层数！");
                return;
            }

            try
            {
                if (Finfo.Bianhao != null)
                {
                    string strsql = "UPDATE fangyuan SET zhuangtai='" + Finfo.Zhuangtai + "',laiyuan='" + Finfo.Laiyuan + "',wuye='" + Finfo.Wuye + "',huxing='" + Finfo.Huxing + "',mianju='" + Finfo.Mianji + "',area='" + Finfo.Area + "',z_floor='" + Finfo.Z_floor + "',n_floor='" + Finfo.N_floor + "',guwen='" + Finfo.Guwen + "',yongtu='" + Finfo.Yongtu + "',wuye_type='" + Finfo.Wuye_type + "', chengdu='" + Finfo.Chengdu + "',fang_type='" + Finfo.Fang_type + "',jiancheng='" + Finfo.Jiancheng + "',address='" + Finfo.Yezhu_address + "',jichusheshi='" + Finfo.Jichusheshi + "',peitaosheshi='" + Finfo.Peitaosheshi + "',yezhu_name='" + Finfo.Yezhu_name + "',tele='" + Finfo.Tele + "',mobliephone='" + Finfo.MobliePhone + "',beizhu='" + Finfo.Beizhu + "',xiangxi='" + Finfo.Xiangxi + "',lend='" + Finfo.Lend + "',sell='" + Finfo.Sell + "',lend_price='" + Finfo.Lend_price + "',lend_shuoming='" + Finfo.Lend_shuoming + "',sell_price='" + Finfo.Sell_price + "',sell_shuoming='" + Finfo.Sell_shuoming + "',yezhu_address='" + Finfo.Yezhu_address + "'  WHERE bianhao='" + Finfo.Bianhao + "'";
                    int p = data.Runsql(strsql);
                    if (p > 0)
                    {
                        MessageBox.Show("更新成功！");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                        this.Close();
                    }
                }
                else
                {
                    string strsql = "INSERT INTO fangyuan (lend,sell,bianhao,jichusheshi,huxing,laiyuan,zhuangtai,wuye,mianji,area,z_floor,n_floor,guwen,yongtu,wuye_type,chengdu,fang_type,jiancheng,address,yezhu_name,yezhu_address,tele,MobliePhone,beizhu,xiangxi,date,lend_price,lend_shuoming,sell_price,sell_shuoming) " +
                                                   "VALUES(" + Finfo.Lend + Finfo.Sell + Finfo.Bianhao + Finfo.Jichusheshi + Finfo.Huxing + Finfo.Laiyuan + Finfo.Zhuangtai + Finfo.Wuye + Finfo.Mianji + Finfo.Area + Finfo.Z_floor + Finfo.N_floor + Finfo.Guwen + Finfo.Yongtu + Finfo.Wuye_type + Finfo.Chengdu + Finfo.Fang_type + Finfo.Jiancheng + Finfo.Address + Finfo.Yezhu_name + Finfo.Yezhu_address + Finfo.Tele + Finfo.MobliePhone + Finfo.Beizhu + Finfo.Xiangxi + Finfo.Date + Finfo.Lend_price + Finfo.Lend_shuoming + Finfo.Sell_price + Finfo.Sell_shuoming + ")";
                    int p = data.Runsql(strsql);
                    if (p > 0)
                    {
                        MessageBox.Show("保存成功！");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
