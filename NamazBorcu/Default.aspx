<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NamazBorcu._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Calendar ID="ThisMonth" runat="server" OnDayRender="ThisMonth_DayRender" OnSelectionChanged="ThisMonth_SelectionChanged"></asp:Calendar>
    </main>

</asp:Content>
