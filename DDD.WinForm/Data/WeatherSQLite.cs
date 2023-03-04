using DDD.WinForm.Common;
using System.Data;
using System.Data.SQLite;

namespace DDD.WinForm.Data
{
    public static class WeatherSQLite
    {
        public static DataTable GetLatest(int areaId)
        {
            string sql = @"
select DataDate,
       Condition,
       Temperature
from Weather
where AreaId = @AreaId
order by DataDate desc
LIMIT 1
";

            DataTable dt = new DataTable();
            using (var connection = new SQLiteConnection(CommonConst.ConnectionString)) //SQLiteのインスタンス生成
            using (var command = new SQLiteCommand(sql, connection))    // コマンドのインスタンス生成
            {//usingブロックを抜けるタイミングで自動的にリソースが破棄されるようにしている
                connection.Open();    // データベースへの接続を開く
                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dt);    // データ取得
                }
            }
            return dt;
        }
    }
}
