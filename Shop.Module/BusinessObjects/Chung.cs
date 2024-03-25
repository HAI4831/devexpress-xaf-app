using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;

namespace Shop.Module.BusinessObjects
{
    public class Chung
    {
        public static DateTime Tungay = DateTime.Now;
        public static DateTime Denngay = DateTime.Now;
        public static IBindingList GetDoanhthu(IObjectSpace objectSpace)
        {
            BindingList<DoanhthuRpt> objects = new();
            Session session = ((XPObjectSpace)objectSpace).Session;
            XPCollection<DongXuat> dongxuats = new (session);
            //Điều kiện truy vấn
            //dongxuats.Criteria = CriteriaOperator.Parse($"Phieu.NgayCT >= ? and Phieu.NgayCT <= ?", Tungay, Denngay);
            foreach (DongXuat dong in dongxuats)
            {
                DoanhthuRpt obj = new()
                {
                    Oid = dong.Oid,
                    Nhom = dong.Hang.Nhom.Tennhom,
                    MaSP = dong.Hang.Masp,
                    TenSP = dong.Hang.TenSP,
                    Dvt = dong.Hang.Dvt,
                    Soluong = dong.SoLuong,
                    Doanhthu = dong.ThanhTien,
                    Giavon = dong.DongiaVon * (decimal)dong.SoLuong,
                    Laigop = dong.ThanhTien- dong.DongiaVon * (decimal)dong.SoLuong
                };
                objects.Add(obj);
            }
            return objects;
        }

    }
}
