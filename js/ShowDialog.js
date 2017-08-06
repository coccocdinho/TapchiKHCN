//ShowPopup for all Page
function ShowPopup(ObjectGUID, params) {

    if (ObjectGUID === undefined || ObjectGUID == "") ObjectGUID = PageGUID;
    if (params === undefined) params = "";
    //WL(ObjectGUID, "Bấm " + this.popupTitle);

    OpenDialog(this.popupName, this.popupTitle, this.popupWidth, this.popupHeight, this.popupStyle, this.popupScrollable, this.url + params);
}
//ClosePopup Pupup for all Page
function ClosePopup(reload) {

    $('#dialog' + this.popupName).dialog('close');
    if (reload !== undefined) location.reload();
}
//----------------------------------------------Dialog-------------------------------------------------------------------------------
function ShowDialog(dialogName, dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, scrollingType) {
    if ($("#dialog" + dialogName).length == 0)
        $(document.body).append(
                    "<div id='dialog" + dialogName + "'>"
                       + "<iframe id='frame" + dialogName + "' name='frame" + dialogName + "' frameborder='0' width='100%' scrolling='" + scrollingType + "' style='overflow: hidden;" +
                            "overflow-x: hidden; overflow-y: hidden; height: 100%; width: 100%; position: absolute;" +
                            "top: 0px; left: 0px; right: 0px; bottom: 0px'></iframe>" +
                    "</div>");
    $("#dialog" + dialogName).dialog({
        dialogClass: dialogStyle,
        resizable: false,
        modal: true,

        open: function (type, data) {
            $(this).parent().appendTo("form");
            $("#frame" + dialogName).attr("src", url);
        },
        width: dialogWidth,
        height: dialogHeight,
        title: dialogTitle,
        closeOnEscape: true
    });
}

// HInhPD viết thay thế
function OpenDialog(dialogName, dialogTitle, dialogWidth, dialogHeight, dialogStyle, scrollingType, url) {
    OpenBkavDialog(dialogName, dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, scrollingType);
}

function OpenBkavDialog(dialogName, dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, scrollingType) {
    if ($("#dialog" + dialogName).length == 0)
        $(document.body).append(
                    "<div id='dialog" + dialogName + "'>"
                       + "<iframe id='frame" + dialogName + "'  name='frame" + dialogName + "' frameborder='0' width='100%' scrolling='" + scrollingType + "' style='overflow: hidden;" +
                            "overflow-x: hidden; overflow-y: hidden; height: 100%; width: 100%; position: absolute;" +
                            "top: 0px; left: 0px; right: 0px; bottom: 0px'></iframe>" +
                    "</div>");
    $("#dialog" + dialogName).dialog({
        dialogClass: dialogStyle,
        resizable: false,
        modal: true,
        open: function (type, data) {
            $(this).parent().appendTo("form");
            $("#frame" + dialogName).attr("src", url);
        },
        width: dialogWidth,
        height: dialogHeight,
        title: dialogTitle,
        closeOnEscape: true
    });

}

/*
ThinhTD tạo hàm hiển thị popup thông báo lỗi
*/
function ShowDialogError(message, width, height) {
    window.parent.parent.CloseDialogUpdateInvoiceNotPostBack();
    if ($("#dialogErrorCheck").length == 0)
        $(document.body).append("<div id='dialogErrorCheck' class='font-popup-bkav'><input type='hidden' id='autoFocus' autofocus='true'/> "
            + message
            + "<div class='modal-footer modal-footer-bkav'><input type='button' class='btn btn-primary btn-primary-bkav' value='Đóng' onclick=\"$('#dialogErrorCheck').dialog('close');\""
            + "</div>"
            + "</div>");
    $("#dialogErrorCheck").dialog({
        dialogClass: 'DynamicDialogStyle',
        resizable: false,
        modal: true,
        width: width,
        height: height,
        closeOnEscape: true,
        title: "van.eHoadon.vn",
        open: function (event, ui) {
            $('#autoFocus').focus();
        }
    });
}

