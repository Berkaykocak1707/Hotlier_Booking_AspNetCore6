using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotlier_Booking_AspNetCore6.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactSubject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoomPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomBed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomBath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomAvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRoomActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Subscribe",
                columns: table => new
                {
                    SubscribeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscribeEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribe", x => x.SubscribeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BookingEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adult = table.Column<int>(type: "int", nullable: false),
                    Child = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    BookingMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDone = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dce5aee8-f1b7-45f3-b05c-ae98eed840b6", "c4e5fd19-2389-48b3-b0bb-325cc7d45d0c", "Editor", "EDITOR" },
                    { "e4ef08a3-3afc-4b35-9d56-a8ba771b94b7", "476251da-3314-40e6-8c0f-a096c56907dc", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "ContactID", "ContactEmail", "ContactMessage", "ContactName", "ContactSubject" },
                values: new object[,]
                {
                    { 1, "Sevdigimkiz@hotmail.com", "Haberi köye düştü", "Ali Cabbar", "Askere gidiyorum" },
                    { 2, "Sevdigimkiza@hotmail.com", "Haberi köye düştü la", "Ali Cabbara", "Askere gidiyoruma" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "IsRoomActive", "RoomAvailableDate", "RoomBath", "RoomBed", "RoomDetail", "RoomName", "RoomPhotoUrl", "RoomPrice" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2444), "1 Banyo", "Çift Kişilik Yatak", "Deniz Manzaralı", "Standart Oda", "/images/room-1.jpg", 100.00m },
                    { 2, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2447), "1 Banyo", "İki Tek Kişilik Yatak", "Bahçe Manzaralı", "Deluxe Oda", "/images/room-2.jpg", 150.00m },
                    { 3, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2448), "2 Banyo", "Bir Çift ve İki Tek Kişilik Yatak", "Orman Manzaralı", "Aile Odası", "/images/room-3.jpg", 200.00m },
                    { 4, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2449), "1 Banyo", "Çift Kişilik Yatak", "Havuz Manzaralı", "Süit Oda", "/images/room-1.jpg", 180.00m },
                    { 5, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2450), "2 Banyo", "İki Çift Kişilik Yatak", "Deniz Manzaralı", "Lüks Villa", "/images/room-2.jpg", 300.00m },
                    { 6, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2451), "1 Banyo", "Tek Kişilik Yatak", "Şehir Manzaralı", "Tek Kişilik Oda", "/images/room-3.jpg", 80.00m },
                    { 7, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2452), "1 Banyo", "Çift Kişilik Yatak", "Havuz ve Deniz Manzaralı", "Balayı Süiti", "/images/room-1.jpg", 250.00m },
                    { 8, true, new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(2453), "1 Banyo", "Çift Kişilik Yatak", "Dağ Manzaralı", "Jakuzili Oda", "/images/room-2.jpg", 170.00m }
                });

            migrationBuilder.InsertData(
                table: "Subscribe",
                columns: new[] { "SubscribeID", "SubscribeEmail" },
                values: new object[,]
                {
                    { 1, "kocak@gmail.com" },
                    { 2, "kocak2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "Adult", "BookingEmail", "BookingMessage", "BookingName", "CheckIn", "CheckOut", "Child", "IsDone", "RoomID" },
                values: new object[] { 1, 1, "f@gmail.com", "falanca", " dalanca", new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(1446), new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(1453), 1, false, 1 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "Adult", "BookingEmail", "BookingMessage", "BookingName", "CheckIn", "CheckOut", "Child", "IsDone", "RoomID" },
                values: new object[] { 2, 1, "f@gmail.com", "falanca", " dalanca", new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(1455), new DateTime(2023, 12, 5, 0, 17, 10, 433, DateTimeKind.Local).AddTicks(1456), 1, false, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomID",
                table: "Bookings",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Subscribe");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
