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
    [ImageName("khach")]
    [System.ComponentModel.DisplayName("Khách hàng")]
    [DefaultProperty("Tenkhach")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class KhachHang : BaseObject
    {
        public KhachHang(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private NhomKhach _Nhom;
        [Association]
        [XafDisplayName("Nhóm")]
        public NhomKhach Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomKhach>(nameof(Nhom), ref _Nhom, value); }
        }


        private string _Tenkhach;
        [XafDisplayName("Tên khách hàng"), Size(255)]
        public string Tenkhach
        {
            get { return _Tenkhach; }
            set { SetPropertyValue<string>(nameof(Tenkhach), ref _Tenkhach, value); }
        }

        private string _Diachi;
        [XafDisplayName("Địa chỉ"), Size(255)]
        public string Diachi
        {
            get { return _Diachi; }
            set { SetPropertyValue<string>(nameof(Diachi), ref _Diachi, value); }
        }

        private string _Dienthoai;
        [XafDisplayName("Điện thoại"), Size(50)]
        public string Dienthoai
        {
            get { return _Dienthoai; }
            set { SetPropertyValue<string>(nameof(Dienthoai), ref _Dienthoai, value); }
        }

        private string _Email;
        [XafDisplayName("Email"), Size(255)]
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }

        private string _Ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("khach-nhap")]
        [XafDisplayName("Phiếu nhập")]
        public XPCollection<PhieuNhap> phieunhaps
        {
            get { return GetCollection<PhieuNhap>(nameof(phieunhaps)); }
        }
        [DevExpress.Xpo.Aggregated, Association("khach-xuat")]
        [XafDisplayName("Phiếu xuất")]
        public XPCollection<PhieuXuat> phieuxuats
        {
            get { return GetCollection<PhieuXuat>(nameof(phieuxuats)); }
        }

        [DevExpress.Xpo.Aggregated, Association("khach-thu")]
        [XafDisplayName("Phiếu thu")]
        public XPCollection<PhieuThu> phieuThus
        {
            get { return GetCollection<PhieuThu>(nameof(phieuThus)); }
        }

        [DevExpress.Xpo.Aggregated, Association("khach-chi")]
        [XafDisplayName("Phiếu chi")]
        public XPCollection<PhieuChi> phieuChis
        {
            get { return GetCollection<PhieuChi>(nameof(phieuChis)); }
        }
    }
}