using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Collage 的摘要说明
    /// </summary>
    public class College : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetCollegeList(context);
                    break;
                case "getcollege":
                    GetCollegeInfo(context);
                    break;
                case "addcollege":
                    AddCollegeInfo(context);
                    break;
                case "delcollege":
                    DelCollegeInfo(context);
                    break;
                default:
                    break;
            }
        }

        private static void GetCollegeList(HttpContext context)
        {
            string pageIndexStr = context.Request["pageIndex"];
            string pageSizeStr = context.Request["pageSize"];
            int pageIndex = 0;
            int pageSize = 0;

            if (int.TryParse(pageIndexStr, out pageIndex) && int.TryParse(pageSizeStr, out pageSize))
            {
                context.Response.Write(JsonSerializer.Serialize(GetList(pageIndex, pageSize)));
            }
        }

        private static void GetCollegeInfo(HttpContext context)
        {
            string CollegeStr = context.Request["collegeId"];
            int CollegeId = 0;
            if (int.TryParse(CollegeStr, out CollegeId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(CollegeId)));
            }
        }

        private static void AddCollegeInfo(HttpContext context)
        {
            var item = new collegeSet()
            {
                name = context.Request["name"],
                desc = context.Request["desc"],
                createTime = Convert.ToDateTime(context.Request["creatTime"]),
                content = context.Request["content"],
                img = context.Request["img"],
                sort = Convert.ToInt32(context.Request["sort"])
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelCollegeInfo(HttpContext context)
        {
            string CollegeStr = context.Request["collegeId"];
            int CollegeId = 0;
            if (int.TryParse(CollegeStr, out CollegeId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(CollegeId)));
            }
        }

        #region Provider

        public static List<collegeSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.collegeSet.OrderBy(x => x.sort).ThenByDescending(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static collegeSet GetEntity(int collegeId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.collegeSet.FirstOrDefault(x => x.Id == collegeId);
            }
            return null;
        }

        public static Result AddEntity(collegeSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.collegeSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int collegeId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.collegeSet.FirstOrDefault(x => x.Id == collegeId);
                if (entity != null)
                {
                    edm.collegeSet.Attach(entity);
                    edm.collegeSet.Remove(entity);
                    edm.SaveChanges();
                }
                else
                    return new Result(false, "删除失败,未找到该记录!");
            }
            return new Result();
        }

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}