using System;
using System.IO;
using Xamarin.Forms;
using AppSampledb.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace AppSampledb.Droid
{
    public class SQLite_Android: ISQLite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            /*var filename = "Licencia.db3";
            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;*/

            var dbName = "Licencia.db3";
            var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, dbName);

            return new SQLite.SQLiteConnection(path, false);

            /*var platform = new SQLite.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;*/

        }
    }
}