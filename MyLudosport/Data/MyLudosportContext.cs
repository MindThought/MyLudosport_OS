using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLudosport.Models;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Identity;

namespace MyLudosport.Data
{
    public class MyLudosportContext : DbContext
    {
        private readonly string ConnectionString;
        public IConfiguration Configuration { get; }
        #region DbSets
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Duel> Duels { get; set; }
        #endregion

        #region Constructors
        public MyLudosportContext()
        {
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public MyLudosportContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=myludosport;User=Application;Password=test");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region IdentityFixes
            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(p => new { p.Id });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUser>().HasKey(p => new { p.UserName });
            modelBuilder.Entity<IdentityRole>().HasKey(p => new { p.Id });

            #endregion

            #region RelationsDefinitions
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Athlete)
                .WithOne(a => a.Account)
                .HasForeignKey<Athlete>(a => a.AccountId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Judge)
                .WithOne(j => j.Account)
                .HasForeignKey<Judge>(a => a.AccountId);

            modelBuilder.Entity<AthleteClanRelation>()
                .HasKey(e => new { e.AthleteId, e.ClanId });

            modelBuilder.Entity<AthleteSchoolRelation>()
                .HasKey(e => new { e.AthleteId, e.SchoolId });

            modelBuilder.Entity<AthleteAcademyRelation>()
                .HasKey(e => new { e.AthleteId, e.AcademyId });

            modelBuilder.Entity<AthleteDuelRelations>()
                .HasKey(e => new { e.AthleteId, e.DuelId });

            #endregion

            #region DataSeed
            #region Users
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser {
                Id = "c5924f4e-993c-4e22-8b67-7da98b585d9e",
                UserName = "carl.anders.kallen@gmail.com",
                NormalizedUserName = "CARL.ANDERS.KALLEN@GMAIL.COM",
                Email = "carl.anders.kallen@gmail.com",
                NormalizedEmail = "CARL.ANDERS.KALLEN@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEES2Zd6UD62yafyVUAU7d2Q4HGkZZaXz0fPZvdzkal2P2aQw/G/GtodbArCE9Yngug==",
                SecurityStamp = "HZZ2IQBRGINP626G4ZWZNWOWG3TUJF73",
                ConcurrencyStamp = "88786e02-2729-47fe-9ea8-c26918483dd0"
            });
            #endregion
            #region Athletes
            modelBuilder.Entity<Athlete>().HasData(new Athlete { Id = new System.Guid("08d6fd57-38d6-5e3e-ef71-0955c4f2aa79"), BattleName = "TheMountain" , AccountId = "carl.anders.kallen@gmail.com" });
            #endregion
            #region AthleteRelations
            #endregion
            #endregion

        }
    }
}
