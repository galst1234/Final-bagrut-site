<%@ Page Title="Update User Info" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserUpdateInf.aspx.cs" Inherits="UserUpdateInfV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function check() {
        var flag = true;
        var fname = document.getElementById("fname").value;
        if (fname != "") {
            //alert("fnames working");
            document.getElementById('invname').innerHTML = '';
        }
        else {
            document.getElementById('invname').innerHTML = '*please enter first name';
            flag = false;
        }
        var lname = document.getElementById("lname").value;
        if (lname != "") {
            document.getElementById('invlname').innerHTML = '';
            //alert("lnames working");
        }
        else {
            document.getElementById('invlname').innerHTML = '*please enter last name';
            flag = false;
        }
        var Id = document.getElementById("id").value;
        if (Id.length == 9 && !isNaN(Id)) {
            //alert("ID is fine");
            document.getElementById('invid').innerHTML = '';
        }
        else {
            document.getElementById('invid').innerHTML = '*invalid id';
            flag = false;
        }
        var phone = document.getElementById("phnum").value;
        if (phone != "" && phone.indexOf("-") != -1 && (phone.length == 10 || phone.length == 11)) {
            //alert("phones ok");
            document.getElementById('invphone').innerHTML = '';
        }
        else {
            document.getElementById('invphone').innerHTML = '*please enter a valid phone number with a -';
            flag = false;
        }
        var mail = document.getElementById("email").value;
        if (mail.length > 4 && mail.indexOf("@") < mail.lastIndexOf(".") && mail.lastIndexOf(".") - mail.indexOf("@") > 1 && mail.split('@').length == 2) {
            //alert("mail is ok");
            document.getElementById('invmail').innerHTML = '';
        }
        else {
            document.getElementById('invmail').innerHTML = '*invalid email adress';
            flag = false;
        }
        var pass = document.getElementById("password").value;
        var passconf = document.getElementById("passconf").value;
        if (pass.length > 5) {
            //alert("pass is working");
            document.getElementById('invpass').innerHTML = '';
        }
        else {
            document.getElementById('invpass').innerHTML = '*please enter a password with 6 or more characters';
            flag = false;
        }
        if (pass == passconf) {
            //alert("passs matching");
            document.getElementById('invmatch').innerHTML = '';
        }
        else {
            document.getElementById('invmatch').innerHTML = '*passwords dont match';
            flag = false;
        }
        var username = document.getElementById("username").value;
        if (username == "") {
            document.getElementById('invuser').innerHTML = '*please enter a username';
            flag = false;
        }
        else {
            document.getElementById('invuser').innerHTML = '';
        }
        if (flag == true) {
            //alert("אחד או יותר מהשדות מולאו לא כראוי, שים/י לב כי יש להזין שם מלא, מספר טלפון כולל מקף, כתובת דואר אלקטרוני, כתובת הכוללת רחוב מספר בית ועיר וסיסמא בעלת שישה תווים או יותר. רק הסעיפים שמסומנים בכוכבית הם סעיפי חובה.");
            document.getElementById("sub").disabled = false;
        }
    }
    function disable() {
        document.getElementById("sub").disabled = true;
    }
  </script>
    id: <input value="<%=id %>" name="id" id="id" onblur="javascript:disable()"/><label class="inv" id="invid"></label><br />
    fname: <input value="<%=fname %>" name="fname" id="fname" onblur="javascript:disable()"/><label class="inv" id="invname"></label><br />
    lname: <input value="<%=lname %>" name="lname" id="lname" onblur="javascript:disable()"/><label class="inv" id="invlname"></label><br />
    email: <input value="<%=email %>" name="email" id="email" onblur="javascript:disable()"/><label class="inv" id="invmail"></label><br />
    phone number: <input value="<%=phnum %>" name="phnum" id="phnum" onblur="javascript:disable()"/><label class="inv" id="invphone"></label><br />
    username: <input value="<%=username %>" name="username" id="username" onblur="javascript:disable()"/><label class="inv" id="invuser"></label><br />
    password: <input value="<%=password %>" name="password" id="password" onblur="javascript:disable()"/><label class="inv" id="invpass"></label><br />
    password confirmation: <input name="passconf"  id="passconf" onblur="javascript:disable()"/><label class="inv" id="invmatch"></label><br />
    <asp:Label id="userinfolable" runat="server"></asp:Label><br />
    <asp:Label ID="used" ForeColor="Red" runat="server"></asp:Label><br />
    <input type="button" onclick="javascript:check()" value="Check fields"/> <input type="submit" name="sub" disabled="disabled" id="sub"/> <input type="reset" value="Reset" onclick="javascript:disable()"/><br />
    <asp:Label id="notlogedin" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>

