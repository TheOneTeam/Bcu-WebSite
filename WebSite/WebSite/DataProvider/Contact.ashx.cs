using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Contact 的摘要说明
    /// </summary>
    public class Contact : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetContactList(context);
                    break;
                case "getContact":
                    GetContactInfo(context);
                    break;
                case "addContact":
                    AddContactInfo(context);
                    break;
                case "delContact":
                    DelContactInfo(context);
                    break;
                default:
                    break;
            }
        }



        private static void GetContactList(HttpContext context)
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

        private static void GetContactInfo(HttpContext context)
        {
            string contactStr = context.Request["contactId"];
            int contactId = 0;
            if (int.TryParse(contactStr, out contactId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(contactId)));
            }
        }

        private static void AddContactInfo(HttpContext context)
        {
            var item = new contactSet()
            {
                title = context.Request["title"],
                content = context.Request["content"],
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelContactInfo(HttpContext context)
        {
            string contactStr = context.Request["contactId"];
            int contactId = 0;
            if (int.TryParse(contactStr, out contactId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(contactId)));
            }
        }

        #region Provider

        public static List<contactSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.contactSet.OrderByDescending(x => x.createTime).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static contactSet GetEntity(int contactId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.contactSet.FirstOrDefault(x => x.Id == contactId);
            }
            return null;
        }

        public static Result AddEntity(contactSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.contactSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int contactId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.contactSet.FirstOrDefault(x => x.Id == contactId);
                if (entity != null)
                {
                    edm.contactSet.Attach(entity);
                    edm.contactSet.Remove(entity);
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