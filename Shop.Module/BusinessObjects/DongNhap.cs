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
    [NavigationItem(false)]
    [System.ComponentModel.DisplayName("Hàng nhập")]
    [ImageName("BO_Contact")]
    [DefaultProperty("soluong")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class DongNhap : BaseObject
    { 
        public DongNhap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Tinhdong();
        }
        private PhieuNhap _Phieu;
        [Association()]
        [XafDisplayName("Phiếu nhập")]
        public PhieuNhap phieu
        {
            get { return _Phieu; }
            set { SetPropertyValue<PhieuNhap>(nameof(phieu), ref _Phieu, value); }
        }
        private Sanpham _Hang;
        [Association]
        [XafDisplayName("Hàng hoá")]
        public Sanpham Hang
        {
            get { return _Hang; }
            set { SetPropertyValue<Sanpham>(nameof(Hang), ref _Hang, value); }
        }

        private double _soluong;
        [XafDisplayName("Số lượng"), Size(255)]
        public double soLuong
        {
            get { return _soluong; }
            set {
                    bool isModified = SetPropertyValue<double>(nameof(soLuong), ref _soluong, value);
                    //Tinhdong();
                    if (!IsLoading && !IsSaving) { Tinhdong(); }
            }
        }
        private decimal _Dongia;
        [XafDisplayName("Đơn giá"), Size(255)]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal donGia
        {
            get { return _Dongia; }
            set {
                bool isModified = SetPropertyValue<decimal>(nameof(donGia), ref _Dongia, value);
                //Tinhdong();
                if (!IsLoading && !IsSaving) { Tinhdong(); } 
            }
        }

        private double _Chietkhau;
        [XafDisplayName("Chiết khấu (%)"), Size(255)]
        public double chietKhau
        {
            get { return _Chietkhau; }
            set { bool isModified =  SetPropertyValue<double>(nameof(chietKhau), ref _Chietkhau, value);
                //Tinhdong();
                if (!IsLoading && !IsSaving) { Tinhdong(); }
            }
        }

        private double _Vat;
        [XafDisplayName("Vat (%)"), Size(255)]
        public double vat
        {
            get { return _Vat; }
            set { bool isModified = SetPropertyValue<double>(nameof(vat), ref _Vat, value);
                //Tinhdong();
                if (!IsLoading && !IsSaving) { Tinhdong(); }
            }
        }

        private decimal _Thanhtien;
        [XafDisplayName("Thành tiền"),ModelDefault("AllowEdit","false")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal Thanhtien
        {
            get { return _Thanhtien; }
            set { SetPropertyValue<decimal>(nameof(Thanhtien), ref _Thanhtien, value); }
        }
        //khi có sự thay đổi trong thanh toán sản phẩm dongnhap sẽ kích hoạt Tinhdong để tổng
        //tiền thanh toán và gọi phieu.Tinhtong để tính tổng tiền hoá đơn phiếu nhập  
        private void Tinhdong()
        {
            decimal tien = 0;
            tien = (decimal)soLuong * donGia;
            decimal tienck = (decimal)(chietKhau / 100) * tien;
            tien -= tienck;
            decimal tienvat = (decimal)(vat / 100) * tien;
            tien += tienvat;
            Thanhtien = tien;
            if (phieu != null) phieu.Tinhtong();
        }
    }
}