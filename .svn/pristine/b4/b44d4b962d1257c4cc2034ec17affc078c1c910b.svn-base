<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="SystemConfigPage.aspx.cs" Inherits="SystemConfigPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>Cấu hình hệ thống
        </h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên công ty</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtCompanyName" placeholder="Nhập tên hệ thống" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên website</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtWebsite" placeholder="Nhập tên Website" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Sologan</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtSologan" placeholder="Nhập Sologan" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tài khoản Mailserver</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtEmailSmtp" placeholder="Vd: abc@gmail.com" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mật khẩu Mailserver</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPassSmtp" TextMode="Password" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Đăng ký bản quyền</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtCopyRight" placeholder="Nhập Địa chỉ" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Địa chỉ</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtAddress" placeholder="Nhập Địa chỉ" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Điện thoại</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtPhone" placeholder="Nhập số điện thoại" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Email</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Nhập địa chỉ Email" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Phát triển bởi</label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="txtDeverloper" placeholder="Nhập Người phát triển" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Lời nói đầu</label>
            <div class="col-sm-9">
                <telerik:RadEditor ID="txtIntroduction" runat="server">
                    <ImageManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <DocumentManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <FlashManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <MediaManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                </telerik:RadEditor>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Logo</label>
            <div class="col-sm-6">
                <asp:FileUpload ID="fulLogo" runat="server" />
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnUpdateLogo" runat="server" Text="Cập nhật" OnClick="btnUpdateLogo_Click" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1"></label>
            <div class="col-sm-9">
                <asp:Image ID="imgLogo" runat="server" Height="160px" Width="200px" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Banner</label>
            <div class="col-sm-6">
                <asp:FileUpload ID="fulBanner" runat="server" />
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnUpdateBanner" runat="server" Text="Cập nhật" OnClick="btnUpdateBanner_Click" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1"></label>
            <div class="col-sm-9">
                <asp:Image ID="imgBanner" runat="server" Height="160px" Width="680px" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mẫu nhận xét</label>
            <div class="col-sm-9">
                <telerik:RadEditor OnClientLoad="OnClientLoad" ID="txtMauNhanXet" EnableEmbeddedSkins="true" Skin="Office2007" runat="server">
                    <ImageManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <DocumentManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <FlashManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <MediaManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                </telerik:RadEditor>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Mẫu Thư gửi</label>
            <div class="col-sm-9">
                <telerik:RadEditor OnClientLoad="OnClientLoad" EnableEmbeddedSkins="true" Skin="Office2007" ID="txtMauMailGuiPhanBien" runat="server">
                    <ImageManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <DocumentManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <FlashManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                    <MediaManager UploadPaths="/Images/System" ViewPaths="/Images/System" />
                </telerik:RadEditor>
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
    <asp:HiddenField ID="hdfId" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function OnClientLoad(editor, args) {
            var style = editor.get_contentArea().style;
            style.backgroundImage = "none";
            style.backgroundColor = "white";
        }
</script> 
</asp:Content>

