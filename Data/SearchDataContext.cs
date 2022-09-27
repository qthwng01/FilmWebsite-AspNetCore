using Jobject_Parse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobject_Parse.Data
{
    public class SearchDataContext : DbContext
    {
        public SearchDataContext(DbContextOptions<SearchDataContext> options): base(options)
        {
        }
        public DbSet<SearchDatass> SearchDatass { get; set; }
    }
}
