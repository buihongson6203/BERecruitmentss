using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BERecruitmentss.Migrations
{
    /// <inheritdoc />
    public partial class update_table_candidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentApplicant_Vacancies_RecruitmentID",
                table: "RecruitmentApplicant");

            migrationBuilder.RenameColumn(
                name: "RecruitmentID",
                table: "RecruitmentApplicant",
                newName: "VacanciesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecruitmentApplicant_RecruitmentID",
                table: "RecruitmentApplicant",
                newName: "IX_RecruitmentApplicant_VacanciesId");

            migrationBuilder.AddColumn<string>(
                name: "Cv",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentApplicant_Vacancies_VacanciesId",
                table: "RecruitmentApplicant",
                column: "VacanciesId",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruitmentApplicant_Vacancies_VacanciesId",
                table: "RecruitmentApplicant");

            migrationBuilder.DropColumn(
                name: "Cv",
                table: "Candidate");

            migrationBuilder.RenameColumn(
                name: "VacanciesId",
                table: "RecruitmentApplicant",
                newName: "RecruitmentID");

            migrationBuilder.RenameIndex(
                name: "IX_RecruitmentApplicant_VacanciesId",
                table: "RecruitmentApplicant",
                newName: "IX_RecruitmentApplicant_RecruitmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruitmentApplicant_Vacancies_RecruitmentID",
                table: "RecruitmentApplicant",
                column: "RecruitmentID",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }
    }
}
