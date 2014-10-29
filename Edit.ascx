<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Christoc.Modules.SQLWorldDBv1.Edit" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    <div class="dnnFormExpandContent dnnRight "><a href=""><%=LocalizeString("ExpandAll")%></a></div>

    <h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead dnnClear">
        <a href="" class="dnnSectionExpanded">
            <%=LocalizeString("BasicSettings")%></a></h2>




    <div>





        <div>
            <h4>Simple Add/Insert, Edit/Update, Delete Gridview Data Example</h4>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <table style="float:left;">
                <tr>
                    <td>Subject Id:</td>
                    <td>
                        <asp:TextBox ID="txtSubjectId" runat="server" Enabled="false" />
                    </td>
                </tr>
                <tr>
                    <td>Subject Name:</td>
                    <td>
                        <asp:TextBox ID="txtSubjectName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" Text="*"
                            ControlToValidate="txtSubjectName" ForeColor="Red" ValidationGroup="vgAdd" />
                    </td>
                </tr>
                <tr>
                    <td>Marks:</td>
                    <td>
                        <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMarks" runat="server" ControlToValidate="txtMarks"
                            Text="*" ForeColor="Red" ValidationGroup="vgAdd" />
                        <%--<asp:RegularExpressionValidator ID="revMarks" runat="server" ForeColor="Red"
                            ValidationExpression="^[0-9]*$" Text="*Numbers" ControlToValidate="txtMarks"
                            ValidationGroup="vgAdd" />--%>
                    </td>
                </tr>
                <tr>
                    <td>Grade:</td>
                    <td>
                        <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvGrade" runat="server" ControlToValidate="txtGrade"
                            Text="*" ForeColor="Red" ValidationGroup="vgAdd" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click"
                            ValidationGroup="vgAdd" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            ValidationGroup="vgAdd" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            OnClientClick="return confirm('Are you sure you want to delete this record?')"
                            ValidationGroup="vgAdd" />
                        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CausesValidation="false" />
                    </td>
                </tr>
            </table>

            <asp:GridView ID="gvImages" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">


                <Columns>
                    <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL"></asp:BoundField>
                    <asp:BoundField DataField="CCode" HeaderText="CCode" SortExpression="CCode"></asp:BoundField>
                </Columns>
            </asp:GridView>


            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:SiteSqlServer %>' SelectCommand="SELECT * FROM [countryImages] WHERE ([CCode] = @CCode)" DeleteCommand="DELETE FROM [countryImages] WHERE [ID] = @ID" InsertCommand="INSERT INTO [countryImages] ([ID], [Name], [URL], [CCode]) VALUES (@ID, @Name, @URL, @CCode)" UpdateCommand="UPDATE [countryImages] SET [Name] = @Name, [URL] = @URL, [CCode] = @CCode WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Name" Type="String"></asp:Parameter>
                    <asp:Parameter Name="URL" Type="String"></asp:Parameter>
                    <asp:Parameter Name="CCode" Type="String"></asp:Parameter>
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtSubjectId" PropertyName="Text" Name="CCode" Type="String"></asp:ControlParameter>
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String"></asp:Parameter>
                    <asp:Parameter Name="URL" Type="String"></asp:Parameter>
                    <asp:Parameter Name="CCode" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
            <div style="clear:both"></div>

            <br />
            <asp:GridView ID="gvSubDetails" DataKeyNames="Code" runat="server"
                OnSelectedIndexChanged="gvSubDetails_SelectedIndexChanged" Width="500"
                AutoGenerateColumns="false">
                <HeaderStyle BackColor="#9a9a9a" ForeColor="White" Font-Bold="true" Height="30" />
                <AlternatingRowStyle BackColor="#f5f5f5" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="Select" Text="Select" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SubjectName">
                        <ItemTemplate>
                            <asp:Label ID="lblSubjectName" runat="server" Text='<%#Eval("Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marks">
                        <ItemTemplate>
                            <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("Region") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade">
                        <ItemTemplate>
                            <asp:Label ID="lblGrade" runat="server" Text='<%#Eval("SurfaceArea") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>






    </div>

</div>
<asp:LinkButton ID="btnSubmit" runat="server"
    OnClick="btnSubmit_Click" resourcekey="btnSubmit" CssClass="dnnPrimaryAction" />
<asp:LinkButton ID="btnCancel" runat="server"
    OnClick="btnCancel_Click" resourcekey="btnCancel" CssClass="dnnSecondaryAction" />





<script language="javascript" type="text/javascript">
    /*globals jQuery, window, Sys */
    (function ($, Sys) {
        function dnnEditBasicSettings() {
            $('#dnnEditBasicSettings').dnnPanels();
            $('#dnnEditBasicSettings .dnnFormExpandContent a').dnnExpandAll({ expandText: '<%=Localization.GetString("ExpandAll", LocalResourceFile)%>', collapseText: '<%=Localization.GetString("CollapseAll", LocalResourceFile)%>', targetArea: '#dnnEditBasicSettings' });
        }

        $(document).ready(function () {
            dnnEditBasicSettings();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                dnnEditBasicSettings();
            });
        });

    }(jQuery, window.Sys));
</script>
