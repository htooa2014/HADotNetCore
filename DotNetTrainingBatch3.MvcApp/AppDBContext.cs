using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.MvcApp
{
    public class AppDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder()
             {
                 DataSource = "HA\\SQL2019",
                 InitialCatalog = "TestDB",
                 UserID = "sa",
                 Password = "sasa",
                 TrustServerCertificate = true,
             };


        optionsBuilder.UseSqlServer(sqlBuilder.ConnectionString); 
        }

        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<PageStatisticsModel> PageStatistics { get; set; }

        public DbSet<RadarChartModel> Radar { get; set; }
    }
}
