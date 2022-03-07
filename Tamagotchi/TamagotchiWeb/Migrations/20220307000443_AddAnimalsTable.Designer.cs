﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TamagotchiWeb.Data;

#nullable disable

namespace TamagotchiWeb.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220307000443_AddAnimalsTable")]
    partial class AddAnimalsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TamagotchiWeb.Entities.Animal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("attributeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("catsEnvinronment")
                        .HasColumnType("bit");

                    b.Property<bool?>("childrenEnvinronment")
                        .HasColumnType("bit");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("coat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("dogsEnvinronment")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isMixedBreed")
                        .HasColumnType("bit");

                    b.Property<bool>("isUnknownBreed")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organizationAnimalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organizationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryBreed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("published_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("secondaryBreed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondaryColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("status_changed_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tertiaryColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("videos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
