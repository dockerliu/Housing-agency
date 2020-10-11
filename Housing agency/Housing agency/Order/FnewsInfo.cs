using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Housing_agency.Order
{
    public class FnewsInfo
    {
        #region 定义数据库变量

        private string _bianhao;
        private string _laiyuan;
        private string _date;
        private string _zhuangtai;
        private string _wuye;
        private string _huxing;
        private int _mianji;
        private string _area;
        private int _z_floor;
        private int _n_floor;
        private string _guwen;
        private string _yongtu;
        private string _wuye_type;
        private string _chengdu;
        private string _fang_type;
        private string _jiancheng;
        private string _address;
        private bool _lend;
        private bool _sell;
        private string _lend_shuoming;
        private string _sell_shuoming;
        private string _xiangxi;
        private string _lend_price;
        private string _sell_price;
        private string _jichusheshi;
        private string _peitaosheshi;
        private string _yezhu_name;
        private string _tele;
        private string _MobliePhone;
        private string _beizhu;
        private string _yezhu_address;

        #endregion

        #region 封装自定义数据变量

        /// <summary>
        /// 编号
        /// </summary>
        public string Bianhao { get => _bianhao; set => _bianhao = value; }
        /// <summary>
        /// 房屋来源
        /// </summary>
        public string Laiyuan { get => _laiyuan; set => _laiyuan = value; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Date { get => _date; set => _date = value; }
        /// <summary>
        /// 当前房屋状态
        /// </summary>
        public string Zhuangtai { get => _zhuangtai; set => _zhuangtai = value; }
        /// <summary>
        /// 物业
        /// </summary>
        public string Wuye { get => _wuye; set => _wuye = value; }

        /// <summary>
        /// 户型
        /// </summary>
        public string Huxing { get => _huxing; set => _huxing = value; }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get => _area; set => _area = value; }
        /// <summary>
        /// 总层数
        /// </summary>
        public int Z_floor { get => _z_floor; set => _z_floor = value; }
        /// <summary>
        /// 房屋位于层数
        /// </summary>
        public int N_floor { get => _n_floor; set => _n_floor = value; }
        /// <summary>
        /// 面积
        /// </summary>
        public int Mianji { get => _mianji; set => _mianji = value; }
        /// <summary>
        /// 顾问
        /// </summary>
        public string Guwen { get => _guwen; set => _guwen = value; }
        /// <summary>
        /// 用途
        /// </summary>
        public string Yongtu { get => _yongtu; set => _yongtu = value; }
        /// <summary>
        /// 物业类型
        /// </summary>
        public string Wuye_type { get => _wuye_type; set => _wuye_type = value; }
        /// <summary>
        /// 程度
        /// </summary>
        public string Chengdu { get => _chengdu; set => _chengdu = value; }
        /// <summary>
        /// 房屋类型
        /// </summary>
        public string Fang_type { get => _fang_type; set => _fang_type = value; }
        /// <summary>
        /// 建成年份
        /// </summary>
        public string Jiancheng { get => _jiancheng; set => _jiancheng = value; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get => _address; set => _address = value; }
        /// <summary>
        ///  是否出租
        /// </summary>
        public bool Lend { get => _lend; set => _lend = value; }
        /// <summary>
        /// 是否出售
        /// </summary>
        public bool Sell { get => _sell; set => _sell = value; }
        /// <summary>
        /// 出租说明
        /// </summary>
        public string Lend_shuoming { get => _lend_shuoming; set => _lend_shuoming = value; }
        /// <summary>
        /// 出售说明
        /// </summary>
        public string Sell_shuoming { get => _sell_shuoming; set => _sell_shuoming = value; }
        /// <summary>
        /// 详细
        /// </summary>
        public string Xiangxi { get => _xiangxi; set => _xiangxi = value; }
        /// <summary>
        /// 出租价格
        /// </summary>
        public string Lend_price { get => _lend_price; set => _lend_price = value; }
        /// <summary>
        /// 出售价格
        /// </summary>
        public string Sell_price { get => _sell_price; set => _sell_price = value; }
        /// <summary>
        /// 基础设施
        /// </summary>
        public string Jichusheshi { get => _jichusheshi; set => _jichusheshi = value; }
        /// <summary>
        /// 配套设施
        /// </summary>
        public string Peitaosheshi { get => _peitaosheshi; set => _peitaosheshi = value; }
        /// <summary>
        /// 业主姓名
        /// </summary>
        public string Yezhu_name { get => _yezhu_name; set => _yezhu_name = value; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Tele { get => _tele; set => _tele = value; }

        /// <summary>
        /// 电话
        /// </summary>
        public string MobliePhone { get => _MobliePhone; set => _MobliePhone = value; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Beizhu { get => _beizhu; set => _beizhu = value; }
        /// <summary>
        /// 业主地址
        /// </summary>
        public string Yezhu_address { get => _yezhu_address; set => _yezhu_address = value; } 
        #endregion
    }
}
