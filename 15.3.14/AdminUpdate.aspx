<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminUpdate.aspx.cs" Inherits="AdminUpdateV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    User change: the id you want to change:<input name="ID" />
    <input type="submit" name="sub" value="Update User"/>
    <button name="delete">Delete User</button><br />
    Item change: the makat you want to change:<input name="makat" />
    <button name="newitem">New item</button>
    <button name="updateitem">Update item</button>
    <button name="deleteitem">Delete Item</button><br /><br />
    <asp:Label id="pagebody" runat="server"></asp:Label>
</asp:Content>

