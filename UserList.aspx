<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Page_UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/js/ShowDialog.js?ver<%=DateTime.Now.Ticks.ToString()%>" type="text/javascript"></script>
    <script type="text/javascript">
        var PageGUID = "1111-222222";
        var Popup = {
            UsersDetails: { popupName: "UsersDetails", popupTitle: "Quản lý Người dùng", popupWidth: 800, popupHeight: 600, popupScrollable: "yes", url: "UserAdd.aspx", ShowPopup: ShowPopup, ClosePopup: ClosePopup },
        }

        function OpenUpdate(keyid) {
            var dialogWidth = 800;
            var dialogHeight = 600;
            var dialogStyle = "DynamicDialogStyle";
            var url = "UserAdd.aspx?KeyId=" + keyid;
            var dialogTitle = "Cập nhật Tài khoản";
            ShowDialog("dgUpdateMailserver", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }

        function OpenResetPassWord(keyid) {
            var dialogWidth = 800;
            var dialogHeight = 260;
            var dialogStyle = "DynamicDialogStyle";
            var url = "ResetPassword.aspx?KeyId=" + keyid;
            var dialogTitle = "Reset mật khẩu";
            ShowDialog("dgResetPassword", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }

        function OpenDelete(keyid) {
            var isOk = confirm("Bạn có chắc muốn xóa?");
            if (!isOk) return;
            var _url = "Handler/DeleteUsers.ashx/Process";
            var _data = "KeyId=" + keyid;
            $.ajax({
                type: "POST",
                url: _url,
                data: _data,
                async: false,
                dataType: "html",
                success: function (data) {
                    if (data.length > 0) {
                        alert(data);
                    } else { alert('Xử lý thành công'); }
                    location.reload();
                },
                error: function (err) {
                    alert("Hệ thống xảy ra lỗi.");
                    check = false;
                }
            });
        }

    </script>
    <div id="User" style="width: 100%; padding: 1px 15px; position: relative;">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <div style="height: 30px; text-align: right; padding-bottom: 8px;">
            <input id="btnAddNew" runat="server" class="btn btn-info btn-sm" onclick="Popup.UsersDetails.ShowPopup()"
                style="margin-right: 0px; margin-bottom: 10px;" type="button" value="Thêm mới" />
        </div>
        <div class="row" style="padding-left: 15px; padding-right: 15px; padding-top: 8px;">
            <div class="row">
                <div class="col-md-12 table-container">
                    <asp:Repeater runat="server" ID="rpList" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table class="table table-bordered invoiceRelease">
                                <thead>
                                    <tr>
                                        <th style="text-align: center; vertical-align: middle;">STT</th>
                                        <th style="text-align: center; vertical-align: middle;">Tài khoản</th>
                                        <th style="text-align: center; vertical-align: middle;">Họ tên</th>
                                        <th style="text-align: center; vertical-align: middle;">Quyền</th>
                                        <th style="text-align: center; vertical-align: middle;">Số điện thoại</th>
                                        <th style="text-align: center; vertical-align: middle;">Trạng thái</th>
                                        <th style="text-align: center; vertical-align: middle;">Chức năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 30px; text-align: center"><%#Container.ItemIndex +1%></td>
                                <td style="width: 120px; text-align: center"><%# Eval("UserName") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("FullName") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("RoleName") %></td>
                                <td style="width: 100px; text-align: center;"><%# Eval("Phone") %></td>
                                <td style="width: 150px; text-align: center;"><%# Eval("UserStatusName") %></td>
                                <td style="width: 120px; text-align: center;"><%# GetButtonFuntion(Eval("UserId"))%></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                </table>
                                <span style="margin-bottom: -100px;">
                                    <asp:Label ID="lblEmptyData" runat="server" Visible='<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>' Text="Không có bản ghi nào" />
                                </span>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div id="pop" class="popup"></div>
    </div>
</asp:Content>

