using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace TestProjesi.Classes
{
    static class Extensions
    {
        
        /// <summary>
        /// if this list is on the current web return false else return true
        /// </summary>
        /// <param name="spWeb"></param>
        /// <param name="listName"></param>
        /// <returns></returns>
        public static bool IsThereAList(this SPWeb spWeb, string listName)
        {
            SPList list = spWeb.Lists.TryGetList(listName);
            return list == null ? true : false;
        }
        /// <summary>
        /// Return field Static Name 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="staticFieldName"></param>
        /// <returns></returns>
        public static string TryGetListFieldInternalName(this SPList list, string staticFieldName)
        {
            return list.Fields.TryGetFieldByStaticName(staticFieldName).InternalName;
        }
        /// <summary>
        /// Change the Title Display Name 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="TitleName"></param>
        public static void ChangeTitleDisplayName(this SPList list, string TitleName) 
        {
            if (list!=null)
            {
                SPField titlefield = list.Fields["Title"];
                titlefield.Title = TitleName;
                titlefield.PushChangesToLists = true;
                titlefield.Update(true);
            }
            
        }

        public static void CreateDocumentFolder(this SPWeb spWeb,string folderName)
        {
            
            
        }

    }
}

