$(document).ready(function () {

    $('#invoiceReport').click(function () {


        var month = $('#month-select').val()
        console.log(month)
        window.location = "https://localhost:44330/Admin/InvoiceReport?m=" + month
    })
    $('#productReport').click(function () {

        window.location = "https://localhost:44330/Admin/ProductReport"
    })
})