<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th {
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            background-color: #99CDF2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ShopTab" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <asp:HyperLink ID="hlkShopTab" runat="server" NavigateUrl="ShopTab.aspx">ShopTab</asp:HyperLink>
    </div>

    <div id="ShopInformatie" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
    </div>

    <div id="AfhaalpuntInformatie" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
    </div>
</asp:Content>
