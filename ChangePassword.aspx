﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>Đổi mật khẩu</h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mật khẩu hiện tại</label>
            <div class="col-sm-9">
                <asp:TextBox TextMode="Password" runat="server" ID="txtOldPassword" placeholder="Nhập Mật khẩu hiện tại" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mật khẩu mới</label>
            <div class="col-sm-9">
                <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" placeholder="Nhập Mật khẩu mới" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Nhập lại Mật khẩu mới</label>
            <div class="col-sm-9">
                <asp:TextBox TextMode="Password" runat="server" ID="txtRePassword" placeholder="Nhập lại Mật khẩu mới" class="form-control" />
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

