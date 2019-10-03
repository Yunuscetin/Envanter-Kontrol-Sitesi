<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="logo_toplanti_app.admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logo Yazılım | Oda Yönetim Admin Paneli</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
</head>
<body>
    <div class="container">
        <div class="row justify-content-md-center" style="margin-top: 10%;">
            <div class="col col-lg-2">
                
            </div>
            <div class="col-md-auto">
                <div class="card" style="text-align:center">
                    <asp:Label ID="Label1"  runat="server" Text="Logo Yazılım Oda Yönetimi Admin Paneli"></asp:Label>
                    <img src="http://img.bigpara.com/c/1/70/650x365/bp/logo_0222.png" width="auto" style="margin-left: 5%;" height="180" class="card-image-top">
                    <div class="card-body">
                        <form id="form1" runat="server">
                            <dt>
                                <label for="email">Username</label>
                                <dd>
                                    <asp:TextBox class="form-control" ID="username" runat="server"></asp:TextBox>
                                </dd>
                                <dt>
                                    <label for="password">Password</label>
                                    <dd>
                                        <asp:TextBox class="form-control" ID="password" TextMode="Password" runat="server"></asp:TextBox>
                                    </dd>
                                    <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Giriş" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
            <div class="col col-lg-2">
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</body>
</html>
