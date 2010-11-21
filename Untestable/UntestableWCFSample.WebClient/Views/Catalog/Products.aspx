<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UntestableWCFSample.WebClient.ViewModels.ProductsForCategoryViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.CategoryName) %></h2>

    <% foreach (var product in Model.Products) { %>
    
        <li>
            <%= Html.Encode(product) %>
        </li>
        
    <% } %>

    </table>
    
    <p>This data brought to you by WCF Services</p>

</asp:Content>

