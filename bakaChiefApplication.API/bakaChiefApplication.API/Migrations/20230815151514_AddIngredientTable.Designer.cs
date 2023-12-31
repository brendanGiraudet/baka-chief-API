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
    [Migration("20230815151514_AddIngredientTable")]
    partial class AddIngredientTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.IngredientNutrimentType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("IngredientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NutrimentTypeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("NutrimentTypeId");

                    b.ToTable("IngredientNutrimentType");
                });

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

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.IngredientNutrimentType", b =>
                {
                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Ingredient", "Ingredient")
                        .WithMany("NutrimentTypes")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bakaChiefApplication.API.DatabaseModels.NutrimentType", "NutrimentType")
                        .WithMany("Ingredients")
                        .HasForeignKey("NutrimentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("NutrimentType");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Ingredient", b =>
                {
                    b.Navigation("NutrimentTypes");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.NutrimentType", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