// 
function OpenBkavDialogAddButton(dialogName, dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, scrollingType) {
    if ($("#dialog" + dialogName).length == 0)
        $(document.body).append(
                    "<div id='dialog" + dialogName + "'>"
                       + "<iframe id='frame" + dialogName + "'  name='frame" + dialogName + "' frameborder='0' width='100%' scrolling='" + scrollingType + "' style='overflow: hidden;" +
                            "overflow-x: hidden; overflow-y: hidden; height: 100%; width: 100%; position: absolute;" +
                            "top: 0px; left: 0px; right: 0px; bottom: 0px'></iframe>" +
                    "</div>");
    $("#dialog" + dialogName).dialog({
        dialogClass: dialogStyle,
        resizable: false,
        modal: true,
        width: dialogWidth,
        height: dialogHeight,
        title: dialogTitle,
        closeOnEscape: true,
        open: function (type, data) {
            $(this).parent().appendTo("form");
            $("#frame" + dialogName).attr("src", url);
        }
    });

}
//Set chiều cao, chiều rộng và vị trí của popup
function SetOptionsDialog(nameDialog, width, height, title) {
    if (window.parent != null) {
        var dialog = window.parent.$("#dialog" + nameDialog);
        if (dialog != null) {
            dialog.dialog("option", "width", width);
            dialog.dialog("option", "height", height);
            dialog.dialog("open");
            if (title != "")
                dialog.dialog("option", "title", title);

            dialog.dialog({
                position: { my: "center", at: "center", of: window.top }
            });
        }
    }
}
//----------------------alert------------------------------------------------------------------------

function bkav_alert_close(isInsideiFrame) {
    if (isInsideiFrame) {
        window.location.reload();
        $("#bkav_alert_dialog").dialog("close");
    }
    else {
        $("#bkav_alert_dialog").dialog("close");
    }
}
function bkav_error(content) {
    bkav_alert('van.ehoadon.vn', 'error', content);
}
function bkav_success(content) {
    bkav_alert('van.ehoadon.vn', 'success', content);
}
function bkav_warning(content) {
    bkav_alert('van.ehoadon.vn', 'warning', content);
}
function bkav_alert_html(content) {
    bkav_alert('van.ehoadon.vn', 'html', content);
}

//typeAlert (kiểu thông báo VD: error, success, warning, html (kiểu có định dạng html))
function bkav_alert(title, typeAlert, content) {
    var imgtypeurl = '';
    var htmlcontent = '';
    var btnGroup = "<div class='col-md-12 footer' style='margin-bottom: 10px; padding-right: 5px!important;padding-top: 15px;'><div class='pull-right'>" + " <button class='btn btn-close' onclick=bkav_alert_close(false);>Đóng</button>" + "</div></div>";
    if (title == '') { title = 'Thông báo'; }
    if (typeAlert == 'html') {
        htmlcontent = " <div class='row' style='margin-top:10px'>" +
               " <div class='col-xs-12 col-md-12'>" +
                    content +
                "</div></div>";
    }
    else {
        switch (typeAlert) {
            case "error": imgtypeurl = '/img/icon-loi.png'; break;
            case "success": imgtypeurl = '/img/icon-thanh-cong.png'; break;
            case "warning": imgtypeurl = '/img/icon-thong-bao.png'; break;
            case "info": imgtypeurl = '/img/icon-info.png'; break;

        }
        htmlcontent = "<input type='hidden' id='autoFocus' autofocus='true'/> <div class='row' style='margin-top:10px'>" +
               " <div class='col-xs-2 col-md-2'>" +
                  "  <img src='" + imgtypeurl + "' class='img' width='50px'/>" +
               " </div>" +
               " <div class='col-xs-10 col-md-10'>" +
                    content +
                "</div></div>";
    }
    if ($('#bkav_alert_dialog').length > 0) {
        $('#bkav_alert_dialog').html(htmlcontent + btnGroup);
    } else {
        $(document.body).append("<div style='font-family:Helvetica,Arial, sans-serif-Regular;font-size:14px; overflow:hidden;margin-bottom: 10px' id='bkav_alert_dialog'>" +
            htmlcontent + btnGroup + "</div>");
    }

    $("#bkav_alert_dialog").dialog({
        resizable: false,
        modal: true,
        title: title,
        minWidth: 550,
        maxWidth: 600,
        closeOnEscape: true,
        open: function (event, ui) {
            $('#autoFocus').focus();
        }
    });

}

