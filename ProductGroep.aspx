<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductGroep.aspx.cs" Inherits="IndividueleOpdrachtSE2.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="productTab" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <asp:HyperLink ID="hlkProductTab" runat="server" NavigateUrl="~/ProductTab.aspx">ProductTab</asp:HyperLink>
    </div>

    <div id="ProductGroepNaam" style="width: 1200px; margin-left: auto; margin-right: auto;">
        <asp:Label ID="lblProductGroepNaam" runat="server" Text=""></asp:Label>
        <asp:ListView ID="lvwProducten" runat="server">
            <LayoutTemplate>
                <table>
                    <tr runat="server">
                        <th>ID</th>
                        <th>Merk</th>
                        <th>Naam</th>
                        <th>TestDatum</th>
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
                        <asp:HyperLink ID="hlProductID" runat="server" NavigateUrl='<%# "product.aspx?id="+ Eval("ID") %>' Text='<%#Eval("ID") %>'>HyperLink</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="lblProductMerk" runat="server" Text='<%#Eval("Merk") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblProductNaam" runat="server" Text='<%#Eval("Naam") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblProductTestDatum" runat="server" Text='<%#Eval("TestDatum") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
