<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #ProductTabs a {
            float: left;
            border: 1px groove #050709;
            border-radius: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ProductTabs" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">

    </div>

    <div id="ProductInformatie" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
    </div>

    <div id="ProductSpecificaties" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
    </div>
</asp:Content>
