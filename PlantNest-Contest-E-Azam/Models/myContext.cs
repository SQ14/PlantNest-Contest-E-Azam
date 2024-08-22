﻿using Microsoft.EntityFrameworkCore;

namespace PlantNest_Contest_E_Azam.Models
{
	public class myContext : DbContext
	{
        public myContext(DbContextOptions options) : base (options)
        {
                
        }

		public DbSet<Admin> tbl_admin { get; set; }
		public DbSet<User> tbl_user { get; set; }
	}
}
