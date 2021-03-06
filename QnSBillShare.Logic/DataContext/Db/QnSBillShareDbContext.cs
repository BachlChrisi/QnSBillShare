//@CustomizeCode
//MdStart
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using QnSBillShare.Logic.Entities.Persistence.Account;
using QnSBillShare.Logic.Entities.Persistence.App;

namespace QnSBillShare.Logic.DataContext.Db
{
    partial class QnSBillShareDbContext
    {
        static QnSBillShareDbContext()
        {
            if (Configuration.Configurator.Contains(CommonBase.StaticLiterals.ConnectionStringKey))
            {
                ConnectionString = Configuration.Configurator.Get(CommonBase.StaticLiterals.ConnectionStringKey);
            }
        }

#if DEBUG
        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddDebug();
        });
#endif
        private static string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDb;Database=QnSBillShareDb;Integrated Security=True;";

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            BeforeConfiguring(optionsBuilder);
            optionsBuilder
#if DEBUG        
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(loggerFactory)
#endif
                .UseSqlServer(ConnectionString);
            AfterConfiguring(optionsBuilder);
        }
        partial void BeforeConfiguring(DbContextOptionsBuilder optionsBuilder);
        partial void AfterConfiguring(DbContextOptionsBuilder optionsBuilder);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BeforeModelCreating(modelBuilder);
            DoModelCreating(modelBuilder);
            AfterModelCreating(modelBuilder);
        }
        partial void BeforeModelCreating(ModelBuilder modelBuilder);
        partial void DoModelCreating(ModelBuilder modelBuilder);
        partial void AfterModelCreating(ModelBuilder modelBuilder);

        partial void ConfigureEntityType(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder
                .Ignore(p => p.Password);

            entityTypeBuilder
                .HasIndex(p => p.Email)
                .IsUnique();
            entityTypeBuilder
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(128);
            entityTypeBuilder
                .Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(128);
            entityTypeBuilder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(128);
            entityTypeBuilder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(128);
            entityTypeBuilder
                .Property(p => p.AvatarMimeType)
                .HasMaxLength(64);
        }
        partial void ConfigureEntityType(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasIndex(p => p.Designation)
                .IsUnique();
            entityTypeBuilder
                .Property(p => p.Designation)
                .IsRequired()
                .HasMaxLength(64);
            entityTypeBuilder
                .Property(p => p.Description)
                .HasMaxLength(256);
        }
        partial void ConfigureEntityType(EntityTypeBuilder<UserXRole> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasIndex(p => new { p.UserId, p.RoleId })
                .IsUnique();
        }
        partial void ConfigureEntityType(EntityTypeBuilder<LoginSession> entityTypeBuilder)
        {
            entityTypeBuilder
                .Property(p => p.SessionToken)
                .IsRequired()
                .HasMaxLength(256);
        }
        #endregion Configuration

        #region Customize
        partial void ConfigureEntityType(EntityTypeBuilder<Bill> entityTypeBuilder)
        {
            entityTypeBuilder
                 .ToTable(nameof(Bill))
                .HasKey(p => p.Id);
            entityTypeBuilder
                .HasIndex(p => p.Title)
                .IsUnique();
            entityTypeBuilder
                .Property(p => p.Title)
                .HasMaxLength(256);
            entityTypeBuilder
                .Property(p => p.Description)
                .HasMaxLength(256);
            entityTypeBuilder
                .Property(p => p.Friends)
                .IsRequired()
                .HasMaxLength(256);
            entityTypeBuilder
                .Property(p => p.Currency)
                .IsRequired()
                .HasMaxLength(10);
        }

        partial void ConfigureEntityType(EntityTypeBuilder<Expense> entityTypeBuilder)
        {
            entityTypeBuilder
                .Property(p => p.Designation)
                .IsRequired()
                .HasMaxLength(256);
            entityTypeBuilder
                .Property(p => p.Friend)
                .IsRequired()
                .HasMaxLength(50);
        }
        #endregion
    }
}
//MdEnd
