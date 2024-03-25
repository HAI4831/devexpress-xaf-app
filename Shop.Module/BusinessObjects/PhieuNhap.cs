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
using System.Runtime.InteropServices;
using System.Text;

namespace Shop.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Phiếu nhập")]
    [ImageName("phieunhap")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class PhieuNhap : BaseObject
    {
        public PhieuNhap(Session session)
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
            SoCT = getSoCT().ToString();
        }
        protected override void OnSaving()
        {
            Tinhtong();
            base.OnSaving();
        }
        private KhachHang _khach;
        [Association("khach-nhap")]
        [XafDisplayName("Nhà cung cấp")]
        public KhachHang khach
        {
            get { return _khach; }
            set { SetPropertyValue<KhachHang>(nameof(khach), ref _khach, value); }
        }
        private NhanVien _Ketoan;
        [Association("kt-nhap")]
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
        [DevExpress.Xpo.Aggregated, Association()]
        [XafDisplayName("Hàng nhập")]
        public XPCollection<DongNhap> dongNhaps
        {
            get { return GetCollection<DongNhap>(nameof(dongNhaps)); }
        }

        private decimal _Tongtien;
        [XafDisplayName("Tổng tiền"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat","{0:### ### ### ###}")]
        public decimal Tongtien
        {
            get { return _Tongtien; }    
            set { SetPropertyValue<decimal>(nameof(Tongtien),ref _Tongtien, value);}
        }
        public void Tinhtong()
        {
            decimal tong = 0;
            foreach(DongNhap dong in dongNhaps)
            {
                tong += dong.Thanhtien;
            }
            Tongtien = tong;
        }
        //hàm tìm giá trị số chứng từ giao dịch tiếp theo cần chèn là max(soCT)+1
        //đề cập đến một con số hoặc một dãy số được gắn với mỗi tài liệu chứng từ như hóa đơn, 
        // biên nhận, chứng từ xuất nhập kho, chứng từ thanh toán, v.v.Số chứng từ thường được sử dụng để theo dõi và xác định các giao dịch và các sự kiện tài chính cụ thể trong doanh nghiệp.
        private int getSoCT()
        {
            string query =
                "SELECT MAX(CAST(SoCT AS INT)) as MaxSoCT\r\n" +
                "FROM Phieunhap\r\nWHERE ISNUMERIC(SoCT)=1 " +
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