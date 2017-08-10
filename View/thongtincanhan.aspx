﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="thongtincanhan.aspx.cs" Inherits="View_thongtincanhan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 align="center">THÔNG TIN CÁ NHÂN</h1>
				<div class="leftcontent">
					<a href="#"><img runat="server" id="imgInfo" class="imgifo" src="images/imgl.gif" alt="" /></a>
				</div>
				<div class="rightcontent">
					<p class="headtitle"><asp:Label runat="server" ID="lblPrifixName"></asp:Label> <asp:Label runat="server" ID="lblFullName"></asp:Label></p>
					<table class="noborder"
						style="font-size: 12px; line-height: 12px;">
						<tr>
							<td width="35%">Cơ quan:</td>
							<td><strong><asp:Label runat="server" ID="lblCompanyName"></asp:Label></strong></td>
						</tr>
						<tr>
							<td width="35%">Chức vụ:</td>
							<td><strong><asp:Label runat="server" ID="lblPositionName"></asp:Label></strong></td>
						</tr>

						<tr>
							<td width="35%">Chức danh khoa học:</td>
							<td><strong><asp:Label runat="server" ID="lblPrifixName2"></asp:Label></strong></td>
						</tr>
						<tr>
							<td width="35%">Chuyên ngành:</td>
							<td><strong><asp:Label runat="server" ID="lblMajoringInScience"></asp:Label></strong></td>
						</tr>
						<tr>
							<td width="35%">Điện thoại:</td>
							<td><strong><asp:Label runat="server" ID="lblPhone"></asp:Label></strong></td>
						</tr>
						<tr>
							<td width="35%">Email:</td>
							<td><strong><asp:Label runat="server" ID="lblEmail"></asp:Label></strong></td>
						</tr>
					</table>
				</div>
</asp:Content>

