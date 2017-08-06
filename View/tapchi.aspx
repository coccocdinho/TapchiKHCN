<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="tapchi.aspx.cs" Inherits="View_tapchi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1><asp:Label runat="server" ID="lblGroupName"></asp:Label>  <asp:Label runat="server" ID="lblLinkDownFile"></asp:Label> </h1>
    <div id="infomation">
        <table summary="Summary Here" id="tblList">
            <thead>
                <tr>
                    <th>STT</th>
                    <th>Bài báo</th>
                    <th>Tác giả</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptListTopic">
                    <ItemTemplate>
                        <tr>
                            <td><%#Container.ItemIndex +1%></td>
                            <td><a
                                href='chitietbaibao.aspx?id=<%# Eval("ScientificTopicId") %>'><%# Eval("Title") %></a>
                                <p>
                                    <a
                                        href='chitietbaibao.aspx?id=<%# Eval("ScientificTopicId") %>'><%# Eval("TitleEn") %></a>
                                </p>
                            </td>
                            <td><%# Eval("Author") %></td>
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
    </div>
    <script>
        $('#tblList > tbody  > tr').each(function () {
            var index = $("#tblList tr").index(this);
            if (index % 2 == 0) {
                $(this).addClass("dark");
            }
            else {
                $(this).addClass("light");
            }
        });
    </script>
</asp:Content>

