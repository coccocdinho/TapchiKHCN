<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCTopicProcess.ascx.cs" Inherits="Usercontrol_UCTopicProcess" %>
<div class="row" style="padding-left: 15px; padding-right: 15px; padding-top: 8px;">
    <div class="row">
        <div class="col-md-12 table-container">
            <asp:Repeater runat="server" ID="rpList" ClientIDMode="Static">
                <HeaderTemplate>
                    <table class="table table-bordered invoiceRelease">
                        <thead>
                            <tr>
                                <th style="text-align: center; vertical-align: middle;">STT</th>
                                <th style="text-align: center; vertical-align: middle;">Người xử lý</th>
                                <th style="text-align: center; vertical-align: middle;">Nội dung</th>
                                <th style="text-align: center; vertical-align: middle;">Ngày xử lý</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width: 30px; text-align: center"><%#Container.ItemIndex +1%></td>
                        <td style="width: 120px; text-align: center"><%# Eval("UserName") %></td>
                        <td style="width: auto; text-align: center;"><%# Eval("ProcessContent") %></td>
                        <td style="width: 120px; text-align: center;"><%# UtilityFormat.FormatDateTimeToStringFullMinute(Convert.ToDateTime(Eval("ProcessDate"))) %></td>
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
