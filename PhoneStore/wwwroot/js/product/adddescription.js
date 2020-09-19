$(document).ready(function () {



    $('#text-editor').summernote()





    $('#upload').click(function () {

        var textHTML = $('#text-editor').summernote('code');
        var proid = $('#proid').val();
        console.log(textHTML);
        var data = new FormData();
        data.append("proid", proid)
        data.append("description", textHTML)
        $.ajax({
            url: "/admin/uploaddescription",
            type: "post",
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                
                alert("Them sam pham thanh cong")
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
    })











})