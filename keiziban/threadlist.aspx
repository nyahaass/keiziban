<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="threadlist.aspx.cs" Inherits="keiziban.threadlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>掲示板</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Content/Site.css">
    <link rel="stylesheet" type="text/css" href="./Content/threadlist.css">
</head>
<body>
    <!-- <a href="edit.aspx.designer.cs">edit.aspx.designer.cs</a>-->
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
                <div class="caption">
                    <h5 class="homemsg">
                        <label>どちゃくそ掲示板:　書き込みリスト</label>
                    </h5>
                    <h5 class="homemsg">
                        <p id="title">
                            <asp:Label ID="txtTitle" runat="server"></asp:Label>
                        </p>
                    </h5>
                    <p id="info">
                        <asp:Label ID="txtInfo" runat="server"></asp:Label>
                    </p>
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-1">
                    <asp:Label ID="lblDate" runat="server">期間</asp:Label>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtDateFr" runat="server" placeholder="0000/00/00"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <asp:label id="nami" runat="server">～</asp:label>
                </div>
                <div class="col-sm-2 col-sm-pull-1">
                    <asp:TextBox ID="txtDateTo" runat="server" placeholder="0000/00/00"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <asp:HiddenField ID="hdnThreadNo" runat="server" />
                <asp:HiddenField ID="hdnKanriNo" runat="server" />
                <asp:HiddenField ID="hdnUserNo" runat="server" />
                <div class="col-sm-9">
                    <table id="tblList" >
                        <asp:Table ID="tblListItems" CssClass="table table-bordered" runat="server"></asp:Table>
                    </table>
                </div>
                <div class="col-sm-3"></div>
            </div>
        </div>
    </form>
    <script src="./Scripts/jquery-3.4.1.min.js"></script>
    <script src="./Scripts/bootstrap.min.js"></script>
    <script src="./Scripts/thread.js"></script>
</body>
</html>

