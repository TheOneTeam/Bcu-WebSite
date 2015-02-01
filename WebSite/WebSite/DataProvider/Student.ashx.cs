using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Student 的摘要说明
    /// </summary>
    public class Student : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetStudentList(context);
                    break;
                case "getstudent":
                    GetStudentInfo(context);
                    break;
                case "addstudent":
                    AddStudentInfo(context);
                    break;
                case "delstudent":
                    DelStudentInfo(context);
                    break;
                default:
                    break;
            }
        }


        private static void GetStudentList(HttpContext context)
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

        private static void GetStudentInfo(HttpContext context)
        {
            string studentStr = context.Request["studentId"];
            int studentId = 0;
            if (int.TryParse(studentStr, out studentId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(studentId)));
            }
        }

        private static void AddStudentInfo(HttpContext context)
        {
            var item = new studentSet()
            {
                name = context.Request["name"],
                desc = context.Request["desc"],
                createTime = Convert.ToDateTime(context.Request["creatTime"]),
                course = context.Request["course"],
                imgPath = context.Request["img"],
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelStudentInfo(HttpContext context)
        {
            string studentStr = context.Request["studentId"];
            int studentId = 0;
            if (int.TryParse(studentStr, out studentId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(studentId)));
            }
        }

        #region Provider

        public static List<studentSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.studentSet.OrderByDescending(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static studentSet GetEntity(int studentId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.studentSet.FirstOrDefault(x => x.Id == studentId);
            }
            return null;
        }

        public static Result AddEntity(studentSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.studentSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int studentId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.studentSet.FirstOrDefault(x => x.Id == studentId);
                if (entity != null)
                {
                    edm.studentSet.Attach(entity);
                    edm.studentSet.Remove(entity);
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