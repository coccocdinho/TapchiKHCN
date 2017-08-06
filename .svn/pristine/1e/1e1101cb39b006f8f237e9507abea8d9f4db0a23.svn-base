<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="NewEdit.aspx.cs" Inherits="NewEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-2 control-label no-padding-right" for="form-field-1">Tiêu đề</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtTitle" placeholder="Tài khoản" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label no-padding-right" for="form-field-1">Chọn nhóm</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlGroup" runat="server" class="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label no-padding-right" for="form-field-1">Mô tả ngắn</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtShortDescription" runat="server" Height="64px" TextMode="MultiLine" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label no-padding-right" for="form-field-1">Nội dung</label>
            <div class="col-sm-10">
                <telerik:RadEditor OnClientLoad="OnClientLoad" EnableEmbeddedSkins="true" Skin="Office2007" ID="radContent" runat="server">
                    <Content>
                    </Content>
                    <ImageManager UploadPaths="~/Images/News" ViewPaths="~/Images/News" />
                </telerik:RadEditor>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label no-padding-right" for="form-field-1">Duyệt</label>
            <div class="col-sm-10">
                <asp:CheckBox ID="cbPublísh" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label no-padding-right" for="form-field-1">Ảnh đại diện</label>
            <div class="col-sm-10">
                <asp:FileUpload ID="fulImages" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label no-padding-right" for="form-field-1"></label>
            <div class="col-sm-10">
                <asp:Image ID="img" runat="server" />
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
    <script type="text/javascript">
        function OnClientLoad(editor, args) {
            var style = editor.get_contentArea().style;
            style.backgroundImage = "none";
            style.backgroundColor = "white";
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>


