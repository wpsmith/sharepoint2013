<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdatePanelWpUserControl.ascx.cs" Inherits="TestProjesi.Webparts.UpdatePanelWp.UpdatePanelWpUserControl" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    
    <ContentTemplate >
       <%-- Eger tetikleyen bir kontrol update panel içerisinde ise tetikleyiciye ihtiyac yok--%>
        <asp:Label ID="LblUpdatePanel" runat="server" Text="Saat"></asp:Label>
        <asp:Button ID="BtnUpdatePanel" runat="server" Text="Saat Guncelle" />
        
    </ContentTemplate>

</asp:UpdatePanel>

<asp:Label ID="lblSaat" runat="server" Text="Saat"></asp:Label>

<hr />


<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

    <ContentTemplate>
        <asp:Label ID="lblUpdatePanel2" runat="server" Text="Saat"></asp:Label>
 
    </ContentTemplate>
    <Triggers >
        <asp:AsyncPostBackTrigger ControlID="btmGuncelle" EventName="Click" />                
    </Triggers>
</asp:UpdatePanel>

<asp:Button ID="btmGuncelle" runat="server" Text="saati update panelde guncelle" />

<asp:UpdatePanel ID="GetApplicationPage" ChildrenAsTriggers="false" >

    <ContentTemplate>
        
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="" EventName="Click" />
    </Triggers>

</asp:UpdatePanel>
