<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MultiplexEx.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Compra il biglietto:</h1>
    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
    <asp:TextBox ID="TxtSurname" runat="server"></asp:TextBox>

    <asp:DropDownList ID="ReservationRoom" runat="server">
        <asp:ListItem runat="server">SALA NORD</asp:ListItem>
        <asp:ListItem runat="server">SALA EST</asp:ListItem>
        <asp:ListItem runat="server">SALA SUD</asp:ListItem>    
    </asp:DropDownList>

    <asp:DropDownList ID="TicketType" runat="server">
        <asp:ListItem runat="server">INTERO</asp:ListItem>
        <asp:ListItem runat="server">RIDOTTO</asp:ListItem>
    </asp:DropDownList>

    <asp:Button ID="Button1" runat="server" Text="Prenota" OnClick="Btn_Click"/>

    <asp:Label ID="LabelNord" runat="server" Text=""></asp:Label>
    <asp:Label ID="LabelEst" runat="server" Text=""></asp:Label>
    <asp:Label ID="LabelSud" runat="server" Text=""></asp:Label>

</asp:Content>
