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
    [ImageName("nhanvien")]
    [System.ComponentModel.DisplayName("Nhân viên")]
    [DefaultProperty("Hoten")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class NhanVien : BaseObject
    { 
        public NhanVien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private string _Hoten;
        [XafDisplayName("Họ tên"),Size(255)]
        public string Hoten
        {
            get { return _Hoten; }
            set { SetPropertyValue<string>(nameof(Hoten), ref _Hoten, value); }
        }
        private string _Diachi;
        [XafDisplayName("Địa chỉ"), Size(255)]
        public string Diachi
        {
            get { return _Diachi; }
            set { SetPropertyValue<string>(nameof(Diachi), ref _Diachi, value); }
        }
        private string _Dienthoai;
        [XafDisplayName("Điện thoại"), Size(255)]
        public string Dienthoai
        {
            get { return _Dienthoai; }
            set { SetPropertyValue<string>(nameof(Dienthoai), ref _Dienthoai, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("kt-nhap")]
        [XafDisplayName("Phiếu nhập")]
        public XPCollection<PhieuNhap> phieunhaps
        {
            get { return GetCollection<PhieuNhap>(nameof(phieunhaps)); }
        }
        [DevExpress.Xpo.Aggregated, Association("kt-xuat")]
        [XafDisplayName("Phiếu xuất")]
        public XPCollection<PhieuXuat> phieuxuats
        {
            get { return GetCollection<PhieuXuat>(nameof(phieuxuats)); }
        }

        [DevExpress.Xpo.Aggregated, Association("kt-thu")]
        [XafDisplayName("Phiếu thu")]
        public XPCollection<PhieuThu> phieuThus
        {
            get { return GetCollection<PhieuThu>(nameof(phieuThus)); }
        }

        [DevExpress.Xpo.Aggregated, Association("kt-chi")]
        [XafDisplayName("Phiếu chi")]
        public XPCollection<PhieuChi> phieuChis
        {
            get { return GetCollection<PhieuChi>(nameof(phieuChis)); }
        }
    }
}