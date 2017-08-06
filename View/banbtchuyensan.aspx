<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="banbtchuyensan.aspx.cs" Inherits="View_banbtchuyensan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p align="center">
        <strong>DANH SÁCH THƯỜNG TRỰC BAN BIÊN TẬP</strong>
    </p>
    <p align="center">
        <strong>TẠP CHÍ KHOA HỌC VÀ CÔNG NGHỆ - ĐẠI HỌC THÁI NGUYÊN</strong>
    </p>
    <br />
    <p align="center">
        Chuyên san: <strong>Nông Lâm – Sinh - Y</strong>
    </p>
    <table summary="Summary Here" class="tbdisplay">
        <thead>
            <tr>
                <th>STT</th>
                <th>Họ và tên</th>
                <th>Trách nhiệm</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpt1">
                <ItemTemplate>

                    <tr class="light">
                        <td><%#Container.ItemIndex +1%></td>
                        <td><a href='thongtincanhan.aspx?Id=<%# Eval("Id") %>'><%# Eval("PrifixName") %> <%# Eval("FullName") %></a></td>
                        <td><%# Eval("PositionInScient") %></td>
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
        </tbody>
    </table>
    <p align="center">
        Chuyên san: <strong>Khoa học tự nhiên – Kỹ thuật</strong>
    </p>
    <table summary="Summary Here" class="tbdisplay">
        <thead>
            <tr>
                <th>STT</th>
                <th>Họ và tên</th>
                <th>Trách nhiệm</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpt2">
                <ItemTemplate>

                    <tr class="light">
                        <td><%#Container.ItemIndex +1%></td>
                        <td><a href='thongtincanhan.aspx?Id=<%# Eval("Id") %>'><%# Eval("PrifixName") %> <%# Eval("FullName") %></a></td>
                        <td><%# Eval("PositionInScient") %></td>
                    </tr>

                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                </table>
                                <span style="margin-bottom: -100px;">
                                    <asp:Label ID="Label1" runat="server" Visible='<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>' Text="Không có bản ghi nào" />
                                </span>
                </FooterTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <p align="center">
        Chuyên san: <strong>Khoa học xã hội – Hành vi – Kinh tế</strong>
    </p>
    <table summary="Summary Here" class="tbdisplay">
        <thead>
            <tr>
                <th>STT</th>
                <th>Họ và tên</th>
                <th>Trách nhiệm</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpt3">
                <ItemTemplate>

                    <tr class="light">
                        <td><%#Container.ItemIndex +1%></td>
                        <td><a href='thongtincanhan.aspx?Id=<%# Eval("Id") %>'><%# Eval("PrifixName") %> <%# Eval("FullName") %></a></td>
                        <td><%# Eval("PositionInScient") %></td>
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
        </tbody>
    </table>


    <script>
        $('.tbdisplay > tbody  > tr').each(function () {
            var index = $(".tbdisplay tr").index(this);
            if (index % 2 == 0) {
                $(this).addClass("dark");
            }
            else {
                $(this).addClass("light");
            }
        });
    </script>
</asp:Content>

