using System;
using System.Collections.Generic;
using System.Text;
using HastaneProjesi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneProjesi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doktorlar> Doktorlar { get; set; }
        public DbSet<HastaGecmisi> HastaGecmisi { get; set; }
        public DbSet<HastaKabul> HastaKabul { get; set; }
        public DbSet<Hastalar> Hastalar { get; set; }
        public DbSet<Hastaneler> Hastaneler { get; set; }
        public DbSet<Tahliller> Tahliller { get; set; }
        public DbSet<HastaSikayeti> HastaSikayeti { get; set; }
        public DbSet<Ilaclar> Ilaclar { get; set; }
        public DbSet<KanGrubu> KanGrubu { get; set; }
        public DbSet<Poliniklik> Poliniklik { get; set; }
        public DbSet<Recete> Recete { get; set; }
        public DbSet<Unvanlar> Unvanlar { get; set; }
   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hastaneler>().HasData(
               new Hastaneler
               {
                   Id = 1,
                   Ad = "Devlet Hastanesi",

               },
                new Hastaneler
                {
                    Id = 2,
                    Ad = "Özel Aktıp Hastanesi",

                },
                 new Hastaneler
                 {
                     Id = 3,
                     Ad = "Özel Medikar Hastanesi",

                 },
                  new Hastaneler
                  {
                      Id = 4,
                      Ad = "Atatürk Hastanesi",

                  },
                   new Hastaneler
                   {
                       Id = 5,
                       Ad = "Araştırma Hastanesi",

                   }
               );

            builder.Entity<Poliniklik>().HasData(
         new Poliniklik
         {
             Id = 1,
             PolinikAd = "Dâhiliye Polikliniği",
             HastanelerId = 1
         },
         new Poliniklik
         {
             Id = 2,
             PolinikAd = "Gastroenteroloji Polikliniği",
             HastanelerId = 1
         },
         new Poliniklik
         {
             Id = 3,
             PolinikAd = "KBB Polikliniği",
             HastanelerId = 2
         },
         new Poliniklik
         {
             Id = 4,
             PolinikAd = "Psikiyatri Polikliniği",
             HastanelerId = 3
         },
         new Poliniklik
         {
             Id = 5,
             PolinikAd = "Ortopedi Polikliniği",
             HastanelerId = 4
         }
         );

            builder.Entity<Unvanlar>().HasData(
            new Unvanlar
            {
                Id = 1,
                UnvanAd = "Pratisyen Doktor",



            },
            new Unvanlar
            {
                Id = 2,
                UnvanAd = "Uzman Doktor"
            },
            new Unvanlar
            {
                Id = 3,
                UnvanAd = "Operatör Doktor"
            },
            new Unvanlar
            {
                Id = 4,
                UnvanAd = "Yardımcı Doçent"
            },
            new Unvanlar
            {
                Id = 5,
                UnvanAd = " Doçent"
            },
            new Unvanlar
            {
                Id = 6,
                UnvanAd = " Profesör"
            },
            new Unvanlar
            {
                Id = 7,
                UnvanAd = "Ordinaryus "
            }
          );

            builder.Entity<Doktorlar>().HasData(
         new Doktorlar
         {
             Id = 1,
             Ad = "Meryem",
             Soyad = "Çetiner",
             DogumYeri = "Istanbul",
             DogumTarihi = DateTime.Parse("02-02-1996"),
             Cinsiyet = Cinsiyet.Kız,
             UnvanlarId = 1,
             PoliniklikId = 1

         },
         new Doktorlar
         {
             Id = 2,
             Ad = "Murat",
             Soyad = "Gül",
             DogumYeri = "Ankara",
             DogumTarihi = DateTime.Parse("05-11-1995"),
             Cinsiyet = Cinsiyet.Erkek,
             UnvanlarId = 4,
             PoliniklikId = 3

         },
         new Doktorlar
         {
             Id = 3,
             Ad = "Şule",
             Soyad = "Piyaz",
             DogumYeri = "Burdur",
             DogumTarihi = DateTime.Parse("12-03-1990"),
             Cinsiyet = Cinsiyet.Kız,
             UnvanlarId = 5,
             PoliniklikId = 2

         },
         new Doktorlar
         {
             Id = 4,
             Ad = "Yavuz",
             Soyad = "Selim",
             DogumYeri = "Sinop",
             DogumTarihi = DateTime.Parse("12-09-1986"),
             Cinsiyet = Cinsiyet.Erkek,
             UnvanlarId = 4,
             PoliniklikId = 2

         },
         new Doktorlar
         {
             Id = 5,
             Ad = "Cenk",
             Soyad = "İnce",
             DogumYeri = "Samsun",
             DogumTarihi = DateTime.Parse("04-03-1989"),
             Cinsiyet = Cinsiyet.Erkek,
             UnvanlarId = 5,
             PoliniklikId = 4

         }

         );

            builder.Entity<KanGrubu>().HasData(
       new KanGrubu
       {
           Id = 1,
           KanGrubuAd = "O Rh-"
       },
        new KanGrubu
        {
            Id = 2,
            KanGrubuAd = "O Rh+"
        },
         new KanGrubu
         {
             Id = 3,
             KanGrubuAd = "A Rh+ "
         },
          new KanGrubu
          {
              Id = 4,
              KanGrubuAd = "A Rh-"
          },
           new KanGrubu
           {
               Id = 5,
               KanGrubuAd = "B Rh-"
           },
            new KanGrubu
            {
                Id = 6,
                KanGrubuAd = "B Rh+"
            },
             new KanGrubu
             {
                 Id = 7,
                 KanGrubuAd = "AB Rh+"
             },
             new KanGrubu
             {
                 Id = 8,
                 KanGrubuAd = "AB Rh-"
             }
       );


            builder.Entity<Hastalar>().HasData(
          new Hastalar
          {
              Id = 1,
              Ad = "Aysu",
              Soyad = "Şirin",
              DogumTarihi = DateTime.Parse("06-09-1981"),
              MedeniHali = MedeniHali.Bekar,
              Meslek = "Öğretmen",
              Cinsiyet = Cinsiyet.Kız,
              KanGrubuId = 2,
              DogumYeri = "Bartın"
          },
           new Hastalar
           {
               Id = 2,
               Ad = "Begüm",
               Soyad = "Yavuz",
               DogumTarihi = DateTime.Parse("01-02-1983"),
               MedeniHali = MedeniHali.Evli,
               Meslek = "Öğretmen",
               Cinsiyet = Cinsiyet.Kız,
               KanGrubuId = 3,
               DogumYeri = "Yozgat"
           },
            new Hastalar
            {
                Id = 3,
                Ad = "Arda",
                Soyad = "Öz",
                DogumTarihi = DateTime.Parse("12-10-1984"),
                MedeniHali = MedeniHali.Bekar,
                Meslek = "Öğretmen",
                Cinsiyet = Cinsiyet.Erkek,
                KanGrubuId = 1,
                DogumYeri = "Kayseri"
            },
             new Hastalar
             {
                 Id = 4,
                 Ad = "Mert",
                 Soyad = "Şirin",
                 DogumTarihi = DateTime.Parse("06-09-1988"),
                 MedeniHali = MedeniHali.Bekar,
                 Meslek = "Öğretmen",
                 Cinsiyet = Cinsiyet.Erkek,
                 KanGrubuId = 5,
                 DogumYeri = "Çorum"
             },
              new Hastalar
              {
                  Id = 5,
                  Ad = "Cihan",
                  Soyad = "Yiğit",
                  DogumTarihi = DateTime.Parse("09-01-1991"),
                  MedeniHali = MedeniHali.Bekar,
                  Meslek = "Öğretmen",
                  Cinsiyet = Cinsiyet.Kız,
                  KanGrubuId = 2,
                  DogumYeri = "Tokat"
              }

          );
            builder.Entity<HastaKabul>().HasData(
         new HastaKabul
         {
             Id = 1,
             GelisTarihi = DateTime.Parse("10-09-2020"),
             HastalarId = 1,
             DoktorlarId = 3


         },
          new HastaKabul
          {
              Id = 2,
              GelisTarihi = DateTime.Parse("10-08-2020"),
              HastalarId = 2,
              DoktorlarId = 1


          },
           new HastaKabul
           {
               Id = 3,
               GelisTarihi = DateTime.Parse("10-07-2020"),
               HastalarId = 3,
               DoktorlarId = 4


           },
            new HastaKabul
            {
                Id = 4,
                GelisTarihi = DateTime.Parse("10-06-2020"),
                HastalarId = 4,
                DoktorlarId = 2


            },
             new HastaKabul
             {
                 Id = 5,
                 GelisTarihi = DateTime.Parse("10-05-2020"),
                 HastalarId = 5,
                 DoktorlarId = 1


             }
         );

            builder.Entity<HastaSikayeti>().HasData(
          new HastaSikayeti
          {
              Id = 1,
              HastaSikayet = "Hemogram Yetmezliği",
              HastaKabulId = 1
          },
           new HastaSikayeti
           {
               Id = 2,
               HastaSikayet = "Alkalen Fosfataz Hastalığı",
               HastaKabulId = 2
           },
            new HastaSikayeti
            {
                Id = 3,
                HastaSikayet = "Kreatinin Klerensi",
                HastaKabulId = 3
            },
             new HastaSikayeti
             {
                 Id = 4,
                 HastaSikayet = "Asit Fosfataz",
                 HastaKabulId = 4
             },
              new HastaSikayeti
              {
                  Id = 5,
                  HastaSikayet = "Prostat-Spesifik Antijen",
                  HastaKabulId = 5
              }
          );

            builder.Entity<HastaGecmisi>().HasData(
                     new HastaGecmisi
                     {
                         Id = 1,
                         GecirdigiHastaliklar = "Yok",
                         GecirdigiAmeliyatlar="Yok",
                         Tarih= DateTime.Parse("10-05-2020"),
                         HastaSikayetiId=1
                     },
                     new HastaGecmisi
                     {
                         Id = 2,
                         GecirdigiHastaliklar = "Yok",
                         GecirdigiAmeliyatlar = "Yok",
                         Tarih = DateTime.Parse("11-01-2020"),
                         HastaSikayetiId = 2
                     },
                     new HastaGecmisi
                     {
                         Id = 3,
                         GecirdigiHastaliklar = "Yok",
                         GecirdigiAmeliyatlar = "Yok",
                         Tarih = DateTime.Parse("08-03-2020"),
                         HastaSikayetiId = 3
                     },
                     new HastaGecmisi
                     {
                         Id = 4,
                         GecirdigiHastaliklar = "Yok",
                         GecirdigiAmeliyatlar = "Yok",
                         Tarih = DateTime.Parse("06-04-2020"),
                         HastaSikayetiId = 4
                     },
                     new HastaGecmisi
                     {
                         Id = 5,
                         GecirdigiHastaliklar = "Yok",
                         GecirdigiAmeliyatlar = "Yok",
                         Tarih = DateTime.Parse("04-03-2020"),
                         HastaSikayetiId = 5
                     }
                     );

            builder.Entity<Tahliller>().HasData(
         new Tahliller
         {
             Id = 1,
             TahlilAd = "Sedimantasyon",
             TahlilSonucu = "Kanın çökme hızıdır. İltihabi durumlar, romatizmal hastalıklar, mikrobik durumlar, Kan hastalıklarında, bazı kanserlerde yüksek bulunur. Aşırı kan yapımında (polisitemi) düşük çıkar",
             HastaGecmisiId = 1

         },
          new Tahliller
          {
              Id = 2,
              TahlilAd = "Üre-Bun- Kreatinin",
              TahlilSonucu = "Böbreklerin çalışmasını gösterir. Böbrek yetersizliğinde yüksek bulunur. Ürik asit: Protein yıkımının son ürünüdür.Gut hastalığında ve böbrek yetersizliğinde yüksek çıkar.Aşırı proteinle beslenenlerde ve doku yıkımı olan durumlarda(kan hastalıklarında) da yüksek çıkabilir.",
              HastaGecmisiId = 2

          },
          new Tahliller
          {
              Id = 3,
              TahlilAd = "AST-ALT",
              TahlilSonucu = "Karaciğer fonksiyonlarını gösterir. AST ayrıca kalp, kas hastalıklarında ve alkol alanlarda da yüksek bulunabilir",
              HastaGecmisiId = 3

          },
          new Tahliller
          {
              Id = 4,
              TahlilAd = "Glukoz",
              TahlilSonucu = "Kan şekerini gösterir",
              HastaGecmisiId = 4

          },
          new Tahliller
          {
              Id = 5,
              TahlilAd = "GGT-ALP",
              TahlilSonucu = "Karaciğer ve safra yolları hastalıklarında yüksek çıkar. ALP aynı zamanda kemik hastalıklarını da gösterebilir. Çocuklarda ve gebelerde fizyolojik olarak yüksek bulunabilir.",
              HastaGecmisiId = 5

          }
         );

            builder.Entity<Recete>().HasData(
         new Recete
         {
             Id = 1,
             IlacAd = "AFINITOR 10 mg tablet",
             TahlillerId = 1
         },
          new Recete
          {
              Id = 2,
              IlacAd = "ALOMIDE %0.1 Steril Göz Damlası",
              TahlillerId = 2
          },
           new Recete
           {
               Id = 3,
               IlacAd = "Arzerra 100 mg IV infüzyonluk çözelti konsantresi içeren flakon",
               TahlillerId = 3
           },
            new Recete
            {
                Id = 4,
                IlacAd = "AZARGA",
                TahlillerId = 4
            },
             new Recete
             {
                 Id = 5,
                 IlacAd = "BETOPTIC %0.5 Steril Oftalmik Çözelti",
                 TahlillerId = 5
             }
             
         );

            builder.Entity<Ilaclar>().HasData(
         new Ilaclar
         {
             Id = 1,
             Adet=2,
             Fiyat = 10,
             ReceteId = 1
         },
         new Ilaclar
         {
             Id = 2,
             Adet = 3,
             Fiyat = 20,
             ReceteId = 2
         },
         new Ilaclar
         {
             Id = 3,
             Adet = 1,
             Fiyat = 30,
             ReceteId = 3
         },
         new Ilaclar
         {
             Id = 4,
             Adet = 2,
             Fiyat = 50,
             ReceteId = 4
         },
         new Ilaclar
         {
             Id = 5,
             Adet = 1,
             Fiyat = 165,
             ReceteId = 5
         }
         );



            builder.Entity<AppUser>().HasData(
        new AppUser
        {
            Id = "c342b369-ccd2-4648-b187-10c5c655bbb5",
            UserName = "b191210304@sakarya.edu.tr",
            NormalizedUserName = "B191210304@SAKARYA.EDU.TR",
            EmailConfirmed = false,
            PasswordHash= "AQAAAAEAACcQAAAAEEhgfwI70dzvoYp2RTjqqfw60wbI6kbGq9rQ/uiZPc6RRFwz9uUQmrBHcKjeuwpz4A==",
            SecurityStamp="RNMOTMWYZL6PRE362MLDKMO2QTCRNLIB",
            ConcurrencyStamp= "2b47a270-2410-42b1-ad1b-b564966cd6b0",
            PhoneNumberConfirmed=false,
            TwoFactorEnabled=false,
            LockoutEnabled=true,
            AccessFailedCount=0,
            Name="Muhammet",
            SurName="Sağlam"

        },
        new AppUser
        {
            Id = "36035f22-9c94-42bd-8282-8e2b019b2fd1",
            UserName = "b191210307@sakarya.edu.tr",
            NormalizedUserName = "B191210307@SAKARYA.EDU.TR",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAEAACcQAAAAEEHoQ0ViyBmp3yPvMsGBVSrLUiubppv3DnUDJHHp7RnyYwULnf9W5dEiACxRfQVcFA==",
            SecurityStamp = "ST4AAWGZ5UA2RSQGVBI6BHW5JO7JZQYW",
            ConcurrencyStamp = "d8e84a25-0ff2-425c-8cc0-c6ed76b60d21",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            Name = "Numan",
            SurName = "Güngör"

        }
        );

            builder.Entity<AppRole>().HasData(
              new AppRole
              {
                  Id = "c25676d8-829e-41cb-8a7f-af3d177c8fca",
                  Name = "User",
                  NormalizedName= "USER",
                  ConcurrencyStamp = "5282ce18-8d92-4464-864c-b0687afbe92e"
              },
               new AppRole
               {
                   Id = "e17291ae-2332-4977-a6bf-e5d6b3bcf356",
                   Name = "Admin",
                   NormalizedName= "ADMIN",
                   ConcurrencyStamp = "b815f8ca-442b-4b81-8f8e-73d5ba2a2271"
               }
              );

            builder.Entity<UserRol>().HasData(
             new UserRol
             {
                 UserId = "c342b369-ccd2-4648-b187-10c5c655bbb5",
                 RoleId = "e17291ae-2332-4977-a6bf-e5d6b3bcf356"
             },
              new UserRol
              {
                  UserId = "36035f22-9c94-42bd-8282-8e2b019b2fd1",
                  RoleId = "e17291ae-2332-4977-a6bf-e5d6b3bcf356"
              }
             );


            base.OnModelCreating(builder);
        }
    }
}
