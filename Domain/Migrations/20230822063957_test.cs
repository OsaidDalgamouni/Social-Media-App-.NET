using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.CreateSequence(
                name: "BOOK_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.CreateSequence(
                name: "BOOKS_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.CreateSequence(
                name: "BOOKS_SEQUENCE",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.CreateSequence(
                name: "ORDER_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.CreateSequence(
                name: "ORDERS_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.CreateTable(
                name: "BOOK",
                schema: "TRAINING_SCHEMA_OSAID",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(15)", precision: 15, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "VARCHAR2(1000)", unicode: false, maxLength: 1000, nullable: true),
                    AUTHOR = table.Column<string>(type: "VARCHAR2(1000)", unicode: false, maxLength: 1000, nullable: true),
                    NUMBEROFPAGE = table.Column<long>(type: "NUMBER(15)", precision: 15, nullable: true),
                    PUBLISHEDAT = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                schema: "TRAINING_SCHEMA_OSAID",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CITYNAME = table.Column<string>(type: "VARCHAR2(7)", unicode: false, maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                schema: "TRAINING_SCHEMA_OSAID",
                columns: table => new
                {
                    ORDERID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ORDERDATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    CUSTOMERNAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    TOTALAMOUNT = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ORDERID);
                });

            migrationBuilder.CreateTable(
                name: "ORDERITEM",
                schema: "TRAINING_SCHEMA_OSAID",
                columns: table => new
                {
                    ORDERITEMID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    ORDERID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    PRODUCTNAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    QUANTITY = table.Column<decimal>(type: "NUMBER", nullable: false),
                    UNITPRICE = table.Column<decimal>(type: "NUMBER", nullable: false),
                    TOTALPRICE = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERITEM", x => x.ORDERITEMID);
                    table.ForeignKey(
                        name: "FK_ORDER",
                        column: x => x.ORDERID,
                        principalSchema: "TRAINING_SCHEMA_OSAID",
                        principalTable: "ORDERS",
                        principalColumn: "ORDERID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERITEM_ORDERID",
                schema: "TRAINING_SCHEMA_OSAID",
                table: "ORDERITEM",
                column: "ORDERID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOK",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropTable(
                name: "CITY",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropTable(
                name: "ORDERITEM",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropTable(
                name: "ORDERS",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropSequence(
                name: "BOOK_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropSequence(
                name: "BOOKS_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropSequence(
                name: "BOOKS_SEQUENCE",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropSequence(
                name: "ORDER_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");

            migrationBuilder.DropSequence(
                name: "ORDERS_SEQ",
                schema: "TRAINING_SCHEMA_OSAID");
        }
    }
}
