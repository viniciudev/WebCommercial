﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20210802231352_alter cadastro cliente")]
    partial class altercadastrocliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Bairro")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CellPhone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Complement")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NameCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_client");
                });

            modelBuilder.Entity("Model.Registrations.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorporateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorporateName = "Empresa Padrão"
                        });
                });

            modelBuilder.Entity("Model.Registrations.DescriptionFiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descriptionProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupItems")
                        .HasColumnType("int");

                    b.Property<int>("idCompany")
                        .HasColumnType("int");

                    b.Property<string>("valueProduct")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("idCompany");

                    b.ToTable("tb_descriptionFiles");
                });

            modelBuilder.Entity("Model.Registrations.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Files")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdDescriptionFiles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDescriptionFiles");

                    b.ToTable("tb_file");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1983, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@padrao.com.br",
                            IdCompany = 1,
                            Name = "Admin",
                            Password = "Admin"
                        });
                });

            modelBuilder.Entity("Model.Registrations.DescriptionFiles", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("DescriptionFiles")
                        .HasForeignKey("idCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Registrations.File", b =>
                {
                    b.HasOne("Model.Registrations.DescriptionFiles", "DescriptionFiles")
                        .WithMany("Files")
                        .HasForeignKey("IdDescriptionFiles")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DescriptionFiles");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Registrations.Company", b =>
                {
                    b.Navigation("DescriptionFiles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Model.Registrations.DescriptionFiles", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
