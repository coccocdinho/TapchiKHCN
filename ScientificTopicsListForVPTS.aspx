﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="ScientificTopicsListForVPTS.aspx.cs" Inherits="ScientificTopicsListForVPTS" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/js/ShowDialog.js?ver<%=DateTime.Now.Ticks.ToString()%>" type="text/javascript"></script>
    <script type="text/javascript">
        var PageGUID = "1111-222223";
        var Popup = {
            ObjDetail: { popupName: "CustomerDetail", popupTitle: "Quản lý Khách hàng", popupWidth: 800, popupHeight: 360, popupScrollable: "yes", url: "ScientificTopicProcessPage.aspx", ShowPopup: ShowPopup, ClosePopup: ClosePopup }
        }

        function OpenDelete(keyid, userid) {
            var isOk = confirm("Bạn có chắc muốn xóa?");
            if (!isOk) return;
            var _url = "Handler/DeleteScientificTopics.ashx/Process";
            var _data = "CustomerId=" + keyid + "&UserId=" + userid;
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

        //Popup sửa
        function OpenUpdate(keyid) {
            var dialogWidth = 1000;
            var dialogHeight = 680;
            var dialogStyle = "DynamicDialogStyle";
            var url = "ScientificTopicProcessPage.aspx?KeyId=" + keyid;
            var dialogTitle = "Xử lý thông tin bài báo";
            ShowDialog("OpenUpdate", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }

        //Popup xem nhật ký
        function OpenHistory(keyid) {
            var dialogWidth = 1000;
            var dialogHeight = 400;
            var dialogStyle = "DynamicDialogStyle";
            var url = "ScientTopicProcessHistory.aspx?KeyId=" + keyid;
            var dialogTitle = "Nhật ký xử lý";
            ShowDialog("OpenUpdate", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }

        //Popup Kết xuất
        function OpenExport(keyid) {
            var dialogWidth = 800;
            var dialogHeight = 600;
            var dialogStyle = "DynamicDialogStyle";
            var url = "KetXuatNhanXet.aspx?KeyId=" + keyid;
            var dialogTitle = "Kết xuất File nhận xét";
            ShowDialog("KetXuatNhanXet", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }

    </script>
    <div id="User" style="width: 100%; padding: 1px 15px; position: relative;">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <div class="row">
            <div class="form-group">
                <div class="col-sm-4" style="padding-left:28px;">
                    <asp:TextBox runat="server" ID="txtAuthor" placeholder="Nhập tên hoặc tài khoản của tác giả)" class="form-control" />
                </div>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtTitle" placeholder="Nhập tên bài báo" class="form-control" />
                </div>
                <div class="col-sm-4">
                    <asp:Button CssClass="btn btn-info btn-sm" runat="server" ID="btnSearch" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                </div>
            </div>
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
                                        <th style="text-align: center; vertical-align: middle;">Tên bài báo</th>
                                        <th style="text-align: center; vertical-align: middle;">Mã bài báo</th>
                                        <th style="text-align: center; vertical-align: middle;">Ngày gửi</th>
                                        <th style="text-align: center; vertical-align: middle;">Tác giả</th>
                                        <th style="text-align: center; vertical-align: middle;">Trạng thái</th>
                                        <th style="text-align: center; vertical-align: middle;">Tạp chí</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 30px; text-align: center"><%#Container.ItemIndex +1%></td>
                                <td style="width: auto; text-align: center"><%# Eval("Title") %></td>
                                <td style="width: 120px; text-align: center;"><%# Eval("TopicCode") %></td>
                                <td style="width: 120px; text-align: center;"><%# UtilityFormat.FormatDateToString(Convert.ToDateTime(Eval("CreateDate"))) %></td>
                                <td style="width: 120px; text-align: center;"><%# Eval("FullName") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("StatusName") %></td>
                                <td style="width: 120px; text-align: center;"><%# Common.GetGroupName(int.Parse(Eval("ScientificTopicId").ToString()))%></td>
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
                <div class="pull-right">
                    <cc1:CollectionPager ID="pager" runat="server" PageSize="15"></cc1:CollectionPager>
                </div>
            </div>
        </div>
        <div id="pop" class="popup"></div>
    </div>
</asp:Content>