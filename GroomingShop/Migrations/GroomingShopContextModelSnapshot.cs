﻿// <auto-generated />
using System;
using GroomingShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GroomingShop.Migrations
{
    [DbContext(typeof(GroomingShopContext))]
    partial class GroomingShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GroomingShop.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("GroomerId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<int>("ParentPetId")
                        .HasColumnType("int");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time(6)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("GroomerId");

                    b.HasIndex("ParentPetId");

                    b.HasIndex("PetId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("GroomingShop.Models.Groomer", b =>
                {
                    b.Property<int>("GroomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("GroomerId");

                    b.ToTable("Groomers");
                });

            modelBuilder.Entity("GroomingShop.Models.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("ParentId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("GroomingShop.Models.ParentPet", b =>
                {
                    b.Property<int>("ParentPetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.HasKey("ParentPetId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PetId");

                    b.ToTable("ParentPets");
                });

            modelBuilder.Entity("GroomingShop.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("VaccExpDate")
                        .HasColumnType("date");

                    b.Property<string>("Vet")
                        .HasColumnType("longtext");

                    b.Property<string>("VetPhone")
                        .HasColumnType("longtext");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("PetId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("GroomingShop.Models.Appointment", b =>
                {
                    b.HasOne("GroomingShop.Models.Groomer", "Groomer")
                        .WithMany("Appointments")
                        .HasForeignKey("GroomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroomingShop.Models.Pet", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentPetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroomingShop.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.Navigation("Groomer");

                    b.Navigation("Parent");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("GroomingShop.Models.ParentPet", b =>
                {
                    b.HasOne("GroomingShop.Models.Parent", "Parent")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroomingShop.Models.Pet", "Pet")
                        .WithMany("JoinEntities")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("GroomingShop.Models.Groomer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("GroomingShop.Models.Parent", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("GroomingShop.Models.Pet", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
