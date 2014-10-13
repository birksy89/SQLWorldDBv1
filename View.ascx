<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.SQLWorldDBv1.View" %>

<asp:Repeater ID="Repeater1" runat="server">

</asp:Repeater>
<hr />

<asp:Button ID="btnName" runat="server" Text="Name" OnClick="btnName_Click" />
<asp:Button ID="btnArea" runat="server" Text="Surface Area" OnClick="btnArea_Click" />

<hr />

<asp:Literal ID="Literal1" runat="server"></asp:Literal>

<div id="RazorDiv1" runat="server"></div>