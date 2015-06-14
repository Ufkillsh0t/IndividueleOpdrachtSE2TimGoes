<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm3" %>
<%@ MasterType VirtualPath="~/Site.Master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        text-align: left;
        width: 135px;
    }
    .auto-style3 {
        width: 135px;
    }
    .auto-style4 {
        width: 220px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style2">User Name:</td>
        <td class="auto-style4">
            <asp:TextBox ID="tbUserName" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="tbUserName" ErrorMessage="User Name is required!" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Email:</td>
        <td class="auto-style4">
            <asp:TextBox ID="tbEmail" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="E-mail is required!" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="You must enter a valid Email address!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Password:</td>
        <td class="auto-style4">
            <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="A password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Confirm Password:</td>
        <td class="auto-style4">
            <asp:TextBox ID="tbConfirmPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="tbConfirmPassword" ErrorMessage="Confirm Password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" ErrorMessage="Both passwords must be the same!" ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style4">
            <asp:Button ID="btRegister" runat="server" style="text-align: center" Text="Register" OnClick="btRegister_Click" />
            <input id="ResetRegForm" type="reset" value="reset" /></td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
