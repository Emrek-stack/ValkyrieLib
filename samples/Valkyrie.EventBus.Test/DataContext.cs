using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Valkyrie.EventBus.Test
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
    }
    public class DataContext2 : DbContext
    {
        public DataContext2(DbContextOptions<DataContext2> options)
            : base(options)
        { }
    }
}
