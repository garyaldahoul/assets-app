using System;
using Microsoft.EntityFrameworkCore;

namespace AssetProject.Model
{
	public class AssetDBContext :DbContext
	{
        public AssetDBContext(DbContextOptions<AssetDBContext> options) : base(options)
        {
        }
        public DbSet<Asset> Assets{ get; set; }
    }
}

