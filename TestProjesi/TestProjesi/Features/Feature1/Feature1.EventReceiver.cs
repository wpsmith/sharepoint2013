using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using TestProjesi.Classes;

namespace TestProjesi.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("b92f8e19-93cc-420d-ab8e-c7a2f60ac7b8")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            try
            {
                using (SPSite site = (properties.Feature.Parent as SPSite))
                {
                    using (SPWeb web = site.OpenWeb())
                    {

                        if (web.IsThereAList("Category"))
                        {
                            SPList list = web.Lists.TryGetList("Category");
                            web.Lists.Add("Category", "keep the Idea Category", SPListTemplateType.GenericList);

                            if (web.IsThereAList("Category")) { return; }

                            SPList createdList = web.Lists.TryGetList("Category");

                            createdList.ChangeTitleDisplayName("CategoryName");
                            //createdList.Fields.Add("CategoryName", SPFieldType.Text, true);
                            createdList.Fields.Add("CategoryDescription", SPFieldType.Note, false);
                            createdList.Update();

                            SPView currentView = createdList.DefaultView;
                            currentView.ViewFields.DeleteAll();
                            currentView.ViewFields.Add(createdList.TryGetListFieldInternalName("Title"));
                            currentView.ViewFields.Add(createdList.TryGetListFieldInternalName("CategoryDescription"));
                            currentView.Update();
                            createdList.Update();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SaveLogs.newLogItem(ex, "Sharepoint.Deneme EventReceive FeatureActivated");
            }
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            try
            {
                using (SPSite site = (properties.Feature.Parent as SPSite))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        if (!web.IsThereAList("Category"))
                        {
                            SPList list = web.Lists.TryGetList("Category");
                            list.Delete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SaveLogs.newLogItem(ex, "Sharepoint.Deneme EventReceive FeatureDeactivating");
            }
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
