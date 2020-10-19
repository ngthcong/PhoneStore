$(document).ready(function () {

    var timeout = null;
    $(document).on("click", function (e) {
        if ($(e.target).is("#search-input,#SearchData") === false) {
            $("#SearchData").removeClass("open");
        }
    });
    $("#search-input").on("keyup", function () {

        clearTimeout(timeout);

        timeout = setTimeout(function () {
            var k = $("#search-input").val().trim();
            if (k.length == 0) {
                $(".search-list").removeClass("open");
            }
            else {
                var SearchData = $("#SearchData");

                SearchData.html("");
                $.ajax({
                    type: "get",
                    url: "/api/search/" + k,
                    contentType: "html",
                    success: function (result) {


                        if (result.length == 2) {

                            var data = '<div class="search-item">' +

                                '<p>Không tìm thấy kết quả nào </p>' +


                                '</div>';

                            SearchData.append(data);
                        }
                        else {


                            $.each(result, function (index, value) {
                                var price;
                                if (value.proSalePrice === null) {
                                    price = value.proRetailPrice
                                }
                                else {
                                    price = value.proSalePrice
                                }
                                price = new Intl.NumberFormat('it-IT', { style: 'currency', currency: 'VND' }).format(price)
                                new Intl.NumberFormat('it-IT', { style: 'currency', currency: 'VND' }).format(1200000)
                                var data2 = '<div class="search-item">' +
                                    '<a href="/Product/ProductInfo?pid=' + value.proId + '">' +
                                    '<img class="image" src="' + value.proImage + '"></img><div class="info">' +
                                    '<p>' + value.proName + '</p>' +
                                    '<p>' + price + '</p>' +
                                   

                                    '</div></a></div>';

                                SearchData.append(data2);
                            });
                        }
                    }
                })
                $(".search-list").toggleClass("open", true);
            }

        }, 1000);



    })

})