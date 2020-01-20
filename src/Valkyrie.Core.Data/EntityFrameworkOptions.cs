using System;
using System.Collections.Generic;
using System.Text;

namespace Valkyrie.Data.Ef
{
    public class EntityFrameworkOptions
    {
        public string ConnectionString { get; set; }
        public Provider Provider { get; set; }


    }

    public enum Provider
    {
        SqlSever,
        MySql,
        Sqlite,
        Postgresql
    }
}
