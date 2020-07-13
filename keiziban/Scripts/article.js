$(function () {
    $(document).on('click', '.btnReg', function () {
        rebTweet();
        return false;
    });

    $(document).on('click', '.article', function () {
        var article = this;
        RequestArticle(article)

        return false;
    });
});

function RequestArticle(article) {
    var no = article.getAttribute("no");
    location.href = "main.aspx?no=" + no;
}