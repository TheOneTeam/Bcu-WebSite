using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Job 的摘要说明
    /// </summary>
    public class Job : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetJobList(context);
                    break;
                case "getjob":
                    GetJobInfo(context);
                    break;
                case "addjob":
                    AddJobInfo(context);
                    break;
                case "deljob":
                    DelJobInfo(context);
                    break;
                default:
                    break;
            }
        }


        private static void GetJobList(HttpContext context)
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

        private static void GetJobInfo(HttpContext context)
        {
            string jobStr = context.Request["jobId"];
            int jobId = 0;
            if (int.TryParse(jobStr, out jobId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(jobId)));
            }
        }

        private static void AddJobInfo(HttpContext context)
        {
            var item = new jobSet()
            {
                title = context.Request["name"],
                company = context.Request["desc"],
                address = context.Request["desc"],
                salary = context.Request["desc"],
                createTime = Convert.ToDateTime(context.Request["creatTime"]),
                content = context.Request["content"],
                desc = context.Request["desc"],
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelJobInfo(HttpContext context)
        {
            string jobStr = context.Request["JobId"];
            int jobId = 0;
            if (int.TryParse(jobStr, out jobId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(jobId)));
            }
        }

        #region Provider

        public static List<jobSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.jobSet.OrderByDescending(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static jobSet GetEntity(int jobId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.jobSet.FirstOrDefault(x => x.Id == jobId);
            }
            return null;
        }

        public static Result AddEntity(jobSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.jobSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int jobId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.jobSet.FirstOrDefault(x => x.Id == jobId);
                if (entity != null)
                {
                    edm.jobSet.Attach(entity);
                    edm.jobSet.Remove(entity);
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