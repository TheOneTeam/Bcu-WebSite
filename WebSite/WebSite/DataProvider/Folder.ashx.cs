using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    /// <summary>
    /// Folder 的摘要说明
    /// </summary>
    public class Folder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request["fn"];
            switch (fn)
            {
                case "getlist":
                    GetFolderList(context);
                    break;
                case "getfolder":
                    GetFolderInfo(context);
                    break;
                case "addfolder":
                    AddFolderInfo(context);
                    break;
                case "delfolder":
                    DelFolderInfo(context);
                    break;
                default:
                    break;
            }
        }


        private static void GetFolderList(HttpContext context)
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

        private static void GetFolderInfo(HttpContext context)
        {
            string folderStr = context.Request["folderId"];
            int folderId = 0;
            if (int.TryParse(folderStr, out folderId))
            {
                context.Response.Write(JsonSerializer.Serialize(GetEntity(folderId)));
            }
        }

        private static void AddFolderInfo(HttpContext context)
        {
            var item = new folderSet()
            {
                name = context.Request["name"],
                path = context.Request["desc"],
                sort = Convert.ToInt32(context.Request["sort"])
            };
            context.Response.Write(JsonSerializer.Serialize(AddEntity(item)));
        }

        private static void DelFolderInfo(HttpContext context)
        {
            string folderStr = context.Request["folderId"];
            int folderId = 0;
            if (int.TryParse(folderStr, out folderId))
            {
                context.Response.Write(JsonSerializer.Serialize(DelEntity(folderId)));
            }
        }

        #region Provider

        public static List<folderSet> GetList(int pageIndex, int pageSize)
        {
            var recordIndex = pageSize * pageIndex;
            using (var edm = new BcuEntities())
            {
                return edm.folderSet.OrderBy(x => x.sort).Skip(recordIndex).Take(pageSize).ToList();
            }
            return null;
        }

        public static folderSet GetEntity(int FolderId)
        {
            using (var edm = new BcuEntities())
            {
                return edm.folderSet.FirstOrDefault(x => x.Id == FolderId);
            }
            return null;
        }

        public static Result AddEntity(folderSet entity)
        {
            using (var edm = new BcuEntities())
            {
                edm.folderSet.Add(entity);
                edm.SaveChanges();
            }
            return new Result();
        }

        public static Result DelEntity(int FolderId)
        {
            using (var edm = new BcuEntities())
            {
                var entity = edm.folderSet.FirstOrDefault(x => x.Id == FolderId);
                if (entity != null)
                {
                    edm.folderSet.Attach(entity);
                    edm.folderSet.Remove(entity);
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