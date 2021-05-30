﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skymly.JyGameStudio.Data;

namespace Skymly.JyGameStudio.Data.Migrations
{
    [DbContext(typeof(ScriptsContext))]
    [Migration("20210530174033_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Skymly.JyGameStudio.Models.Aoyi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddPower")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Animation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Buff")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Probability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aoyi");
                });

            modelBuilder.Entity("Skymly.JyGameStudio.Models.AoyiCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AoyiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AoyiId");

                    b.ToTable("AoyiCondition");
                });

            modelBuilder.Entity("Skymly.JyGameStudio.Models.Battle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mapkey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Music")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Must")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Battle");
                });

            modelBuilder.Entity("Skymly.JyGameStudio.Models.BattleRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Animation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BattleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Face")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Index")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBoss")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("X")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Y")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BattleId");

                    b.ToTable("BattleRole");
                });

            modelBuilder.Entity("Skymly.JyGameStudio.Models.AoyiCondition", b =>
                {
                    b.HasOne("Skymly.JyGameStudio.Models.Aoyi", null)
                        .WithMany("AoyiConditions")
                        .HasForeignKey("AoyiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Skymly.JyGameStudio.Models.BattleRole", b =>
                {
                    b.HasOne("Skymly.JyGameStudio.Models.Battle", null)
                        .WithMany("Roles")
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Skymly.JyGameStudio.Models.Aoyi", b =>
                {
                    b.Navigation("AoyiConditions");
                });

            modelBuilder.Entity("Skymly.JyGameStudio.Models.Battle", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
