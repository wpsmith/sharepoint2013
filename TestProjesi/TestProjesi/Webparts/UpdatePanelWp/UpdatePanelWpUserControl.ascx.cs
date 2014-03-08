using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace TestProjesi.Webparts.UpdatePanelWp
{
    public partial class UpdatePanelWpUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblUpdatePanel.Text = DateTime.Now.ToString();
            lblSaat.Text = DateTime.Now.ToString();
            lblUpdatePanel2.Text = DateTime.Now.ToString();
        }
        
    }
}
