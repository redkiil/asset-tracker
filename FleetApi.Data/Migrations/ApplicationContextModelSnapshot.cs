﻿// <auto-generated />
using System;
using FleetApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetApi.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FleetApi.Domain.Entities.Employee", b =>
                {
                    b.Property<short>("Badge")
                        .HasColumnType("smallint");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Badge");

                    b.HasAlternateKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("FleetApi.Domain.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("JSON");

                    b.Property<short>("EmployeeBadge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)9999);

                    b.Property<string>("EquipType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<short>("Fleet")
                        .HasColumnType("smallint");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 8, 26, 23, 32, 3, 608, DateTimeKind.Utc).AddTicks(3369));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<short>("ModelYear")
                        .HasColumnType("smallint");

                    b.Property<string>("Position")
                        .HasColumnType("JSON");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeBadge");

                    b.HasIndex("GroupId");

                    b.ToTable("equipments");
                });

            modelBuilder.Entity("FleetApi.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("FleetApi.Domain.Entities.Employee", b =>
                {
                    b.HasOne("FleetApi.Domain.Entities.Group", "group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("group");
                });

            modelBuilder.Entity("FleetApi.Domain.Entities.Equipment", b =>
                {
                    b.HasOne("FleetApi.Domain.Entities.Employee", "Employee")
                        .WithMany("equipment")
                        .HasForeignKey("EmployeeBadge")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetApi.Domain.Entities.Group", "Group")
                        .WithMany("equipment")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FleetApi.Domain.Entities.Employee", b =>
                {
                    b.Navigation("equipment");
                });

            modelBuilder.Entity("FleetApi.Domain.Entities.Group", b =>
                {
                    b.Navigation("equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
