﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for BlogPostRepository
/// </summary>
public class TagRepository
{
    private static readonly string _connectionstring = "DefaultConnection";

    public TagRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static dynamic Get(int id)
    {
        using(var db = Database.Open(_connectionstring))
        {
            var sql = "SELECT * FROM Tags WHERE Id = @0";
            return db.QuerySingle(sql, id);
        }
    }
    public static dynamic Get(string friendlyName)
    {
        using (var db = Database.Open(_connectionstring))
        {
            var sql = "SELECT * FROM Tags WHERE UrlFriendlyName = @0";
            return db.QuerySingle(sql, friendlyName);
        }
    }
    public static IEnumerable<dynamic> GetAll(string orderBy = null,string where = null)
    {
        using (var db = Database.Open(_connectionstring))
        {
            var sql = "SELECT * FROM Tags ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += "WHERE " + orderBy;
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                sql += "ORDER BY " + orderBy;
            }
            return db.Query(sql);
        }
    }
    public static void Add(string name,string friendlyName)
    {
        using (var db = Database.Open(_connectionstring))
        {
            var sql = "INSERT INTO Tags (Name,UrlFriendlyName)" +
                "VALUES (@0,@1)";

            db.Execute(sql, name,friendlyName);
        }
    }
    public static void Edit(int id,string name, string friendlyName)
    {
        using (var db = Database.Open(_connectionstring))
        {
            var sql = "UPDATE Tags SET Name=@0,UrlFriendlyName=@1 " + "WHERE Id = @2";

            db.Execute(sql, name, friendlyName,id);
        }
    }
    public static void Remove(string friendlyName)
    {
        using (var db = Database.Open(_connectionstring))
        {
            var sql = "DELETE FROM Tags WHERE UrlFriendlyName=@0";

            db.Execute(sql, friendlyName);
        }
    }

}