
$(document).ready(function () {
    var pform = $('#p-form');
    var hpform = $('#hp-form');
    var cgform = $('#cg-form');
    var pbform = $('#pb-form');
    var lform = $('#l-form');

    var url = "";




    var phonediv = $('#p-div');
    var chargerdiv = $('#cg-div');
    var pbankdiv = $('#pb-div'); 
    var hpdiv = $('#hp-div');
    var ldiv = $('#l-div');


    $('#pro-select').change(function () {
        console.log($('#pro-select').val())
        if ($('#pro-select').val() == "1") {
            pbankdiv.removeClass('show', 1);
            hpdiv.removeClass('show', 1);
            chargerdiv.removeClass('show', 1);
            ldiv.removeClass('show', 1);
            phonediv.toggleClass('show', true)
        }
        if ($('#pro-select').val() == "2") {
            pbankdiv.removeClass('show', 1);
            hpdiv.removeClass('show', 1);
            phonediv.removeClass('show', 1);
            ldiv.removeClass('show', 1);
            chargerdiv.toggleClass('show', true)
        }
        if ($('#pro-select').val() == "3") {
            pbankdiv.removeClass('show', 1);
            chargerdiv.removeClass('show', 1);
            phonediv.removeClass('show', 1);
            ldiv.removeClass('show', 1);
            hpdiv.toggleClass('show', true);
        }
        if ($('#pro-select').val() == "4") {
            hpdiv.removeClass('show', 1);
            chargerdiv.removeClass('show', 1);
            phonediv.removeClass('show', 1);
            ldiv.removeClass('show', 1);
            pbankdiv.toggleClass('show', true);
        }
        if ($('#pro-select').val() == "5") {
            hpdiv.removeClass('show', 1);
            chargerdiv.removeClass('show', 1);
            phonediv.removeClass('show', 1);
            pbankdiv.removeClass('show', 1);
            ldiv.toggleClass('show', true);
        }
    })
  










    pform.submit(function (e) {
        e.preventDefault();
        pform.validate({
            rules: {
                proName: {
                    required: true,
                },
                proBrandId: {
                    required: true
                },
                proImageStream: {
                    required: true
                },
                proRetailPrice: {
                    required: true
                },
                pScreen: {
                    required: true
                },
                pFrontCam: {
                    required: true
                },
                pRearCam: {
                    required: true
                },
                pCPU: {
                    required: true
                },
                pRAM: {
                    required: true
                },
                pGPU: {
                    required: true
                },
                pROM: {
                    required: true
                },
                pStorage: {
                    required: true
                },
                pSensor: {
                    required: true
                },
                pSimType: {
                    required: true
                },
                pConnect: {
                    required: true
                },
                pBattery: {
                    required: true
                },
                pWarranty: {
                    required: true
                },
                pOrigin: {
                    required: true
                },
                pYOM: {
                    required: true
                },
                pImageStream: {
                    required: true
                },


            },
            messages: {
                proName: {
                    required: "Không được bỏ trống ô này",

                },
                proBrandId: {
                    required: "Không được bỏ trống ô này"
                },
                proImageStream: {
                    required: "Không được bỏ trống ô này"
                },
                proRetailPrice: {
                    required: "Không được bỏ trống ô này"
                },
                pScreen: {
                    required: "Không được bỏ trống ô này"
                },
                pFrontCam: {
                    required: "Không được bỏ trống ô này"
                },
                pRearCam: {
                    required: "Không được bỏ trống ô này"
                },
                pCPU: {
                    required: "Không được bỏ trống ô này"
                },
                pRAM: {
                    required: "Không được bỏ trống ô này"
                },
                pGPU: {
                    required: "Không được bỏ trống ô này"
                },
                pROM: {
                    required: "Không được bỏ trống ô này"
                },
                pStorage: {
                    required: "Không được bỏ trống ô này"
                },
                pSensor: {
                    required: "Không được bỏ trống ô này"
                },
                pSimType: {
                    required: "Không được bỏ trống ô này"
                },
                pConnect: {
                    required: "Không được bỏ trống ô này"
                },
                pBattery: {
                    required: "Không được bỏ trống ô này"
                },
                pWarranty: {
                    required: "Không được bỏ trống ô này"
                },
                pOrigin: {
                    required: "Không được bỏ trống ô này"
                },
                pYOM: {
                    required: "Không được bỏ trống ô này"
                },
                pImageStream: {
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
        if (pform.valid()) {
            var input = $('#p-form .spec-info input[type=text]')

            addSpecIndex(input);

            var data = new FormData(this);
            disableElements(pform)

            for (var value of data.values()) {
                console.log(value
                );
            }
            $.ajax({
                url: "/admin/addphone",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess === true) {
                        enableElements(pform)
                        resetInput(pform)
                        window.location = response.data;
                    }
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });

        }


    })


    lform.submit(function (e) {
        e.preventDefault();
        lform.validate({
            rules: {
                proName: {
                    required: true,
                },
                proBrandId: {
                    required: true
                },
                proImageStream: {
                    required: true
                },
                proRetailPrice: {
                    required: true
                },
                lScreen: {
                    required: true
                },
              
                lCPU: {
                    required: true
                },
                lRAM: {
                    required: true
                },
                lGPU: {
                    required: true
                },
                lOS: {
                    required: true
                },
                lStorage: {
                    required: true
                },
                
                lWeight: {
                    required: true
                },
                lDimension: {
                    required: true
                },
                lBattery: {
                    required: true
                },
                lWarranty: {
                    required: true
                },
                lOrigin: {
                    required: true
                },
                lYOM: {
                    required: true
                },

            },
            messages: {
                proName: {
                    required: "Không được bỏ trống ô này",
                },
                proBrandId: {
                    required: "Không được bỏ trống ô này"
                },
                proImageStream: {
                    required: "Không được bỏ trống ô này"
                },
                proRetailPrice: {
                    required: "Không được bỏ trống ô này"
                },
                lScreen: {
                    required: "Không được bỏ trống ô này"
                },
                lCPU: {
                    required: "Không được bỏ trống ô này"
                },
                lRAM: {
                    required: "Không được bỏ trống ô này"
                },
                lGPU: {
                    required: "Không được bỏ trống ô này"
                },
                lOS: {
                    required: "Không được bỏ trống ô này"
                },
                lStorage: {
                    required: "Không được bỏ trống ô này"
                },
                lWeight: {
                    required: "Không được bỏ trống ô này"
                },
                lDimension: {
                    required: "Không được bỏ trống ô này"
                },
                lBattery: {
                    required: "Không được bỏ trống ô này"
                },
                lWarranty: {
                    required: "Không được bỏ trống ô này"
                },
                lOrigin: {
                    required: "Không được bỏ trống ô này"
                },
                lYOM: {
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
        if (lform.valid()) {
            var input = $('#l-form .spec-info input[type=text]')

            addSpecIndex(input);

            var data = new FormData(this);
            disableElements(lform)

            for (var value of data.values()) {
                console.log(value
                );
            }
            $.ajax({
                url: "/admin/addlaptop",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess === true) {
                        enableElements(lform)
                       resetInput(lform)
                        window.location = response.data;
                    }
                    
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });

        }


    })


    cgform.submit(function (e) {
        e.preventDefault();
        cgform.validate({
            rules: {

                proName: {
                    required: true,
                },
                proBrandId: {
                    required: true
                },
                proRetailPrice: {
                    required: true
                },
                proImageStream: {
                    required: true
                },
                cgmaterial: {
                    required: true
                },
                cgconnect: {
                    required: true
                },
                cgamperage: {
                    required: true
                },
                cgcblengh: {
                    required: true
                },
                cgtype: {
                    required: true
                },
                cgmodel: {
                    required: true
                },
                cgport: {
                    required: true
                },
                cgwarranty: {
                    required: true
                },
                cgfeature: {
                    required: true
                },
                cgorigin: {
                    required: true
                },
            },
            messages: {
                proName: {
                    required: "Không được bỏ trống ô này"
                },
                proBrandId: {
                    required: "Không được bỏ trống ô này"
                },
                proRetailPrice: {
                    required: "Không được bỏ trống ô này"
                },
                proImageStream: {
                    required: "Không được bỏ trống ô này"
                },
                cgmaterial: {
                    required: "Không được bỏ trống ô này"
                },
                cgconnect: {
                    required: "Không được bỏ trống ô này"
                },
                cgamperage: {
                    required: "Không được bỏ trống ô này"
                },
                cgcblengh: {
                    required: "Không được bỏ trống ô này"
                },
                cgtype: {
                    required: "Không được bỏ trống ô này"
                },
                cgmodel: {
                    required: "Không được bỏ trống ô này"
                },
                cgport: {
                    required: "Không được bỏ trống ô này"
                },
                cgwarranty: {
                    required: "Không được bỏ trống ô này"
                },
                cgfeature: {
                    required: "Không được bỏ trống ô này"
                },
                cgorigin: {
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
        if (cgform.valid()) {
            var input = $('#cg-form .spec-info input[type=text]')

            addSpecIndex(input);
            var data = new FormData(this);
            disableElements(cgform)

            for (var value of data.values()) {
                console.log(value
                );
            }
            $.ajax({
                url: "/admin/addcharger",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess === true) {
                        enableElements(cgform)
                        resetInput(cgform)
                        window.location = response.data;
                    }
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });

        }


    })


    hpform.submit(function (e) {
        e.preventDefault();
        hpform.validate({
            rules: {

                proName: {
                    required: true,
                },

                proRetailPrice: {
                    required: true
                },
                proBrandId: {
                    required: true
                },
                proImageStream: {
                    required: true
                },
                hpconType: {
                    required: true
                },
                hpType: {
                    required: true
                },
                hpcolor: {
                    required: true
                },
                hpfrequency: {
                    required: true
                },
                hpwarranty: {
                    required: true
                },
                hpfeature: {
                    required: true
                },
                hpimpedance: {
                    required: true
                },
                hporigin: {
                    required: true
                },

            },
            messages: {
                proName: {
                    required: "Không được bỏ trống ô này"
                },
                proBrandId: {
                    required: "Không được bỏ trống ô này"
                },
                proRetailPrice: {
                    required: "Không được bỏ trống ô này"
                },
                proImageStream: {
                    required: "Không được bỏ trống ô này"
                },
                hpconType: {
                    required: "Không được bỏ trống ô này"
                },
                hpType: {
                    required: "Không được bỏ trống ô này"
                },
                hpcolor: {
                    required: "Không được bỏ trống ô này"
                },
                hpfrequency: {
                    required: "Không được bỏ trống ô này"
                },
                hpwarranty: {
                    required: "Không được bỏ trống ô này"
                },
                hpfeature: {
                    required: "Không được bỏ trống ô này"
                },
                hpimpedance: {
                    required: "Không được bỏ trống ô này"
                },
                hporigin: {
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
        if (hpform.valid()) {
            var input = $('#hp-form .spec-info input[type=text]')

            addSpecIndex(input);
            var data = new FormData(this);
            disableElements(hpform)

            for (var value of data.values()) {
                console.log(value
                );
            }
            $.ajax({
                url: "/admin/addheadphone",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess === true) {
                        enableElements(hpform)
                        resetInput(hpform)
                        window.location = response.data;
                    }
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
                }
            });

        }


    })

    pbform.submit(function (e) {
        e.preventDefault();
        pbform.validate({
            rules: {

                proName: {
                    required: true,
                },
                proBrandId: {
                    required: true
                },
                proRetailPrice: {
                    required: true
                },
                proImageStream: {
                    required: true
                },
                pbmaterial: {
                    required: true
                },
                pbportOut: {
                    required: true
                },
                pbportIn: {
                    required: true
                },
                pbreliability: {
                    required: true
                },
                pbcapacity: {
                    required: true
                },
                pbchargeTime: {
                    required: true
                },
                pbcell: {
                    required: true
                },
                pbmodel: {
                    required: true
                },
                pboutput: {
                    required: true
                },
                pbcolor: {
                    required: true
                },
                pbinput: {
                    required: true
                },
                pbwarranty: {
                    required: true
                },
                pbchargeTime: {
                    required: true
                },
                pbportNum: {
                    required: true
                },
                pbfeature: {
                    required: true
                },
                pborigin: {
                    required: true
                },


            },
            messages: {
                proName: {
                    required: "Không được bỏ trống ô này",
                },

                proBrandId: {
                    required: "Không được bỏ trống ô này"
                },
                proRetailPrice: {
                    required: "Không được bỏ trống ô này"
                },
                proImageStream: {
                    required: "Không được bỏ trống ô này"
                },
                pbmaterial: {
                    required: "Không được bỏ trống ô này"
                },
                pbportOut: {
                    required: "Không được bỏ trống ô này"
                },
                pbportIn: {
                    required: "Không được bỏ trống ô này"
                },
                pbreliability: {
                    required: "Không được bỏ trống ô này"
                },
                pbcapacity: {
                    required: "Không được bỏ trống ô này"
                },
                pbchargeTime: {
                    required: "Không được bỏ trống ô này"
                },
                pbcell: {
                    required: "Không được bỏ trống ô này"
                },
                pbmodel: {
                    required: "Không được bỏ trống ô này"
                },
                pboutput: {
                    required: "Không được bỏ trống ô này"
                },
                pbcolor: {
                    required: "Không được bỏ trống ô này"
                },
                pbinput: {
                    required: "Không được bỏ trống ô này"
                },
                pbwarranty: {
                    required: "Không được bỏ trống ô này"
                },
                pbchargeTime: {
                    required: "Không được bỏ trống ô này"
                },
                pbportNum: {
                    required: "Không được bỏ trống ô này"
                },
                pbfeature: {
                    required: "Không được bỏ trống ô này"
                },
                pborigin: {
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
        if (pbform.valid()) {
            var input = $('#pb-form .spec-info input[type=text]')

            addSpecIndex(input);
            var data = new FormData(this);
            disableElements(pbform)

            for (var value of data.values()) {
                console.log(value
                );
            }
            $.ajax({
                url: "/admin/addpowerbank",
                type: "post",
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess === true) {
                        enableElements(pbform)
                        resetInput(pbform)
                        window.location = response.data;
                    }
                },
                error: function (xhr, error, status) {
                    console.log(error, status);
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