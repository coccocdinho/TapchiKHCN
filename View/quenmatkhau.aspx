<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="quenmatkhau.aspx.cs" Inherits="View_banbtchuyensan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 align="left">Quên mật khẩu</h2>
    <p>Vui lòng nhập email của bạn và bấm <strong>Gửi</strong> để nhận email với hướng dẫn chi tiết.</p>
    <fieldset>
        <form action="" method="post">
            <input type="email" size="50" style="height: 25px;" placeholder="Email">
            <input type="submit" value="Gửi" style="padding: 5px 20px;">
        </form>
    </fieldset>
</asp:Content>

