﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="ScientificTopicProcessPage.aspx.cs" Inherits="ScientificTopicProcessPage" %>

<%@ Register Src="Usercontrol/UCTopicProcess.ascx" TagName="UCTopicProcess" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên bài báo</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ReadOnly="true" ID="txtTitle" placeholder="Nhập tên bài báo" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên bài báo bằng tiếng Anh</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ReadOnly="true" ID="txtTitleEn" placeholder="Nhập Tên bài báo bằng tiếng Anh" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mô tả ngắn</label>
        <div class="col-sm-9">
            <asp:TextBox TextMode="MultiLine" ReadOnly="true" runat="server" ID="txtShortDescription" placeholder="Nhập mô tả ngắn của bài báo" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mô tả ngắn bằng tiếng Anh</label>
        <div class="col-sm-9">
            <asp:TextBox TextMode="MultiLine" ReadOnly="true" runat="server" ID="txtShortDescriptionEn" placeholder="Nhập Mô tả ngắn bằng tiếng Anh" class="form-control" />
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlChonChuyenSan" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Phân loại</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlChuyenSan" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlChuyenSan_SelectedIndexChanged" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlGroupTopic" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chọn số Tạp chí</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlGroup" class="form-control" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlTopicCode" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mã bài báo</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ReadOnly="true" ID="txtTopicCode" placeholder="vd: NSY170223-09" class="form-control" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlPositon" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Vị trí</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPositon" placeholder="vd:Tập 1 Số 1 Năm 2017" class="form-control" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNumber" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Số tại Tạp chí</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtNumber" placeholder="vd:1" class="form-control" />
            </div>
        </div>
    </asp:Panel>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">File đính kèm</label>
        <div class="col-sm-9">
            <asp:Panel runat="server" ID="pnlUpfile" Visible="false">
                <asp:FileUpload ID="fulFile" runat="server" />
                <asp:Button ID="btnUpFile" runat="server" OnClick="btnUpFile_Click" Text="Up file đính kèm" />&nbsp;
            </asp:Panel>
            <asp:HyperLink ID="hplUrlFile" runat="server">[hplUrlFile]</asp:HyperLink>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Từ khóa tiếng việt</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ReadOnly="true" ID="txtMetaKeyword" placeholder="Nhập Từ khóa tiếng việt" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Từ khóa bắng tiếng Anh</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ReadOnly="true" ID="txtMetaKeywordEn" placeholder="Nhập Từ khóa bắng tiếng Anh" class="form-control" />
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAuthorInfo">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tác giả</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtAuthorName" ReadOnly="true" placeholder="Nhập tên tác giả" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Đồng tác giả</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ReadOnly="true" ID="txtSameAuthorName" placeholder="Nhập vào đồng tác giả, cách nhau bởi dấu phẩy" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Địa chỉ tác giả</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtSameAuthorAddress" ReadOnly="true" placeholder="Điền địa chỉ của tất cả các Tác giả, thường thì sẽ là tên các trường ĐH các tác giả đang công tác" class="form-control" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlChonPhanBien" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Đề xuất phản biện</label>
            <div class="col-sm-9">
                <div class="checkbox">
                    <asp:CheckBoxList RepeatDirection="Horizontal" runat="server" ID="chkPhanBien" ClientIDMode="Static" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlListPhanBien" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Danh sách phản biện</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlListPhanBien" ClientIDMode="Static" onchange="LeaveChange();"></asp:DropDownList>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlAppointmentDate" Visible="false">
        <div class="form-group">
            <label data-toggle="popover" data-trigger="hover" data-placement="top" data-content='Ngày hẹn' class="col-sm-3 control-label no-padding-right" for="form-field-1">Ngày hẹn</label>
            <div class="col-sm-9">
                <div class="input-group">
                    <asp:TextBox runat="server" class="form-control date-picker" ID="txtAppointmentDate" type="text" data-date-format="dd/mm/yyyy" />
                    <span class="input-group-addon">
                        <i class="fa fa-calendar bigger-110"></i>
                    </span>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewCommentFile" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">File nhận xét</label>
            <div class="col-sm-9">
                <asp:Panel runat="server" ID="pnlUpdateCommentFile" Visible="false">
                    <asp:FileUpload ID="fulCommentfile" runat="server" />
                    <asp:Button ID="btnUpdateCommentFile" runat="server" OnClick="btnUpdateCommentFile_Click" Text="Upload file đính kèm" />&nbsp;
                </asp:Panel>
                <asp:HyperLink ID="hplUrlCommentFile" runat="server">[hplUrlFile]</asp:HyperLink>
            </div>
        </div>
    </asp:Panel>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Nhật ký xử lý</label>
        <div class="col-sm-9" id="nkxl">
            <uc1:UCTopicProcess ID="UCTopicProcess1" runat="server" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Nội dung xử lý</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtProcessContent" placeholder="Nhập nội dung xử lý" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Trạng thái xử lý</label>
        <div class="col-sm-9">
            <div class="radio">
                <asp:RadioButtonList RepeatDirection="Horizontal" runat="server" ID="rbtListStatus" />
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="col-xs-5"></div>
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info btn-sm" Text="Ghi lại" OnClick="btnSave_Click" />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>
    <style type="text/css">
        #nkxl
        {
            overflow-y: scroll;
            max-height: 200px;
        }

        .radio input[type=radio]
        {
            margin-left: 4px !important;
        }

        .checkbox input[type=checkbox]
        {
            margin-left: 2px !important;
        }

        .checkbox label
        {
            padding-left: 22px !important;
            padding-right: 8px !important;
            margin-top: -2px;
        }
    </style>
    <asp:HiddenField runat="server" ID="hfIsNewFile" Value="0" />
    <asp:HiddenField runat="server" ID="hfIsNewCommentFile" Value="0" />
    <asp:HiddenField runat="server" ID="hfRole" ClientIDMode="Static" Value="0" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfPhanBienId" Value="0" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function LeaveChange() {
            $('input[id^="chkPhanBien"]').prop('checked', false);
            var phanbienId = $('#ddlListPhanBien :selected').val();
            $("#hfPhanBienId").val(phanbienId);
            //alert(phanbienId);
        }
        $(document).ready(function () {
            var role = $("#hfRole").val();
            if (role == 5) {
                $('input[id^="chkPhanBien"]').click(function () {
                    // The one that fires the event is always the
                    $('input[id^="chkPhanBien"]').each(function () {
                        $(this).prop("checked","");
                    });
                    $(this).prop("checked","checked");
                    //alert($(this).val());
                    //$('#ddlListPhanBien :selected').val(0);
                    if ($(this).prop("checked")) {
                        //alert($(this).val());
                        $("#ddlListPhanBien").prop("selectedIndex", 0);
                        $("#hfPhanBienId").val($(this).val());
                        //alert(phanbienId);
                    }
                    else {
                        $("#hfPhanBienId").val(0);
                    }
                });
            }
        });
    </script>
</asp:Content>


