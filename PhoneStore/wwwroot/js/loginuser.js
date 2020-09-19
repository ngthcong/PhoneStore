$(document).ready(function () {


    $('#loginUser').submit(function (e) {

        e.preventDefault();

        $('#loginUser').validate({
            rules: {
                Email: {
                    required: true
                },
                Pass: {
                    required: true
                },
            },
            messages: {
                Email: {
                    required: "Nhập Email đăng nhập"
                },
                Pass: {
                    required: "Nhập mật khẩu"
                },
            },
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                element.closest('.validate-input').append(error);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).addClass('is-invalid');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).removeClass('is-invalid');
            },

        });

        $('#alert').remove();

        if ($('#loginUser').valid()) {
            var data = new FormData(this);
            $.ajax({
                url: "/home/login",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    console.log(response.isSuccess)
                    if (response.isSuccess === false) {
                        var div = document.createElement('div');
                        div.textContent = response.message;
                        div.setAttribute('class', 'alert alert-warning');
                        div.setAttribute('id', 'alert');
                        $('#error').append(div);
                        console.log(response.message)
                    }
                    if (response.isSuccess === true) {
                        window.location = response.data;
                    }
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });
        }
    })
})