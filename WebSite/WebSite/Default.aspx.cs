using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.DataProvider;

namespace WebSite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewsListBind();
                CourseListBind();
                ActivityListBind();
            }
        }

        protected string CutContent(object content,int length)
        {
            if (content.ToString().Length <= length)
                return content.ToString() + "…";
            return content.ToString().Substring(0, length) + "…";
        }

        private void NewsListBind()
        {
            this.newsRpt.DataSource = News.GetList(1, 10);
            this.newsRpt.DataBind();
        }

        private void CourseListBind()
        {
            this.courseRpt.DataSource = Course.GetList(1, 10);
            this.courseRpt.DataBind();
        }

        private void ActivityListBind()
        {
            this.activityRpt.DataSource = Activity.GetList(1, 10);
            this.activityRpt.DataBind();
        }
    }
}