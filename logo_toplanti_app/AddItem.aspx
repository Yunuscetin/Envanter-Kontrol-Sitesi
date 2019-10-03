<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="logo_toplanti_app.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
        <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
          <asp:Label ID="Label1" runat="server" Text="Eşya Ekle"></asp:Label>
        
      </h1>
      
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">

        <div class="col-md-12">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">
                  <asp:Label ID="Label2" runat="server" Text="Eşya Ekleme Formu"></asp:Label></h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form role="form">
            <div class="box-body">
                <div class="form-group">
                    <label for="exampleInputEmail1">
                        <asp:Label ID="Label3" runat="server" Text="Eşya Adı"></asp:Label></label>
                   
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Eşya adı giriniz"></asp:TextBox> 
                    <div class="box box-primary">
            <div class="box-header with-border">
              <h4 class="box-title">Eşyanın bulunacağı odaları seçiniz</h4>
            </div>            
                </div>                
                <div class="form-group">
                    

                    <table class="nav-justified">
                        <tr>
                            <td style="text-align: center">
                                <asp:ListBox ID="ListBox1" runat="server" CssClass="col-xs-offset-0" Height="250px" Width="185px" SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="&gt;" Height="24px" Width="24px" OnClick="Button1_Click" />
                                <br />
                                <asp:Button ID="Button2" runat="server" Text="&lt;" Height="24px" Width="24px" OnClick="Button2_Click" />
                                <br />
                                <asp:Button ID="Button3" runat="server" Text="&gt;&gt;" Height="24px" Width="24px" OnClick="Button3_Click" />
                                <br />
                                <asp:Button ID="Button4" runat="server" Text="&lt;&lt;" Height="24px" Width="24px" OnClick="Button4_Click" />
                            </td>
                            <td style="text-align: center">
                                <asp:ListBox ID="ListBox2" runat="server" Height="250px" Width="185px" SelectionMode="Multiple"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                     <div class="box-footer">
                    <table style="width: 323px; height: 49px">
                        <tr>
                            <td>
                                <asp:Button ID="Button6" runat="server" class="btn btn-primary" Text="Kaydet" OnClick="Button6_Click" />
                            </td>
                            <td>
                                 <asp:Button ID="Button5" runat="server" class="btn btn-danger" Text="İptal" Visible="false" OnClick="Button5_Click"/>
                            </td>
                        </tr>
                    </table>
                         <asp:Label ID="Label4" runat="server" Text="" Visible="false"></asp:Label>
                    
            </div>
                    

            </div>
            <!-- /.box-body -->

            
        </form>
          </div>
          <!-- /.box -->

        </div>

      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>
