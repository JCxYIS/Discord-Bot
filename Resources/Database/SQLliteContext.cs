using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DISCORD_BOT.Database
{
    /*
    public class SQLiteContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            string DBlocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.0", @"Data\DataBase.sqlite");
            option.UseSqlite("Data Source="+DBlocation);
        }
    }
    */
}