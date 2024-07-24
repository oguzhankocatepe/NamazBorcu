<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="NamazBorcu.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <asp:Panel ID="NamazPanel" runat="server">
            <asp:Table ID="NamazTable" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Sabah</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Öğle</asp:TableHeaderCell>
                    <asp:TableHeaderCell>İkindi</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Akşam</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Yatsı</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Toplam</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="SabahSünnet" Text="Sünnet" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ÖğleSünnet" Text="Sünnet" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="İkindiSünnet" Text="Sünnet" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox4" Text="Sünnet" runat="server" /> -->
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="YatsıSünnet" Text="Sünnet" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="SünnetToplam" runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="SabahFarz" Text="Farz" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ÖğleFarz" Text="Farz" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="İkindiFarz" Text="Farz" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="AkşamFarz" Text="Farz" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="YatsıFarz" Text="Farz" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="FarzToplam" runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox11" Text="SonSünnet" runat="server" /> -->
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ÖğleSonSünnet" Text="SonSünnet" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox13" Text="SonSünnet" runat="server" />-->
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="AkşamSonSünnet" Text="SonSünnet" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="YatsıSonSünnet" Text="SonSünnet" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="SonSünnetToplam" runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox16" Text="SonSünnet" runat="server" />-->
                    </asp:TableCell>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox17" Text="SonSünnet" runat="server" />-->
                    </asp:TableCell>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox18" Text="SonSünnet" runat="server" />-->
                    </asp:TableCell>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox19" Text="SonSünnet" runat="server" />-->
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="Vitr" Text="Vitr" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="VitrToplam"  runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                     <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="SabahToplam"  runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="ÖğleToplam"  runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="İkindiToplam"  runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="AkşamToplam"  runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="YatsıToplam"  runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="GenelToplam"  runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
    </asp:Panel>
    </main>
</asp:Content>
