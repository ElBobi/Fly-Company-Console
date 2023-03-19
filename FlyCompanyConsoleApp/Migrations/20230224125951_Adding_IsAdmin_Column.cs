using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyCompanyConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsAdminColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    gender = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__3213E83F7FC4A9EC", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    countoffirstclassseats = table.Column<int>(name: "count_of_first_class_seats", type: "int", nullable: false),
                    countofsecondclassseats = table.Column<int>(name: "count_of_second_class_seats", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__planes__3213E83F6B6BAC36", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    gender = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    registerdate = table.Column<DateTime>(name: "register_date", type: "date", nullable: true),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: true),
                    isadmin = table.Column<bool>(name: "is_admin", type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F6B02A6CB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fromdestination = table.Column<string>(name: "from_destination", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    todestination = table.Column<string>(name: "to_destination", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    takeofftime = table.Column<DateTime>(name: "take_off_time", type: "date", nullable: false),
                    landtime = table.Column<DateTime>(name: "land_time", type: "date", nullable: false),
                    planeid = table.Column<int>(name: "plane_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__flights__3213E83F455E39EF", x => x.id);
                    table.ForeignKey(
                        name: "FK__flights__plane_i__412EB0B6",
                        column: x => x.planeid,
                        principalTable: "planes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "seats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    planeid = table.Column<int>(name: "plane_id", type: "int", nullable: false),
                    @class = table.Column<byte>(name: "class", type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__seats__3213E83F4B8C7C8E", x => x.id);
                    table.ForeignKey(
                        name: "FK__seats__plane_id__440B1D61",
                        column: x => x.planeid,
                        principalTable: "planes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "canceled_flights",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightid = table.Column<int>(name: "flight_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__canceled__3213E83F9434E783", x => x.id);
                    table.ForeignKey(
                        name: "FK__canceled___fligh__4F7CD00D",
                        column: x => x.flightid,
                        principalTable: "flights",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "flights_crew",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightid = table.Column<int>(name: "flight_id", type: "int", nullable: false),
                    employeeid = table.Column<int>(name: "employee_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__flights___3213E83FF9F04661", x => x.id);
                    table.ForeignKey(
                        name: "FK__flights_c__emplo__4D94879B",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__flights_c__fligh__4CA06362",
                        column: x => x.flightid,
                        principalTable: "flights",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "flights_travelers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightid = table.Column<int>(name: "flight_id", type: "int", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__flights___3213E83F2A10C4EA", x => x.id);
                    table.ForeignKey(
                        name: "FK__flights_t__fligh__49C3F6B7",
                        column: x => x.flightid,
                        principalTable: "flights",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__flights_t__user___4AB81AF0",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_canceled_flights_flight_id",
                table: "canceled_flights",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_plane_id",
                table: "flights",
                column: "plane_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_crew_employee_id",
                table: "flights_crew",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_crew_flight_id",
                table: "flights_crew",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_travelers_flight_id",
                table: "flights_travelers",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_travelers_user_id",
                table: "flights_travelers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_seats_plane_id",
                table: "seats",
                column: "plane_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A1936A6B755A72C2",
                table: "Users",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E61643137215D",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__F3DBC5728F2F953F",
                table: "Users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "canceled_flights");

            migrationBuilder.DropTable(
                name: "flights_crew");

            migrationBuilder.DropTable(
                name: "flights_travelers");

            migrationBuilder.DropTable(
                name: "seats");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "planes");
        }
    }
}
