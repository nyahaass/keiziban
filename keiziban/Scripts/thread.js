$(function () {
    $(document).on('click', '.btnReg', function () {
        RegTweet();

        return false;
    });

    $(document).on('click', '.goodicon', function () {       
        RegGood();

        return false;
    });
});

function RequestArticle(article) {
    var no = article.getAttribute("no");
    location.href = "main.aspx?no=" + no;
}

function RegTweet() {

}

function RegGood() {

}