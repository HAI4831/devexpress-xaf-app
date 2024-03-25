using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Shop.Module.BusinessObjects;

public class DoanhthuController : ViewController
{
    ParametrizedAction actionTungay;
    ParametrizedAction actionDenngay;

    public DoanhthuController()
    {
        TargetViewId = "DoanhthuRpt_ListView";

        actionTungay = new ParametrizedAction(this, "actionTungay", "View", typeof(DateTime))
        {
            Caption = "Từ ngày",
            TargetViewId = "DoanhthuRpt_ListView"
        };
        actionTungay.Execute += ActionTungay_Execute;

        actionDenngay = new ParametrizedAction(this, "actionDenngay", "View", typeof(DateTime))
        {
            Caption = "Đến ngày",
            TargetViewId = "DoanhthuRpt_ListView"
        };
        actionDenngay.Execute += ActionDenngay_Execute;
    }

    protected override void OnActivated()
    {
        base.OnActivated();
        actionTungay.Value = Chung.Tungay;
        actionDenngay.Value = Chung.Denngay;
    }

    private void ActionDenngay_Execute(object sender, ParametrizedActionExecuteEventArgs e)
    {
        if (e.ParameterCurrentValue != null)
        {
            Chung.Denngay = (DateTime)e.ParameterCurrentValue;
        }
    }

    private void ActionTungay_Execute(object sender, ParametrizedActionExecuteEventArgs e)
    {
        if (e.ParameterCurrentValue != null)
        {
            Chung.Tungay = (DateTime)e.ParameterCurrentValue;
        }
    }
}

