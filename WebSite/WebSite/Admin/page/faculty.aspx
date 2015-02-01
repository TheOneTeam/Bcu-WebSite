<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSite.Master" AutoEventWireup="true" CodeBehind="faculty.aspx.cs" Inherits="WebSite.Admin.page.faculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
       <section id="widget-grid" class="">
				
					<!-- row -->
					<div class="row">
						
						<!-- NEW WIDGET START -->
						<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
							<!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-darken" id="wid-id-0" data-widget-colorbutton="false" data-widget-editbutton="false" data-widget-togglebutton="false" data-widget-fullscreenbutton="false" data-widget-sortable="false">
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
									<span class="widget-icon"> <i class="fa fa-pencil"></i> </span>
									<h2>特色学院介绍</h2>				
									<a id="btnsave" class="btn btn-primary btn-sm jarviswidget-ctrls" href="javascript:void(0);">保存</a>
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
										
											<textarea id="ckeditor" name="ckeditor">
												
				                			</textarea>						
										
									</div>
									<!-- end widget content -->
									
								</div>
								<!-- end widget div -->
								
							</div>
							<!-- end widget -->
				
						</article>
						<!-- WIDGET END -->
						
					</div>
				
					<!-- end row -->
				
				</section>
</asp:Content>
<asp:Content ID="scriptContent" runat="server" ContentPlaceHolderID="footContent">
    
		<!-- PAGE RELATED PLUGIN(S) -->
	<script src="../js/plugin/ckeditor/ckeditor.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            CKEDITOR.on('instanceReady', function (ev) {
                // Show the editor name and description in the browser status bar.
                //$("#ckeditor").val(msg.content);
            });
            CKEDITOR.replace('ckeditor', { height: '380px', startupFocus: true });
            //CKEDITOR.replace('editor1', {
            //    height: '380px',
            //    on: {
            //        // Check for availability of corresponding plugins.
            //        pluginsLoaded: function (evt) {
            //            var doc = CKEDITOR.document, ed = evt.editor;
            //            if (!ed.getCommand('bold'))
            //                doc.getById('exec-bold').hide();
            //            if (!ed.getCommand('link'))
            //                doc.getById('exec-link').hide();
            //        }
            //    }
            //});

            $.ajax({
                type: 'post',
                url: '/DataProvider/Dict.ashx?fn=getdict',
                data: { key: 'faculty' },
                dataType: 'json',
                success: function (msg) {
                    if (msg) {
                        $("#ckeditor").val(msg.content);
                    }
                }
            })
        })

        $("#btnsave").click(function () {
            $.ajax({
                type: 'post',
                url: '/DataProvider/Dict.ashx?fn=updatedict',
                data: { key: 'faculty', content: CKEDITOR.instances.ckeditor.getData() },
                dataType: 'json',
                success: function (msg) {
                    if (msg && msg.Flag) {
                        if (msg.Flag)
                            alert("修改成功");
                        else
                            alert("修改失败! 原因:" + msg.Msg);
                    } else {
                        alert("修改失败!");
                    }
                },
                error: function (msg) {
                    alert("修改失败!");
                }
            })
        });
    </script>
</asp:Content>