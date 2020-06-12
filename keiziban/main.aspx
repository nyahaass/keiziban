<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="keiziban.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>掲示板</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Content/Site.css">
    <link rel="stylesheet" type="text/css" href="./Content/articlelist.css">
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
                                <asp:Label ID="txtLogDate" Text="" runat="server"></asp:Label>
                            </div>
                            <div class="panel-body">パネル内容</div>
                            <div class="panel-footer">NAME : ななしさん </div>
                        </div>

                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="item item_main">
                        <div class="articleinput" style="background-color: #fff;">
                            <li class="media minput">
                                <div class="pull-left">
                                </div>
                                <div class="media-heading">
                                    <asp:Label class="lbl" runat="server" >ジャンル</asp:Label><asp:DropDownList ID="ddlMenu" runat="server"></asp:DropDownList>                                   
                                </div>
                                <asp:Label class="lbl" runat="server" >タイトル </asp:Label><asp:TextBox id="txtTitle"  runat="server"></asp:TextBox> 
                                <div class="media-body" style="">
                                    <asp:TextBox id="txtInput" TextMode="MultiLine"  rows="5" runat="server"></asp:TextBox> 
                                </div>
                            </li>
                            <div class="media-footer"  >
                                <asp:Button ID="btnReg" class="btn btn-primary" runat="server" Text="ツイート" OnClick="btnReg_Click"/>
                            </div>
                        </div>
                    </div>
                    <div class="item item_main">
                        <asp:Repeater ID="rptListItems" runat="server">
                            <ItemTemplate>
                                <div class="article" style="background-color: #fff;">
                                    <li class="media mBook">
                                        <div class="pull-left">
                                        </div>
                                        <div class="media-heading">
                                            <p>
                                                <img class="media-objec" src='./img/news.png'  />
                                                タイトル : <%# Eval("title_name") %>
                                            </p>


                                        </div>
                                        <div class="media-body">
                                            <p class="pDescript">本文 :  <%# Eval("title_msg") %> </p>
                                            <span class="pPublish">ユーザー :  <%# Eval("create_user") %> 作成日: none</span>
                                        </div>
                                    </li>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
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
