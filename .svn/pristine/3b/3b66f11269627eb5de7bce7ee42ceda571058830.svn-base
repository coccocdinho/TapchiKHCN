<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="GroupTopicListPage.aspx.cs" Inherits="GroupTopicListPage" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/js/ShowDialog.js?ver<%=DateTime.Now.Ticks.ToString()%>" type="text/javascript"></script>
    <script type="text/javascript">
        var PageGUID = "1111-222226";
        var Popup = {
            ObjDetail: { popupName: "ObjDetail", popupTitle: "Thêm mới Tạp chí", popupWidth: 900, popupHeight: 400, popupScrollable: "yes", url: "GroupTopicAddPage.aspx", ShowPopup: ShowPopup, ClosePopup: ClosePopup }
        }

        function OpenDelete(keyid) {
            var isOk = confirm("Bạn có chắc muốn xóa?");
            if (!isOk) return;
            var _url = "Handler/DeleteChuyenSan.ashx/Process";
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

        //Popup sửa
        function OpenUpdate(keyid) {
            var dialogWidth = 900;
            var dialogHeight = 400;
            var dialogStyle = "DynamicDialogStyle";
            var url = "GroupTopicAddPage.aspx?KeyId=" + keyid;
            var dialogTitle = "Cập nhật Tạp chí";
            ShowDialog("OpenUpdate", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }

        //Popup sửa
        function OpenListScienTopic(keyid) {
            var dialogWidth = 900;
            var dialogHeight = 600;
            var dialogStyle = "DynamicDialogStyle";
            var url = "ListScientTopicByGroup.aspx?KeyId=" + keyid;
            var dialogTitle = "Danh sách Bài báo";
            ShowDialog("ListScientTopicByGroup", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }
    </script>
    <div id="User" style="width: 100%; padding: 1px 15px; position: relative;">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <div class="row">
            <div class="form-group">
                <label class="col-sm-1 control-label no-padding-right" for="form-field-1">Chọn nhóm</label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" Width="200px">
                    </asp:DropDownList>
                </div>
                <label class="col-sm-2 control-label no-padding-right" for="form-field-1">Chọn trạng thái</label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="2">Tất cả</asp:ListItem>
                        <asp:ListItem Value="1">Đã phát hành</asp:ListItem>
                        <asp:ListItem Value="0">Chưa phát hành</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3 control-label no-padding-right">
                    <input id="btnAddNew" style="margin-right:30px;" runat="server" class="btn btn-info btn-sm" onclick="Popup.ObjDetail.ShowPopup()" type="button" value="Thêm mới" />
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
                                        <th style="text-align: center; vertical-align: middle;">Tên tạp chí</th>
                                        <th style="text-align: center; vertical-align: middle;">Mô tả</th>
                                        <th style="text-align: center; vertical-align: middle;">Ngày tạo</th>
                                        <th style="text-align: center; vertical-align: middle;">Xuất bản</th>
                                        <th style="text-align: center; vertical-align: middle;">Chức năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 30px; text-align: center"><%#Container.ItemIndex +1%></td>
                                <td style="width: auto; text-align: center"><%# Eval("Name") %></td>
                                <td style="width: 120px; text-align: center;"><%# Eval("Description") %></td>
                                <td style="width: 120px; text-align: center;"><%# UtilityFormat.FormatDateToString(Convert.ToDateTime(Eval("CreateDate"))) %></td>
                                <td style="width: 120px; text-align: center;"><asp:CheckBox runat="server" ID="chkStatus" Checked='<%# Eval("GroupTopicStatus") %>' /></td>
                                <td style="width: 120px; text-align: center;"><%# GetButtonFuntion(Eval("GroupTopicId"))%></td>
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
                    <cc1:CollectionPager ID="pager" runat="server" PageSize="20"></cc1:CollectionPager>
                </div>
            </div>
        </div>
        <div id="pop" class="popup"></div>
    </div>
</asp:Content>

