using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


namespace TestProjesi.Classes
{
    class SaveLogs
    {
        public static void newLogItem(Exception ex, string LogLocation)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory(LogLocation, TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, ex.Message, ex.StackTrace);
            });
        }
    }
}
