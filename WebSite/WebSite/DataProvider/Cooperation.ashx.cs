using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Cooperation 的摘要说明
    /// </summary>
    public class Cooperation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetCooperationList(context);
                    break;
                case "getcooperation":
                    GetCooperationInfo(context);
                    break;
                case "addcooperation":
                    AddCooperationInfo(context);
                    break;
                case "delcooperation":
                    DelCooperationInfo(context);
                    break;
                default:
                    break;
            }
        }



        private static void GetCooperationList(HttpContext context)
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

        private static void GetCooperationInfo(HttpContext context)
        {
            string cooperationStr = context.Request["cptId"];
            int cooperationId = 0;
            if (int.TryParse(cooperationStr, out cooperationId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(cooperationId)));
            }
        }

        private static void AddCooperationInfo(HttpContext context)
        {
            var item = new cooperationSet()
            {
                title = context.Request["title"],
                content = context.Request["content"],
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelCooperationInfo(HttpContext context)
        {
            string cooperationStr = context.Request["cptId"];
            int cooperationId = 0;
            if (int.TryParse(cooperationStr, out cooperationId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(cooperationId)));
            }
        }


        #region Provider

        public static List<cooperationSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.cooperationSet.OrderBy(x => x.title).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static cooperationSet GetEntity(int cooperationId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.cooperationSet.FirstOrDefault(x => x.Id == cooperationId);
            }
            return null;
        }

        public static Result AddEntity(cooperationSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.cooperationSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int cooperationId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.cooperationSet.FirstOrDefault(x => x.Id == cooperationId);
                if (entity != null)
                {
                    edm.cooperationSet.Attach(entity);
                    edm.cooperationSet.Remove(entity);
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