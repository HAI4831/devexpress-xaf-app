using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl;
using Shop.Module.BusinessObjects;
using System;

namespace Shop.Module.Controllers
{
    public abstract class InPhieuXuat : ViewController
    {
        public InPhieuXuat()
        {
            TargetObjectType = typeof(PhieuXuat);
            SimpleAction inphieuxuat = new SimpleAction(this, "inphieuxuat", "View")
            {
                Caption = "In phiếu",
                ImageName = "printer",
                ToolTip = "In phiếu xuất",
                ConfirmationMessage = "Có chắc chắn in không?"
            };
            inphieuxuat.Execute += Inphieuxuat_Execute;
        }

        private void Inphieuxuat_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject is PhieuXuat p)
            {
                string ChungtuOid = p.Oid.ToString();
                if (!string.IsNullOrEmpty(ChungtuOid))
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
                    IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(
                        new BinaryOperator("DisplayName", "pxuat"));
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
