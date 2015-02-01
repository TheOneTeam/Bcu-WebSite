using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Attachment 的摘要说明
    /// </summary>
    public class Attachment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetAttachmentList(context);
                    break;
                case "getattachment":
                    GetAttachmentInfo(context);
                    break;
                case "addattachment":
                    AddAttachmentInfo(context);
                    break;
                case "delattachment":
                    DelAttachmentInfo(context);
                    break;
                default:
                    break;
            }
        }

        private static void GetAttachmentList(HttpContext context)
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

        private static void GetAttachmentInfo(HttpContext context)
        {
            string attachmentStr = context.Request["attachmentId"];
            int attachmentId = 0;
            if (int.TryParse(attachmentStr, out attachmentId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(attachmentId)));
            }
        }

        private static void AddAttachmentInfo(HttpContext context)
        {
            var item = new attachmentSet()
            {
                name = context.Request["name"],
                fid = context.Request["fId"],
                createTime = Convert.ToDateTime(context.Request["creatTime"]),
                path = context.Request["path"],
                extension = context.Request["extension"]
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelAttachmentInfo(HttpContext context)
        {
            string attachmentStr = context.Request["attachmentId"];
            int attachmentId = 0;
            if (int.TryParse(attachmentStr, out attachmentId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(attachmentId)));
            }
        }

        #region Provider

        public static List<attachmentSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageIndex == 1 ? 0 : pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.attachmentSet.OrderByDescending(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static attachmentSet GetEntity(int attachmentId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.attachmentSet.FirstOrDefault(x => x.Id == attachmentId);
            }
            return null;
        }

        public static Result AddEntity(attachmentSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.attachmentSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int attachmentId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.attachmentSet.FirstOrDefault(x => x.Id == attachmentId);
                if (entity != null)
                {
                    edm.attachmentSet.Attach(entity);
                    edm.attachmentSet.Remove(entity);
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