function onChange(e) {
    Recaptcha.create("6Lfem_gSAAAAAEt4qMbtKzPNamKixaU1AvPBG4zE", 'recaptcha', { theme: 'custom', custom_theme_widget: 'recaptcha_widget' });

    var container = $('.form-horizontal'),
        validatable = e.sender.editable.validatable;

    validatable.validate = function () {
        return container.valid();
    };
    validatable.validateInput = function () {
        return true;
    };

    $.validator.unobtrusive.parse(container);
    $(container).validate();
}

$(function () {
    $("#grid").kendoGrid({
        dataSource: {
            type: "odata",
            transport: {
                read: {
                    url: "/odata/msgs",
                    dataType: "json",
                    accepts: {
                        json: "application/json;odata=verbose",
                    }
                },
                create: {
                    url: "/odata/msgs",
                    dataType: "json",
                    accepts: {
                        json: "application/json;odata=verbose",
                    },
                    headers: {
                        "X-XSRF-Token": $('[name=__RequestVerificationToken]').val(),
                    },
                    data: function () {
                        return {
                            recaptcha_challenge_field: $('#recaptcha_challenge_field').val(),
                            recaptcha_response_field: $('#recaptcha_response_field').val()
                        };
                    }
                },
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { defaultValue: 0 },
                        UserName: { type: "string" },
                        Email: { type: "string" },
                        HomePage: { type: "string" },
                        Text: { type: "string" },
                        Date: { type: "date", editable: false }
                    }
                }
            },
            error: function (e) {
                Recaptcha.reload();
                var responseJSON = e.xhr.responseJSON;

                if (responseJSON) {
                    var errorMsg = responseJSON.error.innererror.message,
                        re = /[а-яёa-z0-9_\x20]+\s\:\s[а-яёa-z0-9_\x20]+/ig,
                        errors = errorMsg.match(re),
                        errObj = {},
                        validator = $('.form-horizontal').validate();

                    $(errors).each(function (i, v) {
                        var paths = v.split(' : ');
                        errObj[paths[0]] = paths[1];
                    });

                    validator.showErrors(errObj);
                }
            },
            pageSize: 25,
            serverPaging: true,
            serverSorting: true,
            sort: { field: "Date", dir: "desc" }
        },
        sortable: true,
        pageable: true,
        batch: false,
        toolbar: ["create"],
        editable: {
            mode: "popup",
            template: kendo.template($("#popup_editor").html()),
            window: {
                title: "Добавление новой записи"
            }
        },
        columns:
        [
        {
            field: "UserName",
            title: "Имя",
            width: 120
        },
        {
            field: "Email",
            width: 200
        },
        {
            field: "HomePage",
            title: "Домашняя страница",
            sortable: false,
            width: 200

        },
        {
            field: "Date",
            title: "Дата",
            format: "{0:dd.MM.yyyy HH:mm}",
            width: 130
        },
        {
            field: "Text",
            title: "Сообщение",
            sortable: false
        }
        ],
        edit: onChange
    });
});