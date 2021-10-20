﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodBankDataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BBMSDBEntities : DbContext
    {
        public BBMSDBEntities()
            : base("name=BBMSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbAdmin> tbAdmins { get; set; }
        public virtual DbSet<tbBloodBank> tbBloodBanks { get; set; }
        public virtual DbSet<tbEventRegistration> tbEventRegistrations { get; set; }
        public virtual DbSet<tbEvent> tbEvents { get; set; }
        public virtual DbSet<tbHistory> tbHistories { get; set; }
        public virtual DbSet<tbNotification> tbNotifications { get; set; }
        public virtual DbSet<tbUser> tbUsers { get; set; }
        public virtual DbSet<tbBloodStock> tbBloodStocks { get; set; }
    
        public virtual ObjectResult<spGetEventsByBloodBank_Result> spGetEventsByBloodBank()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetEventsByBloodBank_Result>("spGetEventsByBloodBank");
        }
    
        public virtual ObjectResult<spGetBloodStockByBloodBank_Result> GetBloodBankStock()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetBloodStockByBloodBank_Result>("GetBloodBankStock");
        }
    
        public virtual ObjectResult<spGetEventRegisterDetails_Result> GetRegisterDetails(Nullable<int> bloodBankId)
        {
            var bloodBankIdParameter = bloodBankId.HasValue ?
                new ObjectParameter("bloodBankId", bloodBankId) :
                new ObjectParameter("bloodBankId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetEventRegisterDetails_Result>("GetRegisterDetails", bloodBankIdParameter);
        }
    }
}
