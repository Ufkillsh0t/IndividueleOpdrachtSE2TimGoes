<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zoek.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ProductZoekResultaten" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <h2>Gevonden producten</h2>
        <div id="divGevondenProducten" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
            <asp:ListView ID="lvwProducten" runat="server">
                <LayoutTemplate>
                    <table>
                        <tr runat="server">
                            <th>Naam</th>
                            <th>Merk</th>
                            <th>TestDatum</th>
                            <th>ID</th>
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
                            <asp:Label ID="lblProductNaam" runat="server" Text='<%#Eval("Naam") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblProductMerk" runat="server" Text='<%#Eval("Merk") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblProductTestDatum" runat="server" Text='<%#Eval("TestDatum") %>' />
                        </td>
                        <td>
                            <asp:HyperLink ID="hlProductID" runat="server" NavigateUrl='<%# "product.aspx?id="+ Eval("ID") %>' Text='<%#Eval("ID") %>'>HyperLink</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <br />

    <div id="ShopZoekResultaten" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <h2>Gevonden shops</h2>
        <div id="divGevondenShops" runat="server" style="width: 1200px; margin-left: auto; margin-right: auto;">
            <asp:ListView ID="lvwShops" runat="server">
                <LayoutTemplate>
                    <table>
                        <tr runat="server">
                            <th>Bedrijfsnaam</th>
                            <th>Website</th>
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
                            <asp:Label ID="lblProductMerk" runat="server" Text='<%#Eval("Naam") %>' />
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkWebsite" runat="server" NavigateUrl='<%# Eval("Website") %>' Text='<%#Eval("Website") %>'>HyperLink</asp:HyperLink>
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
    </div>
</asp:Content>
