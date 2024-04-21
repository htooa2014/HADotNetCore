using DotNetTrainingBatch3.LoginApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.LoginApp
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

        public DbSet<UserModel> users { get; set; }
        public DbSet<LoginModel> logins { get; set; }

    }
}
