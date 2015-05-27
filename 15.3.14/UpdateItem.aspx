<%@ Page Title="Item Update" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateItem.aspx.cs" Inherits="UpdateItemV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    makat: <input value="<%=makat %>" name="makat"/><br />
    name: <input value="<%=name %>" name="name"/><br />
    quantity: <input value="<%=quantity %>" name="quantity"/><br />
    price: <input value="<%=price %>" name="price"/>₪<br />
    picture name: <input value="<%=picturename %>" name="picturename"/>*<br />
    <input type="submit" name="sub" />
    <p style="color:Red">*be sure the picture exists in the picture folder and write its full name includint .type.</p>
</asp:Content>

