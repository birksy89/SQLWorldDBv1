<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.SQLWorldDBv1.View" %>

<asp:Repeater ID="Repeater1" runat="server">

</asp:Repeater>
<hr />

<asp:Literal ID="Literal1" runat="server"></asp:Literal>

<div id="RazorDiv1" runat="server"></div>
<asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>Name</asp:ListItem>
    <asp:ListItem Value="SurfaceArea">Surface Area</asp:ListItem>
</asp:DropDownList>