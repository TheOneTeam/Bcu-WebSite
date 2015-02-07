<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site.Master" CodeBehind="course.aspx.cs" Inherits="WebSite.page.hnd.course" %>
<asp:Content runat="server" ID="TitleContent" ContentPlaceHolderID="TitleContent">
    <title>课程对接</title>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container rel">
        <div class="page-cont">
            <div class="page-tt">
                <h1 class="page-h1 lt">课程对接</h1>
                <div class="page-menu rt">
                    <a href="/">返回首页</a>><a>课程对接</a>
                </div>
                <div class="clear"></div>
            </div>
            <div class="page-lt">
                <table class="bcu-tb1" border="1">
                        <tr>
                            <th><div class="fz14"><b>HND专业</b></div></th>
                            <th><div class="fz14"><b>所衔接的课程</b></div></th>
                        </tr>
                        <tr>
                            <th>
                                <div class="fz14"><b>Business</b></div>
                            </th>
                            <td>
                                <ul class="page-ol">
                                    <li><span>BA (Hons) Business & Management Year3</span></li>
                                    <li><span>BA (Hons)  Business Administration (top-up)</span></li>
                                    <li><span>BA (Hons) International Business (top-up)</span></li>                                    
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <div class="fz14"><b>Business with Accounting</b></div>
                            </th>
                            <td>
                                <ul class="page-ol">
                                    <li><span>BA (Hons)  Accountancy & Business Year 3</span></li>
                                    <li><span>BA (Hons) Business Administration (top-up)</span></li>
                                    <li><span>BA (Hons) International Business (top-up)</span></li> 
                                    <li><span>BA (Hons) International Finance (top-up)</span></li>                                    
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <div class="fz14"><b>Business with HRM</b></div>
                            </th>
                            <td>
                                <ul class="page-ol">
                                    <li><span>BA (Hons) Business & HRM Final Year</span></li>
                                    <li><span>BA (Hons) Business Administration  (top-up)</span></li>
                                    <li><span>BA (Hons) International Business (top-up)</span></li>                                    
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <div class="fz14"><b>Business with Marketing</b></div>
                            </th>
                            <td>
                                <ul class="page-ol">
                                    <li><span>BA (Hons) Business & Marketing Final Year</span></li>
                                    <li><span>BA (Hons) Business Administration  (top-up)</span></li>
                                    <li><span>BA (Hons) International Business (top-up)</span></li>  
                                    <li><span>BA (Hons) International Marketing (top-up)</span></li>                                    
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <div class="fz14"><b>Global Trade and Business</b></div>
                            </th>
                            <td>
                                <ul class="page-ol">
                                    <li><span>BA (Hons) International Business (top-up)</span></li>                                   
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <div class="fz14"><b>Financial Services</b></div>
                            </th>
                            <td>
                                <ul class="page-ol">
                                    <li><span>BA (Hons) Business & Finance Final Year3</span></li>
                                    <li><span>BA (Hons) Business Administration  (top-up)</span></li>
                                    <li><span>BA (Hons) International Business (top-up)</span></li>  
                                    <li><span>BA (Hons) International Finance (top-up)</span></li> 
                                </ul>
                            </td>
                        </tr>
                    </table>
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