<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>The default (out-of-the-box) implementation of a WCF service client is untestable.</p>
    <p>However, it is possible to create wrappers for svcutil-generated WCF service clients that are much more test-friendly...</p>
</asp:Content>
