<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="admisrequire.aspx.cs" Inherits="WebSite.page.hnd.admisrequire" %>
<asp:Content runat="server" ID="TitleContent" ContentPlaceHolderID="TitleContent">
    <title>入学要求</title>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container rel">
        <div class="page-cont">
            <div class="page-tt">
                <h1 class="page-h1 lt">入学要求</h1>
                <div class="page-menu rt">
                    <a href="/">返回首页</a>><a>入学要求</a>
                </div>
                <div class="clear"></div>
            </div>
            <div class="page-lt">
                <div class="fz14 m-t10 m-b10"><b>SQA-HND 成绩:全部通过所有课程，且考核课成绩至少为BBB,或ABC或AAC。
雅思成绩为6.0,单科不低于5.5.</b></div>
            </div>
            <div class="page-rt">
                <div class="page-block">
                    <a class="page-block-link">大学介绍</a>
                    <a class="page-block-link">学部介绍</a>
                    <a class="page-block-link">学院特色介绍</a>                   
                </div>
                <div class="page-block">
                    <h2 class="page-block-tt">视频播放</h2>
                    <div class="page-block-video">
                        <video style="width: 250px; height: 250px; background:#808080;"></video>
                    </div>
                </div>                
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>