<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ilmoittaudu.aspx.cs" Inherits="Ilmoittaudu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <h1>Ilmoittaudu läsnäolevaksi</h1>
    <p>Etunimi
    <asp:TextBox ID="txtEtunimi" runat="server"></asp:TextBox></p>
    <p>Sukunimi
    <asp:TextBox ID="txtSukunimi" runat="server"></asp:TextBox></p>
    <p>AsioID
    <asp:TextBox ID="txtAsioid" runat="server"></asp:TextBox></p>
    <asp:Button ID="btnIlmoittaudu" runat="server" Text="Ilmoittaudu" OnClick="btnIlmoittaudu_Click" />

</asp:Content>

