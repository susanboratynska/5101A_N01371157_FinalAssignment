<%@ Page Title="Edit Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditPage.aspx.cs" Inherits="N01371157_FinalAssignment.sln.EditPage" %>

<asp:Content ID="page_edit" ContentPlaceHolderID="body" runat="server">

    <h1>Edit Page</h1>
    <div id="edit_page" runat="server">
         <div class="back_to_list">
             <!-- ASP BUTTON REDIRECT -->
             <!-- SRC: https://stackoverflow.com/questions/23976683/asp-net-button-to-redirect-to-another-page -->
            <asp:Button runat="server" class="button" Text="Back to List Pages" PostBackUrl="~/ListPages.aspx" />
        </div>
        <div class="form_row">
            <label class="textbox_label">Page Title:</label>
            <asp:TextBox runat="server" class="text_title" ID="page_title"></asp:TextBox>
        </div>
        <div class="form_row">
            <label class="textbox_label">Body Content:</label>
            <asp:TextBox runat="server" class="text_body" ID="page_body" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form_row">
            <label>Publish Page:</label> 
            <asp:CheckBox runat="server" ID="page_publish" />
        </div>
        <div class="button_div">
            <!-- SRC: CRUD Essentials - Christine Bittle-->
            <!-- asp:Button onclick event -->
            <asp:Button OnClientClick="if(!confirm('Are you sure you want to update this page entry?')) return false;" class="button" OnClick="Update_Page" Text="Update Page" runat="server" />
        </div>
    </div>

</asp:Content>

