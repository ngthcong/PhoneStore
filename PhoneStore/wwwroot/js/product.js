/* JS Document */



/******************************

[Table of Contents]

1. Vars and Inits
2. Set Header
3. Init Search
4. Init Menu
5. Init Image
6. Init Quantity
7. Init Isotope


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
        info_responsive()
    });

    $(document).on('scroll', function () {
        setHeader();
    });

    initSearch();
    initMenu();
    initImage();
    initQuantity();
    initIsotope();
    info_responsive();
    ajaxImage();

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

	5. Init Image

	*/

    function initImage() {
        var images = $('.details_image_thumbnail');
        var selected = $('.details_image_large img');

        images.each(function () {
            var image = $(this);
            image.on('click', function () {
                var imagePath = new String(image.data('image'));
                selected.attr('src', imagePath);
                images.removeClass('active');
                image.addClass('active');
            });
        });
    }

	/* 

	6. Init Quantity

	*/

    function initQuantity() {
        // Handle product quantity input
        if ($('.product_quantity').length) {
            var input = $('#quantity_input');
            var incButton = $('#quantity_inc_button');
            var decButton = $('#quantity_dec_button');

            var originalVal;
            var endVal;

            incButton.on('click', function () {
                originalVal = input.val();
                endVal = parseFloat(originalVal) + 1;
                input.val(endVal);
            });

            decButton.on('click', function () {
                originalVal = input.val();
                if (originalVal > 0) {
                    endVal = parseFloat(originalVal) - 1;
                    input.val(endVal);
                }
            });
        }
    }

	/* 

	7. Init Isotope

	*/

    function initIsotope() {
        var sortingButtons = $('.product_sorting_btn');
        var sortNums = $('.num_sorting_btn');

        if ($('.product_grid').length) {
            var grid = $('.product_grid').isotope({
                itemSelector: '.product',
                layoutMode: 'fitRows',
                fitRows:
                {
                    gutter: 30
                },
                getSortData:
                {
                    price: function (itemElement) {
                        var priceEle = $(itemElement).find('.product_price').text().replace('$', '');
                        return parseFloat(priceEle);
                    },
                    name: '.product_name',
                    stars: function (itemElement) {
                        var starsEle = $(itemElement).find('.rating');
                        var stars = starsEle.attr("data-rating");
                        return stars;
                    }
                },
                animationOptions:
                {
                    duration: 750,
                    easing: 'linear',
                    queue: false
                }
            });
        }
    }



    function info_responsive() {
        var width = $(window).width();
        console.log(width);
        if (width <= 768) {
            $("#des").before($("#info"));
        }
        if (width >= 769) {
            $("#info").before($("#des"));
        }
    }

    function ajaxImage() {
        var icon = $('.fs-dticolor-img li');


        icon.each(function () {
            var image = $(this);
            image.on('click', function () {
                var vid = image.data('vid');
                $.ajax({
                    url: "/product/variantimage?vid=" + vid,
                    type: "get",
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (response) {

                        console.log((response.isSuccess));
                        if (response.isSuccess === true) {
                            $(".details_image_large img").attr('src',"/" + response.data[0].image);
                            var length = response.data.length;
                            var data = response.data;
                            for (var i = 0; i < length; i++) {
                                console.log(data[i].index);
                                $("#image_" + data[i].index).data("image","/"+ data[i].image)
                                $("#image_" + data[i].index).find("img").attr("src","/"+ data[i].image)
                            }
                        }
                    },
                    error: function (xhr, error, status) {
                        console.log(error, status);
                    }
                });
            });

        });
    }
    $("#addtocart").click(function () {
        var id = $(this).data('pid');
        console.log(id)
        var data = new FormData();
        data.append("pid", id);
        $.ajax({
            url: "/product/addcart",
            type: "post",
            cache: false,
            data: data,
            contentType: false,
            processData: false,
            success: function (response) {

                console.log((response.isSuccess));
                if (response.isSuccess === true) {
                    window.location.replace(response.data);
                }
            },
            error: function (xhr, error, status) {
                console.log(error, status);
            }
        });
    })



});