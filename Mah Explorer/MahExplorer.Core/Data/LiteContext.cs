using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahExplorer.Data
{
    public static class LiteContext
    {
        public static LiteCollection<T> GetCollection<T>(string path = "") where T : class
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            if (path == "")
                path = Path.Combine(local, "Data.db");

            using (var db = new LiteDatabase(path))
            {
                var typeOfAction = typeof(T);
                var titles = db.GetCollection<T>(typeOfAction.Name);

                return titles;

            }
        }
    }
}
