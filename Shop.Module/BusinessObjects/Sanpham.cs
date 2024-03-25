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
    [System.ComponentModel.DisplayName("Hàng hoá")]
    [ImageName("product")]
    [DefaultProperty("TenSP")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class Sanpham : BaseObject
    {
        public Sanpham(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private NhomSP _Nhom;
        [Association]
        [XafDisplayName("Nhóm")]
        public NhomSP Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomSP>(nameof(Nhom), ref _Nhom, value); }
        }

        private string _Masp;
        [XafDisplayName("Mã"), Size(20)]
        [RuleRequiredField("Yeucau MaSP",DefaultContexts.Save,"Phải có Mã sản phẩm")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string Masp
        {
            get { return _Masp; }
            set { SetPropertyValue<string>(nameof(Masp), ref _Masp, value); }
        }
        private string _Mavach;
        [XafDisplayName("Mã vạch"), Size(20)]
        public string Mavach
        {
            get { return _Mavach; }
            set { SetPropertyValue<string>(nameof(Mavach), ref _Mavach, value); }
        }
        private string _TenSP;
        [XafDisplayName("Tên hàng"), Size(20)]
        public string TenSP
        {
            get { return _TenSP; }
            set { SetPropertyValue<string>(nameof(TenSP), ref _TenSP, value); }
        }

        private string _Dvt;
        [XafDisplayName("Đvt"), Size(20)]
        public string Dvt
        {
            get { return _Dvt; }
            set { SetPropertyValue<string>(nameof(Dvt), ref _Dvt, value); }
        }

        private double _Vat;
        [XafDisplayName("Vat"), Size(20)]
        public double Vat
        {
            get { return _Vat; }
            set { SetPropertyValue<double>(nameof(Vat), ref _Vat, value); }
        }
        private decimal _Giaban;
        [XafDisplayName("Giá bán"), Size(20)]
        public decimal Giaban
        {
            get { return _Giaban; }
            set { SetPropertyValue<decimal>(nameof(Giaban), ref _Giaban, value); }
        }

        private double _Soton;
        [XafDisplayName("Số lượng tồn"), ModelDefault("AllowEdit","false")]
        public double Soton
        {
            get { return _Soton; }
            set { SetPropertyValue<double>(nameof(Soton), ref _Soton, value); }
        }
        private decimal _Giatriton;
        [XafDisplayName("Giá trị tồn"), ModelDefault("AllowEdit", "false")]
        public decimal Giatriton
        {
            get { return _Giatriton; }
            set { SetPropertyValue<decimal>(nameof(Giatriton), ref _Giatriton, value); }
        }

        private string _Ghichu;
        [XafDisplayName("Ghi chú"), ModelDefault("AllowEdit", "false")]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Nhập")]
        public XPCollection<DongNhap> dongnhaps
        {
            get { return GetCollection<DongNhap>(nameof(dongnhaps)); }
        }
        [DevExpress.Xpo.Aggregated, Association("hang-xuat")]
        [XafDisplayName("Hàng xuất")]
        public XPCollection<DongXuat> dongxuats
        {
            get { return GetCollection<DongXuat>(nameof(dongxuats)); }
        }

    }
}