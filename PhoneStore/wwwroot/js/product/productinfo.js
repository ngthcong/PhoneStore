
$(document).ready(function () {
  
    var form = $('#form');



    form.submit(function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
        form.validate({
            rules: {
                ProName: {
                    required: true,
                },
                
                ProRetailPrice: {
                    required: true
                },
               
                ProStatus: {
                    required: true
                },

            },
            messages: {
                ProName: {
                    required: "Không được bỏ trống ô này",

                },
                ProRetailPrice: {
                    required: "Không được bỏ trống ô này"
                },
               
                ProStatus: {
                    required: "Không được bỏ trống ô này"
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
                url: "/admin/updateproduct",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess === false) {
                        alert(response.message)
                    }
                    if (response.isSuccess === true) {
                        alert(response.message)
                    }

            

                    
                },
                error: function (xhr, error, status) {
                    alert("Đã có lỗi xảy ra, vui lòng thử lại sau")
                }
            });

        }


    })


  

    function addSpecIndex(input) {
        $(input).val(function (index, val) {
            return $(this).data('spec') + "//" + val;
        });
    }

    function disableElements(e) {
        $(e).find('*').attr('disabled', true);
    }
    function enableElements(e) {
        $(e).find('*').attr('disabled', false);
    }

    function resetInput(e) {
        $(e).find("option:selected").prop("selected", false);
        $(e).find("option:first").prop("selected", "selected");
        $(e).find("input[type!='hidden']").val('');
    }

})