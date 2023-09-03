﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bakaChiefApplication.API.Repositories;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("IngredientNutrimentType", b =>
                {
                    b.Property<string>("IngredientsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("NutrimentTypesId")
                        .HasColumnType("TEXT");

                    b.HasKey("IngredientsId", "NutrimentTypesId");

                    b.HasIndex("NutrimentTypesId");

                    b.ToTable("IngredientNutrimentType");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.NutrimentType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NutrimentTypes");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Recip", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageFilePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonsNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Recips");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.RecipIngredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("IngredientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MeasureUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecipId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipId");

                    b.ToTable("RecipIngredients");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.RecipStep", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecipId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipId");

                    b.ToTable("RecipSteps");
                });

            modelBuilder.Entity("IngredientNutrimentType", b =>
                {
                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bakaChiefApplication.API.DatabaseModels.NutrimentType", null)
                        .WithMany()
                        .HasForeignKey("NutrimentTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.RecipIngredient", b =>
                {
                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Ingredient", "Ingredient")
                        .WithMany("RecipIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Recip", "Recip")
                        .WithMany("RecipIngredients")
                        .HasForeignKey("RecipId");

                    b.Navigation("Ingredient");

                    b.Navigation("Recip");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.RecipStep", b =>
                {
                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Recip", "Recip")
                        .WithMany("RecipSteps")
                        .HasForeignKey("RecipId");

                    b.Navigation("Recip");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Ingredient", b =>
                {
                    b.Navigation("RecipIngredients");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Recip", b =>
                {
                    b.Navigation("RecipIngredients");

                    b.Navigation("RecipSteps");
                });
#pragma warning restore 612, 618
        }
    }
}
