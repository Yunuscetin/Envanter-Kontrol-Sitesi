<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="logo_toplanti_app.Rooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <section class="content-header">
      <h1>
        Odalar
        <small>Logo Yazılım toplantı odaları bilgileri</small>
      </h1>
    
    </section>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Oda İşlemleri</h3>
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" class="table table-responsive table-hover" DataKeyNames="rID" PageSize="15" OnRowCreated="GridView1_RowCreated" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" AllowPaging="True">
                                        <Columns>
                                            <asp:BoundField DataField="rID" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="Button5" runat="server" Text="Edit" CommandName="Guncelle" CommandArgument='<%#Eval("rID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Odayı Silmek İstediğinize Emin Misiniz?')" />
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