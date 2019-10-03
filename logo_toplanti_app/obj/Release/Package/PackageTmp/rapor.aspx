<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rapor.aspx.cs" Inherits="logo_toplanti_app.rapor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Logo Yazılım | Oda Yönetimi</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>

    <style type="text/css">
        .auto-style2 {
            left: 0px;
            top: 3px;
        }
    </style>

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
                            <asp:Button ID="Button1" runat="server" class="btn btn-outline-danger" Text="Anasayfa" OnClick="Button1_Click" />
                        </a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="#">
                            <asp:Button class="btn btn-outline-danger" ID="Cikis" runat="server" Text="Çıkış" OnClick="Cikis_Click" />
                        </a>
                      </li>
                      
                    </ul>
                  </div>
            </nav>
        
        
       
        <div style="margin-top: 100px"></div>
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-8 col-xs-12">
                        <table class="table table-responsive table-hover">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" DataKeyNames="reportID" runat="server"  OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Sil" CommandName="Delete" OnClientClick="return confirm('Notu Silmek İstediğinize Emin Misiniz?')">
                                                    </asp:Button>
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
                        </table>


                    </div>
                </div>

            </div>
            <div>
                <div class="row">
                    <div class="auto-style2">                      
                    </div>
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
            </div>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    </form>
</body>
</html>
