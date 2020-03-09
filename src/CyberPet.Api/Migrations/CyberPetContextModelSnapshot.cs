﻿// <auto-generated />
using System;
using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CyberPet.Api.Migrations
{
    [DbContext(typeof(CyberPetContext))]
    partial class CyberPetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CyberPet.Api.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PetName")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("CyberPet.Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                            Email = "ghmeyer0@gmail.com",
                            Name = "Gabriel Helko Meyer",
                            Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600"
                        },
                        new
                        {
                            Id = new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                            Email = "gustavoreinertbsi@gmail.com",
                            Name = "Gustavo Reinert",
                            Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600"
                        },
                        new
                        {
                            Id = new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                            Email = "rrschiavo@gmail.com",
                            Name = "Renato Schiavo",
                            Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600"
                        });
                });

            modelBuilder.Entity("CyberPet.Api.Models.User", b =>
                {
                    b.HasOne("CyberPet.Api.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");
                });
#pragma warning restore 612, 618
        }
    }
}
