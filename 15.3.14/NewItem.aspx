<%@ Page Title="New Item" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewItem.aspx.cs" Inherits="NewItemV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    makat: <input name="makat"/><br />
    name: <input name="name"/><br />
    quantity: <input name="quantity"/><br />
    price: <input name="price"/>₪<br />
    picture name: <input name="picturename"/>*
    <input type="submit" name="sub" /><br />
    <p style="color:Red">*be sure the picture exists in the picture folder and write its full name including .type.</p>
    <asp:Label id="usedMakat" ForeColor="Red" runat="server"></asp:Label>
</asp:Content>

