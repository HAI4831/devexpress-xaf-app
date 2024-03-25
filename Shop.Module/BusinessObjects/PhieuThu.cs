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
    [System.ComponentModel.DisplayName("Phiếu thu")]
    [ImageName("thu")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class PhieuThu : BaseObject
    { 
        public PhieuThu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if(Session.IsNewObject(this))
            {
                NgayCT = DateTime.Now;
            }
        }
        private KhachHang _khach;
        [Association("khach-thu")]
        [XafDisplayName("Thu của")]
        public KhachHang khach
        {
            get { return _khach; }
            set { SetPropertyValue<KhachHang>(nameof(khach), ref _khach, value); }
        }
        private NhanVien _Ketoan;
        [Association("kt-thu")]
        [XafDisplayName("Kế toán")]
        public NhanVien keToan
        {
            get => _Ketoan;
            set => SetPropertyValue<NhanVien>(nameof(keToan), ref _Ketoan, value);
        }
 
        private string _SoCT;
        [XafDisplayName("Số CT"),Size(20),RuleUniqueValue]
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

        private decimal _Sotien;
        [XafDisplayName("Số tiền")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal soTien
        {
            get { return _Sotien; }
            set { SetPropertyValue<decimal>(nameof(soTien), ref _Sotien, value); }
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
    }
}