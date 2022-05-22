using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Json;

namespace ServerEntityDataWCF.Model
{
    internal class ModelContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<IFolder> Folders { get; set; }
        public DbSet<ArchiveFile> ArchiveFiles { get; set; }
        public DbSet<ArchiveFolder> ArchiveFolders { get; set; }
        public DbSet<UserCloud> UsersClouds { get; set; }
        private string ConnectionString;
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
            
        }
        public ModelContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=K2r4Fo71aM?;database=DigitalCloud5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.UserCloud).WithOne(u => u.User).HasForeignKey<UserCloud>(c => c.UserId);

            modelBuilder.Entity<IFolder>().HasMany(f => f.Files).WithOne(f => f.ParentFolder).HasForeignKey(f => f.ParentId);


            //modelBuilder.Entity<UserCloud>().HasMany(u => u.Folders).WithOne(f => f.UserCloud).HasForeignKey(f=>f.UserCloudId);

            modelBuilder.Entity<ArchiveFolder>().HasOne(f=>f.ParentFolder).WithMany(f=>f.Folders).HasForeignKey(f=>f.ParentId);


        }
    }
}
