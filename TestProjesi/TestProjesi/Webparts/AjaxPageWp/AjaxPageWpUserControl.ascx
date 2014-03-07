﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AjaxPageWpUserControl.ascx.cs" Inherits="TestProjesi.Webparts.AjaxPageWp.AjaxPageWpUserControl" %>
<script src="../../../../AssetModule/jquery-1.11.0.js" type="text/javascript"></script>

<script type="text/javascript">
    $.ajax({
        url: '/_layouts/15/TestProjesi/PageAjaxTmp.aspx',
        type: 'GET',
        success: function (result) {
            var content = $(result).find('#Panel1').html();
            $('#Panel2').html(content)
            result.type()
        },
        error: function () {
            alert("bir sorun olustu");
        }
    });

</script>
<asp:Panel ID="Panel2" runat="server" ClientIDMode="Static"></asp:Panel>
