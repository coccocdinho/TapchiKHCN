<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="ScientificTopicAdd.aspx.cs" Inherits="ScientificTopicAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên bài báo</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtTitle" placeholder="Nhập tên bài báo" class="form-control" />
        </div>
    </div>
     <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tên bài báo bằng tiếng Anh</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtTitleEn" placeholder="Nhập tên bài báo bằng tiếng Anh" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tóm tắt bài báo</label>
        <div class="col-sm-9">
            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtShortDescription" placeholder="Nhập mô tả ngắn của bài báo" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tóm tắt bài báo bằng tiếng Anh</label>
        <div class="col-sm-9">
            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtShortDescriptionEn" placeholder="Nhập mô tả ngắn của bài báo bằng tiếng Anh" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Lĩnh vực</label>
        <div class="col-sm-9">
            <asp:DropDownList runat="server" ID="ddlChuyenSan" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">File đính kèm</label>
        <div class="col-sm-9">
            <asp:FileUpload ID="fulFile" runat="server" />
            <asp:Button ID="btnUpFile" runat="server" OnClick="btnUpFile_Click" Text="Up file đính kèm" />
            &nbsp;<asp:HyperLink ID="hplUrlFile" runat="server">[hplUrlFile]</asp:HyperLink>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Từ khóa tiếng việt</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtMetaKeyword" placeholder="Nhập từ khóa" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Từ khóa bắng tiếng Anh</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtMetaKeywordEn" placeholder="Nhập từ khóa bắng tiếng Anh" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Tác giả</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtAuthorName" ReadOnly="true" placeholder="Nhập tên tác giả" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Đồng tác giả</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtSameAuthorName" placeholder="Nhập vào đồng tác giả, cách nhau bởi dấu phẩy" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Địa chỉ tác giả</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" ID="txtSameAuthorAddress" placeholder="Điền địa chỉ của tất cả các Tác giả, thường thì sẽ là tên các trường ĐH các tác giả đang công tác" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">Nội dung trao đổi</label>
        <div class="col-sm-9">
            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtProcessContent" placeholder="Nhập nội dung trao đổi" class="form-control" />
        </div>
    </div>
    <div class="col-xs-12">
        <div class="col-xs-5"></div>
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info btn-sm" Text="Gửi bài" OnClick="btnSave_Click" />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>
</asp:Content>

