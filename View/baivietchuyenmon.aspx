﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="baivietchuyenmon.aspx.cs" Inherits="View_tinkhac" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Bài viết chuyên môn</h1>
    <asp:Repeater runat="server" ID="rptList">
        <ItemTemplate>
            <div class="listnews">
                <a href="#">
                    <img class="imgl" src='<%# ".."+Eval("Images") %>' alt="" /></a>
                <p class="headtitle">
                    <a href='chitiet.aspx?newId=<%# Eval("NewId") %>'><%# Eval("Title") %></a>
                </p>
                <span class="date"><%# UtilityFormat.FormatDateToString(Convert.ToDateTime(Eval("CreateDate"))) %></span>
                <p>
                    <%# Eval("ShortDescription") %>
                </p>
            </div>
        </ItemTemplate>
        <FooterTemplate>
                            </tbody>
                                </table>
                                <span style="margin-bottom: -100px;">
                                    <asp:Label ID="lblEmptyData" runat="server" Visible='<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>' Text="Không có bản ghi nào" />
                                </span>
                        </FooterTemplate>
    </asp:Repeater>

    <div class="pull-right">
        <cc1:CollectionPager ID="pager" runat="server" PageSize="5" BackText="« Trước" NextText="Sau »" ResultsFormat=""></cc1:CollectionPager>
    </div>
</asp:Content>

