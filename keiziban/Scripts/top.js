
$(function () {

    $(document).on('click', '.no', function () {
        var no = this;
        RequestArticle(no);
        return false;
    });
});

function RequestArticle(article) {
    var no = article.getAttribute("no");
    location.href = "thread.aspx?no=" + no;

}