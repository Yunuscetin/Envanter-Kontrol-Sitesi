<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="logo_toplanti_app.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <section class="content-header">
      <h1>
        Kullanıcılar
        <small>Kullanıcılar listesi</small>
      </h1>
      
    </section>

    <!-- Main content -->
    <section class="content">
     <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h4 class="box-title">Logo Yazılım toplantı odaları kullanıcı bilgileri</h4>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" class="table table-responsive table-hover" runat="server" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" DataKeyNames="uID" OnRowDeleting="GridView1_RowDeleting" >
                    <Columns>                       
                        <asp:BoundField DataField="uID" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" Text="Edit" CommandName="Guncelle" CommandArgument='<%#Eval("uID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"  OnClientClick="return confirm('Notu Silmek İstediğinize Emin Misiniz?')" />
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
</asp:Content>
