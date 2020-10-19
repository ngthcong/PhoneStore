$(document).ready(function () {
    var form = $("#form");
    var citiesOption = $('#cities');
    var districOption = $('#district')
 
    citiesOption.change(function () {

        var cid = $(this).val()
        var districElement = $('#district')
        var wardElement = $('#ward')
        districElement.empty();
        wardElement.empty();
        (wardElement).prop("disabled", true);
        (districElement).prop("disabled", true);
        ajaxDistrict(cid)
    })
    districOption.change(function () {

        var did = $(this).val()

        var wardElement = $('#ward')

        wardElement.empty();
        (wardElement).prop("disabled", true);

        ajaxWard(did)
    })

    form.submit(function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
        ajaxCreate();
    })


    function ajaxCreate() {
        console.log("Click")
        var form = $("#form");
        form.validate({
            rules: {
                AccName: {
                    required: true,
                },
                AccPhone: {
                    required: true,
                    minlength: 10,
                    number: true,
                    maxlength: 10
                },
                AccEmail: {
                    required: true,
                    email: true
                },
                AccCityId: {
                    required: true,
                },
                AccDistrictId: {
                    required: true
                },
                AccWardId: {
                    required: true
                },
                AccAddress: {
                    required: true
                },
                AccRoleId: {
                    required: true
                },
                AccPass: {
                    required: true
                },
            },
            messages: {
                AccName: {
                    required: "Nhập họ và tên",

                },
                AccEmail: {
                    required: "Nhập email",
                    email: "Email không hợp lệ"
                },
                AccPhone: {
                    required: "Nhập điện thoại",
                    minlength: "Số điện thoại không hợp lệ",
                    number: "Số điện thoại không hợp lệ",
                    maxlength: "Số điện thoại không hợp lệ"
                },
                AccCityId: {
                    required: "Chọn thành phố",
                    equalTo: "Mật khẩu nhập lại không đúng"
                },
                AccDistrictId: {
                    required: "Chọn quận huyện"
                },
                AccWardId: {
                    required: "Chọn phường xã"
                },
                AccAddress: {
                    required: "Nhập số nhà và đường"
                },
                AccRoleId: {
                    required: "Chọn"
                },
                AccPass: {
                    required: "Nhập mật khẩu"
                },
            },
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                element.closest('.form-group').append(error);
            },


        });

        console.log(form.valid())
        if (form.valid()) {
            let formEmp = document.getElementById('form');
            let formData = new FormData(formEmp);

            for (var value of formData.values()) {
                console.log(value);
            }

            $.ajax({
                url: "/admin/addemployee",
                type: "post",
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    console.log(response.status)
                    if (response.status === 409) {

                        alert("Email đã tồn tại")
                    }
                    if (response.status === 200) {
                        alert("Thêm nhân viên thành công")
                    }
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });
        }




    }


    function ajaxDistrict(cid) {
        var optionElement = $('#district')
        var wardElement = $('#ward')
        $.ajax({
            url: "/product/getdistrict?cid=" + cid,
            type: "get",
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {

                console.log((response.isSuccess));
                if (response.isSuccess === true) {
                    var blankOption = '<option value="" disabled selected hidden></option>';
                    optionElement.append(blankOption);
                    const array = response.data;
                    //for (i = 0; i < array.length; i++) {}
                    array.forEach((element, index) => {
                        var option = ' <option value="' + element.districtId + '">' + element.districtName + '</option>'
                        optionElement.append(option);
                        console.log(element.districtId)
                    });

                    // var options = 
                    (optionElement).prop("disabled", false);
                    wardElement.empty();
                    (wardElement).prop("disabled", true);
                    RefreshCartEventListener()
                }
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
    }
    function ajaxWard(did) {
        var optionElement = $('#ward')
        $.ajax({
            url: "/product/getward?did=" + did,
            type: "get",
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {

                console.log((response.isSuccess));
                if (response.isSuccess === true) {
                    var blankOption = '<option value="" disabled selected hidden></option>';
                    optionElement.append(blankOption);
                    const array = response.data;

                    array.forEach((element, index) => {
                        var option = ' <option value="' + element.wardId + '">' + element.wardName + '</option>'
                        optionElement.append(option);
                        console.log(element.wardId)
                    });

                    (optionElement).prop("disabled", false);

                    RefreshCartEventListener()
                }
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
    }



    function RefreshCartEventListener() {

        var container = $("#containter");
  
        // Remove handler from existing elements
        container.off();

        // Re-add event handler for all matching elements

        container.on('submit', '#form', function (e) {
            e.preventDefault();
            e.stopImmediatePropagation();
            ajaxCreate();
        });
        container.on('change', '#cities', function () {
            ajaxDistrict($(this).val())
        })
        container.on('change', '#district', function () {
            ajaxWard($(this).val())
        })
    
    }
})