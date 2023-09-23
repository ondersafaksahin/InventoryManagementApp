//$(document).ready(function () {
//    GetCategorys();
//});

//function GetCategorys(){
//    $.ajax({
//        url:'/good/GetCategorys',
//        type:'get',
//        datatype:'json',
//        contentType: 'application/json;charset=utf-8',
//        success: function (response) {
//            if (response == null || response == undefined || response.length == 0) {
//                var object = '';
//                object += '<tr>';
//                object += '<td colspan="3">' + 'Categorys not available' + '</td>';
//                object += '<tr>';
//                $('#tblBody').html(object);
//            }
//            else {
//                var object = '';
//                $.each(response, function (index, item) {
//                    object += '<tr>';
//                    object += '<td>' + item.id +'</td>';
//                    object += '<td>' + item.Name +'</td>';
//                    object += '<td>' + item.Description +'</td>';
//                    object += '<td><a href="#" class="btn btn-primary btn-sm" onclick="Edit(' + item.id + ')">Edit</a> <a href="#" class="btn btn-dange btn-sm" onclick="Delete(' + item.id + ')">Delete</a></td>';
                    
//                });
//                $('#tblBody').html(object);
//            }
//        },
//        error: function () { 
//            alert('Unable to read the data');
//        }
//    });
//}

$('#btnAdd').click(function () {
    $('#CategoryModal').modal('show');
    $('modalTitle').text('Add Category');
});


function Insert() {
    var formData = new Object();
    formData.id = $('#ID').val();
    formData.Name = $('#Name').val();
    formData.Description = $('#Description').val();

    $.ajax({
        url: '/good/Insert',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save the data.');
            }
            else {
                GetCategorys();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to save the data.');
        }

    });
}