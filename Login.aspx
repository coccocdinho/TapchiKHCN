﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <head>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
        <meta charset="utf-8" />
        <title>Đăng nhập</title>

        <meta name="description" content="User login page" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

        <!-- bootstrap & fontawesome -->
        <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
        <link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

        <!-- text fonts -->
        <link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

        <!-- ace styles -->
        <link rel="stylesheet" href="assets/css/ace.min.css" />

        <!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
        <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

        <!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

        <!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

        <!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    </head>
</head>
<body class="login-layout blur-login">
    <form id="form1" runat="server">
        <div class="main-container">
            <div class="main-content">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1">
                        <div class="login-container">
                            <div class="center">
                            </div>

                            <div class="space-6"></div>

                            <div class="position-relative">
                                <div id="login-box" class="login-box visible widget-box no-border">
                                    <div class="widget-body">
                                        <h1 align="center">
                                            <%--<i class="ace-icon fa fa-leaf green"></i> --%>
                                            <span class="red">TẠP CHÍ KH&CN</span>
                                        </h1>
                                        <h4 class="red" align="center" id="id-company-text">ĐẠI HỌC THÁI NGUYÊN</h4>
                                        <div class="widget-main">
                                            <div class="space-6">
                                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                            </div>
                                            <form>
                                                <fieldset>
                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input runat="server" id="txtEmail" type="text" class="form-control" placeholder="Email" />
                                                            <i class="ace-icon fa fa-envelope"></i>
                                                        </span>
                                                    </label>

                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input runat="server" id="txtPassword" type="password" class="form-control" placeholder="Mật khẩu" />
                                                            <i class="ace-icon fa fa-lock"></i>
                                                        </span>
                                                    </label>

                                                    <div class="space"></div>

                                                    <div class="clearfix">
                                                        <label class="inline">
                                                            <input type="checkbox" class="ace" />
                                                            <span class="lbl">Duy trì đăng nhập</span>
                                                        </label>

                                                        <a href="view/quenmatkhau.aspx" style="float: right; font-weight: 400; font-size: 14px;" data-target="#forgot-box">Quên mật khẩu?</a>

                                                        <asp:Button ID="btnLogin" OnClick="btnLogin_Click" runat="server" CssClass="pull-right btn btn-sm btn-primary" Text="Đăng Nhập" />

                                                        <div style="padding-top: 60px;">
                                                            <label style="float: right">
                                                                <span class="lbl">Bạn chưa có tài khoản? </span><a href="view/dangky.aspx">Đăng ký</a>
                                                            </label>
                                                        </div>
                                                        <%--<i class="ace-icon fa fa-key"></i>
                                                        <span class="bigger-110">Đăng nhập</span>--%>
                                                        <%--</asp:Button>--%>
                                                    </div>

                                                    <div class="space-4">
                                                        
                                                    </div>
                                                </fieldset>
                                            </form>

                                        </div>
                                        <!-- /.widget-main -->



                                        <div class="toolbar clearfix">
                                            <%--    <div>
                                                <a href="#" data-target="#forgot-box" class="forgot-password-link">
                                                    <i class="ace-icon fa fa-arrow-left"></i>
                                                    Quên mật khẩu
                                                </a>
                                            </div>

                                            <div>
                                                <a href="#" data-target="#signup-box" class="user-signup-link">Đăng ký
													<i class="ace-icon fa fa-arrow-right"></i>
                                                </a>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <!-- /.widget-body -->
                                </div>
                                <!-- /.login-box -->

                                <div id="forgot-box" class="forgot-box widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header red lighter bigger">
                                                <i class="ace-icon fa fa-key"></i>
                                                Quên mật khẩu
                                            </h4>

                                            <div class="space-6"></div>
                                            <p>
                                                Nhập địa chỉ email của bạn để nhận hướng dẫn chi tiết.
                                            </p>

                                            <form>
                                                <fieldset>
                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="email" class="form-control" placeholder="Email" />
                                                            <i class="ace-icon fa fa-envelope"></i>
                                                        </span>
                                                    </label>

                                                    <div class="clearfix">
                                                        <button type="button" class="width-35 pull-right btn btn-sm btn-danger">
                                                            <i class="ace-icon fa fa-lightbulb-o"></i>
                                                            <span class="bigger-110">Gửi</span>
                                                        </button>
                                                    </div>
                                                </fieldset>
                                            </form>
                                        </div>
                                        <!-- /.widget-main -->

                                        <div class="toolbar center">
                                            <a href="#" data-target="#login-box" class="back-to-login-link">Back to login
												<i class="ace-icon fa fa-arrow-right"></i>
                                            </a>
                                        </div>
                                    </div>
                                    <!-- /.widget-body -->
                                </div>
                                <!-- /.forgot-box -->

                                <div id="signup-box" class="signup-box widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header green lighter bigger">
                                                <i class="ace-icon fa fa-users blue"></i>
                                                New User Registration
                                            </h4>

                                            <div class="space-6"></div>
                                            <p>Enter your details to begin: </p>

                                            <form>
                                                <fieldset>
                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="email" class="form-control" placeholder="Email" />
                                                            <i class="ace-icon fa fa-envelope"></i>
                                                        </span>
                                                    </label>

                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="text" class="form-control" placeholder="Username" />
                                                            <i class="ace-icon fa fa-user"></i>
                                                        </span>
                                                    </label>

                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="password" class="form-control" placeholder="Password" />
                                                            <i class="ace-icon fa fa-lock"></i>
                                                        </span>
                                                    </label>

                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="password" class="form-control" placeholder="Repeat password" />
                                                            <i class="ace-icon fa fa-retweet"></i>
                                                        </span>
                                                    </label>

                                                    <label class="block">
                                                        <input type="checkbox" class="ace" />
                                                        <span class="lbl">I accept the
															<a href="#">User Agreement</a>
                                                        </span>
                                                    </label>

                                                    <div class="space-24"></div>

                                                    <div class="clearfix">
                                                        <button type="reset" class="width-30 pull-left btn btn-sm">
                                                            <i class="ace-icon fa fa-refresh"></i>
                                                            <span class="bigger-110">Reset</span>
                                                        </button>

                                                        <button type="button" class="width-65 pull-right btn btn-sm btn-success">
                                                            <span class="bigger-110">Register</span>

                                                            <i class="ace-icon fa fa-arrow-right icon-on-right"></i>
                                                        </button>
                                                    </div>
                                                </fieldset>
                                            </form>
                                        </div>

                                        <div class="toolbar center">
                                            <a href="#" data-target="#login-box" class="back-to-login-link">
                                                <i class="ace-icon fa fa-arrow-left"></i>
                                                Back to login
                                            </a>
                                        </div>
                                    </div>
                                    <!-- /.widget-body -->
                                </div>
                                <!-- /.signup-box -->
                            </div>
                            <!-- /.position-relative -->

                            <%--<div class="navbar-fixed-top align-right">
                            <br />
                            &nbsp;
								<a id="btn-login-dark" href="#">Dark</a>
                            &nbsp;
								<span class="blue">/</span>
                            &nbsp;
								<a id="btn-login-blur" href="#">Blur</a>
                            &nbsp;
								<span class="blue">/</span>
                            &nbsp;
								<a id="btn-login-light" href="#">Light</a>
                            &nbsp; &nbsp; &nbsp;
                        </div>--%>
                        </div>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.main-content -->
        </div>
        <!-- /.main-container -->

        <!-- basic scripts -->

        <!--[if !IE]> -->
        <script src="assets/js/jquery-2.1.4.min.js"></script>

        <!-- <![endif]-->

        <!--[if IE]>
