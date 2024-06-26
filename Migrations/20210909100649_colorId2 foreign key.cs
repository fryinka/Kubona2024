using Microsoft.EntityFrameworkCore.Migrations;

namespace Kubona.Migrations
{
    public partial class colorId2foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TF_ItemsGroup_brandId",
                table: "TF_ItemsGroup",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_TF_ItemsGroup_colorId",
                table: "TF_ItemsGroup",
                column: "colorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TF_ItemsGroup_BW_Brands_brandId",
                table: "TF_ItemsGroup",
                column: "brandId",
                principalTable: "BW_Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TF_ItemsGroup_BW_Colors_colorId",
                table: "TF_ItemsGroup",
                column: "colorId",
                principalTable: "BW_Colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TF_ItemsGroup_BW_Brands_brandId",
                table: "TF_ItemsGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_TF_ItemsGroup_BW_Colors_colorId",
                table: "TF_ItemsGroup");

            migrationBuilder.DropIndex(
                name: "IX_TF_ItemsGroup_brandId",
                table: "TF_ItemsGroup");

            migrationBuilder.DropIndex(
                name: "IX_TF_ItemsGroup_colorId",
                table: "TF_ItemsGroup");
        }
    }
}
