using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using GTANetworkAPI;
using System.IO;

namespace GermanReallife.Datenbank
{
    public class DatabaseHelper: Script
    {

        /* String für Ordnerpfad der Datenbank Datei*/
        public const string DatabasePath = @"./GermanReallifeDB";

        public DatabaseHelper()
        {
            if (!Directory.Exists(DatabasePath))
                Directory.CreateDirectory(DatabasePath);
        }
    }
    public static class Database
    {
        public static bool Upsert<T>(T data)
        {
            using (var db = new LiteDatabase($"{DatabaseHelper.DatabasePath}/Database.db"))
            {
                return db.GetCollection<T>().Upsert(data);
            }
        }

        //Experimentell
        public static bool Delete<T>(BsonValue data)
        {
            using (var db = new LiteDatabase($"{DatabaseHelper.DatabasePath}/Database.db"))
            {
                return db.GetCollection<T>().Delete(data);
            }
        }
        //ENDE

        public static T GetData<T>(string fieldName, BsonValue data)
        {
            using (var db = new LiteDatabase($"{DatabaseHelper.DatabasePath}/Database.db"))
            {
                return db.GetCollection<T>().FindOne(Query.EQ(fieldName, data));
            }
        }

        public static bool Update<T>(T data)
        {
            using (var db = new LiteDatabase($"{DatabaseHelper.DatabasePath}/Database.db"))
            {
                return db.GetCollection<T>().Update(data);
            }
        }

        internal static object GetData<T>(string v1, string vorname, string v2, string nachname)
        {
            throw new NotImplementedException();
        }

        public static T GetById<T>(int id)
        {
            using (var db = new LiteDatabase($"{DatabaseHelper.DatabasePath}/Database.db"))
            {
                return db.GetCollection<T>().FindById(id);
            }
        }

        public static IEnumerable<T> GetCollection<T>()
        {
            using (var db = new LiteDatabase($"{DatabaseHelper.DatabasePath}/Database.db"))
            {
                return db.GetCollection<T>().FindAll();
            }
        }

        public static bool Exists<T>()
        {
            using (var db = new LiteDatabase($"{DatabaseHelper.DatabasePath}/Database.db"))
            {
                return db.CollectionExists(typeof(T).Name);
            }
        }
    }
}
