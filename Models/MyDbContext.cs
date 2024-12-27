using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
    }
   
}
