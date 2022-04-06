﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TamagotchiWeb.Data;

#nullable disable

namespace TamagotchiWeb.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("animalId")
                        .HasColumnType("int");

                    b.Property<bool?>("catsEnvinronment")
                        .HasColumnType("bit");

                    b.Property<bool?>("childrenEnvinronment")
                        .HasColumnType("bit");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("coat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("declawed")
                        .HasColumnType("bit");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("dogsEnvinronment")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("houseTrained")
                        .HasColumnType("bit");

                    b.Property<bool?>("isMixedBreed")
                        .HasColumnType("bit");

                    b.Property<bool?>("isUnknownBreed")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organizationAnimalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organizationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryBreed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("published_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("secondaryBreed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondaryColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("shotsCurrent")
                        .HasColumnType("bit");

                    b.Property<string>("size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("spayedNeutered")
                        .HasColumnType("bit");

                    b.Property<bool?>("specialNeeds")
                        .HasColumnType("bit");

                    b.Property<string>("species")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("status_changed_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tertiaryColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("videos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("TamagotchiWeb.Entities.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Coats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genders")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");
                });

            modelBuilder.Entity("TamagotchiWeb.Entities.Organization", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adoptionPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adoptionUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("friday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mission_statement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("monday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organizationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pinterest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("saturday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sunday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thursday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tuesday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wednesday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("youtube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Organizations");
                });
#pragma warning restore 612, 618
        }
    }
}
