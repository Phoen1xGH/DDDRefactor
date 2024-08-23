using DDDRefactor.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDRefactor.Models.ValueObjects;

namespace DDDRefactor.DBContext
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    /// <param name="configuration">Конфигурация приложения</param>
    public class SIZADBContext : DbContext
    {
        #region fields


        #endregion

        #region DbSets

        public DbSet<Request> Requests { get; set; }
        //public DbSet<UserPermissions> Accesses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LegalPerson> LegalPeople { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Notify> Contacts { get; set; }
        //public DbSet<Attachment> Attachments { get; set; }
        public DbSet<RequestMember> RequestMembers { get; set; }
        //public DbSet<Agreement> Agreements { get; set; }
        //public DbSet<Specification> Specifications { get; set; }
        //public DbSet<NotesMessage> NotesMessages { get; set; }
        public DbSet<CustomNotification> Notifications { get; set; }

        #endregion

        #region ovverride methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SIZADBContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            UpdateEntitiesTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region custom methods

        /// <summary>
        /// Обновить дату изменения сущности 
        /// </summary>
        private void UpdateEntitiesTimestamps()
        {
            var entries1 = ChangeTracker.Entries();
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;
            }
        }

        /// <summary>
        /// Получить строку подключения БД из конфигурации
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            // Заменяем переменные на значения из окружения
            string connectionString = "Host=localhost;Port=5432;Database=DDDTEST;Username=postgres;Password=postgres;Include Error Detail=true";

            return connectionString;
        }

        #endregion
    }
}
