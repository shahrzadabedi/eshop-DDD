﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.Infrastructure.Persistence.EF;

namespace OrderManagement.Infrastructure.Persistence.EF.Migrations
{
    [DbContext(typeof(OrderManagementDbContext))]
    [Migration("20220910192643_change_Product_Id_to_int")]
    partial class change_Product_Id_to_int
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderManagement.Domain.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderManagement.Domain.Model.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShippingInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("OrderManagement.Domain.Model.OrderItem", b =>
                {
                    b.HasOne("OrderManagement.Domain.Model.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("OrderManagement.Domain.Model.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
