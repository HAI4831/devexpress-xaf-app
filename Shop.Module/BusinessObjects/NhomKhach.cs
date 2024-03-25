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
    [System.ComponentModel.DisplayName("Nhóm khách")]
    [ImageName("nhomkhach")]
    [DefaultProperty("Tennhom")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class NhomKhach : BaseObject
    {
        public NhomKhach(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _Tennhom;
        [XafDisplayName("Tên nhóm"), Size(100)]
        public string Tennhom
        {
            get { return _Tennhom; }
            set { SetPropertyValue<string>(nameof(Tennhom), ref _Tennhom, value); }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Khách hàng")]
        public XPCollection<KhachHang> khachhangs
        {
            get { return GetCollection<KhachHang>(nameof(khachhangs)); }
        }
    }
}