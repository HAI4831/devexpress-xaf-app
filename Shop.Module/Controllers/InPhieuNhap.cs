using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl;
using Shop.Module.BusinessObjects;
using System;

namespace Shop.Module.Controllers
{
    public abstract class InPhieuNhap : ViewController
    {
        public InPhieuNhap()
        {
            TargetObjectType = typeof(PhieuNhap);
            SimpleAction inphieunhap = new SimpleAction(this, "inphieunhap", "View")
            {
                Caption = "In phiếu",
                ImageName = "printer",
                ToolTip = "In phiếu nhập",
                ConfirmationMessage = "Có chắc chắn in không?"
            };
            inphieunhap.Execute += Inphieunhap_Execute;
        }

        private void Inphieunhap_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject is PhieuNhap p)
            {
                string ChungtuOid = p.Oid.ToString();
                if (!string.IsNullOrEmpty(ChungtuOid))
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
                    IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(
                        new BinaryOperator("DisplayName", "pnhap"));
                    if (reportData != null)
                    {
                        PrintReport(reportData, Guid.Parse(ChungtuOid));
                    }
                }
            }
        }

        protected abstract void PrintReport(IReportDataV2 reportData, Guid phieuOid);
    }
}
