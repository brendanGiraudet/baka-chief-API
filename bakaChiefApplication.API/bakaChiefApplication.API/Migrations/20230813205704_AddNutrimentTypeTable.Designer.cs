﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bakaChiefApplication.API.Repositories;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230813205704_AddNutrimentTypeTable")]
    partial class AddNutrimentTypeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.NutrimentType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NutrimentTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
