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
                    SPList list = web.Lists.TryGetList("Category");
                    if (list != null)
                    {
                        SPQuery qry = new SPQuery();
                        qry.ViewFields = @"<FieldRef Name='Title' /><FieldRef Name='CategoryDescription' /><FieldRef Name='ID' />";
                        SPListItemCollection listItems = list.GetItems(qry);
                        lvCategory.DataSource = listItems.GetDataTable();
                        lvCategory.DataBind();
                    } 
                }
            }

        }
    }
}
