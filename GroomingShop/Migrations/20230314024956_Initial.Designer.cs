﻿// <auto-generated />
using GroomingShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GroomingShop.Migrations
{
    [DbContext(typeof(GroomingShopContext))]
    [Migration("20230314024956_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("EndTime")
                        .HasColumnType("longtext");

                    b.Property<int>("GroomerId")
                        .HasColumnType("int");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<string>("StartTime")
                        .HasColumnType("longtext");

                    b.HasKey("AppointmentId");

                    b.HasIndex("GroomerId");

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

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.HasKey("GroomerId");

                    b.ToTable("Groomers");
                });

            modelBuilder.Entity("GroomingShop.Models.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
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

                    b.ToTable("ParentPet");
                });

            modelBuilder.Entity("GroomingShop.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

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

                    b.HasOne("GroomingShop.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groomer");

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