using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using Shop.Module.Controllers;
using static System.Net.Mime.MediaTypeNames;
namespace Shop.Blazor.Server.Controllers
{
    public class BlazorInCT_px : InPhieuXuat
    {
        protected override void PrintReport(IReportDataV2 reportData, Guid phieubid)
        {
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null)
            {
                reportsModule.ReportsDataSourceHelper.BeforeShowPreview += (s, args) =>
                {
                    args.Report.Parameters["Maphieu"].Value = phieubid;
                };
                string handle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData);
                ReportServiceController controller = Frame.GetController<ReportServiceController>();
                controller?.ShowPreview(handle);
            }
        }

    }
}
