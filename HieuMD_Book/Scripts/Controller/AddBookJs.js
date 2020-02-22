$("#btnAddCategory").off('click').on('click', function (e){
    e.preventDefault();
    var authorObj = {
        CateName: $('#CategoryName').val(),
        Description: $('#CategoryDescription').val(),
    };
    $.ajax({
        url: "/Category/AddModal",
        data: JSON.stringify(authorObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status) {
                $('#CateId').append(new Option(result.data.CateName, result.data.CateId, true, true));
                //updateDropdown(result.cateId, authorObj.CateName);
                $('#modalAuthorAdd').modal('hide');
                resset('#CategoryName', '#CategoryDescription');

            }
            else {
                alert(result.responseText);
            }
        },
    });
})

    




$("#btnAddAuthor").off('click').on('click', function (e) {
    e.preventDefault();

    var authorObj = {
        AuthorName: $('#AuthorName').val(),
        History: $('#History').val(),
    };
    $.ajax({
        url: "/Author/AddAuthor",
        data: JSON.stringify(authorObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status) {
                $('#AuthorID').append(new Option(result.data.AuthorName, result.data.AuthorId, true, true));
                //updateDropdownA(result.AuthorID, authorObj.AuthorName);
                $('#modalAddAuthor').modal('hide');
                resset('#AuthorName', '#History');

            }
            else {
                alert(result.responseText);
            }
        },
    });
})


$("#btnAddPublisher").off('click').on('click', function (e) {
    e.preventDefault();

    var Publisher = {
        Name: $('#Name').val(),
        Description: $('#Description').val(),
    };
    $.ajax({
        url: "/Publisher/AddPublisher",
        data: JSON.stringify(Publisher),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status) {
                $('#PubId').append(new Option(result.data.Name, result.data.PubId, true, true));
                //updateDropdownP(result.PubId, Publisher.Name);
                $('#modalAddPublisher').modal('hide');
                resset('#Name', '#Description');

            }
            else {
                alert(result.responseText);
            }
        },
    });
})


function validate() {
    var isValid = true;
    if ($('#CateName').val().trim() == "") {
        $('#CateName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#CategoryName').css('border-color', 'lightgrey');
    }
}








function resset(input, textarea){
    $(input).val("");
    $(textarea).val("");
}
