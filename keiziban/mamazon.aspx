<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mamazon.aspx.cs" Inherits="mamazon.mamazon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Mamazon</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/booklist.css" />
    <script src="./Scripts/jquery-3.3.1.min.js"></script>
    <script src="./Scripts/bootstrap.min.js"></script>
    <script src="./Scripts/mamazon.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <nav class="navbar navbar-default" role="navigation">
                <div class="container">
                    <div class="navbar-header col-xs-2">
                        <a class="navbar-brand" href="#">test</a>
                    </div>
                    <div class="nav navbar-nav col-xs-6">
                        <div class="navbar-form navbar-left">
                            <input type="button" class="btn btn-default mainSearch" value="検索" />
                            <input type="button" class="btn btn-default listReload" value="再描画" />
                            <div class="form-group">
                                <input type="text" id="txtQuery" class="form-control1" style="width: 350px" placeholder="検索" />
                            </div>
                        </div>
                    </div>
                    <div class="nav navbar-nav col-xs-4">
                    </div>
                    <table id="tblMainItemList">
                    </table>

                </div>
            </nav>
            <div data-spy="scroll" data-target="#book" style="overflow-y: scroll; height: 900px">
                <div class="media-list book">
                </div>
            </div>

        </div>
    </form>
</body>
</html>
