$(document).ready(function () {


    var form = $('#addvariant');


    form.submit(function (e) {
        e.preventDefault();
        form.validate({
            rules: {
                color: {
                    required: true,

                },
                colorIcon: {
                    required: true,

                },
                proColorImage: {
                    required: true
                },
                proQty: {
                    required: true
                },
                proStatus: {
                    required: true
                },


            },
            messages: {
                color: {
                    required: "Không được bỏ trống ô này",

                },
                colorIcon: {
                    required: "Không được bỏ trống ô này",

                },
                proColorImage: {
                    required: "Không được bỏ trống ô này",
                },
                proQty: {
                    required: "Không được bỏ trống ô này",
                },
                proStatus: {
                    required: "Không được bỏ trống ô này",
                },


            },
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                element.closest('.form-group').append(error);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).addClass('is-invalid');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).removeClass('is-invalid');
            }
        });
        if (form.valid()) {
            var data = new FormData(this);


            for (var value of data.values()) {
                console.log(value
                );
            }
            $.ajax({
                url: "/admin/addvariant",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    alert("Thêm phiên bản sản phẩm thành công")
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });

        }





    })
})