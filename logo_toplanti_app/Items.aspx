<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="logo_toplanti_app.Items" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
        <section class="content-header">
      <h1>
        Esyalar     
      </h1>
      
    </section>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h4 class="box-title">Logo Yazılım toplantı odaları eşya bilgileri</h4>
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" class="table table-responsive table-hover" runat="server" DataKeyNames="iID" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True">
                            <Columns>
                                <asp:BoundField DataField="iID" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="Button5" runat="server" Text="Edit" CommandName="Guncelle" CommandArgument='<%#Eval("iID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Notu Silmek İstediğinize Emin Misiniz?')" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
        </div>
    </section>
    <!-- /.content -->
</asp:Content>
