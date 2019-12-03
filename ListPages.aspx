<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ListPages.aspx.cs" Inherits="N01371157_FinalAssignment.sln.ListPages" %>


<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">

    <h1>List Pages</h1>    
    <div id="add_new_page">
         <!-- ASP BUTTON REDIRECT -->
         <!-- SRC: https://stackoverflow.com/questions/23976683/asp-net-button-to-redirect-to-another-page -->
        <asp:Button runat="server" class="button" Text="Add New Page" PostBackUrl="~/AddPage.aspx" />
    </div>
    <div id="search_div">
        <asp:Label for="page_search" runat="server">Filter:</asp:Label>
        <asp:TextBox ID="page_search" runat="server"></asp:TextBox>
        <asp:Button class="button" runat="server" Text="Search" />
        <div id="sql_debugger" runat="server"></div>
    </div>
      <%-- SRC: https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.table?view=netframework-4.7 --%>
    


    <asp:Table id="list_pages_table" runat="server" CellPadding="15" GridLines="Horizontal" HorizontalAlign="Center" Width="80%">
        <asp:TableRow>
            <asp:TableHeaderCell>Page Title</asp:TableHeaderCell>
            <asp:TableHeaderCell>Page Content</asp:TableHeaderCell>
            <asp:TableHeaderCell>Published</asp:TableHeaderCell>
            <asp:TableHeaderCell>Date Created</asp:TableHeaderCell>
        </asp:TableRow>
    </asp:Table>

    <div id="pages_result" runat="server">

    </div>


</asp:Content>

