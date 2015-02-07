<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="contact.aspx.cs" Inherits="WebSite.page.course" %>
<asp:Content runat="server" ID="TitleContent" ContentPlaceHolderID="TitleContent">
    <title>联系我们</title>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="right">
            <img src="images/a46.gif" />
            <div class="title ">在线咨询</div><br /><br />
            <table border="0" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td valign="top">学校名称:</td>
                    <td><asp:TextBox ID="txtSchoolName" runat="server" size="20" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">电话:</td>
                    <td><asp:TextBox ID="txtPhoneNum" runat="server" size="20" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">Email:</td>
                    <td><asp:TextBox ID="txtEmailAddress" runat="server" size="20" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">留言内容:</td>
                    <td><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                       <asp:Button ID="btnSubmit" Width="50px" Height="28px" runat="server" Text="提交"  />
                       <input name="btnreset"style="width:50px;height:28px;" type="reset" value="重置" /></td>
                </tr>
            </table>
        </div>
</asp:Content>