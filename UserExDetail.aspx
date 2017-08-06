<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="UserExDetail.aspx.cs" Inherits="UserExDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Họ tên </label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtFullname" placeholder="Họ tên" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Ảnh đại diện</label>
            <div class="col-sm-9">
                <asp:FileUpload AllowMultiple="true" runat="server" ID="fulImagePath" class="form-control" />
                <asp:Image runat="server" Width="100" Height="100" ID="imgPath" Visible="false" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chức danh khoa học</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPrifixName" placeholder="Chức danh khoa học" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Cơ quan</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtCompanyName" placeholder="Cơ quan" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chức vụ</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPositionName" placeholder="Chức vụ" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chuyên ngành</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtMajoringInScience" placeholder="Chuyên ngành" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Trách nhiệm</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPositionInScient" placeholder="Trách nhiệm" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Điện thoại</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPhone" placeholder="Điện thoại" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Email</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Email" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chọn nhóm</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlGroup"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chuyên san</label>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddlJournal"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Thứ tự hiển thị</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPriority" type="number" placeholder="Thứ tự hiển thị" class="form-control" />
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

