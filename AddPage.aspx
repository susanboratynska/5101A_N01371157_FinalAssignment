<%@ Page Title="Add Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddPage.aspx.cs" Inherits="N01371157_FinalAssignment.sln.AddPage" %>

<asp:Content ID="page_add" ContentPlaceHolderID="body" runat="server">

    <h1>Add New Page</h1>
    <div class="form_row">
        <label class="button textbox_label">Page Title:</label>
        <asp:TextBox runat="server" Class="text_title" ID="page_title"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="page_title" ErrorMessage="Please enter a Page Title." runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="form_row">
        <label class="textbox_label">Body Content:</label>
        <asp:TextBox runat="server" class="text_body" ID="page_body" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="page_body" ErrorMessage="Please enter Body Content." runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
        <!-- SRC: https://www.codeproject.com/Questions/409042/asp-net-multiline-textbox -->
    </div>
    <div class="form_row">
        <label>Publish Page:</label>
        <asp:CheckBox runat="server" ID="page_publish" />
    </div>
    <div class="button_div">
        <asp:Button Text="Submit" OnClick="Add_Page" class="button" runat="server" CausesValidation="False" />
    </div>

</asp:Content>