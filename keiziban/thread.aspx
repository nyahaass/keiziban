<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thread.aspx.cs" Inherits="keiziban.thread" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>掲示板</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Content/Site.css">
    <link rel="stylesheet" type="text/css" href="./Content/thread.css">
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
                    <h3 class="homemsg">
                        <label>どちゃくそ掲示板:スレッド</label>
                    </h3>
                    <h3 class="homemsg">
                        <p id="title">
                            <asp:Label ID="txtTitle" runat="server"></asp:Label>
                        </p>
                    </h3>

                    <p id="info">
                        <asp:Label ID="txtInfo" runat="server"></asp:Label>
                    </p>
                    <hr />
                </div>
                <asp:HiddenField ID="hdnThreadNo" runat="server" />
                <asp:HiddenField ID="hdnKanriNo" runat="server" />
                <asp:HiddenField ID="hdnUserNo" runat="server" />
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                    <div class="item item_main" id="head">
                        <div class="item item_main">
                            <div class="no" no="<%# Eval("kanri_no") %>">
                                <div class="media-heading">
                                    <p class="title">
                                        <img class="media-objec iPeple" src='./img/peple.png' />
                                        <asp:Label runat="server" ID="txtThTitle"></asp:Label>
                                        <span class="pDescript">ユーザー : 
                                            <asp:Label runat="server" ID="txtThUser"></asp:Label>
                                            <label>作成日</label>
                                            <asp:Label runat="server" ID="txtThDate"></asp:Label>
                                        </span>
                                    </p>
                                    <asp:Label class="topDescript" runat="server" ID="txtThMsg"> </asp:Label>
                                </div>
                                <div id="footer" class="goodicon">
                                    <span class="glyphicon glyphicon-heart goodicon" aria-hidden="true"></span>
                                    <asp:Label runat="server" ID="lblGood"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="item item_main" id="body">
                            <asp:Repeater ID="rptListItems" runat="server">
                                <ItemTemplate>
                                    <div class="no" no="<%# Eval("kanri_no") %>">
                                        <div class="media-heading">
                                            <p class="title">
                                                <img class="media-objec iPeple" src='./img/peple.png' />
                                                <span class="pDescript">ユーザー :  <%# Eval("user_id") %>
                                                    <label class="thread">作成日</label>
                                                    <%# Eval("create_Date") %>
                                                </span>
                                            </p>
                                            <span class="topDescript"><%# Eval("thread_msg") %> </span>
                                        </div>
                                    </div>
                                    <div id="footer2" class="goodicon">
                                        <span class="glyphicon glyphicon-heart goodicon2" style="" aria-hidden="true"></span>
                                        <asp:Label runat="server" ID="lblGood"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="item item_main" id="footer2">
                            <div class="media-heading">
                                <p class="title">
                                    <asp:Label ID="lblTitle" class="pDescript" runat="server"></asp:Label>
                                    <asp:Image ID="imgTitle" class="media-objec" src='' runat="server"></asp:Image>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="item item_main" id="head2">
                        <div class="articleinput" style="background-color: #fff;">
                            <li class="media minput">
                                <h4>返信する：</h4>
                                <div class="media-body" style="">
                                    <asp:TextBox ID="txtInput" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                </div>
                            </li>
                            <div class="media-footer">
                                <asp:Button ID="btnReg" class="btn btn-primary" runat="server" Text="ツイート" OnClick="btnReg_Click" />
                            </div>
                        </div>
                    </div>
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

