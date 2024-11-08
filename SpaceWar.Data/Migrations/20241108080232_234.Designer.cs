﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceWar.Data;

#nullable disable

namespace SpaceWar.Data.Migrations
{
    [DbContext(typeof(SpaceWarContext))]
    [Migration("20241108080232_234")]
    partial class _234
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpaceWar.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ShipID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });

            modelBuilder.Entity("SpaceWar.Core.Domain.Ship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BuiltAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DestroyedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrimaryAttack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimaryAttackPower")
                        .HasColumnType("int");

                    b.Property<string>("SecondaryAttack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecondaryAttackPower")
                        .HasColumnType("int");

                    b.Property<int>("ShipClass")
                        .HasColumnType("int");

                    b.Property<int>("ShipDurability")
                        .HasColumnType("int");

                    b.Property<int>("ShipLevel")
                        .HasColumnType("int");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipWasBuilt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipWasDestroyed")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShipXP")
                        .HasColumnType("int");

                    b.Property<int>("ShipXPNextLevel")
                        .HasColumnType("int");

                    b.Property<string>("UltimateAttack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UltimateAttackPower")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ships");
                });
#pragma warning restore 612, 618
        }
    }
}
