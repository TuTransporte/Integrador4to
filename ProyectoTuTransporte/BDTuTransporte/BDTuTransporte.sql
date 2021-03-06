USE [master]
GO
/****** Object:  Database [DB_A3402F_TuTransporte]    Script Date: 28/03/2018 01:33:56 p. m. ******/
CREATE DATABASE [DB_A3402F_TuTransporte]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A3402F_TuTransporte_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DB_A3402F_TuTransporte_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 512000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A3402F_TuTransporte_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DB_A3402F_TuTransporte_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A3402F_TuTransporte].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET QUERY_STORE = OFF
GO
USE [DB_A3402F_TuTransporte]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DB_A3402F_TuTransporte]
GO
/****** Object:  Table [dbo].[Camiones]    Script Date: 28/03/2018 01:33:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Camiones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](200) NOT NULL,
	[Matricula] [varchar](50) NULL,
	[Comentarios] [varchar](200) NULL,
	[FK_Rutas] [int] NULL,
	[FK_Choferes] [int] NULL,
 CONSTRAINT [PK__Camiones__3214EC07F1BE0746] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaCamiones]    Script Date: 28/03/2018 01:34:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaCamiones]
AS
SELECT        Id, Serie AS 'Número de serie'
FROM            dbo.Camiones


GO
/****** Object:  Table [dbo].[Rutas]    Script Date: 28/03/2018 01:34:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rutas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaRutas]    Script Date: 28/03/2018 01:34:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaRutas]
AS
SELECT        Id, Nombre AS 'Rutas de transporte'
FROM            dbo.Rutas


GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/03/2018 01:34:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Correo_usuario] [varchar](200) NULL,
	[Nombres] [varchar](200) NULL,
	[ApellidoPaterno] [varchar](200) NULL,
	[ApellidoMaterno] [varchar](200) NULL,
	[Telefono] [numeric](18, 0) NULL,
	[Tipo_usuario] [int] NULL,
	[Contrasena] [varchar](50) NULL,
	[Direccion] [varchar](200) NULL,
	[RFC] [varchar](200) NULL,
	[Horario] [varchar](200) NULL,
	[RazonSocial] [varchar](200) NULL,
 CONSTRAINT [PK__Usuario__3214EC0714933BAC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaUsuarios]    Script Date: 28/03/2018 01:34:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaUsuarios]
AS
SELECT        Id, Correo_usuario AS 'Correo', Nombres, Telefono AS 'Teléfono', ApellidoMaterno AS 'Apellido Materno', ApellidoPaterno AS 'Apellido Paterno'
FROM            dbo.Usuario


GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 28/03/2018 01:34:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Accion] [varchar](50) NULL,
	[Tabla] [varchar](128) NULL,
	[PK] [varchar](1000) NULL,
	[Campo] [varchar](128) NULL,
	[ValorOriginal] [varchar](1000) NULL,
	[ValorNuevo] [varchar](1000) NULL,
	[Fecha] [datetime] NULL,
	[Usuario] [varchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chats]    Script Date: 28/03/2018 01:34:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chats](
	[IdMensaje] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](50) NULL,
	[Mensaje] [varchar](500) NULL,
	[PersonaEnvia] [varchar](50) NULL,
	[PersonaRecibe] [varchar](50) NULL,
	[Fecha] [varchar](50) NULL,
 CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED 
(
	[IdMensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatsDenuncia]    Script Date: 28/03/2018 01:34:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatsDenuncia](
	[IdMensaje] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](50) NULL,
	[Mensaje] [varchar](500) NULL,
	[PersonaEnvia] [varchar](50) NULL,
	[PersonaRecibe] [varchar](50) NULL,
	[Fecha] [varchar](50) NULL,
	[IdDenuncia] [int] NULL,
 CONSTRAINT [PK_ChatsDenuncia] PRIMARY KEY CLUSTERED 
(
	[IdMensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Choferes]    Script Date: 28/03/2018 01:34:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Choferes](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[Edad] [int] NULL,
	[Telefono] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Choferes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consejos]    Script Date: 28/03/2018 01:34:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consejos](
	[Id] [int] NULL,
	[Descripcion] [varchar](200) NULL,
	[Titulo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Denuncias]    Script Date: 28/03/2018 01:34:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Denuncias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Denuncia] [varchar](700) NULL,
	[FechaHora] [varchar](70) NULL,
	[FK_Ubicacion] [int] NULL,
	[FK_Usuario] [int] NULL,
	[FK_Camion] [int] NULL,
	[Estado] [int] NULL,
	[Operador] [varchar](50) NULL,
	[Unidad] [varchar](50) NULL,
	[Motivo] [varchar](50) NULL,
	[Ruta] [varchar](50) NULL,
	[Latitud] [varchar](max) NULL,
	[Longitud] [varchar](max) NULL,
	[Imagen] [varchar](max) NULL,
	[Correo] [varchar](50) NULL,
	[Dictamen] [varchar](max) NULL,
 CONSTRAINT [PK_Denuncias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Noticias]    Script Date: 28/03/2018 01:34:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NULL,
	[Mensaje] [varchar](max) NULL,
	[Fecha] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 28/03/2018 01:34:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitud] [varchar](500) NOT NULL,
	[Longitud] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Camiones]  WITH CHECK ADD  CONSTRAINT [FK_Camiones_Choferes] FOREIGN KEY([FK_Choferes])
REFERENCES [dbo].[Choferes] ([Id])
GO
ALTER TABLE [dbo].[Camiones] CHECK CONSTRAINT [FK_Camiones_Choferes]
GO
ALTER TABLE [dbo].[Camiones]  WITH CHECK ADD  CONSTRAINT [FK_Camiones_Rutas] FOREIGN KEY([FK_Rutas])
REFERENCES [dbo].[Rutas] ([Id])
GO
ALTER TABLE [dbo].[Camiones] CHECK CONSTRAINT [FK_Camiones_Rutas]
GO
ALTER TABLE [dbo].[Denuncias]  WITH CHECK ADD  CONSTRAINT [FK_Denuncias_Ubicacion] FOREIGN KEY([FK_Ubicacion])
REFERENCES [dbo].[Ubicacion] ([Id])
GO
ALTER TABLE [dbo].[Denuncias] CHECK CONSTRAINT [FK_Denuncias_Ubicacion]
GO
ALTER TABLE [dbo].[Denuncias]  WITH CHECK ADD  CONSTRAINT [FK_Denuncias_Usuario] FOREIGN KEY([FK_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Denuncias] CHECK CONSTRAINT [FK_Denuncias_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[DenunciaChart]    Script Date: 28/03/2018 01:34:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DenunciaChart] AS
SELECT COUNT(*) as 'Denuncias', Denuncias.Ruta FROM Denuncias GROUP By Ruta
GO
/****** Object:  StoredProcedure [dbo].[MotivoChart]    Script Date: 28/03/2018 01:34:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MotivoChart] AS
SELECT COUNT(*) as 'Denuncias', Denuncias.Motivo FROM Denuncias GROUP By Motivo
GO
/****** Object:  StoredProcedure [dbo].[SPAgregarCamiones]    Script Date: 28/03/2018 01:34:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPAgregarCamiones]
	@Nombre varchar(50)
AS
BEGIN		
	SET NOCOUNT ON;
	IF(Select Count(Serie) From Camiones) = 0
	Insert Into Rutas(Nombre)
	Values (@Nombre)
	Else
	Print 'Serie de camión se encuentra registrado en el sistema'
END


GO
/****** Object:  StoredProcedure [dbo].[SPAgregarRutas]    Script Date: 28/03/2018 01:34:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPAgregarRutas]	
	@Nombre varchar(50)
AS
BEGIN		
	SET NOCOUNT ON;
	IF(Select Count(Nombre) From Rutas) = 0
	Insert Into Rutas(Nombre)
	Values (@Nombre)
	Else
	Print 'Ruta se encuentra registrado en el sistema'
END


GO
/****** Object:  StoredProcedure [dbo].[SPAgregarUsuario]    Script Date: 28/03/2018 01:34:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPAgregarUsuario]	
	@Correo varchar(50),
	@Nombre varchar(50),
	@ApellidoPaterno varchar(50),
	@ApellidoMaterno varchar(50),
	@Telefono int,
	@TipoUsuario int,
	@Contrasena varchar(50)
AS
BEGIN		
	SET NOCOUNT ON;
	IF(Select Count(Correo_usuario) From Usuario) = 0
	Insert Into Usuario (Correo_usuario,Nombres,ApellidoPaterno,ApellidoMaterno,Telefono,Tipo_usuario, Contrasena)
	Values (@Correo,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Telefono,@TipoUsuario,@Contrasena)
	Else
	Print 'Correo electrónico se encuentra registrado en el sistema'
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Camiones"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaCamiones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaCamiones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Rutas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaRutas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaRutas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Usuario"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaUsuarios'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaUsuarios'
GO
USE [master]
GO
ALTER DATABASE [DB_A3402F_TuTransporte] SET  READ_WRITE 
GO
