
$(function () {

    $('button').button({
        icons: {
            primary: "ui-icon-check"
        }
    }).click(function () {

//        $.ajax({
//            type: "POST",
//            url: "/MomocloHandler.ashx",
//            success: function (responseData) {

//                console.log(responseData);
//                var json_res = $.parseJSON(responseData);
//                console.log(json_res);

//                $("#momoclo")[0].addJSONData(json_res);
//            }
//        });

    });

    //    var data = [
    //        { "color": "Green", "name": "有安杏果" },
    //        { "color": "Pink", "name": "佐々木彩夏" },
    //        { "color": "Red", "name": "百田夏菜子" },
    //        { "color": "Yellow", "name": "玉井詩織" },
    //        { "color": "Purple", "name": "高城れに" }
    //    ];





    $("#momoclo").jqGrid({
        //data: data,
        //datatype: "local",
        editurl: "/MomocloHandler.ashx",
        datatype: function (postData) {

            console.log(postData);
            $.each(postData, function (k, v) {
                console.log(k + ":" + v);
            });

            $.ajax({
                type: "POST",
                url: "/MomocloHandler.ashx",
                success: function (responseData) {
                    console.log("data:" + responseData);
                    var json_res = $.parseJSON(responseData);
                    console.log("JSON:" + json_res);

                    $("#momoclo")[0].addJSONData(json_res);
                }
            });
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
        colNames: ['id','色', '名前', '誕生日', '血液型', '出身地', '身長'],
        colModel: [
                    { 'name': 'id', 'width': 30, 'editable': false, 'hidden': false },
                    { 'name': 'color', 'width': 80, 'editable': true },
                    { 'name': 'name', 'width': 130, 'editable': true },
                    //datepickerを表示する
                    {'name': 'birth',
                    'width': 90,
                    'editable': true,
                    'datefmt': "yyyy/mm/dd",
                    editrules: { date: true },
                    'title': false
                },
                    { 'name': 'bloodtype', 'width': 50, 'editable': true, 'edittype': "select", 'editoptions': { value: ":;0:A;1:B;2:AB;3:O" }, 'title': false },
                    { 'name': 'birthplace', 'width': 80, 'editable': false },
                    { 'name': 'height', 'width': 50, 'editable': false }
        ],
        caption: 'ももクロ',
        serializeRowData: function (data) {
            console.log(data);
            $.each(data,function(k,v){
                console.log(k + ":" + v);
            });

            $.ajax({
                type: "POST",
                url: "/MomocloHandler.ashx",
                data: data,
                success: function (responseData) {
                    console.log("data:" + responseData);

                }
            });

        },
    });
    $('#momoclo').jqGrid('navGrid', '#pager', { edit: false, add: false, del: true, search: true });
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
        addParams: { addRowParams: { oneditfunc: onEdit} }
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