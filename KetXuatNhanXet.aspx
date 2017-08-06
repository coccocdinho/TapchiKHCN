﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KetXuatNhanXet.aspx.cs" Inherits="KetXuatNhanXet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tạp chí KHCN Thái Nguyên</title>
    <style type="text/css">

 table.MsoNormalTable
	{font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Times New Roman","serif";
	        margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
        }
a:link
	{color:blue;
	text-decoration:underline;
	text-underline:single;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:670px;margin: 5px 35px;">
    
        <table border="0" cellpadding="0" cellspacing="0" class="MsoNormalTable" style="width:492.9pt;border-collapse:collapse;mso-yfti-tbllook:480;mso-padding-alt:
 0in 5.4pt 0in 5.4pt" width="657">
            <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes">
                <td style="width:215.4pt;padding:0in 5.4pt 0in 5.4pt" valign="top" width="287">
                    <p class="MsoNormal" style="tab-stops:right 189.6pt">
                        <b><span lang="PT-BR" style="mso-ansi-language:PT-BR">
                        <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span></b><span lang="PT-BR" style="mso-ansi-language:PT-BR">ĐẠI HỌC 
                        THÁI NGUYÊN</span><span lang="PT-BR" style="font-size:13.0pt;mso-ansi-language:
  PT-BR"><span style="mso-tab-count:1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><o:p></o:p>
                        </span>
                    </p>
                    <p class="MsoNormal">
                        <b style="mso-bidi-font-weight:normal"><span lang="PT-BR" 
                            style="mso-ansi-language:PT-BR">Tạp chí KHOA HỌC &amp; CÔNG NGHỆ<o:p></o:p></span></b></p>
                    <p align="center" class="MsoNormal" style="text-align:center">
                        <b style="mso-bidi-font-weight:normal">
                        <span lang="PT-BR" style="mso-ansi-language:
  PT-BR">ISSN 1859 - 2171<o:p></o:p></span></b></p>
                    <p class="MsoNormal">
                        <!--[if gte vml 1]><v:line id="_x0000_s1026" style='position:absolute;
   z-index:251657216' from="53.85pt,4.5pt" to="143.85pt,4.5pt" 
                            xmlns:v="urn:schemas-microsoft-com:vml"/><![endif]--><![if !vml]>
                        <span style="mso-ignore:vglayout;position:absolute;z-index:251657216;margin-left:
  71px;margin-top:5px;width:122px;height:2px">
                        <img height="2" 
                            src="file:///C:/Users/ADMINI~1/AppData/Local/Temp/msohtmlclip1/01/clip_image001.gif" 
                            v:shapes="_x0000_s1026" width="122" /></span><![endif]><b><span 
                            lang="PT-BR" style="mso-ansi-language:PT-BR"><o:p></o:p></span></b></p>
                </td>
                <td style="width:277.5pt;padding:0in 5.4pt 0in 5.4pt" valign="top" width="370">
                    <p align="center" class="MsoNormal" style="text-align:center">
                        <b style="mso-bidi-font-weight:normal">
                        <span lang="PT-BR" style="mso-ansi-language:
  PT-BR">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM<o:p></o:p></span></b></p>
                    <p align="center" class="MsoNormal" style="text-align:center">
                        <!--[if gte vml 1]><v:line
   id="_x0000_s1027" style='position:absolute;left:0;text-align:left;flip:y;
   z-index:251658240' from="64.85pt,16.05pt" to="196.85pt,16.05pt" 
                            xmlns:v="urn:schemas-microsoft-com:vml"/><![endif]--><![if !vml]>
                        <span style="mso-ignore:vglayout;position:absolute;z-index:251658240;left:0px;
  margin-left:85px;margin-top:20px;width:178px;height:2px">
                        <img height="2" 
                            src="file:///C:/Users/ADMINI~1/AppData/Local/Temp/msohtmlclip1/01/clip_image002.gif" 
                            v:shapes="_x0000_s1027" width="178" /></span><![endif]><b 
                            style="mso-bidi-font-weight:normal"><span lang="PT-BR" 
                            style="mso-ansi-language:PT-BR">Độc lập - Tự do - Hạnh phúc</span></b><b><span 
                            lang="PT-BR" style="font-size:13.0pt;mso-ansi-language:PT-BR"><o:p></o:p></span></b></p>
                </td>
            </tr>
        </table>
        <p align="center" class="MsoNormal" style="margin-left:2.5in;text-align:center;
text-indent:.5in;line-height:120%">
            <i>
            <span lang="PT-BR" style="font-size:11.0pt;
line-height:120%;mso-ansi-language:PT-BR">Thái Nguyên, ngày<span style="mso-spacerun:yes">&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>tháng<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</span>năm 
            </span>
            <asp:Label ID="lblNam1" runat="server" Text="Label"></asp:Label>
            </i></p>
        <p align="center" class="MsoNormal" style="text-align:center;line-height:120%">
            <b>
            <span lang="PT-BR" style="font-size:13.0pt;line-height:120%;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
mso-ansi-language:PT-BR"><o:p>&nbsp;</o:p></span></b></p>
        <p align="center" class="MsoNormal" style="text-align:center;line-height:120%">
            <b><span lang="PT-BR" 
                style="font-size:13.0pt;line-height:120%;mso-ansi-language:PT-BR">PHIẾU NHẬN 
            XÉT BÀI BÁO<o:p></o:p></span></b></p>
        <p class="MsoNormal" style="line-height:120%">
            <span lang="PT-BR" style="mso-ansi-language:
PT-BR"><o:p>&nbsp;</o:p></span></p>
        <p class="MsoNormal" 
            style="margin-top:6.0pt;text-align:justify;line-height:120%">
            <i style="mso-bidi-font-style:normal">
            <span lang="PT-BR" style="mso-ansi-language:
PT-BR;mso-bidi-font-weight:bold">Tên bài báo</span></i><i style="mso-bidi-font-style:
normal"><span lang="PT-BR" style="font-size:13.0pt;line-height:120%;mso-ansi-language:
PT-BR;mso-bidi-font-weight:bold">:</span></i><i><span lang="PT-BR" 
                style="font-size:13.0pt;line-height:120%;mso-ansi-language:PT-BR">.............................................................................................................................</span></i><span 
                lang="PT-BR" style="font-size:13.0pt;line-height:120%;mso-ansi-language:PT-BR"><o:p></o:p></span></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <asp:TextBox ID="txtTenBaiBao" runat="server" Height="142px" 
                TextMode="MultiLine" Width="659px"></asp:TextBox>
        </p>
        <p class="MsoNormal" style="margin-top:6.0pt;margin-right:0in;margin-bottom:6.0pt;
margin-left:0in;text-align:justify;line-height:120%">
            <i style="mso-bidi-font-style:
normal"><span lang="PT-BR" style="mso-ansi-language:PT-BR;mso-bidi-font-weight:
bold">Mã số:<o:p></o:p><asp:Label ID="lblMaSo" runat="server" Text="Label"></asp:Label>
            </span></i></p>
        <p class="MsoNormal" 
            style="margin-top:6.0pt;text-align:justify;line-height:120%">
            <b><span lang="PT-BR" style="mso-ansi-language:PT-BR"><o:p>&nbsp;</o:p></span></b></p>
        <p class="MsoNormal" 
            style="margin-top:6.0pt;text-align:justify;line-height:120%">
            <b><span lang="PT-BR" style="mso-ansi-language:PT-BR"><o:p>&nbsp;</o:p></span></b></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <b><span lang="PT-BR" 
                style="font-size:13.0pt;line-height:120%;mso-ansi-language:PT-BR">I. Ý KIẾN <span style="mso-spacerun:yes">ĐÁNH GIÁ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></b></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <strong>1</strong><b><span lang="PT-BR" 
                style="mso-ansi-language:PT-BR;mso-bidi-font-style:italic">. Ý nghĩa khoa 
            học và thực tiễn<o:p></o:p></span></b></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <asp:TextBox ID="txtYNghiaThucTien" runat="server" Height="142px" 
                TextMode="MultiLine" Width="659px"></asp:TextBox>
        </p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            &nbsp;</p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <strong>2</strong><b><span lang="PT-BR" 
                style="mso-ansi-language:PT-BR;mso-bidi-font-style:italic">. Hình thức và 
            bố cục</span></b><span lang="PT-BR" style="mso-ansi-language:PT-BR"> (Sự rõ 
            ràng, mạch lạc? Phân bố giữa các phần, bảng biểu, hình vẽ... có hợp lý? Những 
            câu, từ ngữ nên sửa?...). <i>Người nhận xét có thể đánh dấu và sửa chữa vào bài 
            báo</i><b><span style="mso-bidi-font-style:italic"><o:p></o:p></span></b></span></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <span lang="PT-BR" 
                style="font-size:13.0pt;line-height:120%;mso-ansi-language:PT-BR">
            .</span></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <asp:TextBox ID="txtHinhThucBoCuc" runat="server" Height="142px" 
                TextMode="MultiLine" Width="659px"></asp:TextBox>
        </p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            &nbsp;</p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <strong>3</strong><b style="mso-bidi-font-weight:normal"><span lang="PT-BR" style="mso-ansi-language:
PT-BR">. Cách tiếp cận và phương pháp nghiên cứu</span></b><span lang="PT-BR" 
                style="mso-ansi-language:PT-BR"> (Những vấn đề cần sửa chữa hoặc đề nghị tác 
            giả làm rõ...). <i>Người nhận xét có thể đánh dấu và chữa vào bài báo.</i><o:p></o:p></span></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <o:p></o:p></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <asp:TextBox ID="txtCachTiepCan" runat="server" Height="142px" 
                TextMode="MultiLine" Width="659px"></asp:TextBox>
        </p>
        <p class="MsoNormal" 
            style="margin-top:6.0pt;text-align:justify;line-height:120%">
            &nbsp;</p>
        <p class="MsoNormal" 
            style="margin-top:6.0pt;text-align:justify;line-height:120%">
            <strong>4</strong><b><span lang="PT-BR" 
                style="mso-ansi-language:PT-BR;mso-bidi-font-style:italic">. Kết quả nghiên 
            cứu mới (</span></b><span lang="PT-BR" style="mso-ansi-language:PT-BR;
mso-bidi-font-weight:bold;mso-bidi-font-style:italic">Những đóng góp mới về khoa học&amp;công 
            nghệ</span><span lang="PT-BR" style="mso-ansi-language:PT-BR"> hoặc là giải pháp 
            mới trong ứng dụng thực tiễn? Có trùng lặp với nội dung đã công bố của công 
            trình khác không?<b><span style="mso-bidi-font-style:italic"> <o:p></o:p>
            </span>
            </b></span>
        </p>
        <p class="MsoNormal" 
            style="margin-top:6.0pt;text-align:justify;line-height:120%">
            <o:p></o:p>
        </p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <asp:TextBox ID="txtKetQuaNghienCuu" runat="server" Height="142px" 
                TextMode="MultiLine" Width="659px"></asp:TextBox>
        </p>
        <p class="MsoNormal" style="margin-top:6.0pt;text-align:justify">
            &nbsp;</p>
        <p class="MsoNormal" style="margin-top:6.0pt;text-align:justify">
            <strong>5</strong><b><span lang="PT-BR" style="mso-ansi-language:PT-BR">. <span lang="PT-BR" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-ansi-language:PT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">. Những vấn đề cần sửa chữa trước khi đăng </span><i style="mso-bidi-font-style:
normal"><span lang="PT-BR" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-ansi-language:PT-BR;mso-fareast-language:
EN-US;mso-bidi-language:AR-SA;mso-bidi-font-weight:bold">(<span style="letter-spacing:-.2pt">Người nhận xét có thể sửa trực tiếp vào bài hoặc có thể đính kèm thêm bản nhận xét chi tiết.</span>)</span></i></span></b></p>
        <p class="MsoNormal" style="margin-top:6.0pt;text-align:justify">
            <o:p></o:p></p>
        <p class="MsoNormal" style="text-align:justify;line-height:120%">
            <asp:TextBox ID="txtNhungVanDe" runat="server" Height="142px" 
                TextMode="MultiLine" Width="659px"></asp:TextBox>
        </p>
        <p class="MsoNormal">
            <b style="mso-bidi-font-weight:normal"><span lang="PT-BR" style="mso-ansi-language:
PT-BR">6. Những ý kiến khác (nếu có)<o:p></o:p></span></b></p>
        <p class="MsoNormal">
            <o:p></o:p>
        </p>
        <p class="MsoNormal" style="margin-top:6.0pt;text-align:justify">
            <asp:TextBox ID="txtYKienKhac" runat="server" Height="142px" 
                TextMode="MultiLine" Width="659px"></asp:TextBox>
        </p>
        <p class="MsoNormal" style="margin-top:6.0pt;margin-right:0in;margin-bottom:6.0pt;
margin-left:0in;text-align:justify;line-height:120%">
            7<b><span lang="PT-BR" 
                style="font-size:13.0pt;line-height:120%;mso-ansi-language:PT-BR">. KẾT 
            LUẬN</span><span lang="PT-BR" style="mso-ansi-language:PT-BR"><o:p></o:p></span></b></p>
        <p class="MsoNormal" style="margin-left:.5in;text-align:justify;text-indent:.5in;
line-height:130%;tab-stops:102.0pt">
            <asp:CheckBox ID="cbkeLuan1" runat="server" 
                Text="Đồng ý đăng" />
        </p>
        <p class="MsoNormal" style="margin-left:.5in;text-align:justify;text-indent:.5in;
line-height:130%;tab-stops:102.0pt">
            <asp:CheckBox ID="cbkeLuan2" runat="server" 
                Text="Đồng ý đăng và sửa chữa (không cần gửi lại phản biện)" />
        </p>
        <p class="MsoNormal" style="margin-left:.5in;text-align:justify;text-indent:.5in;
line-height:130%;tab-stops:102.0pt">
            <asp:CheckBox ID="cbkeLuan3" runat="server" 
                Text="Đồng ý đăng và sửa chữa (phải gửi lại phản biện)" />
        </p>
        <p class="MsoNormal" style="margin-left:.5in;text-align:justify;text-indent:.5in;
line-height:130%;tab-stops:102.0pt">
            <asp:CheckBox ID="cbkeLuan4" runat="server" Text="Không đồng ý đăng" />
        </p>
        <p class="MsoNormal" 
            style="text-align:justify;text-indent:.5in;tab-stops:102.0pt">
            <span lang="PT-BR" style="mso-ansi-language:PT-BR">
            <span style="mso-tab-count:2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span><o:p></o:p></span>
        </p>
        <p class="MsoNormal">
            <span lang="PT-BR" style="mso-ansi-language:PT-BR"><o:p>&nbsp;</o:p></span></p>
        <p class="MsoNormal">
            <span lang="PT-BR" style="mso-ansi-language:PT-BR"><o:p>&nbsp;</o:p></span></p>
    
    </div>
    <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" 
        Text="Kết xuất" Width="200px" />
    </form>
</body>
</html>
