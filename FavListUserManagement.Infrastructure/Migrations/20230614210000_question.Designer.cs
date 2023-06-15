﻿// <auto-generated />
using System;
using FavListUserManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FavListUserManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230614210000_question")]
    partial class question
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.Catergory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Created_By_Id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Last_Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Last_update_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Modified_By")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid>("Update_by_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Catergories");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.PortalFeature", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Catergory_IdId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Created_By_Id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Last_Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Last_update_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Modified_By")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Screen_Path")
                        .HasColumnType("longtext");

                    b.Property<Guid>("Update_by_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Catergory_IdId");

                    b.ToTable("PortalFeatures");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.Question", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Answer")
                        .HasColumnType("longtext");

                    b.Property<string>("CatergoryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Created_By_Id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Last_Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Last_update_date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("MigratedToRedis")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Modified_By")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SponsorId")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("Update_by_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("date_to_post")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("days_to_remain_open")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("max_answer_count")
                        .HasColumnType("int");

                    b.Property<int>("min_answer_count")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CatergoryId");

                    b.HasIndex("SponsorId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.QuestionDefaultParameter", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Created_By_Id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Days_to_remain_open")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Last_Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Last_update_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Max_answer_count")
                        .HasColumnType("int");

                    b.Property<int>("Min_answer_count")
                        .HasColumnType("int");

                    b.Property<string>("Modified_By")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Update_by_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("QuestionDefaultParameters");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.RoleFeature", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("CanCreate")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanView")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Created_By_Id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Last_Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Last_update_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Modified_By")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PortalFeatures_IdId")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("Update_by_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PortalFeatures_IdId");

                    b.ToTable("RoleFeatures");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.Sponsor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Ad_S3_Url")
                        .HasColumnType("longtext");

                    b.Property<string>("Created_By_Id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Last_Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Last_update_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Logo_S3_Url")
                        .HasColumnType("longtext");

                    b.Property<string>("Modified_By")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Update_by_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("sponsors");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Last_Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Refreshtoken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.Catergory", b =>
                {
                    b.HasOne("FavListUserManagement.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.PortalFeature", b =>
                {
                    b.HasOne("FavListUserManagement.Domain.Entities.Catergory", "Catergory_Id")
                        .WithMany()
                        .HasForeignKey("Catergory_IdId");

                    b.Navigation("Catergory_Id");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.Question", b =>
                {
                    b.HasOne("FavListUserManagement.Domain.Entities.Catergory", "Catergory")
                        .WithMany()
                        .HasForeignKey("CatergoryId");

                    b.HasOne("FavListUserManagement.Domain.Entities.Sponsor", "sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId");

                    b.HasOne("FavListUserManagement.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Catergory");

                    b.Navigation("User");

                    b.Navigation("sponsor");
                });

            modelBuilder.Entity("FavListUserManagement.Domain.Entities.RoleFeature", b =>
                {
                    b.HasOne("FavListUserManagement.Domain.Entities.PortalFeature", "PortalFeatures_Id")
                        .WithMany()
                        .HasForeignKey("PortalFeatures_IdId");

                    b.Navigation("PortalFeatures_Id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FavListUserManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FavListUserManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavListUserManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FavListUserManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
