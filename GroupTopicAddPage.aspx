<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="GroupTopicAddPage.aspx.cs" Inherits="GroupTopicAddPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chọn năm</label>
        <div class="col-sm-2">
            <asp:RadioButton ID="rbChose2" GroupName="gr1" runat="server"
                AutoPostBack="True" OnCheckedChanged="rbChose2_CheckedChanged" />
            <asp:DropDownList ID="ddlGroupTopic" runat="server" Width="80px">
            </asp:DropDownList>
        </div>
        <label class="col-sm-1 control-label no-padding-right" for="form-field-1">Chọn tập</label>
        <div class="col-sm-1">
            <asp:DropDownList ID="ddlTap" runat="server" Width="80px">
            </asp:DropDownList>
        </div>
        <label class="col-sm-1 control-label no-padding-right" for="form-field-1">Chọn số</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlSo" runat="server" Width="80px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên tạp chí</label>
        <div class="col-sm-9">
            <asp:RadioButton ID="rbChose" runat="server" Text="Tùy chọn"
                AutoPostBack="True" OnCheckedChanged="rbChose_CheckedChanged" />
            <asp:TextBox ID="txtName" runat="server" Width="200px" Visible="false"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mô tả</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtDescription" placeholder="Ví dụ: Số 3, Tập 1, Quyển 3" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Chọn Chuyên san</label>
        <div class="col-sm-9">
            <asp:DropDownList ID="ddlChuyensan" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">File</label>
            <div class="col-sm-6">
                <asp:FileUpload class="form-control" ID="fulFile" runat="server" />
            </div>
            <div class="col-sm-3">
                <asp:Button class="btn btn-primary btn-sm" ID="btnUpdateLinkFile" runat="server" Text="Upload file"
                    OnClick="btnUpdateLinkFile_Click" />

            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">File đã Upload</label>
            <div class="col-sm-9">
                <asp:Label class="form-control" ID="lblFile" runat="server"></asp:Label>
            </div>
        </div>
    <asp:Panel runat="server" ID="pnlBienTap" Visible="false">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Phát hành</label>
            <div class="col-sm-9">
                <asp:CheckBox runat="server" ID="cbStatus" class="form-control" />
            </div>
        </div>
    </asp:Panel>


    <div class="col-xs-12">
        <div class="col-xs-5"></div>
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info btn-sm" Text="Ghi lại" OnClick="btnSave_Click" />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>
</asp:Content>

