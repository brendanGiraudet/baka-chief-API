using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class rollbackInFirstIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipProductInfos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "ImageFilePath",
                table: "Recips",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipSteps",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    KcalNumber = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutriments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutriments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<string>(type: "TEXT", nullable: false),
                    RecipId = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    MeasureUnit = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipIngredients", x => new { x.IngredientId, x.RecipId });
                    table.ForeignKey(
                        name: "FK_RecipIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipIngredients_Recips_RecipId",
                        column: x => x.RecipId,
                        principalTable: "Recips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientNutriments",
                columns: table => new
                {
                    NutrimentId = table.Column<string>(type: "TEXT", nullable: false),
                    IngredientId = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutriments", x => new { x.IngredientId, x.NutrimentId });
                    table.ForeignKey(
                        name: "FK_IngredientNutriments_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientNutriments_Nutriments_NutrimentId",
                        column: x => x.NutrimentId,
                        principalTable: "Nutriments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutriments_NutrimentId",
                table: "IngredientNutriments",
                column: "NutrimentId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipIngredients_RecipId",
                table: "RecipIngredients",
                column: "RecipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientNutriments");

            migrationBuilder.DropTable(
                name: "RecipIngredients");

            migrationBuilder.DropTable(
                name: "Nutriments");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Recips",
                newName: "ImageFilePath");

            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipSteps",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    code = table.Column<string>(type: "TEXT", nullable: false),
                    abbreviated_product_name = table.Column<string>(type: "TEXT", nullable: true),
                    added_salt_100g = table.Column<string>(type: "TEXT", nullable: true),
                    added_sugars_100g = table.Column<string>(type: "TEXT", nullable: true),
                    additives = table.Column<string>(type: "TEXT", nullable: true),
                    additives_fr = table.Column<string>(type: "TEXT", nullable: true),
                    additives_n = table.Column<string>(type: "TEXT", nullable: true),
                    additives_tags = table.Column<string>(type: "TEXT", nullable: true),
                    alcohol_100g = table.Column<string>(type: "TEXT", nullable: true),
                    allergens = table.Column<string>(type: "TEXT", nullable: true),
                    allergens_fr = table.Column<string>(type: "TEXT", nullable: true),
                    alpha_linolenic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    arachidic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    arachidonic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    behenic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    beta_carotene_100g = table.Column<string>(type: "TEXT", nullable: true),
                    beta_glucan_100g = table.Column<string>(type: "TEXT", nullable: true),
                    bicarbonate_100g = table.Column<string>(type: "TEXT", nullable: true),
                    biotin_100g = table.Column<string>(type: "TEXT", nullable: true),
                    brand_owner = table.Column<string>(type: "TEXT", nullable: true),
                    brands = table.Column<string>(type: "TEXT", nullable: true),
                    brands_tags = table.Column<string>(type: "TEXT", nullable: true),
                    butyric_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    caffeine_100g = table.Column<string>(type: "TEXT", nullable: true),
                    calcium_100g = table.Column<string>(type: "TEXT", nullable: true),
                    capric_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    caproic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    caprylic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    carbohydrates_100g = table.Column<string>(type: "TEXT", nullable: true),
                    carbon_footprint_100g = table.Column<string>(type: "TEXT", nullable: true),
                    carbon_footprint_from_meat_or_fish_100g = table.Column<string>(type: "TEXT", nullable: true),
                    carnitine_100g = table.Column<string>(type: "TEXT", nullable: true),
                    casein_100g = table.Column<string>(type: "TEXT", nullable: true),
                    categories = table.Column<string>(type: "TEXT", nullable: true),
                    categories_fr = table.Column<string>(type: "TEXT", nullable: true),
                    categories_tags = table.Column<string>(type: "TEXT", nullable: true),
                    cerotic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    chloride_100g = table.Column<string>(type: "TEXT", nullable: true),
                    chlorophyl_100g = table.Column<string>(type: "TEXT", nullable: true),
                    cholesterol_100g = table.Column<string>(type: "TEXT", nullable: true),
                    choline_100g = table.Column<string>(type: "TEXT", nullable: true),
                    chromium_100g = table.Column<string>(type: "TEXT", nullable: true),
                    cities = table.Column<string>(type: "TEXT", nullable: true),
                    cities_tags = table.Column<string>(type: "TEXT", nullable: true),
                    cocoa_100g = table.Column<string>(type: "TEXT", nullable: true),
                    collagen_meat_protein_ratio_100g = table.Column<string>(type: "TEXT", nullable: true),
                    completeness = table.Column<string>(type: "TEXT", nullable: true),
                    copper_100g = table.Column<string>(type: "TEXT", nullable: true),
                    countries = table.Column<string>(type: "TEXT", nullable: true),
                    countries_fr = table.Column<string>(type: "TEXT", nullable: true),
                    countries_tags = table.Column<string>(type: "TEXT", nullable: true),
                    created_datetime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_t = table.Column<long>(type: "INTEGER", nullable: true),
                    creator = table.Column<string>(type: "TEXT", nullable: true),
                    data_quality_errors_tags = table.Column<string>(type: "TEXT", nullable: true),
                    dihomo_gamma_linolenic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    docosahexaenoic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    ecoscore_grade = table.Column<string>(type: "TEXT", nullable: true),
                    ecoscore_score = table.Column<string>(type: "TEXT", nullable: true),
                    eicosapentaenoic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    elaidic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    emb_codes = table.Column<string>(type: "TEXT", nullable: true),
                    emb_codes_tags = table.Column<string>(type: "TEXT", nullable: true),
                    energy_100g = table.Column<string>(type: "TEXT", nullable: true),
                    energy_from_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    energy_kcal_100g = table.Column<string>(type: "TEXT", nullable: true),
                    energy_kj_100g = table.Column<string>(type: "TEXT", nullable: true),
                    erucic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    erythritol_100g = table.Column<string>(type: "TEXT", nullable: true),
                    fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    fiber_100g = table.Column<string>(type: "TEXT", nullable: true),
                    first_packaging_code_geo = table.Column<string>(type: "TEXT", nullable: true),
                    fluoride_100g = table.Column<string>(type: "TEXT", nullable: true),
                    folates_100g = table.Column<string>(type: "TEXT", nullable: true),
                    food_groups = table.Column<string>(type: "TEXT", nullable: true),
                    food_groups_fr = table.Column<string>(type: "TEXT", nullable: true),
                    food_groups_tags = table.Column<string>(type: "TEXT", nullable: true),
                    fructose_100g = table.Column<string>(type: "TEXT", nullable: true),
                    fruits_vegetables_nuts_100g = table.Column<string>(type: "TEXT", nullable: true),
                    fruits_vegetables_nuts_dried_100g = table.Column<string>(type: "TEXT", nullable: true),
                    fruits_vegetables_nuts_estimate_100g = table.Column<string>(type: "TEXT", nullable: true),
                    fruits_vegetables_nuts_estimate_from_ingredients_100g = table.Column<string>(type: "TEXT", nullable: true),
                    gamma_linolenic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    generic_name = table.Column<string>(type: "TEXT", nullable: true),
                    glucose_100g = table.Column<string>(type: "TEXT", nullable: true),
                    glycemic_index_100g = table.Column<string>(type: "TEXT", nullable: true),
                    gondoic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    image_ingredients_small_url = table.Column<string>(type: "TEXT", nullable: true),
                    image_ingredients_url = table.Column<string>(type: "TEXT", nullable: true),
                    image_nutrition_small_url = table.Column<string>(type: "TEXT", nullable: true),
                    image_nutrition_url = table.Column<string>(type: "TEXT", nullable: true),
                    image_small_url = table.Column<string>(type: "TEXT", nullable: true),
                    image_url = table.Column<string>(type: "TEXT", nullable: true),
                    ingredients_analysis_tags = table.Column<string>(type: "TEXT", nullable: true),
                    ingredients_tags = table.Column<string>(type: "TEXT", nullable: true),
                    ingredients_text = table.Column<string>(type: "TEXT", nullable: true),
                    inositol_100g = table.Column<string>(type: "TEXT", nullable: true),
                    insoluble_fiber_100g = table.Column<string>(type: "TEXT", nullable: true),
                    iodine_100g = table.Column<string>(type: "TEXT", nullable: true),
                    iron_100g = table.Column<string>(type: "TEXT", nullable: true),
                    labels = table.Column<string>(type: "TEXT", nullable: true),
                    labels_fr = table.Column<string>(type: "TEXT", nullable: true),
                    labels_tags = table.Column<string>(type: "TEXT", nullable: true),
                    lactose_100g = table.Column<string>(type: "TEXT", nullable: true),
                    last_image_datetime = table.Column<string>(type: "TEXT", nullable: true),
                    last_image_t = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_datetime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    last_modified_t = table.Column<long>(type: "INTEGER", nullable: true),
                    lauric_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    lignoceric_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    linoleic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    magnesium_100g = table.Column<string>(type: "TEXT", nullable: true),
                    main_category = table.Column<string>(type: "TEXT", nullable: true),
                    main_category_fr = table.Column<string>(type: "TEXT", nullable: true),
                    maltodextrins_100g = table.Column<string>(type: "TEXT", nullable: true),
                    maltose_100g = table.Column<string>(type: "TEXT", nullable: true),
                    manganese_100g = table.Column<string>(type: "TEXT", nullable: true),
                    manufacturing_places = table.Column<string>(type: "TEXT", nullable: true),
                    manufacturing_places_tags = table.Column<string>(type: "TEXT", nullable: true),
                    mead_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    melissic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    molybdenum_100g = table.Column<string>(type: "TEXT", nullable: true),
                    monounsaturated_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    montanic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    myristic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    nervonic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    nitrate_100g = table.Column<string>(type: "TEXT", nullable: true),
                    no_nutrition_data = table.Column<string>(type: "TEXT", nullable: true),
                    nova_group = table.Column<string>(type: "TEXT", nullable: true),
                    nucleotides_100g = table.Column<string>(type: "TEXT", nullable: true),
                    nutrient_levels_tags = table.Column<string>(type: "TEXT", nullable: true),
                    nutriscore_grade = table.Column<string>(type: "TEXT", nullable: true),
                    nutriscore_score = table.Column<string>(type: "TEXT", nullable: true),
                    nutrition_score_fr_100g = table.Column<string>(type: "TEXT", nullable: true),
                    nutrition_score_uk_100g = table.Column<string>(type: "TEXT", nullable: true),
                    oleic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    omega_3_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    omega_6_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    omega_9_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    origins = table.Column<string>(type: "TEXT", nullable: true),
                    origins_fr = table.Column<string>(type: "TEXT", nullable: true),
                    origins_tags = table.Column<string>(type: "TEXT", nullable: true),
                    owner = table.Column<string>(type: "TEXT", nullable: true),
                    packaging = table.Column<string>(type: "TEXT", nullable: true),
                    packaging_fr = table.Column<string>(type: "TEXT", nullable: true),
                    packaging_tags = table.Column<string>(type: "TEXT", nullable: true),
                    packaging_text = table.Column<string>(type: "TEXT", nullable: true),
                    palmitic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    pantothenic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    ph_100g = table.Column<string>(type: "TEXT", nullable: true),
                    phosphorus_100g = table.Column<string>(type: "TEXT", nullable: true),
                    phylloquinone_100g = table.Column<string>(type: "TEXT", nullable: true),
                    pnns_groups_1 = table.Column<string>(type: "TEXT", nullable: true),
                    pnns_groups_2 = table.Column<string>(type: "TEXT", nullable: true),
                    polyols_100g = table.Column<string>(type: "TEXT", nullable: true),
                    polyunsaturated_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    popularity_tags = table.Column<string>(type: "TEXT", nullable: true),
                    potassium_100g = table.Column<string>(type: "TEXT", nullable: true),
                    product_name = table.Column<string>(type: "TEXT", nullable: true),
                    product_quantity = table.Column<string>(type: "TEXT", nullable: true),
                    proteins_100g = table.Column<string>(type: "TEXT", nullable: true),
                    purchase_places = table.Column<string>(type: "TEXT", nullable: true),
                    quantity = table.Column<string>(type: "TEXT", nullable: true),
                    salt_100g = table.Column<string>(type: "TEXT", nullable: true),
                    saturated_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    selenium_100g = table.Column<string>(type: "TEXT", nullable: true),
                    serum_proteins_100g = table.Column<string>(type: "TEXT", nullable: true),
                    serving_quantity = table.Column<string>(type: "TEXT", nullable: true),
                    serving_size = table.Column<string>(type: "TEXT", nullable: true),
                    silica_100g = table.Column<string>(type: "TEXT", nullable: true),
                    sodium_100g = table.Column<string>(type: "TEXT", nullable: true),
                    soluble_fiber_100g = table.Column<string>(type: "TEXT", nullable: true),
                    starch_100g = table.Column<string>(type: "TEXT", nullable: true),
                    states = table.Column<string>(type: "TEXT", nullable: true),
                    states_fr = table.Column<string>(type: "TEXT", nullable: true),
                    states_tags = table.Column<string>(type: "TEXT", nullable: true),
                    stearic_acid_100g = table.Column<string>(type: "TEXT", nullable: true),
                    stores = table.Column<string>(type: "TEXT", nullable: true),
                    sucrose_100g = table.Column<string>(type: "TEXT", nullable: true),
                    sugars_100g = table.Column<string>(type: "TEXT", nullable: true),
                    sulphate_100g = table.Column<string>(type: "TEXT", nullable: true),
                    taurine_100g = table.Column<string>(type: "TEXT", nullable: true),
                    traces = table.Column<string>(type: "TEXT", nullable: true),
                    traces_fr = table.Column<string>(type: "TEXT", nullable: true),
                    traces_tags = table.Column<string>(type: "TEXT", nullable: true),
                    trans_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    unique_scans_n = table.Column<string>(type: "TEXT", nullable: true),
                    unsaturated_fat_100g = table.Column<string>(type: "TEXT", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_a_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_b12_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_b1_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_b2_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_b6_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_b9_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_c_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_d_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_e_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_k_100g = table.Column<string>(type: "TEXT", nullable: true),
                    vitamin_pp_100g = table.Column<string>(type: "TEXT", nullable: true),
                    water_hardness_100g = table.Column<string>(type: "TEXT", nullable: true),
                    zinc_100g = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "RecipProductInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ProductInfocode = table.Column<string>(type: "TEXT", nullable: false),
                    RecipId = table.Column<string>(type: "TEXT", nullable: true),
                    MeasureUnit = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipProductInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipProductInfos_Products_ProductInfocode",
                        column: x => x.ProductInfocode,
                        principalTable: "Products",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipProductInfos_Recips_RecipId",
                        column: x => x.RecipId,
                        principalTable: "Recips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipProductInfos_ProductInfocode",
                table: "RecipProductInfos",
                column: "ProductInfocode");

            migrationBuilder.CreateIndex(
                name: "IX_RecipProductInfos_RecipId",
                table: "RecipProductInfos",
                column: "RecipId");
        }
    }
}
