<%@ Page Title="Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowPage.aspx.cs" Inherits="N01371157_FinalAssignment.sln.ShowPage" %>

<asp:Content ID="page_view" ContentPlaceHolderID="body" runat="server">

    <h1>Details <span id="title" runat="server"></span></h1>
    
    <div id="page_details" runat="server">
        <div class="back_to_list">
             <!-- ASP BUTTON REDIRECT -->
             <!-- SRC: https://stackoverflow.com/questions/23976683/asp-net-button-to-redirect-to-another-page -->
            <asp:Button runat="server" class="button" Text="Back to List Pages" PostBackUrl="~/ListPages.aspx" />
        </div>
        Page Title: <span id="page_title" runat="server"></span><br />
        Body Content: <span id="body_content" runat="server"></span><br />
        Published: <span id="page_published" runat="server"></span><br />
        Date Created: <span id="date_created" runat="server"></span><br />

        <div class="button_div">
            <asp:Button class="button edit_button" ID="edit_button" runat="server" Text="Edit Page" />
            <!-- SRC: CRUD Essentials - Christine Bittle-->
            <!-- asp:Button onclick event -->
            <asp:Button OnClientClick="if(!confirm('Are you sure you want to delete this page entry?')) return false;" class="button delete_button" OnClick="Delete_Page" Text="Delete Page" runat="server" />
        </div>

    </div>



</asp:Content>
        
