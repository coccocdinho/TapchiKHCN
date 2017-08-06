<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.master" AutoEventWireup="true" CodeFile="ScientTopicProcessHistory.aspx.cs" Inherits="ScientTopicProcessHistory" %>

<%@ Register Src="Usercontrol/UCTopicProcess.ascx" TagName="UCTopicProcess" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="collapse1" class="col-sm-12">
        <uc1:UCTopicProcess ID="UCTopicProcess1" runat="server" />
    </div>
    <style type="text/css">
        #collapse1
        {
            overflow-y: scroll;
            height: 300px;
        }
    </style>
</asp:Content>

