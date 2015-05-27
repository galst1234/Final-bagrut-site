<%@ Page Title="Store" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function check() {
        var quantity = document.getElementById("quantity").value;
        if (quantity == "") {
            flag = false;
        }
        else {
            document.getElementById('invuser').innerHTML = '';
        }
        if (flag == true) {
            /*alert("אחד או יותר מהשדות מולאו לא כראוי, שים/י לב כי יש להזין שם מלא, מספר טלפון כולל מקף, כתובת דואר אלקטרוני, כתובת הכוללת רחוב מספר בית ועיר וסיסמא בעלת שישה תווים או יותר. רק הסעיפים שמסומנים בכוכבית הם סעיפי חובה.");*/
            document.getElementById("sub").disabled = false;
        }
    }
</script>
<asp:DropDownList id="gametobuy" runat="server"></asp:DropDownList> <input name="gamequantity" id="quantity" value="Quantity"/> <button name="addtocart" onclick="javascript:check()">Add to cart</button><br />
<asp:Label id="purchaseerror" runat="server" ForeColor="Red"></asp:Label>
<br /><asp:Label id="pagebody" runat="server"></asp:Label>
</asp:Content>

