<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookEditor.aspx.cs" Inherits="BookEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Mamazon</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bookedit.css" />
    <script src="./Scripts/jquery-3.3.1.min.js"></script>
    <script src="./Scripts/bootstrap.min.js"></script>
    <script src="./Scripts/bookedit.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <header class="page-header">
                <input type="button" class="btn btn-default mainSearch" value="検索" />
                <input type="button" class="btn btn-default listReload" value="再描画" />
                <input type="text" id="txtQuery" class="form-control1" style="width: 250px" placeholder="検索" />
            </header>
            <div class="row">
                <ul class="nav nav-pills nav-justified">
                    <li class="active"><a href="#list" data-toggle="tab">一覧</a></li>
                    <li><a href="#" data-toggle="tab">新規作成</a></li>
                    <li><a href="#edit" data-toggle="tab">編集</a></li>
                    <li><a href="#" data-toggle="tab">削除</a></li>
                </ul>
            </div>
            <div class="row">
                <div class="fwrapp" style="display: flex">
                    <div class="solid" style="width: 220px">編集用一覧</div>
                    <div class="solid" style="width: 950px;">検索結果確認</div>
                </div>
            </div>
            <div class="row">
                <div class="fwrapp" style="display: flex; width: 1200px">
                    <div data-spy="scroll" data-target="#sBookList" style="overflow-y: scroll; width: 230px; height: 900px">
                        <div class="solid media-list sBookList">
                        </div>
                    </div>
                    <div class="tab-content">
                        <div class="tab-pane active" id="list">
                            <div data-spy="scroll" data-target="#book" style="overflow-y: scroll; width: 940px; height: 900px">
                                <div class="solid media-list book">
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="edit">
                            <div class="well well-sm" style="width:600px;">
                                <div class="fwrapp" style="display: inline-block">
                                    <asp:Label ID="lblTitle" runat="server" Text="タイトル" Style="width: 100px"></asp:Label>
                                    <asp:TextBox ID="txtTitle" runat="server" Style="width: 250px" Text="test"></asp:TextBox>
                                </div>
                                <div class="fwrapp" style="display: inline-block">
                                    <asp:Label ID="lblPublish" runat="server" Text="出版" Style="width: 100px"></asp:Label>
                                    <asp:TextBox ID="txtPublish" runat="server" Style="width: 250px"></asp:TextBox>
                                </div>
                                <div class="fwrapp" style="display: inline-block">
                                    <asp:Label ID="lblPubDate" runat="server" Text="出版日" Style="width: 100px"></asp:Label>
                                    <asp:TextBox ID="txtPubDate" runat="server" Style="width: 250px"></asp:TextBox>
                                </div>
                                <div class="fwrapp" style="display: inline-block">
                                    <asp:Label ID="lblDesc" runat="server" Text="概要" Style="width: 250px"></asp:Label>
                                    <asp:TextBox ID="txtDesc" runat="server" Style="width: 400px; height: 500px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </form>
</body>
</html>
