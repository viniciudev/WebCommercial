﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20230214194130_add tb_plan")]
    partial class addtb_plan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

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

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_client", (string)null);
                });

            modelBuilder.Entity("Model.Moves.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_budget", (string)null);
                });

            modelBuilder.Entity("Model.Moves.BudgetItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBudget")
                        .HasColumnType("int");

                    b.Property<int>("IdItem")
                        .HasColumnType("int");

                    b.Property<int>("TypeItem")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdBudget");

                    b.ToTable("tb_budgetItems", (string)null);
                });

            modelBuilder.Entity("Model.Moves.Financial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinancialStatus")
                        .HasColumnType("int");

                    b.Property<int>("FinancialType")
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<int>("IdCostCenter")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("IdSale")
                        .HasColumnType("int");

                    b.Property<int?>("IdSaleItems")
                        .HasColumnType("int");

                    b.Property<int?>("IdSalesman")
                        .HasColumnType("int");

                    b.Property<int?>("IdService")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.HasIndex("IdCostCenter");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSale");

                    b.HasIndex("IdSaleItems");

                    b.HasIndex("IdSalesman");

                    b.HasIndex("IdService");

                    b.ToTable("tb_financial", (string)null);
                });

            modelBuilder.Entity("Model.Moves.PlanCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("tb_planCompany", (string)null);
                });

            modelBuilder.Entity("Model.Moves.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<int?>("IdSeller")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdCompany");

                    b.HasIndex("IdSeller");

                    b.ToTable("tb_sale", (string)null);
                });

            modelBuilder.Entity("Model.Moves.SaleItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("IdSale")
                        .HasColumnType("int");

                    b.Property<int?>("IdService")
                        .HasColumnType("int");

                    b.Property<DateTime>("InclusionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeItem")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSale");

                    b.HasIndex("IdService");

                    b.ToTable("tb_saleItems", (string)null);
                });

            modelBuilder.Entity("Model.Moves.ServicesProvision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdBudget")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBudget");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_serviceProvision", (string)null);
                });

            modelBuilder.Entity("Model.Moves.ServicesProvisionItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdItem")
                        .HasColumnType("int");

                    b.Property<int>("IdServiceProvision")
                        .HasColumnType("int");

                    b.Property<int>("TypeItem")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdServiceProvision");

                    b.ToTable("tb_servicesProvisionItems", (string)null);
                });

            modelBuilder.Entity("Model.Registrations.Commission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommissionDay")
                        .HasColumnType("int");

                    b.Property<int>("IdCostCenter")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("IdSalesman")
                        .HasColumnType("int");

                    b.Property<int?>("IdService")
                        .HasColumnType("int");

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TypeDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCostCenter");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSalesman");

                    b.HasIndex("IdService");

                    b.ToTable("tb_commission", (string)null);
                });

            modelBuilder.Entity("Model.Registrations.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CorporateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_company", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorporateName = "Empresa Padrão"
                        });
                });

            modelBuilder.Entity("Model.Registrations.CostCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_costCenter", (string)null);
                });

            modelBuilder.Entity("Model.Registrations.DescriptionFiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.ToTable("tb_descriptionFiles", (string)null);
                });

            modelBuilder.Entity("Model.Registrations.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileThumb")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Files")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdDescriptionFiles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDescriptionFiles");

                    b.ToTable("tb_file", (string)null);
                });

            modelBuilder.Entity("Model.Registrations.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_product", (string)null);
                });

            modelBuilder.Entity("Model.Registrations.Salesman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_salesman", (string)null);
                });

            modelBuilder.Entity("Model.Registrations.ServiceProvided", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("tb_ServiceProvided", (string)null);
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("tb_user", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1983, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@padrao.com.br",
                            IdCompany = 1,
                            Name = "Admin",
                            Password = ""
                        });
                });

            modelBuilder.Entity("Model.Client", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Clients")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Moves.Budget", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Budgets")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Moves.BudgetItems", b =>
                {
                    b.HasOne("Model.Moves.Budget", "Budget")
                        .WithMany("BudgetItems")
                        .HasForeignKey("IdBudget")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("Model.Moves.Financial", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Financials")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.CostCenter", "CostCenter")
                        .WithMany("Financials")
                        .HasForeignKey("IdCostCenter")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.Product", "Product")
                        .WithMany("Financials")
                        .HasForeignKey("IdProduct");

                    b.HasOne("Model.Moves.Sale", "Sale")
                        .WithMany("Financials")
                        .HasForeignKey("IdSale");

                    b.HasOne("Model.Moves.SaleItems", "SaleItems")
                        .WithMany("Financials")
                        .HasForeignKey("IdSaleItems");

                    b.HasOne("Model.Registrations.Salesman", "Salesman")
                        .WithMany("Financials")
                        .HasForeignKey("IdSalesman");

                    b.HasOne("Model.Registrations.ServiceProvided", "ServiceProvided")
                        .WithMany("Financials")
                        .HasForeignKey("IdService");

                    b.Navigation("Company");

                    b.Navigation("CostCenter");

                    b.Navigation("Product");

                    b.Navigation("Sale");

                    b.Navigation("SaleItems");

                    b.Navigation("Salesman");

                    b.Navigation("ServiceProvided");
                });

            modelBuilder.Entity("Model.Moves.Sale", b =>
                {
                    b.HasOne("Model.Client", "Client")
                        .WithMany("Sale")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Sale")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.Salesman", "Salesman")
                        .WithMany("Sale")
                        .HasForeignKey("IdSeller");

                    b.Navigation("Client");

                    b.Navigation("Company");

                    b.Navigation("Salesman");
                });

            modelBuilder.Entity("Model.Moves.SaleItems", b =>
                {
                    b.HasOne("Model.Registrations.Product", "Product")
                        .WithMany("SaleItems")
                        .HasForeignKey("IdProduct");

                    b.HasOne("Model.Moves.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("IdSale")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.ServiceProvided", "ServiceProvided")
                        .WithMany("SaleItems")
                        .HasForeignKey("IdService");

                    b.Navigation("Product");

                    b.Navigation("Sale");

                    b.Navigation("ServiceProvided");
                });

            modelBuilder.Entity("Model.Moves.ServicesProvision", b =>
                {
                    b.HasOne("Model.Moves.Budget", "Budget")
                        .WithMany("ServiceProvisions")
                        .HasForeignKey("IdBudget");

                    b.HasOne("Model.Client", "Client")
                        .WithMany("ServiceProvisions")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("ServiceProvisions")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Client");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Moves.ServicesProvisionItems", b =>
                {
                    b.HasOne("Model.Moves.ServicesProvision", "ServiceProvision")
                        .WithMany("ServicesProvisionItems")
                        .HasForeignKey("IdServiceProvision")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ServiceProvision");
                });

            modelBuilder.Entity("Model.Registrations.Commission", b =>
                {
                    b.HasOne("Model.Registrations.CostCenter", "CostCenter")
                        .WithMany("Commissions")
                        .HasForeignKey("IdCostCenter")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.Product", "Product")
                        .WithMany("Commissions")
                        .HasForeignKey("IdProduct");

                    b.HasOne("Model.Registrations.Salesman", "Salesman")
                        .WithMany("Commissions")
                        .HasForeignKey("IdSalesman")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Registrations.ServiceProvided", "ServiceProvided")
                        .WithMany("Commissions")
                        .HasForeignKey("IdService");

                    b.Navigation("CostCenter");

                    b.Navigation("Product");

                    b.Navigation("Salesman");

                    b.Navigation("ServiceProvided");
                });

            modelBuilder.Entity("Model.Registrations.CostCenter", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("CostCenters")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Registrations.DescriptionFiles", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("DescriptionFiles")
                        .HasForeignKey("idCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Registrations.File", b =>
                {
                    b.HasOne("Model.Registrations.DescriptionFiles", "DescriptionFiles")
                        .WithMany("Files")
                        .HasForeignKey("IdDescriptionFiles")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DescriptionFiles");
                });

            modelBuilder.Entity("Model.Registrations.Product", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Registrations.Salesman", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Salesmen")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Registrations.ServiceProvided", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("ServiceProvideds")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.HasOne("Model.Registrations.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Client", b =>
                {
                    b.Navigation("Sale");

                    b.Navigation("ServiceProvisions");
                });

            modelBuilder.Entity("Model.Moves.Budget", b =>
                {
                    b.Navigation("BudgetItems");

                    b.Navigation("ServiceProvisions");
                });

            modelBuilder.Entity("Model.Moves.Sale", b =>
                {
                    b.Navigation("Financials");

                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("Model.Moves.SaleItems", b =>
                {
                    b.Navigation("Financials");
                });

            modelBuilder.Entity("Model.Moves.ServicesProvision", b =>
                {
                    b.Navigation("ServicesProvisionItems");
                });

            modelBuilder.Entity("Model.Registrations.Company", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("Clients");

                    b.Navigation("CostCenters");

                    b.Navigation("DescriptionFiles");

                    b.Navigation("Financials");

                    b.Navigation("Products");

                    b.Navigation("Sale");

                    b.Navigation("Salesmen");

                    b.Navigation("ServiceProvideds");

                    b.Navigation("ServiceProvisions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Model.Registrations.CostCenter", b =>
                {
                    b.Navigation("Commissions");

                    b.Navigation("Financials");
                });

            modelBuilder.Entity("Model.Registrations.DescriptionFiles", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("Model.Registrations.Product", b =>
                {
                    b.Navigation("Commissions");

                    b.Navigation("Financials");

                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("Model.Registrations.Salesman", b =>
                {
                    b.Navigation("Commissions");

                    b.Navigation("Financials");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Model.Registrations.ServiceProvided", b =>
                {
                    b.Navigation("Commissions");

                    b.Navigation("Financials");

                    b.Navigation("SaleItems");
                });
#pragma warning restore 612, 618
        }
    }
}
