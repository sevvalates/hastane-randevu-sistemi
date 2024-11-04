﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnionArchitecture.HostpitalApi.Persistence.Context;

namespace OnionArchitecture.HostpitalApi.Persistence.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20241022122323_AddSsnToDoctor")]
    partial class AddSsnToDoctor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AppointmentStatus")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Corporation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Corporations");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<long>("SocialSecurityNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CorporationId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<long>("SocialSecurityNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CorporationId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("OnionArchitecture.HospitalApi.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnionArchitecture.HospitalApi.Domain.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnionArchitecture.HospitalApi.Domain.Entities.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("OnionArchitecture.HospitalApi.Domain.Entities.Service", "Service")
                        .WithMany("Doctors")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Patient", b =>
                {
                    b.HasOne("OnionArchitecture.HospitalApi.Domain.Entities.Corporation", "Corporation")
                        .WithMany("Patients")
                        .HasForeignKey("CorporationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corporation");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Corporation", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("OnionArchitecture.HospitalApi.Domain.Entities.Service", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}