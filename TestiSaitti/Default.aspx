<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <h1>Syksyn 2013 läsnäolot</h1>
    <asp:Button ID="btnGetIlmos" Text="Hae kaikki ilmot" runat="server" OnClick="btnGetIlmos_Click"/>
    <asp:TextBox ID="txtAsioid" runat="server"></asp:TextBox>
    <asp:DropDownList ID="ddlStudents" runat="server"></asp:DropDownList>
    <asp:Button ID="btnGetSelectedIlmos" Text="Hae annetut ilmot" runat="server" OnClick="btnGetSelectedIlmos_Click"/>
    <asp:Button ID="btnGetIlmosGrouped" Text="Hae kaikkien opiskelijoiden ilmot ryhmiteltynä" runat="server" OnClick="btnGetIlmosGrouped_Click"/>
    <asp:Label ID="lblMessages" Text="..." runat="server"></asp:Label>
    <div id="tulos" runat="server"></div>
    <asp:GridView ID="gvData" runat="server"></asp:GridView>

</asp:Content>

