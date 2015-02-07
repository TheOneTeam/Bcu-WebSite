<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site.Master" CodeBehind="stay.aspx.cs" Inherits="WebSite.page.live.stay" %>
<asp:Content runat="server" ID="TitleContent" ContentPlaceHolderID="TitleContent">
    <title>学校住宿</title>
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
                <p class="fz13 tindent20">作为国际化的大都市，伯明翰能满足各种的住宿需求，包括学生宿舍，学校管理的私人住宅和寄宿家庭。只要在开学前提交申请，大学将优先为国际学生安排就读期间的校园住宿。</p>
                <p class="fz13 tindent20">大多数学生住宿是自炊的，即学生需要自己做饭，并打扫房间卫生。所有房间都有家具，电话和互联网。厨房设有炉具，冰箱，微波炉但不包括餐具。租金包括暖气，水，电。</p>
                <p class="fz13 tindent20">如及时申请，所有中国学生都能获得入住校园宿舍的机会。每个学生有自己的房间，可以在宿舍里上网。</p>
                <p class="fz13 tindent20">同时，学校可以向愿意住在校外的学生提供房源信息，协助其找到合适的住宿。学生在抵达伯明翰时，大学会安排工作人员及志愿者会在伯明翰机场设立咨询台迎接学生并指引学生如何抵达宿舍。</p>
                <p class="fz13 tindent20">具体住宿信息请查阅： http://www.bcu.ac.uk/student-info/accommodation</p>
                <table class="bcu-tb1 bcu-tb2" border="1">
                    <tr>
                        <th><b class="fz13">住宿名称</b></th>
                        <th><b class="fz13">房间类型</b></th>
                        <th><b class="fz13">地理位置</b></th>
                        <th><b class="fz13">优先安排</b></th>
                        <th><b class="fz13">每周价格</b></th>
                    </tr>
                    <tr>
                        <td>Oscott Gardens</td>
                        <td>5-8 间卧室的公寓, 公用厨房，卧室自带卫生间</td>
                        <td>Perry Barr,靠近城北校区</td>
                        <td>城北校区的学生</td>
                        <td>标准 - ￡116.00<br />大房 - ￡127.00<br />加大房-￡132.00</td>
                    </tr>
                    <tr>
                        <td>The Coppice</td>
                        <td>6间卧室的公寓，公用洗手间</td>
                        <td>Perry Barr,靠近城北校区</td>
                        <td>城北校区的学生</td>
                        <td>￡100.00起</td>
                    </tr>
                    <tr>
                        <td>Oakmount Hall</td>
                        <td>4-10间卧室的公寓</td>
                        <td>距市中心2公里</td>
                        <td>城南校区(健康专业的学生)</td>
                        <td>￡99.00起</td>
                    </tr>
                    <tr>
                        <td>Westmount Hall</td>
                        <td>4-10间卧室的公寓 </td>
                        <td>距市中心2公里</td>
                        <td>城南校区(健康专业的学生)</td>
                        <td>￡98.00起</td>
                    </tr>
                    <tr>
                        <td>Private Halls</td>
                        <td>公寓，公用厨房，卧室自带卫生间</td>
                        <td>市中心</td>
                        <td>技术工程学院、音乐学院、媒体学院和艺术设计学院的学生</td>
                        <td>￡105.52--￡114.50</td>
                    </tr>
                </table>
                <div class="fz14 m-t10 m-b10"><b>*以上为2014年9月入学学生住宿价格，仅供参考。</b></div>
                <img src="../../Images/kecheng/bg9.jpg" />
                <img src="../../Images/kecheng/bg10.jpg" />
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