<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignInV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Username: <input name="username" /><br />
    Password: <input name="password" /><br />
    <input type="submit" name="sub" />
    <asp:label id="badlogin" runat="server" ForeColor="Red"></asp:label>
</asp:Content>

