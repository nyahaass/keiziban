<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="keiziban.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>掲示板 : ユーザプロフィール</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Content/Site.css">
    <link rel="stylesheet" type="text/css" href="./Content/articlelist.css">
    <link rel="stylesheet" type="text/css" href="./Content/profile.css">
</head>
<body>
    <form id="eForm" runat="server">
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

            <div class="col-sm-12 item item_header"></div>
            <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                </div>
                <div class="col-sm-3"></div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <div class="item item_nav">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                LOGIN
                                <asp:Label ID="txtEditDate" Text="" runat="server"></asp:Label>
                            </div>
                            <div class="panel-body">パネル内容</div>
                            <div class="panel-footer">NAME : ななしさん </div>
                        </div>

                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="well edit">
                        <div class="item item_main">
                            <div class="form-group">
                                <asp:label id="lblName" for="txtName" runat="server">ユーザー名</asp:label>
                                <asp:TextBox  id="txtName" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:label id="lblPass" for="txtPass" runat="server">パスワード</asp:label>
                                <asp:TextBox  id="txtPass" type="password" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:label id="lblMail" for="txtMail" runat="server">メールアドレス</asp:label>
                                <asp:TextBox  id="txtMail"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:label ID="lblProfile"  for="txtProfile" runat="server">プロフィールメッセージ</asp:label>
                                <asp:TextBox id="txtProfile" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="media-footer"  >
                                <asp:Button ID="btnReg" class="btn btn-primary" runat="server" Text="保存" />
                            </div>
                        </div>
                    </div>
                    <div class="item item_main">
                    </div>
                </div>
                <div class="col-sm-3">
                </div>
                <div class="item item_sidebar">sidebar</div>
            </div>
            <div class="col-sm-12 item item_footer">footer</div>
        </div>
    </form>
</body>
<script src="./Scripts/jquery-3.4.1.min.js"></script>
<script src="./Scripts/bootstrap.min.js"></script>
<script src="./Scripts/article.js"></script>
</html>
