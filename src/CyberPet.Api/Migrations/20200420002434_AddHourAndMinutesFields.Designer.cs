﻿// <auto-generated />
using System;
using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CyberPet.Api.Migrations
{
    [DbContext(typeof(CyberPetContext))]
    [Migration("20200420002434_AddHourAndMinutesFields")]
    partial class AddHourAndMinutesFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:Enum:day_of_week", "sunday,monday,tuesday,wednesday,thursday,friday,saturday")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CyberPet.Api.Models.Bowl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.ToTable("Bowl");
                });

            modelBuilder.Entity("CyberPet.Api.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PetImage")
                        .HasColumnType("text");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                            CreateAt = new DateTime(2020, 4, 19, 21, 24, 34, 82, DateTimeKind.Local).AddTicks(1117),
                            PetName = "Woody",
                            UpdateAt = new DateTime(2020, 4, 19, 21, 24, 34, 82, DateTimeKind.Local).AddTicks(1124),
                            UserId = new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c")
                        });
                });

            modelBuilder.Entity("CyberPet.Api.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Hour")
                        .HasColumnType("integer");

                    b.Property<int>("Minutes")
                        .HasColumnType("integer");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("CyberPet.Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                            CreateAt = new DateTime(2020, 4, 19, 21, 24, 34, 79, DateTimeKind.Local).AddTicks(7699),
                            Email = "ghmeyer0@gmail.com",
                            Name = "Gabriel Helko Meyer",
                            Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600",
                            UpdateAt = new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(5971)
                        },
                        new
                        {
                            Id = new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                            CreateAt = new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6641),
                            Email = "gustavoreinertbsi@gmail.com",
                            Name = "Gustavo Reinert",
                            Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600",
                            UpdateAt = new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6654)
                        },
                        new
                        {
                            Id = new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                            CreateAt = new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6674),
                            Email = "rrschiavo@gmail.com",
                            Name = "Renato Schiavo",
                            Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600",
                            UpdateAt = new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6675)
                        });
                });

            modelBuilder.Entity("CyberPet.Api.Models.Bowl", b =>
                {
                    b.HasOne("CyberPet.Api.Models.Pet", "Pet")
                        .WithOne("Bowl")
                        .HasForeignKey("CyberPet.Api.Models.Bowl", "PetId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();
                });

            modelBuilder.Entity("CyberPet.Api.Models.Pet", b =>
                {
                    b.HasOne("CyberPet.Api.Models.User", "User")
                        .WithMany("Pets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CyberPet.Api.Models.Schedule", b =>
                {
                    b.HasOne("CyberPet.Api.Models.Pet", "Pet")
                        .WithMany("Schedules")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
