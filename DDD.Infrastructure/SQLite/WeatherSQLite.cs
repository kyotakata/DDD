using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite: IＷeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
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

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString)) //SQLiteのインスタンス生成
            using (var command = new SQLiteCommand(sql, connection))    // コマンドのインスタンス生成
            {//usingブロックを抜けるタイミングで自動的にリソースが破棄されるようにしている
                connection.Open();    // データベースへの接続を開く
                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                    }
                }
            }
            return null;
        }
    }
}
