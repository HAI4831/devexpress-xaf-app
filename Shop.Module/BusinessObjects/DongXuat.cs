using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraCharts.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Shop.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Hàng xuất")]
    [ImageName("BO_Contact")]
    [DefaultProperty("soluong")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class DongXuat : BaseObject
    {
        public DongXuat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Tinhdong();
        }
        private PhieuXuat _Phieu;
        [Association("dong-xuat")]
        [XafDisplayName("Phiếu xuất")]
        public PhieuXuat Phieu
        {
            get { return _Phieu; }
            set { SetPropertyValue<PhieuXuat>(nameof(Phieu), ref _Phieu, value); }
        }
        private Sanpham _Hang;
        [Association("hang-xuat")]
        [XafDisplayName("Hàng xuất")]
        public Sanpham Hang
        {
            get { return _Hang; }
            set { SetPropertyValue<Sanpham>(nameof(Hang), ref _Hang, value); }
        }

        private double _soLuong;
        [XafDisplayName("Số lượng"), Size(255)]
        public double SoLuong
        {
            get { return _soLuong; }
            set
            {
                SetPropertyValue<double>(nameof(SoLuong), ref _soLuong, value);
                if (!IsLoading && !IsSaving) { Tinhdong(); }
            }
        }
        private decimal _donGia;
        [XafDisplayName("Đơn giá"), Size(255)]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal DonGia
        {
            get { return _donGia; }
            set
            {
                SetPropertyValue<decimal>(nameof(DonGia), ref _donGia, value);
                if (!IsLoading && !IsSaving) { Tinhdong(); }
            }
        }
        private double _vat;
        [XafDisplayName("Vat"), Size(255)]
        public double Vat
        {
            get { return _vat; }
            set
            {
                SetPropertyValue<double>(nameof(Vat), ref _vat, value);
                if (!IsLoading && !IsSaving) { Tinhdong(); }
            }
        }
        private double _chietKhau;
        [XafDisplayName("Chiết khấu"), Size(255)]
        public double ChietKhau
        {
            get { return _chietKhau; }
            set
            {
                SetPropertyValue<double>(nameof(ChietKhau), ref _chietKhau, value);
                if (!IsLoading && !IsSaving) { Tinhdong(); }
            }
        }
        private decimal _thanhTien;
        [XafDisplayName("Thành tiền"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal ThanhTien
        {
            get { return _thanhTien; }
            set { SetPropertyValue<decimal>(nameof(ThanhTien), ref _thanhTien, value); }
        }
        //private decimal _laigop;
        //[XafDisplayName("Lãi gộp"), ModelDefault("AllowEdit", "false")]
        //[ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        //public decimal Laigop
        //{
        //    get { return _laigop; }
        //    set { SetPropertyValue<decimal>(nameof(Laigop), ref _laigop, value); }
        //}
        private decimal _dongiaVon;
        [XafDisplayName("Đơn giá vốn"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal DongiaVon
        {
            get { return _dongiaVon; }
            set { SetPropertyValue<decimal>(nameof(DongiaVon), ref _dongiaVon, value); }
        }


        private void Tinhdong()
        {
            decimal tien = (decimal)SoLuong * DonGia;
            decimal tienck = (decimal)(ChietKhau / 100) * tien;
            tien -= tienck;
            decimal tienvat = (decimal)(Vat / 100) * tien;
            tien += tienvat;
            ThanhTien = tien;

            if (Phieu != null && Hang != null)
            {
                string sqlngay = Phieu.NgayCT.ToString("yyyy-MM-dd HH:mm:ss");
                double dg = (double)Session.ExecuteScalar("SELECT dbo.Tinhgiavon('" + Hang.Oid + "','" + sqlngay + "') AS von");
                DongiaVon = (decimal)dg;
                Phieu.Tinhtong();
            }
        }
    }
}
