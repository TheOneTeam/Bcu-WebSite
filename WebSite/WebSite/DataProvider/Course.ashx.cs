using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Course 的摘要说明
    /// </summary>
    public class Course : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetCourseList(context);
                    break;
                case "getcourse":
                    GetCourseInfo(context);
                    break;
                case "addcourse":
                    AddCourseInfo(context);
                    break;
                case "delcourse":
                    DelCourseInfo(context);
                    break;
                default:
                    break;
            }
        }

        private static void GetCourseList(HttpContext context)
        {
            string pageIndexStr = context.Request["pageIndex"];
            string pageSizeStr = context.Request["pageSize"];
            int pageIndex = 0;
            int pageSize = 0;

            if(int .TryParse(pageIndexStr,out pageIndex) && int.TryParse(pageSizeStr,out pageSize))
            {
                context.Response.Write(JsonSerializer.Serialize(GetList(pageIndex, pageSize)));
            }
        }

        private static void GetCourseInfo(HttpContext context)
        {
            string courseStr = context.Request["courseId"];
            int courseId = 0;
            if (int.TryParse(courseStr, out courseId))
            { 
                context.Response.Write(JsonSerializer.Serialize(GetEntity(courseId)));
            }
        }

        private static void AddCourseInfo(HttpContext context)
        {
            var item = new courseSet() {
                name = context.Request["name"],
                content = context.Request["content"],
                introduction = context.Request["introduction"],
                img = context.Request["imgPath"],
                sort = Convert.ToInt32(context.Request["sort"])
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelCourseInfo(HttpContext context)
        {
            string courseStr = context.Request["courseId"];
            int courseId = 0;
            if (int.TryParse(courseStr, out courseId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(courseId)));
            }
        }

        #region Provider

        public static List<courseSet> GetList(int pageIndex,int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.courseSet.OrderBy(x => x.sort).ThenByDescending(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static courseSet GetEntity(int courseId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.courseSet.FirstOrDefault(x => x.Id == courseId);
            }
            return null;
        }

        public static Result AddEntity(courseSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.courseSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int courseId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.courseSet.FirstOrDefault(x => x.Id == courseId);
                if (entity != null)
                {
                    edm.courseSet.Attach(entity);
                    edm.courseSet.Remove(entity);
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