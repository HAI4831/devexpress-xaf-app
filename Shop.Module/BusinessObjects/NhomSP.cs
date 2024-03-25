using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Shop.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Nhóm hàng")]
    [ImageName("nhomsp")]
    [DefaultProperty("Tennhom")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class NhomSP : BaseObject
    {
        public NhomSP(Session session)
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
        [XafDisplayName("Số hàng")]
        public int Sohang
        {
            get
            {
                return Sanphams.Count;
            }
        }
        [DevExpress.Xpo.Aggregated,Association]
        [XafDisplayName("Sản phẩm")]
        public XPCollection<Sanpham> Sanphams
        {
            get { return GetCollection<Sanpham>(nameof(Sanphams)); }
        }  
    }
}