//-------------------------------Confirm---------------------------------------------------------------------------
//typeConfirm = true là gọi doPostBack, != 1 là gọi hàm tiếp theo trên Client
// funtionName hàm được gọi trên Client tiếp theo nếu typeConfirm != 1
//yesNo = true/false nút đồng ý hay hủy
function bkav_confirm_check(idBtn, typeConfirm, yesNo, functionName, isInsideiframe, isHref, functionParameters) {

    if (typeConfirm == true && idBtn != '') {
        if (yesNo) {
            if (isHref) {
                window.location.href = $(idBtn).attr('href');

            } else {
                __doPostBack($(idBtn).attr('id'), '');
                bkav_alert_close();
            }

        }
        else {
            bkav_alert_close();
        }
    }
    else {
        if (yesNo) {
            setTimeout(function () {
                var param = functionParameters.split(",");
                var functionNameMain = window[functionName];
                functionNameMain.apply(functionNameMain, param);
                bkav_alert_close(isInsideiframe);
            }, 300);
        }
        else {
            bkav_alert_close(isInsideiframe);
        }

    }
}

//typeConfirm = true là gọi doPostBack, != 1 là gọi hàm tiếp theo trên Client
//Nếu typeConfirm == true cần truyền idBtn (thường là this), ko thì ko cần ''
// functionName hàm được gọi trên Client tiếp theo nếu typeConfirm = false
//Nếu confirm_dialog nằm trong iframe thì isInsideiframe == true
//typeAlert kiểu thông báo ('warning','error','susscess','html')
//isHref nếu nút là thẻ a là true
//functionParameters tham số của hàm truyền vào

