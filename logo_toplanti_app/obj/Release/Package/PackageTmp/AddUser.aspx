<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="logo_toplanti_app.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <section class="content">
      <div class="row">

        <div class="col-md-12">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">
                  <asp:Label ID="Label4" runat="server" Text="Kullanıcı Ekleme Formu"></asp:Label></h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form role="form">
            <div class="box-body">
                <div class="form-group">
                    <label for="exampleInputEmail1">İsim ve Soyisim</label>                   
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="İsim ve Soyisim giriniz"></asp:TextBox> 
                                       
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Kullanıcı Adı</label>
                   
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Kullanıcı adı giriniz"></asp:TextBox> 
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label></div>                   
                </div> 
                <div class="form-group">
                    <label for="exampleInputEmail1">Parola</label>
                   
                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" TextMode="Password" placeholder="Parola giriniz"></asp:TextBox> 
                    <div>
                        <div class="form-group">
                    <label for="exampleInputEmail1">Parolayı tekrar giriniz.</label>
                   
                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" TextMode="Password" placeholder="Parola giriniz"></asp:TextBox> 
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>
                            </div>                   
                </div>                
                
                     <div class="box-footer">
                         <table style="width: 323px; height: 49px">
                             <tr>
                                 <td>
                                     <asp:Button ID="Button6" runat="server" class="btn btn-primary" Text="Kaydet" OnClick="Button6_Click" />
                                 </td>
                                 <td>
                                     <asp:Button ID="Button1" runat="server" class="btn btn-danger" Text="İptal" Visible="false" OnClick="Button1_Click"/>
                                 </td>
                             </tr>
                         </table>
                    
            </div>
                    

            </div>
                </div>
    </section>
</asp:Content>
