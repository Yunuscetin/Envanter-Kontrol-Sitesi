<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="logo_toplanti_app.login" %>

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
        <div class="container">
        <div class="row justify-content-md-center" style="margin-top:10%;"> 
            <div class="col col-lg-2">
            </div>
            <div class="col-md-auto">
            <div class="card">  
            <img src="http://img.bigpara.com/c/1/70/650x365/bp/logo_0222.png" width="auto" style="margin-left:5%;" height="180" class="card-image-top">
            <div class="card-body">
                <form id="form1" runat="server">
                    <dt><label for="email">Username</label>
                    <dd>
                        <asp:TextBox class="form-control" ID="TxtUsername" runat="server"></asp:TextBox>
                    </dd>
                    <dt><label for="password">Password</label>
                    <dd>
                        <asp:TextBox class="form-control" ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </dd>
                    <asp:Button class="btn btn-success" ID="GirisBtn" runat="server" Text="Giriş" OnClick="GirisBtn_Click" />
                        <asp:Label ID="Label1"  runat="server" Text="Şifremi Unuttum."></asp:Label>
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
