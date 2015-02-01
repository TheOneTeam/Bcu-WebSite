using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// News 的摘要说明
    /// </summary>
    public class News : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetNewsList(context);
                    break;
                case "getnews":
                    GetNewsInfo(context);
                    break;
                case "addnews":
                    AddNewsInfo(context);
                    break;
                case "delnews":
                    DelNewsInfo(context);
                    break;
                default:
                    break;
            }
        }

        private static void GetNewsList(HttpContext context)
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

        private static void GetNewsInfo(HttpContext context)
        {
            string NewsStr = context.Request["newsId"];
            int NewsId = 0;
            if (int.TryParse(NewsStr, out NewsId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(NewsId)));
            }
        }

        private static void AddNewsInfo(HttpContext context)
        {
            var item = new newsSet()
            {
                title = context.Request["title"],
                content = context.Request["content"],
                createTime = Convert.ToDateTime(context.Request["creatTime"]),
                img = context.Request["img"],
                sort = Convert.ToInt32(context.Request["sort"])
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelNewsInfo(HttpContext context)
        {
            string NewsStr = context.Request["newsId"];
            int NewsId = 0;
            if (int.TryParse(NewsStr, out NewsId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(NewsId)));
            }
        }

        #region Provider

        public static List<newsSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.newsSet.OrderBy(x => x.sort).ThenByDescending(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static newsSet GetEntity(int newsId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.newsSet.FirstOrDefault(x => x.Id == newsId);
            }
            return null;
        }

        public static Result AddEntity(newsSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.newsSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int newsId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.newsSet.FirstOrDefault(x => x.Id == newsId);
                if (entity != null)
                {
                    edm.newsSet.Attach(entity);
                    edm.newsSet.Remove(entity);
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