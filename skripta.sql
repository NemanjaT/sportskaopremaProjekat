USE [master]
GO
/****** Object:  Database [ProdavnicaPPP]    Script Date: 23/03/2023 13:23:27 ******/
CREATE DATABASE [ProdavnicaPPP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProdavnicaPPP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProdavnicaPPP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProdavnicaPPP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProdavnicaPPP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProdavnicaPPP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProdavnicaPPP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProdavnicaPPP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProdavnicaPPP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProdavnicaPPP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProdavnicaPPP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProdavnicaPPP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProdavnicaPPP] SET  MULTI_USER 
GO
ALTER DATABASE [ProdavnicaPPP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProdavnicaPPP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProdavnicaPPP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProdavnicaPPP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProdavnicaPPP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProdavnicaPPP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProdavnicaPPP] SET QUERY_STORE = OFF
GO
USE [ProdavnicaPPP]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 23/03/2023 13:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artikal]    Script Date: 23/03/2023 13:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artikal](
	[ArtikalID] [int] NOT NULL,
	[NazivArtikla] [nvarchar](50) NOT NULL,
	[Cena] [int] NOT NULL,
	[idKat] [int] NOT NULL,
 CONSTRAINT [PK_Artikal] PRIMARY KEY CLUSTERED 
(
	[ArtikalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategorija]    Script Date: 23/03/2023 13:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorija](
	[idKat] [int] NOT NULL,
	[NazivKategorije] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kategorija] PRIMARY KEY CLUSTERED 
(
	[idKat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 23/03/2023 13:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[IDKorisnika] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[BrTelefona] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[IDKorisnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Porudzbina]    Script Date: 23/03/2023 13:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Porudzbina](
	[PorudzbinaID] [int] IDENTITY(1000,1) NOT NULL,
	[cena] [int] NOT NULL,
	[vreme] [date] NOT NULL,
	[IDKorisnika] [int] NOT NULL,
 CONSTRAINT [PK_Porudzbina] PRIMARY KEY CLUSTERED 
(
	[PorudzbinaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 23/03/2023 13:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](30) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaPorudzbine]    Script Date: 23/03/2023 13:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaPorudzbine](
	[StavkaID] [int] IDENTITY(1500,1) NOT NULL,
	[ArtikalID] [int] NOT NULL,
	[NazivArtikla] [nvarchar](50) NOT NULL,
	[Cena] [int] NOT NULL,
	[PorudzbinaID] [int] NOT NULL,
 CONSTRAINT [PK_StavkaPorudzbine] PRIMARY KEY CLUSTERED 
(
	[StavkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 23/03/2023 13:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/03/2023 13:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](30) NULL,
	[Password] [nvarchar](30) NULL,
	[IsActive] [bit] NULL,
	[Username] [nvarchar](30) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Artikal]  WITH CHECK ADD  CONSTRAINT [FK_Artikal_Kategorija] FOREIGN KEY([idKat])
REFERENCES [dbo].[Kategorija] ([idKat])
GO
ALTER TABLE [dbo].[Artikal] CHECK CONSTRAINT [FK_Artikal_Kategorija]
GO
ALTER TABLE [dbo].[Porudzbina]  WITH CHECK ADD  CONSTRAINT [FK_Porudzbina_User] FOREIGN KEY([IDKorisnika])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Porudzbina] CHECK CONSTRAINT [FK_Porudzbina_User]
GO
ALTER TABLE [dbo].[StavkaPorudzbine]  WITH CHECK ADD  CONSTRAINT [FK_StavkaPorudzbine_Artikal] FOREIGN KEY([ArtikalID])
REFERENCES [dbo].[Artikal] ([ArtikalID])
GO
ALTER TABLE [dbo].[StavkaPorudzbine] CHECK CONSTRAINT [FK_StavkaPorudzbine_Artikal]
GO
ALTER TABLE [dbo].[StavkaPorudzbine]  WITH CHECK ADD  CONSTRAINT [FK_StavkaPorudzbine_Porudzbina] FOREIGN KEY([PorudzbinaID])
REFERENCES [dbo].[Porudzbina] ([PorudzbinaID])
GO
ALTER TABLE [dbo].[StavkaPorudzbine] CHECK CONSTRAINT [FK_StavkaPorudzbine_Porudzbina]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
USE [master]
GO
ALTER DATABASE [ProdavnicaPPP] SET  READ_WRITE 
GO
