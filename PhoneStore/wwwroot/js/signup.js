$(document).ready(function () {


    $('#signupUser').submit(function (e) {

        e.preventDefault();

        $('#signupUser').validate({
            rules: {
                Email: {
                    required: true,
                    email: true
                },
                Pass: {
                    required: true,
                    minlength: 8
                },
                Phone: {
                    required: true,
                    minlength: 10,
                    number: true,
                    maxlength: 10
                },
                RePass: {
                    required: true,
                    equalTo: "#Pass"
                },
                Name: {
                    required: true
                },
            },
            messages: {
                Email: {
                    required: "Nhập Email",
                    email: "Email không hợp lệ"
                },
                Pass: {
                    required: "Nhập mật khẩu",
                    minlength: "Mật khẩu phải dài hơn 6 ký tự"
                    
                },
                Phone: {
                    required: "Nhập điện thoại",
                    minlength: "Số điện thoại không hợp lệ",
                    number: "Số điện thoại không hợp lệ",
                    maxlength: "Số điện thoại không hợp lệ"
                },
                RePass: {
                    required: "Nhập lại mật khẩu",
                    equalTo: "Mật khẩu nhập lại không đúng"
                },
                Name: {
                    required: "Nhập Họ và Tên"
                },
            },
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                element.closest('.validate-input').append(error);
            },
            

        });

        

        if ($('#signupUser').valid()) {
            var data = new FormData(this);
            $.ajax({
                url: "/home/signup",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    console.log(response.isSuccess)
                    if (response.isSuccess === false) {

                        alert(response.message)
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