using InternKYCApplication.Helpers.Utils;
using InternKYCApplication.Models;
using Microsoft.EntityFrameworkCore;


namespace InternKYCApplication
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<OtpDetailModel> OtpDetail { get; set; }
        public virtual DbSet<CustomerDataModel> CustomerData { get; set; }

        
    }
}

    