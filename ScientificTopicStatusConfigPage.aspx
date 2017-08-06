<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="ScientificTopicStatusConfigPage.aspx.cs" Inherits="ScientificTopicStatusConfigPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/js/ShowDialog.js?ver<%=DateTime.Now.Ticks.ToString()%>" type="text/javascript"></script>
    <script type="text/javascript">
        var PageGUID = "1111-222224";
        var Popup = {
            ObjDetail: { popupName: "ObjDetail", popupTitle: "Quản lý Luồng đi", popupWidth: 800, popupHeight: 480, popupScrollable: "yes", url: "ScientificTopicStatusConfigAdd.aspx", ShowPopup: ShowPopup, ClosePopup: ClosePopup },
        }

        function OpenUpdate(keyid) {
            var dialogWidth = 800;
            var dialogHeight = 480;
            var dialogStyle = "DynamicDialogStyle";
            var url = "ScientificTopicStatusConfigAdd.aspx?KeyId=" + keyid;
            var dialogTitle = "Sửa thông tin";
            ShowDialog("dgUpdateMailserver", dialogWidth, dialogHeight, dialogStyle, url, dialogTitle, 'yes');
        }

    </script>
    <div id="User" style="width: 100%; padding: 1px 15px; position: relative;">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <div style="height: 30px; text-align: right; padding-bottom: 8px;">
            <input id="btnAddNew" runat="server" class="btn btn-info btn-sm" onclick="Popup.ObjDetail.ShowPopup()"
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
                                        <th style="text-align: center; vertical-align: middle;">Từ TT</th>
                                        <th style="text-align: center; vertical-align: middle;">Đến TT</th>
                                        <th style="text-align: center; vertical-align: middle;">Thao tác</th>
                                        <th style="text-align: center; vertical-align: middle;">Mô tả</th>
                                        <th style="text-align: center; vertical-align: middle;">Từ</th>
                                        <th style="text-align: center; vertical-align: middle;">Đến</th>
                                        <th style="text-align: center; vertical-align: middle;">Lưu dữ liệu</th>
                                        <th style="text-align: center; vertical-align: middle;">Chức năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 30px; text-align: center"><%#Container.ItemIndex +1%></td>
                                <td style="width: 120px; text-align: center"><%# Eval("FromStatus") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("ToStatus") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("ActionName") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("ActionDescription") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("FromRole") %></td>
                                <td style="width: auto; text-align: center;"><%# Eval("ToRole") %></td>
                                <td style="width: 120px; text-align: center;"><asp:CheckBox runat="server" ID="chkIsSaveData" Checked='<%#Convert.ToBoolean(Eval("IsSaveData"))%>' /> </td>
                                <td style="width: 80px; text-align: center;"><%# GetButtonFuntion(Eval("ConfigId"))%></td>
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

