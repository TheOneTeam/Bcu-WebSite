using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Admin.page.Cooperation
{
    public partial class foundationpro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = this.Master as adminSite;
            master.FoundProCheck = true;
        }
    }
}