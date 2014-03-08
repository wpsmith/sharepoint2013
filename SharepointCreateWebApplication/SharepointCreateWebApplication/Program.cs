using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Security;



namespace SharepointCreateWebApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SPFarm spFarm = SPFarm.Local;
            string webApplicationName = "IlkWebApplication";

            SPWebService spWebService = spFarm.Services.GetValue<SPWebService>("");

            if (!spWebService.WebApplications.Any(x => x.DisplayName == webApplicationName))
            {
                SPWebApplicationBuilder spWebapplicationBuilder = new SPWebApplicationBuilder(spFarm);
                SPWebApplication webApplication;
                spWebapplicationBuilder.AllowAnonymousAccess = true;

                spWebapplicationBuilder.ApplicationPoolId = "ILK WEB APPLICATION OLUSTURMA";

                spWebapplicationBuilder.ApplicationPoolPassword = StringToSecureString("Ceviz2012");
                spWebapplicationBuilder.ApplicationPoolUsername = "CEVIZ\\Administrator";

                spWebapplicationBuilder.DatabasePassword = "Ceviz2012";
                spWebapplicationBuilder.DatabaseUsername = "PortalSetupAdm";
                spWebapplicationBuilder.DatabaseServer = "SHAREPOINT15";
                spWebapplicationBuilder.DatabaseName = webApplicationName;
                spWebapplicationBuilder.CreateNewDatabase = true;

                spWebapplicationBuilder.HostHeader =webApplicationName;
                spWebapplicationBuilder.Port = 4545;
                spWebapplicationBuilder.RootDirectory.Create();
                spWebapplicationBuilder.UseNTLMExclusively = true;

                webApplication = spWebapplicationBuilder.Create();
                //webApplication.UseClaimsAuthentication = true;
                //webApplication.Update();
                webApplication.Provision();
            }

        }

        private static SecureString StringToSecureString(string password)
        {
            char[] pass = password.ToCharArray();
            SecureString ss = new SecureString();
            for (int i = 0; i < password.Count(); i++)
            {
                ss.AppendChar(pass[i]);
            }

            return ss;
        }
    }
}
