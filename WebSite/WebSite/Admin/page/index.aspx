<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSite.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebSite.Admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        
            <!-- widget grid -->
            <section id="widget-grid" class="">

                <!-- row -->
                <div class="row">

                    <!-- NEW WIDGET START -->
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

                        <div class="jarviswidget jarviswidget-color-blueDark" id="wid-id-2" data-widget-editbutton="false">
                            <!-- widget options:
                            usage: <div class="jarviswidget" id="wid-id-0" data-widget-editbutton="false">

                            data-widget-colorbutton="false"
                            data-widget-editbutton="false"
                            data-widget-togglebutton="false"
                            data-widget-deletebutton="false"
                            data-widget-fullscreenbutton="false"
                            data-widget-custombutton="false"
                            data-widget-collapsed="true"
                            data-widget-sortable="false"

                            -->
                            <header>
                                <span class="widget-icon"> <i class="fa fa-table"></i> </span>
                                <h2>留言列表</h2>

                            </header>

                            <!-- widget div-->
                            <div>

                                <!-- widget edit box -->
                                <div class="jarviswidget-editbox">
                                    <!-- This area used as dropdown edit box -->

                                </div>
                                <!-- end widget edit box -->
                                <!-- widget content -->
                                <div class="widget-body no-padding">
                                    <div class="widget-body-toolbar">

                                    </div>
                                    <table id="datatable_col_reorder" class="table table-striped table-hover">
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>标题</th>
                                                <th>留言内容</th>
                                                <th>创建时间</th>
                                                <th>状态</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <td>Jennifer</td>
                                                <td>1-342-463-8341</td>
                                                <td>Et Rutrum Non Associates</td>
                                                <td>35728</td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>Clark</td>
                                                <td>1-516-859-1120</td>
                                                <td>Nam Ac Inc.</td>
                                                <td>7162</td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>Brendan</td>
                                                <td>1-724-406-2487</td>
                                                <td>Enim Commodo Limited</td>
                                                <td>98611</td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>Warren</td>
                                                <td>1-412-485-9725</td>
                                                <td>Odio Etiam Institute</td>
                                                <td>10312</td>
                                            </tr>
                                            <tr>
                                                <td>5</td>
                                                <td>Rajah</td>
                                                <td>1-849-642-8777</td>
                                                <td>Neque Ltd</td>
                                                <td>29131</td>
                                            </tr>
                                            <tr>
                                                <td>6</td>
                                                <td>Demetrius</td>
                                                <td>1-470-329-9627</td>
                                                <td>Euismod In Ltd</td>
                                                <td>1883</td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>
                                <!-- end widget content -->

                            </div>
                            <!-- end widget div -->

                        </div>

                    </article>
                </div>

            </section>
            <!-- end widget grid -->

</asp:Content>