<script src="assets/js/jquery-1.11.3.min.js"></script>
<![endif]-->
        <script type="text/javascript">
            if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
        </script>

        <!-- inline scripts related to this page -->
        <script type="text/javascript">
            jQuery(function ($) {
                $(document).on('click', '.misspass a[data-target]', function (e) {
                    e.preventDefault();
                    var target = $(this).data('target');
                    $('.widget-box.visible').removeClass('visible');//hide others
                    $(target).addClass('visible');//show target
                });
            });



            //you don't need this, just used for changing background
            jQuery(function ($) {
                $('#btn-login-dark').on('click', function (e) {
                    $('body').attr('class', 'login-layout');
                    $('#id-text2').attr('class', 'white');
                    $('#id-company-text').attr('class', 'blue');

                    e.preventDefault();
                });
                $('#btn-login-light').on('click', function (e) {
                    $('body').attr('class', 'login-layout light-login');
                    $('#id-text2').attr('class', 'grey');
                    $('#id-company-text').attr('class', 'blue');

                    e.preventDefault();
                });
                $('#btn-login-blur').on('click', function (e) {
                    $('body').attr('class', 'login-layout blur-login');
                    $('#id-text2').attr('class', 'white');
                    $('#id-company-text').attr('class', 'light-blue');

                    e.preventDefault();
                });

            });

            function CheckLogin(TaxId, IncidentId, type) {
                var _url = "../Handler/ProcessDeleteTaxOrder.ashx/ProcessTaxOrder";
                var _data = "TaxId=" + TaxId + "&IncidentId=" + IncidentId + "&Type=" + type + "&User_Id=" + User_Id;
                $.ajax({
                    type: "POST",
                    url: _url,
                    data: _data,
                    async: false,
                    dataType: "html",
                    success: function (data) {
                        if (data.length > 0) {
                            alert(data);
                        } else { alert('Bạn cập nhật trạng thái Hóa đơn thành công'); }
                        location.reload();
                    },
                    error: function (err) {
                        alert("Hệ thống xảy ra lỗi.");
                        check = false;
                    }
                });
            }

        </script>

        <div>
        </div>
    </form>
</body>
</html>
