<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCustomer.master" AutoEventWireup="true" CodeFile="StaticGroupScientificTopics.aspx.cs" Inherits="StaticGroupScientificTopics" %>

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
                <asp:ListItem Text="Đã phát hành" Selected="True" Value="true"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-sm-1">
            <asp:Button runat="server" CssClass="btn btn-info btn-sm" Text="Thống kê" ID="btnStatic" OnClick="btnStatic_Click" />
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
                                    <th style="text-align: center; vertical-align: middle;">Tạp chí</th>
                                    <th style="text-align: center; vertical-align: middle;">Chuyên san</th>
                                    <th style="text-align: center; vertical-align: middle;">Số lượng bài</th>
                                    <th style="text-align: center; vertical-align: middle;">Trạng thái</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="width: 30px; text-align: center"><%#Container.ItemIndex +1%></td>
                            <td style="width: auto; text-align: center"><%# Eval("GroupName") %></td>
                            <td style="width: 120px; text-align: center;"><%# Eval("ChuyenSan") %></td>
                            <td style="width: 120px; text-align: center;"><%# Eval("Number") %></td>
                            <td style="width: auto; text-align: center;"><%# Eval("StatusName") %></td>
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
                <cc1:CollectionPager ID="pager" runat="server" PageSize="30"></cc1:CollectionPager>
            </div>
        </div>
    </div>
</asp:Content>

