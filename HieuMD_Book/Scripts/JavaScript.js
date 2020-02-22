function checkValid() {
    var item = document.getElementsByClassName('form-control1');
    var item1 = document.getElementsByClassName('check-input');
    var valid = true;
    for (var i = 0; i < item.length; i++) {
        if (item[i].value == "") {
            item[i].style.border = '1px solid red';
            item1[i].style.display = 'block';
            valid = false;
        }
        if (item[i].value != "") {
            item[i].style.border = '1px solid #ccc';
            item1[i].style.display = 'none';

        }
    }
    return valid;
}

function checkValid1() {
    var item = document.getElementsByClassName('form-control1');
  
    var valid = true;
    for (var i = 0; i < item.length; i++) {
        if (item[i].value == "") {
            item[i].style.border = '5px solid cyan';
            valid = false;
        }
        if (item[i].value != "") {
            item[i].style.border = '1px solid #ccc';

        }
    }
    return valid;
}







function Add() {
    
    var empObj = {                                                                                                                                                               
        Name: $('#AuthorName').val(),
        History: $('#History').val(),
  
    };
    $.ajax({
        url: "/Author/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



$('#vehicleChkBox').change(function () {
    cb = $(this);
    cb.val(cb.prop('checked'));
});



function clearTextBox() {
    $('#AuthorName').val("");
    $('#History').val("");
    $('#AuthorName').css('border-color', 'lightgrey');
    $('#History').css('border-color', 'lightgrey');
  
}
