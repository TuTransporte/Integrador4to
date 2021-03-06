USE [master]
GO
/****** Object:  Database [PruebaArrays]    Script Date: 01/12/2017 08:56:36 a. m. ******/
CREATE DATABASE [PruebaArrays]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaArrays', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PruebaArrays.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PruebaArrays_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PruebaArrays_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PruebaArrays] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaArrays].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaArrays] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaArrays] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaArrays] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaArrays] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaArrays] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaArrays] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaArrays] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaArrays] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaArrays] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaArrays] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaArrays] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaArrays] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaArrays] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaArrays] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaArrays] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaArrays] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaArrays] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaArrays] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaArrays] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaArrays] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaArrays] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaArrays] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaArrays] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PruebaArrays] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaArrays] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaArrays] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaArrays] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaArrays] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PruebaArrays] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PruebaArrays]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 01/12/2017 08:56:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Locations](
	[Name] [varchar](100) NOT NULL,
	[Latitude] [numeric](18, 6) NOT NULL,
	[Longitude] [numeric](18, 6) NOT NULL,
	[Description] [varchar](300) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Pedagogica x Av Quetzalcoatl', CAST(20.959867 AS Numeric(18, 6)), CAST(-89.582616 AS Numeric(18, 6)), N'1')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Quetzalcoatl x Calle 14', CAST(20.957006 AS Numeric(18, 6)), CAST(-89.570954 AS Numeric(18, 6)), N'2')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 14 x Av Fidel Velazquez', CAST(20.967836 AS Numeric(18, 6)), CAST(-89.568728 AS Numeric(18, 6)), N'3')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Fidel Velasquez x Cto. Colonias', CAST(20.965287 AS Numeric(18, 6)), CAST(-89.591360 AS Numeric(18, 6)), N'4')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Cto. Colonias x Calle 55', CAST(20.969294 AS Numeric(18, 6)), CAST(-89.591146 AS Numeric(18, 6)), N'5')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 51 x Calle 50', CAST(20.970256 AS Numeric(18, 6)), CAST(-89.579794 AS Numeric(18, 6)), N'6')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 50 x Calle 21', CAST(20.975255 AS Numeric(18, 6)), CAST(-89.580728 AS Numeric(18, 6)), N'7')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 21 x Calle 34', CAST(20.977033 AS Numeric(18, 6)), CAST(-89.572134 AS Numeric(18, 6)), N'8')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 40 x Av Yucatan', CAST(21.006352 AS Numeric(18, 6)), CAST(-89.582101 AS Numeric(18, 6)), N'9')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Yucatan x Av Diaz Bolio', CAST(20.997673 AS Numeric(18, 6)), CAST(-89.596118 AS Numeric(18, 6)), N'10')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Jose Vazconcelos x Calle 9', CAST(21.013288 AS Numeric(18, 6)), CAST(-89.583324 AS Numeric(18, 6)), N'11')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Camara de Comercio x Av Andres Garcia', CAST(21.022432 AS Numeric(18, 6)), CAST(-89.605855 AS Numeric(18, 6)), N'12')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Andres Garcia x Calle 29', CAST(21.032566 AS Numeric(18, 6)), CAST(-89.603476 AS Numeric(18, 6)), N'13')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 29 x Calle 36A', CAST(21.032825 AS Numeric(18, 6)), CAST(-89.608419 AS Numeric(18, 6)), N'14')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 75 x Calle42', CAST(21.030684 AS Numeric(18, 6)), CAST(-89.626009 AS Numeric(18, 6)), N'15')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 23 x Carr.', CAST(21.007840 AS Numeric(18, 6)), CAST(-89.625601 AS Numeric(18, 6)), N'16')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 23A x Calle 16', CAST(21.008245 AS Numeric(18, 6)), CAST(-89.628809 AS Numeric(18, 6)), N'17')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 14', CAST(21.019848 AS Numeric(18, 6)), CAST(-89.629072 AS Numeric(18, 6)), N'18')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle1', CAST(21.031575 AS Numeric(18, 6)), CAST(-89.646152 AS Numeric(18, 6)), N'19')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 35', CAST(21.013178 AS Numeric(18, 6)), CAST(-89.655529 AS Numeric(18, 6)), N'20')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 19B', CAST(21.011726 AS Numeric(18, 6)), CAST(-89.655894 AS Numeric(18, 6)), N'21')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Av Merida 2000', CAST(21.003453 AS Numeric(18, 6)), CAST(-89.665453 AS Numeric(18, 6)), N'22')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 15', CAST(20.997563 AS Numeric(18, 6)), CAST(-89.661816 AS Numeric(18, 6)), N'23')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Las Americas', CAST(20.989981 AS Numeric(18, 6)), CAST(-89.648738 AS Numeric(18, 6)), N'24')
INSERT [dbo].[Locations] ([Name], [Latitude], [Longitude], [Description]) VALUES (N'Calle 50', CAST(20.985483 AS Numeric(18, 6)), CAST(-89.656076 AS Numeric(18, 6)), N'25')
USE [master]
GO
ALTER DATABASE [PruebaArrays] SET  READ_WRITE 
GO
