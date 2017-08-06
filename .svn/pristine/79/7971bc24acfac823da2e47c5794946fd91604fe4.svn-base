<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="ScientificTopicStatusAdd.aspx.cs" Inherits="ScientificTopicStatusAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên trạng thái</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtName" placeholder="Tên trạng thái" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên hiện cho Tác giả</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtNameForAuthor" placeholder="Tên trạng thái hiện cho Tác giả xem" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mô tả</label>
        <div class="col-sm-9">
            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescription" placeholder="Nhập mô tả" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Cập nhật Chuyên san</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="cbIsUpdateJournal" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Cập nhật Tạp chí</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="cbIsUpdateGroup" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Cập nhật Phản biện</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="cbIsUpdateReviewer" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Cập nhật ngày hẹn</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsUpdateAppointmentDate" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chỉ đọc</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="cbIsReadOnly" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem Chuyên san</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewpnlChonChuyenSan" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem Tạp chí</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewpnlGroupTopic" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem Mã bài báo</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewpnlTopicCode" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem Vị trí bài báo</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewpnlPositon" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem số của bài báo</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewpnlNumber" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem Phản biện</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewpnlChonPhanBien" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem Ngày hẹn Phản biện</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewpnlAppointmentDate" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Xem file nhận xét</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsViewCommentFile" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Cập nhật file Nhận xét</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsUpdateCommentFile" class="form-control" />
        </div>
    </div>
    <div class="col-xs-12">
        <div class="col-xs-5"></div>
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info btn-sm" Text="Ghi lại" OnClick="btnSave_Click" />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>
</asp:Content>


