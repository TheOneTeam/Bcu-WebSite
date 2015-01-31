using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Activity 的摘要说明
    /// </summary>
    public class Activity : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetActivityList(context);
                    break;
                case "getactivity":
                    GetActivityInfo(context);
                    break;
                case "addactivity":
                    AddActivityInfo(context);
                    break;
                case "delactivity":
                    DelActivityInfo(context);
                    break;
                default:
                    break;
            }
        }



        private static void GetActivityList(HttpContext context)
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

        private static void GetActivityInfo(HttpContext context)
        {
            string activityStr = context.Request["activityId"];
            int activityId = 0;
            if (int.TryParse(activityStr, out activityId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(activityId)));
            }
        }

        private static void AddActivityInfo(HttpContext context)
        {
            var item = new activitySet()
            {
                title = context.Request["title"],
                address = context.Request["desc"],
                bTime = Convert.ToDateTime(context.Request["bTime"]),
                eTime = Convert.ToDateTime(context.Request["eTime"]),
                createTime = Convert.ToDateTime(context.Request["creatTime"]),
                content = context.Request["content"],
                imgPath = context.Request["img"],
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelActivityInfo(HttpContext context)
        {
            string activityStr = context.Request["activityId"];
            int activityId = 0;
            if (int.TryParse(activityStr, out activityId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(activityId)));
            }
        }

        #region Provider

        public static List<activitySet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.activitySet.OrderBy(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static activitySet GetEntity(int activityId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.activitySet.FirstOrDefault(x => x.Id == activityId);
            }
            return null;
        }

        public static Result AddEntity(activitySet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.activitySet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int activityId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.activitySet.FirstOrDefault(x => x.Id == activityId);
                if (entity != null)
                {
                    edm.activitySet.Attach(entity);
                    edm.activitySet.Remove(entity);
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