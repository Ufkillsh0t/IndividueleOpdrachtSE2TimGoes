<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 115px;
        }

        .auto-style3 {
            width: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Inlog" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:HyperLink ID="hlkRegister" runat="server" NavigateUrl="~/Register.aspx">Registreren</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Gebruikersnaam</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbInlogGebruikersnaam" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbInlogGebruikersnaam" ErrorMessage="U moet een gebruikersnaam invullen!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Wachtwoord</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbInlogWachtwoord" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbInlogWachtwoord" ErrorMessage="Een wachtwoord moet ingevuld worden!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btLogin" runat="server" OnClick="btLogin_Click" Text="Login" />
                </td>
                <td>
                    <asp:Label ID="lblLoginInfo" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
