using SQLite;

namespace XamarinTricountLike.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
