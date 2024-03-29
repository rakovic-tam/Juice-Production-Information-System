USE [master]
GO
/****** Object:  Database [ISBahus]    Script Date: 21-Oct-19 9:45:28 PM ******/
CREATE DATABASE [ISBahus] ON  PRIMARY 
( NAME = N'ISBahus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\ISBahus.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ISBahus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\ISBahus_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ISBahus] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ISBahus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ISBahus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ISBahus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ISBahus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ISBahus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ISBahus] SET ARITHABORT OFF 
GO
ALTER DATABASE [ISBahus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ISBahus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ISBahus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ISBahus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ISBahus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ISBahus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ISBahus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ISBahus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ISBahus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ISBahus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ISBahus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ISBahus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ISBahus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ISBahus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ISBahus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ISBahus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ISBahus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ISBahus] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ISBahus] SET  MULTI_USER 
GO
ALTER DATABASE [ISBahus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ISBahus] SET DB_CHAINING OFF 
GO
USE [ISBahus]
GO
/****** Object:  Table [dbo].[IzvestajOStanjuRepromaterijala]    Script Date: 21-Oct-19 9:45:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IzvestajOStanjuRepromaterijala](
	[SifraIzvestaja] [int] NOT NULL,
	[Datum] [date] NULL,
	[SifraZahteva] [int] NULL,
	[Prima] [int] NULL,
	[Izdaje] [int] NULL,
 CONSTRAINT [PK_IzvestajOStanjuRepromaterijala] PRIMARY KEY CLUSTERED 
(
	[SifraIzvestaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NalogZaProizvodnju]    Script Date: 21-Oct-19 9:45:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NalogZaProizvodnju](
	[SifraNaloga] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [date] NULL,
	[Prima] [int] NULL,
	[Izdaje] [int] NULL,
 CONSTRAINT [PK_NalogZaProizvodnju] PRIMARY KEY CLUSTERED 
(
	[SifraNaloga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Radnik]    Script Date: 21-Oct-19 9:45:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Radnik](
	[SifraRadnika] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](50) NULL,
	[Prezime] [varchar](50) NULL,
	[Profesija] [varchar](50) NULL,
 CONSTRAINT [PK_Radnik] PRIMARY KEY CLUSTERED 
(
	[SifraRadnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sirovina]    Script Date: 21-Oct-19 9:45:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sirovina](
	[SifraSirovine] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](50) NULL,
 CONSTRAINT [PK_Sirovina] PRIMARY KEY CLUSTERED 
(
	[SifraSirovine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkeIzvestajaOStanjuRepromaterijala]    Script Date: 21-Oct-19 9:45:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkeIzvestajaOStanjuRepromaterijala](
	[SifraIzvestaja] [int] NOT NULL,
	[RedniBroj] [int] NOT NULL,
	[Kolicina] [int] NULL,
	[Napomena] [varchar](50) NULL,
	[SifraSirovine] [int] NULL,
 CONSTRAINT [PK_StavkeIzvestajaOStanjuRepromaterijala] PRIMARY KEY CLUSTERED 
(
	[SifraIzvestaja] ASC,
	[RedniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZahtevOStanjuRepromaterijala]    Script Date: 21-Oct-19 9:45:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZahtevOStanjuRepromaterijala](
	[SifraZahteva] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [date] NULL,
	[TekstZahteva] [varchar](50) NULL,
	[Izdaje] [int] NULL,
	[Prima] [int] NULL,
	[SifraNalogaZaProizvodnju] [int] NULL,
 CONSTRAINT [PK_ZahtevOStanjuRepromaterijala] PRIMARY KEY CLUSTERED 
(
	[SifraZahteva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[IzvestajOStanjuRepromaterijala] ([SifraIzvestaja], [Datum], [SifraZahteva], [Prima], [Izdaje]) VALUES (1, CAST(N'2019-05-10' AS Date), 1, 1, 4)
INSERT [dbo].[IzvestajOStanjuRepromaterijala] ([SifraIzvestaja], [Datum], [SifraZahteva], [Prima], [Izdaje]) VALUES (2, CAST(N'2019-05-07' AS Date), 3, 2, 7)
INSERT [dbo].[IzvestajOStanjuRepromaterijala] ([SifraIzvestaja], [Datum], [SifraZahteva], [Prima], [Izdaje]) VALUES (7, CAST(N'2019-06-25' AS Date), 3, 3, 2)
INSERT [dbo].[IzvestajOStanjuRepromaterijala] ([SifraIzvestaja], [Datum], [SifraZahteva], [Prima], [Izdaje]) VALUES (8, CAST(N'2019-06-23' AS Date), 1, 5, 1)
SET IDENTITY_INSERT [dbo].[NalogZaProizvodnju] ON 

INSERT [dbo].[NalogZaProizvodnju] ([SifraNaloga], [Datum], [Prima], [Izdaje]) VALUES (1, CAST(N'2019-06-04' AS Date), 1, 3)
INSERT [dbo].[NalogZaProizvodnju] ([SifraNaloga], [Datum], [Prima], [Izdaje]) VALUES (2, CAST(N'2019-05-17' AS Date), 3, 4)
SET IDENTITY_INSERT [dbo].[NalogZaProizvodnju] OFF
SET IDENTITY_INSERT [dbo].[Radnik] ON 

INSERT [dbo].[Radnik] ([SifraRadnika], [Ime], [Prezime], [Profesija]) VALUES (1, N'Marinko', N'Sokic', N'Programer')
INSERT [dbo].[Radnik] ([SifraRadnika], [Ime], [Prezime], [Profesija]) VALUES (2, N'Milos', N'Damjanovic', N'Menadžer prodaje')
INSERT [dbo].[Radnik] ([SifraRadnika], [Ime], [Prezime], [Profesija]) VALUES (3, N'Teodora', N'Miljkovic', N'Asistent za dobavljace')
INSERT [dbo].[Radnik] ([SifraRadnika], [Ime], [Prezime], [Profesija]) VALUES (4, N'Ana', N'Cvetkovic', N'Front End Developer')
INSERT [dbo].[Radnik] ([SifraRadnika], [Ime], [Prezime], [Profesija]) VALUES (5, N'Nikola', N'Jeremic', N'Front End Developer')
INSERT [dbo].[Radnik] ([SifraRadnika], [Ime], [Prezime], [Profesija]) VALUES (6, N'Ljiljana', N'Knezevic', N'Menadzer logistike')
INSERT [dbo].[Radnik] ([SifraRadnika], [Ime], [Prezime], [Profesija]) VALUES (7, N'Filip', N'Stankovic', N'Menadzer logistike')
SET IDENTITY_INSERT [dbo].[Radnik] OFF
SET IDENTITY_INSERT [dbo].[Sirovina] ON 

INSERT [dbo].[Sirovina] ([SifraSirovine], [Naziv]) VALUES (1, N'Ekstrakt jabuke')
INSERT [dbo].[Sirovina] ([SifraSirovine], [Naziv]) VALUES (2, N'Ekstrakt pomorandze')
INSERT [dbo].[Sirovina] ([SifraSirovine], [Naziv]) VALUES (3, N'Secer')
INSERT [dbo].[Sirovina] ([SifraSirovine], [Naziv]) VALUES (4, N'Voda')
INSERT [dbo].[Sirovina] ([SifraSirovine], [Naziv]) VALUES (5, N'Ekstrakt borovnice')
INSERT [dbo].[Sirovina] ([SifraSirovine], [Naziv]) VALUES (6, N'Ekstrakt visnje')
INSERT [dbo].[Sirovina] ([SifraSirovine], [Naziv]) VALUES (7, N'Ekstrakt maline')
SET IDENTITY_INSERT [dbo].[Sirovina] OFF
INSERT [dbo].[StavkeIzvestajaOStanjuRepromaterijala] ([SifraIzvestaja], [RedniBroj], [Kolicina], [Napomena], [SifraSirovine]) VALUES (1, 1, 5, N'Nema je.', 5)
INSERT [dbo].[StavkeIzvestajaOStanjuRepromaterijala] ([SifraIzvestaja], [RedniBroj], [Kolicina], [Napomena], [SifraSirovine]) VALUES (2, 1, 44, N'Bez napomene.', 2)
INSERT [dbo].[StavkeIzvestajaOStanjuRepromaterijala] ([SifraIzvestaja], [RedniBroj], [Kolicina], [Napomena], [SifraSirovine]) VALUES (8, 1, 45, N'Hitno.', 6)
INSERT [dbo].[StavkeIzvestajaOStanjuRepromaterijala] ([SifraIzvestaja], [RedniBroj], [Kolicina], [Napomena], [SifraSirovine]) VALUES (8, 2, 22, N'Nema je', 7)
SET IDENTITY_INSERT [dbo].[ZahtevOStanjuRepromaterijala] ON 

INSERT [dbo].[ZahtevOStanjuRepromaterijala] ([SifraZahteva], [Datum], [TekstZahteva], [Izdaje], [Prima], [SifraNalogaZaProizvodnju]) VALUES (1, CAST(N'2019-06-23' AS Date), N'Dostaviti kutiju sirovine sto pre.', 3, 2, 2)
INSERT [dbo].[ZahtevOStanjuRepromaterijala] ([SifraZahteva], [Datum], [TekstZahteva], [Izdaje], [Prima], [SifraNalogaZaProizvodnju]) VALUES (3, CAST(N'2019-05-27' AS Date), N'Neophodno je dostaviti 5 galona ekstrakta u BG.', 4, 1, 1)
INSERT [dbo].[ZahtevOStanjuRepromaterijala] ([SifraZahteva], [Datum], [TekstZahteva], [Izdaje], [Prima], [SifraNalogaZaProizvodnju]) VALUES (4, CAST(N'2019-04-12' AS Date), N'Potreban info o sirovini.', 1, 3, 1)
INSERT [dbo].[ZahtevOStanjuRepromaterijala] ([SifraZahteva], [Datum], [TekstZahteva], [Izdaje], [Prima], [SifraNalogaZaProizvodnju]) VALUES (7, CAST(N'2019-06-25' AS Date), N'Stampajte izvestaj.', 1, 6, 1)
SET IDENTITY_INSERT [dbo].[ZahtevOStanjuRepromaterijala] OFF
ALTER TABLE [dbo].[IzvestajOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_IzvestajOStanjuRepromaterijala_Radnik] FOREIGN KEY([Prima])
REFERENCES [dbo].[Radnik] ([SifraRadnika])
GO
ALTER TABLE [dbo].[IzvestajOStanjuRepromaterijala] CHECK CONSTRAINT [FK_IzvestajOStanjuRepromaterijala_Radnik]
GO
ALTER TABLE [dbo].[IzvestajOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_IzvestajOStanjuRepromaterijala_Radnik1] FOREIGN KEY([Izdaje])
REFERENCES [dbo].[Radnik] ([SifraRadnika])
GO
ALTER TABLE [dbo].[IzvestajOStanjuRepromaterijala] CHECK CONSTRAINT [FK_IzvestajOStanjuRepromaterijala_Radnik1]
GO
ALTER TABLE [dbo].[IzvestajOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_IzvestajOStanjuRepromaterijala_ZahtevOStanjuRepromaterijala] FOREIGN KEY([SifraZahteva])
REFERENCES [dbo].[ZahtevOStanjuRepromaterijala] ([SifraZahteva])
GO
ALTER TABLE [dbo].[IzvestajOStanjuRepromaterijala] CHECK CONSTRAINT [FK_IzvestajOStanjuRepromaterijala_ZahtevOStanjuRepromaterijala]
GO
ALTER TABLE [dbo].[NalogZaProizvodnju]  WITH CHECK ADD  CONSTRAINT [FK_NalogZaProizvodnju_Radnik] FOREIGN KEY([Prima])
REFERENCES [dbo].[Radnik] ([SifraRadnika])
GO
ALTER TABLE [dbo].[NalogZaProizvodnju] CHECK CONSTRAINT [FK_NalogZaProizvodnju_Radnik]
GO
ALTER TABLE [dbo].[NalogZaProizvodnju]  WITH CHECK ADD  CONSTRAINT [FK_NalogZaProizvodnju_Radnik1] FOREIGN KEY([Izdaje])
REFERENCES [dbo].[Radnik] ([SifraRadnika])
GO
ALTER TABLE [dbo].[NalogZaProizvodnju] CHECK CONSTRAINT [FK_NalogZaProizvodnju_Radnik1]
GO
ALTER TABLE [dbo].[StavkeIzvestajaOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_StavkeIzvestajaOStanjuRepromaterijala_Izvestaj] FOREIGN KEY([SifraIzvestaja])
REFERENCES [dbo].[IzvestajOStanjuRepromaterijala] ([SifraIzvestaja])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StavkeIzvestajaOStanjuRepromaterijala] CHECK CONSTRAINT [FK_StavkeIzvestajaOStanjuRepromaterijala_Izvestaj]
GO
ALTER TABLE [dbo].[StavkeIzvestajaOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_StavkeIzvestajaOStanjuRepromaterijala_Sirovina] FOREIGN KEY([SifraSirovine])
REFERENCES [dbo].[Sirovina] ([SifraSirovine])
GO
ALTER TABLE [dbo].[StavkeIzvestajaOStanjuRepromaterijala] CHECK CONSTRAINT [FK_StavkeIzvestajaOStanjuRepromaterijala_Sirovina]
GO
ALTER TABLE [dbo].[ZahtevOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_ZahtevOStanjuRepromaterijala_NalogZaProizvodnju] FOREIGN KEY([SifraNalogaZaProizvodnju])
REFERENCES [dbo].[NalogZaProizvodnju] ([SifraNaloga])
GO
ALTER TABLE [dbo].[ZahtevOStanjuRepromaterijala] CHECK CONSTRAINT [FK_ZahtevOStanjuRepromaterijala_NalogZaProizvodnju]
GO
ALTER TABLE [dbo].[ZahtevOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_ZahtevOStanjuRepromaterijala_Radnik] FOREIGN KEY([Izdaje])
REFERENCES [dbo].[Radnik] ([SifraRadnika])
GO
ALTER TABLE [dbo].[ZahtevOStanjuRepromaterijala] CHECK CONSTRAINT [FK_ZahtevOStanjuRepromaterijala_Radnik]
GO
ALTER TABLE [dbo].[ZahtevOStanjuRepromaterijala]  WITH CHECK ADD  CONSTRAINT [FK_ZahtevOStanjuRepromaterijala_Radnik1] FOREIGN KEY([Prima])
REFERENCES [dbo].[Radnik] ([SifraRadnika])
GO
ALTER TABLE [dbo].[ZahtevOStanjuRepromaterijala] CHECK CONSTRAINT [FK_ZahtevOStanjuRepromaterijala_Radnik1]
GO
USE [master]
GO
ALTER DATABASE [ISBahus] SET  READ_WRITE 
GO
