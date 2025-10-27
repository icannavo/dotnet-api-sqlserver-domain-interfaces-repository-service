using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIWebExemplo.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToShortId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adicionar uma nova coluna string temporária
            migrationBuilder.AddColumn<string>(
                name: "NewId",
                table: "Produtos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            // Popular a nova coluna com IDs de 8 caracteres baseados no Guid atual
            migrationBuilder.Sql(@"
                UPDATE Produtos 
                SET NewId = SUBSTRING(REPLACE(REPLACE(REPLACE(REPLACE(CAST(Id AS VARCHAR(36)), '-', ''), '{', ''), '}', ''), ' ', ''), 1, 8)
            ");

            // Remover a chave primária atual
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            // Remover a coluna Guid antiga
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Produtos");

            // Renomear a nova coluna para Id
            migrationBuilder.RenameColumn(
                name: "NewId",
                table: "Produtos",
                newName: "Id");

            // Adicionar a nova chave primária
            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover a chave primária atual
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            // Adicionar uma nova coluna Guid
            migrationBuilder.AddColumn<Guid>(
                name: "OldId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid());

            // Popular a nova coluna com GUIDs baseados no ID string atual
            migrationBuilder.Sql(@"
                UPDATE Produtos 
                SET OldId = NEWID()
            ");

            // Renomear a coluna string para TempId
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produtos",
                newName: "TempId");

            // Renomear a coluna Guid para Id
            migrationBuilder.RenameColumn(
                name: "OldId",
                table: "Produtos",
                newName: "Id");

            // Adicionar a chave primária
            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            // Remover a coluna string temporária
            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Produtos");
        }
    }
}