//VD:   bkav_confirm(this, true, false, true 'warning','Thông báo','Bạn chắc chắn bẩm ký và gửi','')
//VD:   bkav_confirm('', false, true,false 'warning','Thông báo','Bạn chắc chắn bẩm ký và gửi','SignSend()')
function bkav_confirm(idBtn, typeConfirm, isInsideiframe, isHref, typeAlert, title, content, functionName, functionParameters) {

    var imgtypeurl = '';
    var htmlcontent = '';

    if (idBtn == '') { btnGroup = "<div class='col-md-12 footer' style='margin-bottom: 15px'><div class='pull-right'>" + "<button class='btn btn-primary' onclick=bkav_confirm_check(\'\'," + typeConfirm + "," + true + ",\'" + functionName + "\'," + isInsideiframe + "," + isHref + ",'" + functionParameters + "')>Đồng ý</button> <button class='btn btn-close' onclick='bkav_alert_close(" + isInsideiframe + ")'>Đóng</button>" + "</div></div>"; }
    else {
        idBtn = $(idBtn).attr('id');
        btnGroup = "<div class=''col-md-12 footer' style='margin-bottom: 15px'><div class='pull-right'>" + "<button class='btn btn-primary' onclick=bkav_confirm_check(" + idBtn + "," + typeConfirm + "," + true + ",\'" + functionName + "\'," + isInsideiframe + "," + isHref + ",\'\')>Đồng ý</button> <button class='btn btn-close' onclick='bkav_alert_close(" + isInsideiframe + ")'>Đóng</button>" + "</div></div>";
    }
    if (title == '') { title = 'Thông báo'; }
    if (typeAlert == 'html') {
        htmlcontent = " <div class='row' style='margin-top:10px;margin-right:0px'>" +
               " <div class='col-xs-12 col-md-12'>" +
                    content +
                "</div></div>";
    }
    else {
        switch (typeAlert) {
            case "error": imgtypeurl = '/img/icon-loi.png'; break;
            case "success": imgtypeurl = '/img/icon-thanh-cong.png'; break;
            case "warning": imgtypeurl = '/img/icon-thong-bao.png'; break;
        }
        htmlcontent = " <div class='row' style='margin-top:10px;margin-right:0px'>" +
               " <div class='col-xs-2 col-md-2'>" +
                  "  <img src='" + imgtypeurl + "' class='img' width='50px'/>" +
               " </div>" +
               " <div class='col-xs-10 col-md-10'>" +
                    content +
                "</div></div>";
    }
    if ($('#bkav_alert_dialog').length > 0) {
        $('#bkav_alert_dialog').html(htmlcontent + btnGroup);
    } else {
        $(document.body).append("<div class='container' id='bkav_alert_dialog' style='margin-bottom: 10px'>" +
            htmlcontent + btnGroup + "</div>");
    }
    $("#bkav_alert_dialog").dialog({
        resizable: false,
        modal: true,
        title: title,
        minWidth: 430,
        closeOnEscape: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
        }

    });
    return false;
}
//
function bkav_confirm_Continue(idBtn, typeConfirm, isInsideiframe, isHref, typeAlert, title, content, functionName, functionParameters) {
    var imgtypeurl = '';
    var htmlcontent = '';

    if (idBtn == '') { btnGroup = "<div class='col-md-12 footer' style='margin-bottom: 15px'><div class='pull-right'>" + "<button class='btn btn-primary' onclick=bkav_confirm_check(\'\'," + typeConfirm + "," + true + ",\'" + functionName + "\'," + isInsideiframe + "," + isHref + ",'" + functionParameters + "')>Tiếp tục</button> <button class='btn btn-close' onclick='bkav_alert_close(" + isInsideiframe + ")'>Đóng</button>" + "</div></div>"; }
    else {
        idBtn = $(idBtn).attr('id');
        btnGroup = "<div class=''col-md-12 footer' style='margin-bottom: 15px'><div class='pull-right'>" + "<button class='btn btn-primary' onclick=bkav_confirm_check(" + idBtn + "," + typeConfirm + "," + true + ",\'" + functionName + "\'," + isInsideiframe + "," + isHref + ",\'\')>Tiếp tục</button> <button class='btn btn-close' onclick='bkav_alert_close(" + isInsideiframe + ")'>Đóng</button>" + "</div></div>";
    }
    if (title == '') { title = 'Thông báo'; }
    if (typeAlert == 'html') {
        htmlcontent = " <div class='row' style='margin-top:10px;margin-right:0px'>" +
               " <div class='col-xs-12 col-md-12'>" +
                    content +
                "</div></div>";
    }
    else {
        switch (typeAlert) {
            case "error": imgtypeurl = '/img/icon-loi.png'; break;
            case "success": imgtypeurl = '/img/icon-thanh-cong.png'; break;
            case "warning": imgtypeurl = '/img/icon-thong-bao.png'; break;
        }
        htmlcontent = " <div class='row' style='margin-top:10px;margin-right:0px'>" +
               " <div class='col-xs-2 col-md-2'>" +
                  "  <img src='" + imgtypeurl + "' class='img' width='50px'/>" +
               " </div>" +
               " <div class='col-xs-10 col-md-10'>" +
                    content +
                "</div></div>";
    }
    if ($('#bkav_alert_dialog').length > 0) {
        $('#bkav_alert_dialog').html(htmlcontent + btnGroup);
    } else {
        $(document.body).append("<div class='container' id='bkav_alert_dialog' style='margin-bottom: 10px'>" +
            htmlcontent + btnGroup + "</div>");
    }
    $("#bkav_alert_dialog").dialog({
        resizable: false,
        modal: true,
        title: title,
        minWidth: 430,
        closeOnEscape: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
        }

    });
    return false;
}
//
$(document).keydown(function (e) {
    var code = e.which;
    if (code == 27) {//27: Key ESC
        $('.ui-dialog-content').dialog("close");
    }
});
