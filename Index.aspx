<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Welkom" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <asp:Label ID="lblWelkom" runat="server" Text="Welkom op mijn website!" Visible="False"></asp:Label>
        <asp:Label ID="lblIndexGebruikersnaam" runat="server" Visible="False"></asp:Label>
    </div>
</asp:Content>
