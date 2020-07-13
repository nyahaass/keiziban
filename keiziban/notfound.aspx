<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notfound.aspx.cs" Inherits="keiziban.notfound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>掲示板</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Content/Site.css">
    <link rel="stylesheet" type="text/css" href="./Content/top.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <nav class="navbar navbar-default ">
                <div class="container-fluid">
                    <!-- ヘッダー部分 ================ -->
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">掲示板</a>
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#nav_target">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                    <!-- 中央のナビゲーション部分 ================ -->
                    <div class="collapse navbar-collapse" id="nav_target">
                        <ul class="nav navbar-nav">
                            <!-- リンクのみ -->
                            <li class="active"><a href="#">ホーム</a></li>
                            <li><a href="#">一覧</a></li>
                            <!-- Nav3 ドロップダウン -->
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">編集<span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">link 1</a></li>
                                    <li><a href="#">link 2</a></li>
                                    <li class="divider"></li>
                                    <li><a href="#">link3</a></li>
                                </ul>
                            </li>
                        </ul>
                        <!-- 右寄せになる部分 ================ -->
                        <ul class="nav navbar-nav navbar-right">
                            <!-- リンクのみ -->
                            <li><a href="#">
                                <span>ようこそ </span>
                                <asp:Label runat="server">ななしさん</asp:Label>
                            </a>
                            </li>
                            <!-- Nav6 ドロップダウン -->
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">設定 <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">link 1</a></li>
                                    <li><a href="#">link 2</a></li>
                                    <li class="divider"></li>
                                    <li><a href="#">link3</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8  error">
                    <h1>お探しのページは見つかりませんでした</h1>
                    <img class="media-objec" src='./img/404.png' />
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8 bkHome">
                    <asp:Button ID="btnPage" class="btn btn-default" Text="ホームに戻る" runat="server" OnClick="btnPage_Click" />
                </div>
                <div class="col-sm-2">
                </div>
            </div>
        </div>
    </form>
</body>
<script src="./Scripts/jquery-3.4.1.min.js"></script>
<script src="./Scripts/bootstrap.min.js"></script>
<script src="./Scripts/top.js"></script>
</html>

