<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>Thông tin cá nhân
        </h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Họ tên </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtFullName" placeholder="Nhập họ tên" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Email</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Nhập Email" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Số điện thoại</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPhone" placeholder="Nhập Số điện thoại" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chức danh khoa học</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlPrifix"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Địa chỉ </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtAddress" placeholder="Địa chỉ" class="form-control" />
            </div>
        </div>
    </div>
    <br />
    <div class="col-xs-12">
        <div class="col-xs-5"></div>
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info btn-sm" Text="Ghi lại" OnClick="btnSave_Click" />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>
</asp:Content>

