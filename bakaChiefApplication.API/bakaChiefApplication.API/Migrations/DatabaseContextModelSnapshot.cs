﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("RecipSelectedRecipHistory", b =>
                {
                    b.Property<string>("RecipsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SelectedRecipHistoriesId")
                        .HasColumnType("TEXT");

                    b.HasKey("RecipsId", "SelectedRecipHistoriesId");

                    b.HasIndex("SelectedRecipHistoriesId");

                    b.ToTable("RecipSelectedRecipHistory");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "imageUrl");

                    b.Property<double>("KcalNumber")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "kcalNumber");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasAnnotation("Relational:JsonPropertyName", "ingredient");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.IngredientNutriment", b =>
                {
                    b.Property<string>("IngredientId")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "ingredientId");

                    b.Property<string>("NutrimentId")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "nutrimentId");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "quantity");

                    b.HasKey("IngredientId", "NutrimentId");

                    b.HasIndex("NutrimentId");

                    b.ToTable("IngredientNutriments");

                    b.HasAnnotation("Relational:JsonPropertyName", "ingredientNutriments");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Nutriment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("Nutriments");

                    b.HasAnnotation("Relational:JsonPropertyName", "nutriment");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Recip", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "imageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<int>("PersonsNumber")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "personsNumber");

                    b.HasKey("Id");

                    b.ToTable("Recips");

                    b.HasAnnotation("Relational:JsonPropertyName", "recip");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.RecipIngredient", b =>
                {
                    b.Property<string>("IngredientId")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "ingredientId");

                    b.Property<string>("RecipId")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "recipId");

                    b.Property<string>("MeasureUnit")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "measureUnit");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "quantity");

                    b.HasKey("IngredientId", "RecipId");

                    b.HasIndex("RecipId");

                    b.ToTable("RecipIngredients");

                    b.HasAnnotation("Relational:JsonPropertyName", "recipIngredients");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.RecipStep", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "number");

                    b.Property<string>("RecipId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipId");

                    b.ToTable("RecipSteps");

                    b.HasAnnotation("Relational:JsonPropertyName", "recipSteps");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.SelectedRecipHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "date");

                    b.HasKey("Id");

                    b.ToTable("SelectedRecipHistories");
                });

            modelBuilder.Entity("RecipSelectedRecipHistory", b =>
                {
                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Recip", null)
                        .WithMany()
                        .HasForeignKey("RecipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bakaChiefApplication.API.DatabaseModels.SelectedRecipHistory", null)
                        .WithMany()
                        .HasForeignKey("SelectedRecipHistoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.IngredientNutriment", b =>
                {
                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Ingredient", "Ingredient")
                        .WithMany("IngredientNutriments")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Nutriment", "Nutriment")
                        .WithMany("IngredientNutriments")
                        .HasForeignKey("NutrimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Nutriment");
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
                        .HasForeignKey("RecipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recip");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.RecipStep", b =>
                {
                    b.HasOne("bakaChiefApplication.API.DatabaseModels.Recip", "Recip")
                        .WithMany("RecipSteps")
                        .HasForeignKey("RecipId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Recip");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Ingredient", b =>
                {
                    b.Navigation("IngredientNutriments");

                    b.Navigation("RecipIngredients");
                });

            modelBuilder.Entity("bakaChiefApplication.API.DatabaseModels.Nutriment", b =>
                {
                    b.Navigation("IngredientNutriments");
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
