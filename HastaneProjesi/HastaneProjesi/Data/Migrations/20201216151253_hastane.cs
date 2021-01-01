using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneProjesi.Data.Migrations
{
    public partial class hastane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KanGrubu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KanGrubuAd = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanGrubu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAd = table.Column<string>(nullable: false),
                    Sifre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unvanlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnvanAd = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poliniklik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolinikAd = table.Column<string>(nullable: false),
                    HastanelerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliniklik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poliniklik_Hastaneler_HastanelerId",
                        column: x => x.HastanelerId,
                        principalTable: "Hastaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: false),
                    Soyad = table.Column<string>(nullable: false),
                    DogumTarihi = table.Column<DateTime>(nullable: false),
                    MedeniHali = table.Column<int>(nullable: false),
                    DogumYeri = table.Column<string>(nullable: false),
                    Meslek = table.Column<string>(nullable: true),
                    KanGrubuId = table.Column<int>(nullable: true),
                    Cinsiyet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastalar_KanGrubu_KanGrubuId",
                        column: x => x.KanGrubuId,
                        principalTable: "KanGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: false),
                    Soyad = table.Column<string>(nullable: false),
                    DogumYeri = table.Column<string>(nullable: false),
                    Cinsiyet = table.Column<int>(nullable: false),
                    DogumTarihi = table.Column<DateTime>(nullable: false),
                    UnvanlarId = table.Column<int>(nullable: true),
                    PoliniklikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doktorlar_Poliniklik_PoliniklikId",
                        column: x => x.PoliniklikId,
                        principalTable: "Poliniklik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doktorlar_Unvanlar_UnvanlarId",
                        column: x => x.UnvanlarId,
                        principalTable: "Unvanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HastaKabul",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GelisTarihi = table.Column<DateTime>(nullable: false),
                    HastalarId = table.Column<int>(nullable: true),
                    DoktorlarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaKabul", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HastaKabul_Doktorlar_DoktorlarId",
                        column: x => x.DoktorlarId,
                        principalTable: "Doktorlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HastaKabul_Hastalar_HastalarId",
                        column: x => x.HastalarId,
                        principalTable: "Hastalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HastaSikayeti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaSikayet = table.Column<string>(nullable: false),
                    HastaKabulId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaSikayeti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HastaSikayeti_HastaKabul_HastaKabulId",
                        column: x => x.HastaKabulId,
                        principalTable: "HastaKabul",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HastaGecmisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GecirdigiHastaliklar = table.Column<string>(nullable: false),
                    GecirdigiAmeliyatlar = table.Column<string>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    HastaSikayetiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaGecmisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HastaGecmisi_HastaSikayeti_HastaSikayetiId",
                        column: x => x.HastaSikayetiId,
                        principalTable: "HastaSikayeti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tahliller",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TahlilAd = table.Column<string>(nullable: false),
                    TahlilSonucu = table.Column<string>(nullable: false),
                    HastaGecmisiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tahliller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tahliller_HastaGecmisi_HastaGecmisiId",
                        column: x => x.HastaGecmisiId,
                        principalTable: "HastaGecmisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlacAd = table.Column<string>(nullable: false),
                    TahlillerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recete_Tahliller_TahlillerId",
                        column: x => x.TahlillerId,
                        principalTable: "Tahliller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ilaclar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fiyat = table.Column<int>(nullable: false),
                    Adet = table.Column<int>(nullable: false),
                    ReceteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilaclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilaclar_Recete_ReceteId",
                        column: x => x.ReceteId,
                        principalTable: "Recete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Hastaneler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Devlet Hastanesi" },
                    { 2, "Özel Aktıp Hastanesi" },
                    { 3, "Özel Medikar Hastanesi" },
                    { 4, "Atatürk Hastanesi" },
                    { 5, "Araştırma Hastanesi" }
                });

            migrationBuilder.InsertData(
                table: "KanGrubu",
                columns: new[] { "Id", "KanGrubuAd" },
                values: new object[,]
                {
                    { 8, "AB Rh-" },
                    { 7, "AB Rh+" },
                    { 6, "B Rh+" },
                    { 5, "B Rh-" },
                    { 3, "A Rh+ " },
                    { 2, "O Rh+" },
                    { 1, "O Rh-" },
                    { 4, "A Rh-" }
                });

            migrationBuilder.InsertData(
                table: "Unvanlar",
                columns: new[] { "Id", "UnvanAd" },
                values: new object[,]
                {
                    { 6, " Profesör" },
                    { 1, "Pratisyen Doktor" },
                    { 2, "Uzman Doktor" },
                    { 3, "Operatör Doktor" },
                    { 4, "Yardımcı Doçent" },
                    { 5, " Doçent" },
                    { 7, "Ordinaryus " }
                });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumTarihi", "DogumYeri", "KanGrubuId", "MedeniHali", "Meslek", "Soyad" },
                values: new object[,]
                {
                    { 3, "Arda", 0, new DateTime(1984, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kayseri", 1, 1, "Öğretmen", "Öz" },
                    { 1, "Aysu", 1, new DateTime(1981, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bartın", 2, 1, "Öğretmen", "Şirin" },
                    { 5, "Cihan", 1, new DateTime(1991, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokat", 2, 1, "Öğretmen", "Yiğit" },
                    { 2, "Begüm", 1, new DateTime(1983, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yozgat", 3, 0, "Öğretmen", "Yavuz" },
                    { 4, "Mert", 0, new DateTime(1988, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çorum", 5, 1, "Öğretmen", "Şirin" }
                });

            migrationBuilder.InsertData(
                table: "Poliniklik",
                columns: new[] { "Id", "HastanelerId", "PolinikAd" },
                values: new object[,]
                {
                    { 1, 1, "Dâhiliye Polikliniği" },
                    { 2, 1, "Gastroenteroloji Polikliniği" },
                    { 3, 2, "KBB Polikliniği" },
                    { 4, 3, "Psikiyatri Polikliniği" },
                    { 5, 4, "Ortopedi Polikliniği" }
                });

            migrationBuilder.InsertData(
                table: "Doktorlar",
                columns: new[] { "Id", "Ad", "Cinsiyet", "DogumTarihi", "DogumYeri", "PoliniklikId", "Soyad", "UnvanlarId" },
                values: new object[,]
                {
                    { 1, "Meryem", 1, new DateTime(1996, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", 1, "Çetiner", 1 },
                    { 3, "Şule", 1, new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burdur", 2, "Piyaz", 5 },
                    { 4, "Yavuz", 0, new DateTime(1986, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop", 2, "Selim", 4 },
                    { 2, "Murat", 0, new DateTime(1995, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ankara", 3, "Gül", 4 },
                    { 5, "Cenk", 0, new DateTime(1989, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsun", 4, "İnce", 5 }
                });

            migrationBuilder.InsertData(
                table: "HastaKabul",
                columns: new[] { "Id", "DoktorlarId", "GelisTarihi", "HastalarId" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 1, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 1, 3, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 4, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 2, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "HastaSikayeti",
                columns: new[] { "Id", "HastaKabulId", "HastaSikayet" },
                values: new object[,]
                {
                    { 2, 2, "Alkalen Fosfataz Hastalığı" },
                    { 5, 5, "Prostat-Spesifik Antijen" },
                    { 1, 1, "Hemogram Yetmezliği" },
                    { 3, 3, "Kreatinin Klerensi" },
                    { 4, 4, "Asit Fosfataz" }
                });

            migrationBuilder.InsertData(
                table: "HastaGecmisi",
                columns: new[] { "Id", "GecirdigiAmeliyatlar", "GecirdigiHastaliklar", "HastaSikayetiId", "Tarih" },
                values: new object[,]
                {
                    { 2, "Yok", "Yok", 2, new DateTime(2020, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Yok", "Yok", 5, new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Yok", "Yok", 1, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Yok", "Yok", 3, new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Yok", "Yok", 4, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tahliller",
                columns: new[] { "Id", "HastaGecmisiId", "TahlilAd", "TahlilSonucu" },
                values: new object[,]
                {
                    { 2, 2, "Üre-Bun- Kreatinin", "Böbreklerin çalışmasını gösterir. Böbrek yetersizliğinde yüksek bulunur. Ürik asit: Protein yıkımının son ürünüdür.Gut hastalığında ve böbrek yetersizliğinde yüksek çıkar.Aşırı proteinle beslenenlerde ve doku yıkımı olan durumlarda(kan hastalıklarında) da yüksek çıkabilir." },
                    { 5, 5, "GGT-ALP", "Karaciğer ve safra yolları hastalıklarında yüksek çıkar. ALP aynı zamanda kemik hastalıklarını da gösterebilir. Çocuklarda ve gebelerde fizyolojik olarak yüksek bulunabilir." },
                    { 1, 1, "Sedimantasyon", "Kanın çökme hızıdır. İltihabi durumlar, romatizmal hastalıklar, mikrobik durumlar, Kan hastalıklarında, bazı kanserlerde yüksek bulunur. Aşırı kan yapımında (polisitemi) düşük çıkar" },
                    { 3, 3, "AST-ALT", "Karaciğer fonksiyonlarını gösterir. AST ayrıca kalp, kas hastalıklarında ve alkol alanlarda da yüksek bulunabilir" },
                    { 4, 4, "Glukoz", "Kan şekerini gösterir" }
                });

            migrationBuilder.InsertData(
                table: "Recete",
                columns: new[] { "Id", "IlacAd", "TahlillerId" },
                values: new object[,]
                {
                    { 2, "ALOMIDE %0.1 Steril Göz Damlası", 2 },
                    { 5, "BETOPTIC %0.5 Steril Oftalmik Çözelti", 5 },
                    { 1, "AFINITOR 10 mg tablet", 1 },
                    { 3, "Arzerra 100 mg IV infüzyonluk çözelti konsantresi içeren flakon", 3 },
                    { 4, "AZARGA", 4 }
                });

            migrationBuilder.InsertData(
                table: "Ilaclar",
                columns: new[] { "Id", "Adet", "Fiyat", "ReceteId" },
                values: new object[,]
                {
                    { 2, 3, 20, 2 },
                    { 5, 1, 165, 5 },
                    { 1, 2, 10, 1 },
                    { 3, 1, 30, 3 },
                    { 4, 2, 50, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_PoliniklikId",
                table: "Doktorlar",
                column: "PoliniklikId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_UnvanlarId",
                table: "Doktorlar",
                column: "UnvanlarId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaGecmisi_HastaSikayetiId",
                table: "HastaGecmisi",
                column: "HastaSikayetiId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaKabul_DoktorlarId",
                table: "HastaKabul",
                column: "DoktorlarId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaKabul_HastalarId",
                table: "HastaKabul",
                column: "HastalarId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_KanGrubuId",
                table: "Hastalar",
                column: "KanGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaSikayeti_HastaKabulId",
                table: "HastaSikayeti",
                column: "HastaKabulId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilaclar_ReceteId",
                table: "Ilaclar",
                column: "ReceteId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliniklik_HastanelerId",
                table: "Poliniklik",
                column: "HastanelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recete_TahlillerId",
                table: "Recete",
                column: "TahlillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tahliller_HastaGecmisiId",
                table: "Tahliller",
                column: "HastaGecmisiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ilaclar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Recete");

            migrationBuilder.DropTable(
                name: "Tahliller");

            migrationBuilder.DropTable(
                name: "HastaGecmisi");

            migrationBuilder.DropTable(
                name: "HastaSikayeti");

            migrationBuilder.DropTable(
                name: "HastaKabul");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Poliniklik");

            migrationBuilder.DropTable(
                name: "Unvanlar");

            migrationBuilder.DropTable(
                name: "KanGrubu");

            migrationBuilder.DropTable(
                name: "Hastaneler");
        }
    }
}
