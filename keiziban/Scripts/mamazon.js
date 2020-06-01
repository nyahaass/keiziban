var jsonData;

$(function () {

    $(document).on('click', '.mainSearch', function () {
        getBookData();
        return false;
    });

    $(document).on('click', '.listReload', function () {
        mediaListReload();
        return false;
    });
});

function getBookData() {
    // Google Books APIへ問い合わせを行う。
    // もしGoogle Books APIに書籍が存在しない(totalItemsが0の場合)、入力欄に表示されたデータをすべて消去し、該当書籍がないとメッセージを表示する

    const query = $("#txtQuery").val();
    const url = "https://www.googleapis.com/books/v1/volumes?q=" + query;
    let bTitle;
    let bDescription;
    let bPhotoUrl;
    let bPublisher;
    let bPublisherDate;
    let bPrevLink;
    let bInfoLink;
    let bVolumeLink;
    $.getJSON(url, function (data) {
        if (!data.totalItems) {

        } else {
            jsonData = data;
            var rowCount = data.items.length;
            var li = [];

            // 該当書籍が存在した場合、JSONから値を取得して入力項目のデータを取得する
            for (var activeRow = 0; activeRow < rowCount; activeRow++) {
                bTitle = "";
                bDescription = "";
                bPhotoUrl = "";
                bPublisher = "";
                bPublisherDate = "";

                if (data.items[activeRow].volumeInfo.title != null) {
                    bTitle = data.items[activeRow].volumeInfo.title;
                } 

                if (data.items[activeRow].volumeInfo.description != null) {
                    bDescription = data.items[activeRow].volumeInfo.description;
                }

                if (data.items[activeRow].volumeInfo.imageLinks.smallThumbnail != null) {
                    bPhotoUrl = data.items[activeRow].volumeInfo.imageLinks.smallThumbnail;
                }

                if (data.items[activeRow].volumeInfo.publisher != null) {
                    bPublisher = data.items[activeRow].volumeInfo.publisher;
                }

                if (data.items[activeRow].volumeInfo.publishedDate != null) {
                    bPublisherDate = data.items[activeRow].volumeInfo.publishedDate;
                }

                li.push('<li class="media mBook" >');
                li.push('<div class="pull-left"> <img class="media-objec" src=' + bPhotoUrl + '/></div>');
                li.push('<div class="media-body"><p class="media-heading">' + 'タイトル : ' + bTitle + '</p>');
                li.push('<p class="pPublish">' + '出版 : ' + bPublisher + '  ' + bPublisherDate + '</p>');
                li.push('<p class="pDescript">' + '概要 : ' + bDescription + '</p>');

                //リンク作成
                if (data.items[activeRow].volumeInfo.previewLink != null) {
                    bPrevLink = data.items[activeRow].volumeInfo.previewLink;
                    li.push('<div class="button"><a href="' + bPrevLink + '">'+'</a></div>');
                }

                if (data.items[activeRow].volumeInfo.infoLink != null) {
                    bInfoLink = data.items[activeRow].volumeInfo.infoLink;
                    li.push('<div class="button"><a href="' + bInfoLink + '">'+'</a></div>');
                }

                if (data.items[activeRow].volumeInfo.bCanonicalVolumeLink != null) {
                    bVolumeLink = data.items[activeRow].volumeInfo.bCanonicalVolumeLink;
                    li.push('<div class="button"><a href="' + bVolumeLink + '">'+'</a></div>');
                }
                li.push('</div></li>');
            }

            $('.book').append(li.join(""));
        }

    });
}

function mediaListReload() {
    if (jsonData!= null) {
        var rowCount = jsonData.items.length;
        var li = [];

        // 該当書籍が存在した場合、JSONから値を取得して入力項目のデータを取得する
        for (var activeRow = 0; activeRow < rowCount; activeRow++) {
            bTitle = "";
            bDescription = "";
            bPhotoUrl = "";
            bPublisher = "";
            bPublisherDate = "";

            if (jsonData.items[activeRow].volumeInfo.title != null) {
                bTitle = jsonData.items[activeRow].volumeInfo.title;
            }

            if (jsonData.items[activeRow].volumeInfo.description != null) {
                bDescription = jsonData.items[activeRow].volumeInfo.description;
            }

            if (jsonData.items[activeRow].volumeInfo.imageLinks.smallThumbnail != null) {
                bPhotoUrl = jsonData.items[activeRow].volumeInfo.imageLinks.smallThumbnail;
            }

            if (jsonData.items[activeRow].volumeInfo.publisher != null) {
                bPublisher = jsonData.items[activeRow].volumeInfo.publisher;
            }

            if (jsonData.items[activeRow].volumeInfo.publishedDate != null) {
                bPublisherDate = jsonData.items[activeRow].volumeInfo.publishedDate;
            }
            
            li.push('<li class="media mBook" >');
            li.push('<div class="pull-left"> <img class="media-object" src=' + bPhotoUrl + '/></div>');
            li.push('<div class="media-body"><h3 class="media-heading">' + 'タイトル : ' + bTitle + '</h3>');
            li.push('<p class="pPublish">' + '出版 : ' + bPublisher + '  ' + bPublisherDate + '</p>');
            li.push('<p class="pDescript">' + '概要 : ' + bDescription + '</p>');

            //リンク作成
            if (jsonData.items[activeRow].volumeInfo.previewLink != null) {
                bPrevLink = jsonData.items[activeRow].volumeInfo.previewLink;
                li.push('<li class="button"><a href="' + bPrevLink + '">'+ '</a></li>');
            }

            if (jsonData.items[activeRow].volumeInfo.infoLink != null) {
                bInfoLink = jsonData.items[activeRow].volumeInfo.infoLink;
                li.push('<li class="button"><a href="' + bInfoLink + '">' + '</a></li>');
            }

            if (jsonData.items[activeRow].volumeInfo.bCanonicalVolumeLink != null) {
                bVolumeLink = jsonData.items[activeRow].volumeInfo.bCanonicalVolumeLink;
                li.push('<li class="button"><a href="' + bVolumeLink + '">' + '</a></li>');
            }
            li.push('</div></li>');
        }

        $('.book').append(li.join(""));

    }

    return false;
}

