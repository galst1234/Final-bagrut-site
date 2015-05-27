<%@ Page Title="Your Cart" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function check() {
        var flag = true;
        var fname = document.getElementById("fname").value;
        if (fname == "") {
            alert("enter first names");
            flag = false;
        }
        var lname = document.getElementById("lname").value;
        if (lname == "") {
            alert("enter last names");
            flag = false;
        }
        var phone = document.getElementById("phnum").value;
        if (phone == "" || phone.indexOf("-") == -1 || (phone.length != 10 && phone.length != 11)) {
            alert("enter a correct phone number");
            flag = false;
        }
        var ad = document.getElementById("ad").value;
        if (ad.length < 4 || ad.split(" ").length < 2) {
            alert("enter full address");
            flag = false;
        }
        var card = document.getElementById("card").value;
        if (card.length != 16 || isNaN(card)) {
            alert("enter valid credit carn number");
            flag = false;
        }
        if (flag == true) {
            /*alert("אחד או יותר מהשדות מולאו לא כראוי, שים/י לב כי יש להזין שם מלא, מספר טלפון כולל מקף, כתובת דואר אלקטרוני, כתובת הכוללת רחוב מספר בית ועיר וסיסמא בעלת שישה תווים או יותר. רק הסעיפים שמסומנים בכוכבית הם סעיפי חובה.");*/
            document.getElementById("sub").disabled = false;
        }
    }
    function disable() {
        document.getElementById("sub").disabled = true;
    }
  </script>
    <asp:Label id="showcart" runat="server"></asp:Label> To clear your cart <button name="clear">click here</button><br />
    First name: <input id="fname" name="fname" value="<%=fname %>" onblur="javascript:disable()"/><br />
    Last name: <input id="lname" name="lname" value="<%=lname %>" onblur="javascript:disable()"/><br />
    Address: <input id="ad" name="address" value="address" onblur="javascript:disable()"/><br />
    Phone number: <input id="phnum" name="phonenum" value="<%=phone %>" onblur="javascript:disable()"/><br />
    Credic card number: <input id="card" name="card number" value="card number" onblur="javascript:disable()"/><br />
    <input type="button" onclick="javascript:check()" value="Check fields"/> <input name="sub" id="sub" type="submit" disabled="disabled" /><br />
</asp:Content>

