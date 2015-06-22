<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShopTab.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divShopInformatie" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
    </div>

    <div id="divShops" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <asp:ListView ID="lvwShops" runat="server">
            <LayoutTemplate>
                <table>
                    <tr runat="server">
                        <th>Website</th>
                        <th>Bedrijfsnaam</th>
                        <th>Rating</th>
                        <th>ShopPagina</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
                <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="12">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                            FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                            NextPageText=" &gt; " PreviousPageText=" &lt; " />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td>
                        <asp:HyperLink ID="hlkWebsite" runat="server" NavigateUrl='<%# Eval("Website") %>' Text='<%#Eval("Website") %>'>HyperLink</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="lblProductMerk" runat="server" Text='<%#Eval("Naam") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblProductNaam" runat="server" Text='<%#Eval("Rating") %>' />
                    </td>
                    <td>
                        <asp:HyperLink ID="hlkShopNR" runat="server" NavigateUrl='<%# "shop.aspx?nr="+ Eval("ShopNR") %>' Text='<%#Eval("ShopNR") %>'>HyperLink</asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
