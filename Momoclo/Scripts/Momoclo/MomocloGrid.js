
$(function () {

    $('button').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {


    });


    $("#momoclo").jqGrid({
        editurl: "/Service/MomocloHandler.ashx",
        datatype: function (postData) {
            $.ajax({
                type: "POST",
                url: "/Service/MomocloHandler.ashx",
                success: function (responseData) {
                    var json_res = $.parseJSON(responseData);
                    console.log("response:" + responseData);
                    $("#momoclo")[0].addJSONData(json_res);
                }
            });
        },
        jsonReader: {
            page: "page",
            total: "total",
            records: "records",
            root: "data",
            repeatitems: false,
            id: "id"
        },
        width: 600,
        height: '100%',
        rownumbers: true,
        shrinkToFit: false,
        hidegrid: false,
        pager: "#pager",
        pgbuttons: false,
        pginput: false,
        viewrecords: true,
        colNames: ['id', '色', '名前', '誕生日', '血液型', '出身地', '身長'],
        colModel: [
                    { 'name': 'id', 'index': 'id', 'width': 30, 'editable': true, 'hidden': true },
                    { 'name': 'color', 'width': 80, 'editable': true },
                    { 'name': 'name', 'width': 130, 'editable': true },
                    { 'name': 'birth', //datepickerを表示する
                        'width': 90,
                        'editable': true,
                        'datefmt': "yyyy/mm/dd",
                        'editrules': { date: true },
                        'title': false
                    },
                    { 'name': 'bloodtype', 'width': 50, 'editable': true, 'edittype': "select", 'editoptions': { value: ":;0:A;1:B;2:AB;3:O" }, 'title': false },
                    { 'name': 'birthplace', 'width': 80, 'editable': true },
                    { 'name': 'height', 'width': 50, 'editable': true }
        ],
        caption: 'ももクロ',
        serializeRowData: function (data) {
            $.each(data, function (k, v) {
                console.log(k + ":" + v);
            });

            return data;
        }
    });
    $('#momoclo').jqGrid('navGrid', '#pager', { edit: false, add: false, del: true, search: false });
    $('#momoclo').jqGrid('inlineNav', '#pager', {
        edit: true,
        editicon: "ui-icon-pencil",
        add: true,
        addicon: "ui-icon-plus",
        save: true,
        saveicon: "ui-icon-disk",
        cancel: true,
        cancelicon: "ui-icon-cancel",
        editParams: { oneditfunc: onEdit },
        addParams: {
            "rowID": 0, //初期値
            "addRowParams": {
                oneditfunc: onEdit,
                successfunc: function (response) {
                    $('#momoclo').trigger("reloadGrid"); //リロード

                    return true;
                }                
            }
        }
    }
    );
    $("#momoclo").jqGrid('navButtonAdd', "#pager", {
        caption: "",
        buttonicon: "ui-icon-document",
        title: "document",
        onClickButton: function () {
            $('#documentDialog')
                .empty()
                .append('<ul id="selectable" class="ui-selectable"></ul>');


            var ids = $('#momoclo').jqGrid('getDataIDs');

            var data;
            for (var i = 0; i < ids.length; i++) {
                data = $('#momoclo').jqGrid('getRowData', ids[i]);
                $('<li class="ui-widget-content">' + data.color + ':' + data.name + '</li>')
                    .appendTo('#selectable');
            }
            $('#documentDialog').dialog('open');
            $('#selectable').selectable();
        }
    });

    function onEdit(id) {
        $("#" + id + "_birth").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'yy/mm/dd',
            yearRange: '1970:2100'
        }).addClass("grid-datepicker");
    }

    $("#documentDialog").dialog({
        autoOpen: false,
        resizable: false,
        height: 'auto',
        width: 'auto',
        modal: true
    });
});