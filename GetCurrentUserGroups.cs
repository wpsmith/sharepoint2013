using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace TuprasUserGroup
{
    public static class GetCurrentUserGroups
    {
        public static Object[] GetCurrentUserGroupsName(this SPWeb web)
        {
            SPGroupCollection groupCollection = web.CurrentUser.Groups;
            object[] groupsName = new object[groupCollection.Count];
            for (int i = 0; i < groupCollection.Count; i++)
            {
                groupsName[i] = groupCollection[i].LoginName;
            }
            return groupsName;
        }

        public static SPGroupCollection UserToAllGroups(this SPWeb web, string userName)
        {
            SPUser spUser = web.EnsureUser(userName);
            SPGroupCollection spGroupCollection = spUser.Groups;
            return spGroupCollection;
        }

        public static bool UserInGroup(this SPWeb web, string userName, string groupName)
        {
            SPGroupCollection spGroupCollection = UserToAllGroups(web, userName);
            return spGroupCollection.OfType<SPGroup>().Select(p => p.LoginName).Contains(groupName);
        }
    }
}
