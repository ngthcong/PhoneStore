/* JS Document */



/******************************

[Table of Contents]

1. Vars and Inits
2. Set Header
3. Init Search
4. Init Menu
5. Init Quantity


******************************/

$(document).ready(function () {
    "use strict";

	/* 

	1. Vars and Inits

	*/

    var header = $('.header');
    var hambActive = false;
    var menuActive = false;

    setHeader();

    $(window).on('resize', function () {
        setHeader();
    });

    $(document).on('scroll', function () {
        setHeader();
    });

    initSearch();
    initMenu();
    initQuantity();

	/* 

	2. Set Header

	*/

    function setHeader() {
        if ($(window).scrollTop() > 100) {
            header.addClass('scrolled');
        }
        else {
            header.removeClass('scrolled');
        }
    }

	/* 

	3. Init Search

	*/

    function initSearch() {
        if ($('.search').length && $('.search_panel').length) {
            var search = $('.search');
            var panel = $('.search_panel');

            search.on('click', function () {
                panel.toggleClass('active');
            });
        }
    }

	/* 

	4. Init Menu

	*/

    function initMenu() {
        if ($('.hamburger').length) {
            var hamb = $('.hamburger');

            hamb.on('click', function (event) {
                event.stopPropagation();

                if (!menuActive) {
                    openMenu();

                    $(document).one('click', function cls(e) {
                        if ($(e.target).hasClass('menu_mm')) {
                            $(document).one('click', cls);
                        }
                        else {
                            closeMenu();
                        }
                    });
                }
                else {
                    $('.menu').removeClass('active');
                    menuActive = false;
                }
            });

            //Handle page menu
            if ($('.page_menu_item').length) {
                var items = $('.page_menu_item');
                items.each(function () {
                    var item = $(this);

                    item.on('click', function (evt) {
                        if (item.hasClass('has-children')) {
                            evt.preventDefault();
                            evt.stopPropagation();
                            var subItem = item.find('> ul');
                            if (subItem.hasClass('active')) {
                                subItem.toggleClass('active');
                                TweenMax.to(subItem, 0.3, { height: 0 });
                            }
                            else {
                                subItem.toggleClass('active');
                                TweenMax.set(subItem, { height: "auto" });
                                TweenMax.from(subItem, 0.3, { height: 0 });
                            }
                        }
                        else {
                            evt.stopPropagation();
                        }
                    });
                });
            }
        }
    }

    function openMenu() {
        var fs = $('.menu');
        fs.addClass('active');
        hambActive = true;
        menuActive = true;
    }

    function closeMenu() {
        var fs = $('.menu');
        fs.removeClass('active');
        hambActive = false;
        menuActive = false;
    }

	/* 

	5. Init Quantity

	*/

    function initQuantity() {
        // Handle product quantity input

        var cartinfo = $(".cart_info");
        var incButton = $('.quantity_inc');
        var form = $('#checkout-form');
        var citiesOption = $('#cities');
        var districOption = $('#district')


        cartinfo.on('click', '.quantity_inc', function () {
            var pid = $(this).data('pid');
            ajaxCart(pid, true)
        });
        cartinfo.on('click', '.delete-item', function () {
            var pid = $(this).data('pid');
            ajaxDelete(pid)
        });

        cartinfo.on('click', '.quantity_dec', function () {
            var pid = $(this).data('pid');
            ajaxCart(pid, false)
        });
        cartinfo.on('change', '.input-variant', function () {
            var pid = $(this).data('pid');
            var vid = $(this).data('vid');

            ajaxVariant(pid, vid)
        });

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
            ajaxCheckOut();
        })


    }

    function ajaxCart(pid, change) {
        var cart_container = $("#cart_container");
        var data = new FormData();
        data.append("pid", pid);
        data.append("change", change);
        $.ajax({
            url: "/product/changecartproduct",
            type: "post",
            cache: false,
            data: data,
            contentType: false,
            processData: false,
            success: function (response) {

                console.log((response.isSuccess));
                if (response.isSuccess === true) {
                    $.get(response.data, function (data) {
                        cart_container.replaceWith(data);
                    });
                    RefreshCartEventListener()
                }
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
    }

    function ajaxDelete(pid) {
        var cart_container = $("#cart_container");
        var data = new FormData();
        data.append("pid", pid);
        $.ajax({
            url: "/product/DeleteFromCart",
            type: "post",
            cache: false,
            data: data,
            contentType: false,
            processData: false,
            success: function (response) {

                console.log((response.isSuccess));
                if (response.isSuccess === true) {
                    $.get(response.data, function (data) {
                        cart_container.replaceWith(data);
                    });
                    RefreshCartEventListener()
                }
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
    }

    function ajaxVariant(pid, vid) {
        var cart_container = $("#cart_container");
        var data = new FormData();
        data.append("pid", pid);
        data.append("vid", vid);
        $.ajax({
            url: "/product/ChangeCartVariant",
            type: "post",
            cache: false,
            data: data,
            contentType: false,
            processData: false,
            success: function (response) {

                console.log((response.isSuccess));
                if (response.isSuccess === true) {
                    $.get(response.data, function (data) {
                        cart_container.replaceWith(data);
                    });
                    RefreshCartEventListener()
                }
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
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



    var url = "";
 

    function ajaxCheckOut() {

        var myForm = $('#checkout-form');

        myForm.validate({
            rules: {
                InvCusName: {
                    required: true,
                },
                InvCusPhone: {
                    required: true,
                    minlength: 10,
                    number: true,
                    maxlength: 10
                },
                InvCusEmail: {
                    required: true,
                    email: true
                },
                InvCityId: {
                    required: true,

                },
                InvDistrictId: {
                    required: true
                },
                InvWardId: {
                    required: true
                },
                InvAddress: {
                    required: true
                },
            },
            messages: {
                InvCusName: {
                    required: "Nhập họ và tên",

                },
                InvCusEmail: {
                    required: "Nhập email",
                    email: "Email không hợp lệ"
                },
                InvCusPhone: {
                    required: "Nhập điện thoại",
                    minlength: "Số điện thoại không hợp lệ",
                    number: "Số điện thoại không hợp lệ",
                    maxlength: "Số điện thoại không hợp lệ"
                },
                InvCityId: {
                    required: "Chọn thành phố",
                    equalTo: "Mật khẩu nhập lại không đúng"
                },
                InvDistrictId: {
                    required: "Chọn quận huyện"
                },
                InvWardId: {
                    required: "Chọn phường xã"
                },
                InvAddress: {
                    required: "Nhập số nhà và đường"
                },
            },
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                element.closest('.input-group1').append(error);
            },


        });
        

        if (myForm.valid()) {
            let form = document.getElementById('checkout-form');
            let formData = new FormData(form);
           
            console.log(formData.get('InvCusName'))

            $.ajax({
                url: "/product/checkout",
                type: "post",
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    console.log(response.isSuccess)
                    if (response.isSuccess === false) {

                        alert(response.message)
                    }
                    if (response.isSuccess === true) {
                        var message = response.message;
                        var array = message.split(".");
                        $('#model-text1').text(array[0])
                        $('#model-text2').text(array[1])

                        $('#modal-default').modal('show');
                        url =  response.data;
                    }
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });
        }



        hidden.bs.modal

    }
    $('#modal-default').on('hidden.bs.modal', function (event) {
        window.location = url;
    })


    function RefreshCartEventListener() {

        var cartinfo = $(".cart_info");
        var citiesOption = $('#cities');
        var districtOption = $('#district');
        var form = $('#checkout-form');
        // Remove handler from existing elements
        cartinfo.off();

        // Re-add event handler for all matching elements

        cartinfo.on('submit', '#checkout-form', function (e) {
            e.preventDefault();
            e.stopImmediatePropagation();
            ajaxCheckOut();
        });
       
        cartinfo.on('click', '.quantity_inc', function () {
            var pid = $(this).data('pid');
            ajaxCart(pid, true)
        });

        cartinfo.on('click', '.quantity_dec', function () {
            var pid = $(this).data('pid');
            ajaxCart(pid, false)
        });
        cartinfo.on('change', '.input-variant', function () {
            var pid = $(this).data('pid');
            var vid = $(this).data('vid');

            ajaxVariant(pid, vid)
        });
        cartinfo.on('change', '#cities', function () {
            ajaxDistrict($(this).val())
        })
        cartinfo.on('change', '#district', function () {
            ajaxWard($(this).val())
        })
        cartinfo.on('click', '.delete-item', function () {
            var pid = $(this).data('pid');
            ajaxDelete(pid)
        });
    }



});