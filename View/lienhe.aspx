<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="lienhe.aspx.cs" Inherits="View_lien_he" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contactform">
        <h2 align="center"><strong>LIÊN HỆ</strong></h2>
        <form action="#" method="post">
            <fieldset>
                <legend>Contact Form</legend>
                <label for="fullname">
                    Họ tên:
                    <input id="fullname"
                        name="fullname" type="text" value="" />
                </label>
                <br>
                <label for="emailaddress" class="margin">
                    Email:
                    <input
                        id="emailaddress" name="emailaddress" type="text" value="" />
                </label>
                <br>
                <label for="phone">
                    Điện thoại:
                    <input id="phone"
                        name="phone" type="text" value="" />
                </label>
                <br>
                <label for="message">
                    Nội dung:<br />
                    <textarea
                        id="message" name="message" cols="40" rows="4"></textarea>
                </label>
                <br>
                <p>
                    <input id="submitform" name="submitform" type="submit"
                        value="Gửi" />
                </p>
            </fieldset>
        </form>
    </div>
</asp:Content>

