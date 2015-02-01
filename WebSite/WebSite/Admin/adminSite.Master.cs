using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Admin
{
    public partial class adminSite : System.Web.UI.MasterPage
    {
        #region 选中菜单

        public bool IndexCheck { get; set; }

        public bool MsgCheck { get; set; }

        public bool UniversityIdtCheck { get; set; }

        public bool CollegeIdtCheck { get; set; }

        public bool FacultyIdtCheck { get; set; }

        public bool StudyRequireCheck { get; set; }

        public bool CourseMgtCheck { get; set; }

        public bool DbcldgeCheck { get; set; }

        public bool DMasterCheck { get; set; }

        public bool ExChangeCheck { get; set; }

        public bool ContratCheck { get; set; }

        public bool SummerCheck { get; set; }

        public bool FoundProCheck { get; set; }

        public bool FolderCheck { get; set; }

        public bool FileCheck { get; set; }
        public bool StayCheck { get; set; }

        public bool ServiceCheck { get; set; }

        public bool StudentCheck { get; set; }

        public bool ActivityCheck { get; set; }

        public bool JobCheck { get; set; }

        public bool HNDStudyRequireCheck { get; set; }

        public bool  HNDCourseCheck { get; set; }

        public bool HNDApplyGuidCheck { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}