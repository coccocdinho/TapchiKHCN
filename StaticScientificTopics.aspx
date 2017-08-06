<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="StaticScientificTopics.aspx.cs" Inherits="StaticScientificTopics" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <label class="col-sm-1 control-label no-padding-right" for="form-field-1">Chọn năm</label>
        <div class="col-sm-1">
            <asp:DropDownList runat="server" ID="ddlYear"></asp:DropDownList>
        </div>
        <label class="col-sm-1 control-label no-padding-right" for="form-field-1">Chọn tháng</label>
        <div class="col-sm-1">
            <asp:DropDownList runat="server" ID="ddlMonth"></asp:DropDownList>
        </div>
        <label class="col-sm-1 control-label no-padding-right" for="form-field-1">Chuyên san</label>
        <div class="col-sm-2">
            <asp:DropDownList runat="server" ID="ddlChuyenSan"></asp:DropDownList>
        </div>
        <label class="col-sm-1 control-label no-padding-right" for="form-field-1">Trạng thái</label>
        <div class="col-sm-2">
            <asp:DropDownList runat="server" ID="ddlStatus">
                <asp:ListItem Text="Đã gửi" Value="1"></asp:ListItem>
                <asp:ListItem Text="Chấp nhận đăng" Value="2"></asp:ListItem>
                <asp:ListItem Text="Không duyệt" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-sm-1">
            <asp:Button runat="server" CssClass="btn btn-info btn-sm" Text="Thống kê" ID="btnStatic" OnClick="btnStatic_Click" />
        </div>
    </div>
    <div class="form-group">
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
                                        <th style="text-align: center; vertical-align: middle;">Tác giả</th>
                                        <th style="text-align: center; vertical-align: middle;">Chuyên san</th>
                                        <th style="text-align: center; vertical-align: middle;">Ngày gửi</th>
                                        <th style="text-align: center; vertical-align: middle;">Phản biện</th>
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
                                <td style="width: 120px; text-align: center;"><%# Eval("Author") %></td>
                                <td style="width: 120px; text-align: center;"><%# Eval("JournaName") %></td>
                                <td style="width: 120px; text-align: center;"><%# UtilityFormat.FormatDateToString(Convert.ToDateTime(Eval("CreateDate"))) %></td>
                                <td style="width: 120px; text-align: center;"><%# Eval("PhanBien") %></td>
                                <td style="width: 120px; text-align: center;"><%# Eval("StatusName") %></td>
                                <td style="width: 120px; text-align: center;"><%# Eval("GroupTopicName") %></td>
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
                    <cc1:collectionpager id="pager" runat="server" pagesize="30"></cc1:collectionpager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

