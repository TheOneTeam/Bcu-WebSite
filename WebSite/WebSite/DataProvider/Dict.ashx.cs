using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Dict 的摘要说明
    /// </summary>
    public class Dict : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetDictList(context);
                    break;
                case "getdict":
                    GetDictInfo(context);
                    break;
                case "adddict":
                    AddDictInfo(context);
                    break;
                case "deldict":
                    DelDictInfo(context);
                    break;
                case "updatedict":
                    UpdateDictInfo(context);
                    break;
                default:
                    break;
            }
        }

        private static void GetDictList(HttpContext context)
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

        private static void GetDictInfo(HttpContext context)
        {
            string key = context.Request["key"];
            if (!string.IsNullOrEmpty(key))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(key)));
            }
        }

        private static void AddDictInfo(HttpContext context)
        {
            var item = new dictSet()
            {
                title = context.Request["title"],
                content = context.Request["content"],
                balanceImg = context.Request["balanceImg"],
                key = context.Request["key"]
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelDictInfo(HttpContext context)
        {
            string NewsStr = context.Request["newsId"];
            int NewsId = 0;
            if (int.TryParse(NewsStr, out NewsId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(NewsId)));
            }
        }

        private static void UpdateDictInfo(HttpContext context)
        {
            string key = context.Request["key"];
            string content = context.Request["content"];
            if (!string.IsNullOrEmpty(key))
            {
                using (var edm = new BcuEntities())
                {
                    var item = edm.dictSet.FirstOrDefault(x => x.key.ToLower() == key.ToLower());
                    if (item != null)
                    {
                        item.content = content;
                        edm.SaveChanges();
                        context.Response.Write(JsonSerializer.Serialize(new Result()));
                        return;
                    }
                }
            }
            context.Response.Write(JsonSerializer.Serialize(new Result(false, "保存失败!")));
        }

        #region Provider

        public static List<dictSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.dictSet.Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static dictSet GetEntity(string key)
        {
            using (var edm = new BcuEntities())
            {
                return edm.dictSet.FirstOrDefault(x => x.key == key);
            }
            return null;
        }

        public static Result AddEntity(dictSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.dictSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int newsId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.dictSet.FirstOrDefault(x => x.Id == newsId);
                if (entity != null)
                {
                    edm.dictSet.Attach(entity);
                    edm.dictSet.Remove(entity);
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