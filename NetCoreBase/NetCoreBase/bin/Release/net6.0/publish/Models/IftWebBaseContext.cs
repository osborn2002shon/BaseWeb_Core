using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetCoreBase.Models;

public partial class IftWebBaseContext : DbContext
{
    public IftWebBaseContext()
    {
    }

    public IftWebBaseContext(DbContextOptions<IftWebBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SystemMenu> SystemMenus { get; set; }

    public virtual DbSet<SystemMenuAu> SystemMenuAus { get; set; }

    public virtual DbSet<SystemTaiwan> SystemTaiwans { get; set; }

    public virtual DbSet<SystemUserAccount> SystemUserAccounts { get; set; }

    public virtual DbSet<SystemUserAuType> SystemUserAuTypes { get; set; }

    public virtual DbSet<SystemUserLog> SystemUserLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=211.22.64.113;Initial Catalog=IFT_WebBase;User ID=admin_sean;Password=guitar;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SystemMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("System_Menu");

            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .HasColumnName("groupName");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsShow).HasColumnName("isShow");
            entity.Property(e => e.Memo).HasColumnName("memo");
            entity.Property(e => e.MenuId).HasColumnName("menuID");
            entity.Property(e => e.MenuName)
                .HasMaxLength(50)
                .HasColumnName("menuName");
            entity.Property(e => e.MenuUrl).HasColumnName("menuURL");
            entity.Property(e => e.OrderByGroup).HasColumnName("orderBy_group");
            entity.Property(e => e.OrderByMenu).HasColumnName("orderBy_menu");
        });

        modelBuilder.Entity<SystemMenuAu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("System_MenuAu");

            entity.Property(e => e.AuTypeId).HasColumnName("auTypeID");
            entity.Property(e => e.MenuId).HasColumnName("menuID");
        });

        modelBuilder.Entity<SystemTaiwan>(entity =>
        {
            entity.HasKey(e => e.TwId);

            entity.ToTable("System_Taiwan");

            entity.Property(e => e.TwId).HasColumnName("twID");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasColumnName("area");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CityId).HasColumnName("cityID");
        });

        modelBuilder.Entity<SystemUserAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK_System_UserAccountInfo");

            entity.ToTable("System_UserAccount");

            entity.Property(e => e.AccountId).HasColumnName("accountID");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .HasColumnName("account");
            entity.Property(e => e.AuTypeId).HasColumnName("auTypeID");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.InsertAccountId).HasColumnName("insertAccountID");
            entity.Property(e => e.InsertDateTime)
                .HasColumnType("datetime")
                .HasColumnName("insertDateTime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastUpdatePwdateTime)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdatePWDateTime");
            entity.Property(e => e.Memo).HasColumnName("memo");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RemoveAccountId).HasColumnName("removeAccountID");
            entity.Property(e => e.RemoveDateTime)
                .HasColumnType("datetime")
                .HasColumnName("removeDateTime");
            entity.Property(e => e.Unit).HasColumnName("unit");
            entity.Property(e => e.UpdateAccountId).HasColumnName("updateAccountID");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateDateTime");
        });

        modelBuilder.Entity<SystemUserAuType>(entity =>
        {
            entity.HasKey(e => e.AuTypeId).HasName("PK_Sys_AuType");

            entity.ToTable("System_UserAuType");

            entity.Property(e => e.AuTypeId).HasColumnName("auTypeID");
            entity.Property(e => e.AuTypeName)
                .HasMaxLength(50)
                .HasColumnName("auTypeName");
            entity.Property(e => e.Memo).HasColumnName("memo");
        });

        modelBuilder.Entity<SystemUserLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("System_UserLog");

            entity.Property(e => e.LogId).HasColumnName("logID");
            entity.Property(e => e.AccountId).HasColumnName("accountID");
            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.LogDateTime)
                .HasColumnType("datetime")
                .HasColumnName("logDateTime");
            entity.Property(e => e.LogItem)
                .HasMaxLength(50)
                .HasColumnName("logItem");
            entity.Property(e => e.LogType)
                .HasMaxLength(50)
                .HasColumnName("logType");
            entity.Property(e => e.Memo).HasColumnName("memo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
