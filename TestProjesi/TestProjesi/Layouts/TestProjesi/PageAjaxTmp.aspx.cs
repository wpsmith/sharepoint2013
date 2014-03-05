using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace TestProjesi.Layouts.TestProjesi
{
    public partial class PageAjaxTmp : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SPSite site= new SPSite(SPContext.Current.Site.ID))
            {
                using (SPWeb web= site.OpenWeb())
                {

                }
            }

        }
    }
}
