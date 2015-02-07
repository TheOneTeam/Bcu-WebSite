<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="service.aspx.cs" Inherits="WebSite.page.live.service" %>
<asp:Content runat="server" ID="TitleContent" ContentPlaceHolderID="TitleContent">
    <title>国际学生服务</title>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container rel">
        <div class="page-cont">
            <div class="page-tt">
                <h1 class="page-h1 lt">学校住宿</h1>
                <div class="page-menu rt">
                    <a href="/">返回首页</a>><a>学校住宿</a>
                </div>
                <div class="clear"></div>
            </div>
            <div class="page-lt">
                <div class="fz14 m-t10 m-b10"><b>BCU为来自将近100个国家和地区的国际学生提供以下服务：</b></div>
                <ul class="page-ol">
                    <li><span>开学前3天安排工作人员及志愿者在伯明翰机场设立咨询台，指导国际学生如何到校。</span></li>
                    <li><span>移民和签证办公室：指导国际学生续签、访问签证办理等服务</span></li>
                    <li><span>就业指导办公室：指导国际学生如何准备简历，会定期安排校园招聘会组织公司进校园</span></li>
                    <li><span>理财指导办公室：指导国际学生如何在海外留学时更好的管理自己的财产</span></li>
                    <li><span>心理咨询办公室：为国际学生提供心理咨询等服务</span></li>
                    <li><span>住宿管理办公室：指导国际如何申请学校宿舍，为不准备申请学校宿舍的学生提供校外房源信息</span></li>
                    <li><span>国际办公室：国际学生有任何问题可以咨询我们位于市中心校区的国际办公室。</span></li>                        
                </ul>
                <img src="../../Images/kecheng/bg7.jpg" />
                <img src="../../Images/kecheng/bg8.jpg" />
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