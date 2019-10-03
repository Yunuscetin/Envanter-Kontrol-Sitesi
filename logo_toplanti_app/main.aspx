<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="logo_toplanti_app.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Logo Yazılım | Oda Yönetimi</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    </head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <nav class="navbar navbar-expand-lg navbar-light bg-light "  style="background-color: #f8f8ff;" >
                <a class="navbar-brand" href="#"><img src="images/35.yil_imza_logosu_v2.png" /></a>
                  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                  </button>
                
                <div class="collapse navbar-collapse  mr-auto mt-2 mt-lg-0" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto">
                      <li class="nav-item active">
                        <a class="nav-link" href="#">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <asp:Button ID="BtnRpr" class="btn btn-outline-danger" runat="server" Text="Arıza Raporu" OnClick="BtnRpr_Click" />
                        </a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="#">
                            <asp:Button class="btn btn-outline-danger" ID="CikisBtn" runat="server" Text="Çıkış" OnClick="CikisBtn_Click" />
                        </a>
                      </li>
                      
                    </ul>
                  </div>
                
            </nav>
           
                <div class="card">
                    <div class="card-body">
                        <h5>ODALAR</h5>
                        <hr />
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                        <div class="row">
                            <div class="col-12">
                                <table class="table table-responsive table-hover">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView1" DataKeyNames="mID" runat="server" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="CalisanBtn" class="btn btn-success" runat="server" Text="Çalışıyor" CommandName="Calisiyor" CommandArgument='<%#Eval("mID") %>' />
                                                                <asp:Button ID="ArizaliBtn" class="btn btn-danger" runat="server" Text="Arızalı" CommandName="Arizali" CommandArgument='<%#Eval("mID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                                <div class="row">
                                    <div class="col-md-8 col-xs-12 text-center">
                                        <asp:Label ID="LblBilgi" runat="server" Text="Bilgi"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TxtBilgi" runat="server" Height="79px" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="margin-top: 20px"></div>
                                <div class="row">
                                    <div class="col-md-8 col-xs-12 text-center">
                                        <asp:Button ID="BtnKaydet" runat="server" class="btn btn-success" Text="Kaydet" OnClick="Button4_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="margin-top: 20px"></div>

                    </div>
                </div>
            <div class="row">

                <div class="col-md-12 col-xs-12">

                    <div style="float:left">
                        <strong>Copyright &copy; 2019 Yunus Çetin.</strong> All rights reserved.
                    </div>
                     
                    <div style="float:right">
                        <b>Version</b> 1.0.0
                    </div>
                

                </div>
            </div>
      
        </div>
        
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    </form>


</body>
</html>
