<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="UserAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tài khoản </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtUserName" placeholder="Tài khoản" class="form-control" />
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlIsNew" Visible="true">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mật khẩu </label>
                <div class="col-sm-9">
                    <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" placeholder="Mật khẩu" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Nhập lại Mật khẩu </label>
                <div class="col-sm-9">
                    <asp:TextBox TextMode="Password" runat="server" ID="txtRePassword" placeholder="Mật khẩu" class="form-control" />
                </div>
            </div>
        </asp:Panel>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Họ tên </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtFullname" placeholder="Họ tên" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Email </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Họ tên" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Điện thoại </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPhone" placeholder="Họ tên" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Địa chỉ </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtAddress" placeholder="Nhập địa chỉ" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chọn nhóm</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlRole"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chuyện chuyên san</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlJounal"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chọn chức danh</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlPrefix"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chọn trạng thái</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlUserStatus"></asp:DropDownList>
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
</asp:Content>

