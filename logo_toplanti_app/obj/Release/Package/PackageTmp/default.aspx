<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="logo_toplanti_app._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <section class="content">
      <!-- Small boxes (Stat box) -->
      <div class="row">
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua">
            <div class="inner">
              <h3>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>

              <p>Toplam Oda Sayısı</p>
            </div>
            <div class="icon">
              <i class="ion ion-bag"></i>
            </div>
            <a href="Rooms.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-green">
            <div class="inner">
              <h3>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label><sup style="font-size: 20px"></sup></h3>

              <p>Toplam Eşya Sayısı</p>
            </div>
            <div class="icon">
              <i class="ion ion-stats-bars"></i>
            </div>
            <a href="Items.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow">
            <div class="inner">
              <h3>
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h3>

              <p>Toplam Kullanıcı Sayısı</p>
            </div>
            <div class="icon">
              <i class="ion ion-person-add"></i>
            </div>
            <a href="users.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
          <div>  <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Kullanıcı Arayüzü" OnClick="Button1_Click"  /></div>
        <!-- ./col -->
      
      </div>
     
</asp:Content>