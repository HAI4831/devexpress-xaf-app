using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Shop.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Phiếu xuất")]
    [ImageName("phieuxuat")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class PhieuXuat : BaseObject
    { 
        public PhieuXuat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                NgayCT = DateTime.Now;
                SoCT = getSoCT().ToString();
            }
        }
        private KhachHang _khach;
        [Association("khach-xuat")]
        [XafDisplayName("Nhà tiêu dùng")]
        public KhachHang khach
        {
            get { return _khach; }
            set { SetPropertyValue<KhachHang>(nameof(khach), ref _khach, value); }
        }
        private NhanVien _Ketoan;
        [Association("kt-xuat")]
        [XafDisplayName("Kế toán")]
        public NhanVien keToan
        {
            get => _Ketoan;
            set => SetPropertyValue<NhanVien>(nameof(keToan), ref _Ketoan, value);
        }

        private string _SoCT;
        [XafDisplayName("Số CT"), Size(20), RuleUniqueValue]
        public string SoCT
        {
            get { return _SoCT; }
            set { SetPropertyValue<string>(nameof(SoCT), ref _SoCT, value); }
        }
        private DateTime _NgayCT;
        [XafDisplayName("Ngày CT")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayCT
        {
            get { return _NgayCT; }
            set { SetPropertyValue<DateTime>(nameof(NgayCT), ref _NgayCT, value); }
        }

        private string _SoHD;
        [XafDisplayName("Số HD")]
        public string SoHD
        {
            get { return _SoHD; }
            set { SetPropertyValue<string>(nameof(SoHD), ref _SoHD, value); }
        }
        private DateTime _NgayHD;
        [XafDisplayName("Ngày HD")]
        public DateTime NgayHD
        {
            get { return _NgayHD; }
            set { SetPropertyValue<DateTime>(nameof(NgayHD), ref _NgayHD, value); }
        }
        private string _Ghichu;
        [XafDisplayName("Ghi chú"), ModelDefault("AllowEdit", "false")]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("dong-xuat")]
        [XafDisplayName("Hàng xuất")]
        public XPCollection<DongXuat> Dongxuats
        {
            get { return GetCollection<DongXuat>(nameof(Dongxuats)); }
        }

        private decimal _Tongtien;
        [XafDisplayName("Tổng tiền"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal Tongtien
        {
            get { return _Tongtien; }
            set { SetPropertyValue<decimal>(nameof(Tongtien), ref _Tongtien, value); }
        }
        private decimal _Giavon;

        [XafDisplayName("Giá vốn")]
        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:#,###.##}")]
        public decimal Giavon
        {
            get => _Giavon;
            set => SetPropertyValue<decimal>(nameof(Giavon), ref _Giavon, value);
        }

        private decimal _Laigop;

        [XafDisplayName("Lãi gộp")]
        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:#,###.##}")]
        public decimal Laigop
        {
            get => _Laigop;
            set => SetPropertyValue<decimal>(nameof(Laigop), ref _Laigop, value);
        }
        public void Tinhtong()
        {
            decimal tong = 0, gv = 0;
            foreach (DongXuat dong in Dongxuats)
            {
                tong += dong.ThanhTien;
                gv += (decimal)dong.SoLuong;
            }
            Tongtien = tong;
            Giavon = gv;
            Laigop = Tongtien - gv;
        }

        private int getSoCT()
        {
            string query =
                "SELECT MAX(CAST(SoCT AS INT)) as MaxSoCT\r\n" +
                "FROM Phieuxuat\r\nWHERE ISNUMERIC(SoCT)=1 " +
                "AND GCRecord IS NULL;\r\n";
            int soCT = 1;
            var ret = Session.ExecuteScalar(query);
            if (ret != null)
            {
                soCT = Convert.ToInt32(ret) + 1;
            }
            return soCT;
        }
    }
}