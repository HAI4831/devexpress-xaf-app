using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Module.BusinessObjects
{
    [DomainComponent]
    //là id của NavigationItem chungtu item  trong Model.DesignedDiffs 
    [NavigationItem("chungtu")]
    [System.ComponentModel.DisplayName("Doanh thu")]
    public class DoanhthuRpt
    {
        [DevExpress.ExpressApp.Data.Key]
        public Guid Oid { get; set; }

        [XafDisplayName("Nhóm")]
        public string Nhom { get; set; }

        [XafDisplayName("Mã")]
        public string MaSP { get; set; }

        [XafDisplayName("Tên Sản phẩm")]
        public string TenSP { get; set; }

        [XafDisplayName("ĐVT")]
        public string Dvt { get; set; }

        [XafDisplayName("Số Lượng")]
        [ModelDefault("DisplayFormat", "#,###")]
        public Nullable<double> Soluong { get; set; }

        [XafDisplayName("Doanh thu")]
        [ModelDefault("DisplayFormat", "#,###")]
        public Nullable<decimal> Doanhthu { get; set; }

        [XafDisplayName("Giá vốn")]
        [ModelDefault("DisplayFormat", "#,###")]
        public Nullable<decimal> Giavon { get; set; }

        [XafDisplayName("Lãi gộp")]
        [ModelDefault("DisplayFormat", "#,###")]
        public Nullable<decimal> Laigop { get; set; }
    }
}
