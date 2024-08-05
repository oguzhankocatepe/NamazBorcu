<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Culture="tr-TR" UICulture="tr-TR" CodeBehind="Default.aspx.cs" Inherits="NamazBorcu._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Panel style="display: inline-block;" ID="CalendarPanel" runat="server" Direction="LeftToRight" HorizontalAlign="Center" ScrollBars="Auto" Wrap="True" Width="100%" Height="100%"></asp:Panel>
        <asp:Panel ID="addPanel" HorizontalAlign="Center" runat="server">
            <asp:Label ID="addLabel" runat="server" Text="Nafile Namaz Gir:  "></asp:Label>
            <asp:TextBox ID="addTextBox" runat="server"></asp:TextBox> 
            <asp:Button ID="addButton" runat="server" Text="Ekle" BackColor="#0099FF" OnClick="AddFarzNamaz" />
        </asp:Panel>
    </main>
</asp:Content>