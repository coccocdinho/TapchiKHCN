<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="ScientificTopicStatusConfigAdd.aspx.cs" Inherits="ScientificTopicStatusConfigAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Trạng thái xử lý</label>
        <div class="col-sm-9">
            <asp:DropDownList runat="server" ID="ddlFromStatus" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Trạng thái tới</label>
        <div class="col-sm-9">
            <asp:DropDownList runat="server" ID="ddlToStatus" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên thao tác</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtActionName" placeholder="Tên thao tác xử lý" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mô tả</label>
        <div class="col-sm-9">
            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtActionDescription" placeholder="Nhập mô tả mục đích của thao tác" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Bộ phận xử lý</label>
        <div class="col-sm-9">
            <asp:DropDownList runat="server" ID="ddlFromRole" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chuyển đến bộ phận</label>
        <div class="col-sm-9">
            <asp:DropDownList runat="server" ID="ddlToRole" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Có lưu dữ liệu</label>
        <div class="col-sm-9">
            <asp:CheckBox runat="server" ID="chkIsSaveData" Checked="false" class="form-control" />
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

