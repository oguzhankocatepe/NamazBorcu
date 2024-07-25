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
                        <asp:CheckBox ID="SABAHSUNNET" Text="Sünnet" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="OGLESUNNET" Text="Sünnet" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="IKINDISUNNET" Text="Sünnet" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox4" Text="Sünnet" runat="server" /> -->
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="YATSISUNNET" Text="Sünnet" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label ID="SünnetToplam" runat="server" Text="0"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="SABAHFARZ" Text="Farz" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="OGLEFARZ" Text="Farz" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="IKINDIFARZ" Text="Farz" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="AKSAMFARZ" Text="Farz" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="YATSIFARZ" Text="Farz" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
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
                        <asp:CheckBox ID="OGLESONSUNNET" Text="SonSünnet" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <!-- <asp:CheckBox ID="CheckBox13" Text="SonSünnet" runat="server" />-->
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="AKSAMSONSUNNET" Text="SonSünnet" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="YATSISONSUNNET" Text="SonSünnet" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
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
                        <asp:CheckBox ID="VITR" Text="Vitr" OnCheckedChanged="Namaz_CheckedChanged" EnableViewState="true" AutoPostBack="true" runat="server" />
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
