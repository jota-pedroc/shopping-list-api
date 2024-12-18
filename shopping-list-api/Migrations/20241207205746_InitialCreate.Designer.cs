﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shopping_list_api.AppContext;

#nullable disable

namespace shopping_list_api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241207205746_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("itemsapi")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("shopping_list_api.model.ItemModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Items", "itemsapi");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d6089e16-62f7-4131-8ed4-13fbc2e1c85d"),
                            Name = "Paçoca"
                        },
                        new
                        {
                            Id = new Guid("b17b0981-e76f-48fb-a12e-d33eba793523"),
                            Name = "Queijo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}