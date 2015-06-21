<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #ProductTabs a {
            float: left;
            border: 1px groove #050709;
            border-radius: 3px;
        }

        th {
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            background-color: #99CDF2;
        }

        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ProductTabs" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
    </div>

    <div id="ProductInformatie" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
    </div>

    <div id="Tabs" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <div id="btnPlacement" style="float: left;">
            <asp:Button ID="btnSpecificaties" runat="server" Text="Specificaties" OnClick="btnSpecificaties_Click" />
        </div>
        <div id="btnPlacement2" style="float: left; margin-left:10px;">
            <asp:Button ID="btnPrijzen" runat="server" Text="Button" OnClick="btnPrijzen_Click" />
        </div>
    </div>
    <br />

    <div id="ProductSpecificaties" runat="server" style="width: 1200px; margin-top:50px; margin-left: auto; margin-right: auto;overflow:auto;" >
    </div>
</asp:Content>
