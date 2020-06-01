<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="keiziban.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ようこそ</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Content/Site.css">
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginform" class="panel panel-default displayed">
            <div class="panel-heading">ログイン画面</div>
            <div class="panel-body">
                <asp:Label for="txtId" runat="server">ユーザ名</asp:Label>
                <asp:TextBox ID="txtId" class="form" runat="server"></asp:TextBox>
                <asp:Label for="txtPass" class="mg20" runat="server">パスワード</asp:Label>
                <asp:TextBox ID="txtPass" class="form" type="password" runat="server"></asp:TextBox>
            </div>
            <div class="panel-footer">
                <div style="text-align: right;">
                    <asp:Button ID="btn_Login" Text="ログインする" runat="server" OnClick="btn_Login_Click" />
                </div>
            </div>
        </div>
    </form>
</body>

<script src="./Scripts/bootstrap.min.js"></script>
<script src="./Scripts/jquery-3.4.1.min.js"></script>
</html>
