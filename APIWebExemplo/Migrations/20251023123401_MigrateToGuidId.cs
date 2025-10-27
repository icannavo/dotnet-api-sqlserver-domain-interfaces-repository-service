using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIWebExemplo.Migrations
{
    /// <inheritdoc />
    public partial class MigrateToGuidId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Primeiro, adicionar uma nova coluna Guid
            migrationBuilder.AddColumn<Guid>(
                name: "NewId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid());

            // Popular a nova coluna com valores Guid únicos baseados no Id atual
            migrationBuilder.Sql(@"
                UPDATE Produtos 
                SET NewId = NEWID()
            ");

            // Remover a chave primária atual
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            // Remover a coluna Id antiga
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

            // Adicionar uma nova coluna int
            migrationBuilder.AddColumn<int>(
                name: "OldId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Popular a nova coluna com valores sequenciais
            migrationBuilder.Sql(@"
                DECLARE @counter INT = 1
                DECLARE @id UNIQUEIDENTIFIER
                DECLARE cursor_id CURSOR FOR 
                    SELECT Id FROM Produtos ORDER BY Id
                OPEN cursor_id
                FETCH NEXT FROM cursor_id INTO @id
                WHILE @@FETCH_STATUS = 0
                BEGIN
                    UPDATE Produtos SET OldId = @counter WHERE Id = @id
                    SET @counter = @counter + 1
                    FETCH NEXT FROM cursor_id INTO @id
                END
                CLOSE cursor_id
                DEALLOCATE cursor_id
            ");

            // Renomear a coluna Guid para TempId
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produtos",
                newName: "TempId");

            // Renomear a coluna int para Id
            migrationBuilder.RenameColumn(
                name: "OldId",
                table: "Produtos",
                newName: "Id");

            // Adicionar a chave primária
            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            // Remover a coluna Guid temporária
            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Produtos");
        }
    }
}
