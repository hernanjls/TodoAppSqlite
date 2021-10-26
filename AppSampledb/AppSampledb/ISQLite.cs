using SQLite;

namespace AppSampledb
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
