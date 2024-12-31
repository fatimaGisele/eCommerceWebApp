using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using My

namespace appPDWebMVC.Models
{
    public partial class MydbContext : DbContext
    {
        public MydbContext()
        {
        }

        public MydbContext(DbContextOptions<MydbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           
        {
            
        }
    }
   
}
