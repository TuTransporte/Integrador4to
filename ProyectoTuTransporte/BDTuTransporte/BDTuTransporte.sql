USE [master]
GO
/****** Object:  Database [ProyectoTuTransporte]    Script Date: 26/11/2017 04:48:31 p. m. ******/
CREATE DATABASE [ProyectoTuTransporte]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoTuTransporte', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProyectoTuTransporte.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoTuTransporte_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProyectoTuTransporte_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProyectoTuTransporte] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoTuTransporte].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoTuTransporte] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProyectoTuTransporte] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoTuTransporte] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoTuTransporte] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProyectoTuTransporte] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoTuTransporte] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProyectoTuTransporte] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoTuTransporte] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoTuTransporte] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoTuTransporte] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoTuTransporte] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProyectoTuTransporte] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoTuTransporte] SET QUERY_STORE = OFF
GO
USE [ProyectoTuTransporte]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [ProyectoTuTransporte]
GO
/****** Object:  DatabaseRole [UsuarioBasico]    Script Date: 26/11/2017 04:48:32 p. m. ******/
CREATE ROLE [UsuarioBasico]
GO
/****** Object:  DatabaseRole [Manager]    Script Date: 26/11/2017 04:48:32 p. m. ******/
CREATE ROLE [Manager]
GO
/****** Object:  DatabaseRole [Administrador]    Script Date: 26/11/2017 04:48:32 p. m. ******/
CREATE ROLE [Administrador]
GO
/****** Object:  Table [dbo].[Camiones]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Camiones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](200) NOT NULL,
	[Matricula] [varchar](50) NULL,
	[Comentarios] [varchar](200) NULL,
	[FK_Rutas] [int] NOT NULL,
 CONSTRAINT [PK__Camiones__3214EC07F1BE0746] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaCamiones]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaCamiones]
AS
SELECT        Id, Serie AS 'Número de serie'
FROM            dbo.Camiones



GO
/****** Object:  Table [dbo].[Rutas]    Script Date: 26/11/2017 04:48:32 p. m. ******/
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
/****** Object:  View [dbo].[VistaRutas]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaRutas]
AS
SELECT        Id, Nombre AS 'Rutas de transporte'
FROM            dbo.Rutas



GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Correo_usuario] [varchar](200) NOT NULL,
	[Nombres] [varchar](200) NOT NULL,
	[ApellidoPaterno] [varchar](200) NOT NULL,
	[ApellidoMaterno] [varchar](200) NOT NULL,
	[Telefono] [numeric](18, 0) NOT NULL,
	[Tipo_usuario] [int] NOT NULL,
	[Contrasena] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Usuario__3214EC07D05FCA95] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaUsuarios]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaUsuarios]
AS
SELECT        Id, Correo_usuario AS 'Correo', Nombres, Telefono AS 'Teléfono', ApellidoMaterno AS 'Apellido Materno', ApellidoPaterno AS 'Apellido Paterno'
FROM            dbo.Usuario



GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 26/11/2017 04:48:32 p. m. ******/
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
/****** Object:  Table [dbo].[Choferes]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Choferes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[FK_Camion] [int] NOT NULL,
	[FK_Turno] [int] NOT NULL,
	[ApellidoPaterno] [varchar](100) NULL,
	[ApellidoMaterno] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Denuncias]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Denuncias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Denuncia] [text] NOT NULL,
	[FechaHora] [varchar](200) NOT NULL,
	[FK_Ubicacion] [int] NOT NULL,
	[FK_Usuario] [int] NOT NULL,
	[FK_Chofer] [int] NOT NULL,
	[FK_Camion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horarios]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Turno] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Noticias]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[Mensaje] [varchar](max) NULL,
	[Fecha] [varchar](50) NULL,
 CONSTRAINT [PK_Noticias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntoReferencia]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoReferencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RutaxPuntos]    Script Date: 26/11/2017 04:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RutaxPuntos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_Ruta] [int] NOT NULL,
	[FK_puntoReferencia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 26/11/2017 04:48:32 p. m. ******/
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
ALTER TABLE [dbo].[Camiones]  WITH CHECK ADD  CONSTRAINT [FK_Camiones_Rutas] FOREIGN KEY([FK_Rutas])
REFERENCES [dbo].[Rutas] ([Id])
GO
ALTER TABLE [dbo].[Camiones] CHECK CONSTRAINT [FK_Camiones_Rutas]
GO
ALTER TABLE [dbo].[Choferes]  WITH CHECK ADD  CONSTRAINT [FK_Choferes_Camiones] FOREIGN KEY([FK_Camion])
REFERENCES [dbo].[Camiones] ([Id])
GO
ALTER TABLE [dbo].[Choferes] CHECK CONSTRAINT [FK_Choferes_Camiones]
GO
ALTER TABLE [dbo].[Choferes]  WITH CHECK ADD  CONSTRAINT [FK_Choferes_Horarios] FOREIGN KEY([FK_Turno])
REFERENCES [dbo].[Horarios] ([Id])
GO
ALTER TABLE [dbo].[Choferes] CHECK CONSTRAINT [FK_Choferes_Horarios]
GO
ALTER TABLE [dbo].[Denuncias]  WITH CHECK ADD  CONSTRAINT [FK_Camion] FOREIGN KEY([Id])
REFERENCES [dbo].[Camiones] ([Id])
GO
ALTER TABLE [dbo].[Denuncias] CHECK CONSTRAINT [FK_Camion]
GO
ALTER TABLE [dbo].[Denuncias]  WITH CHECK ADD  CONSTRAINT [FK_Chofer] FOREIGN KEY([Id])
REFERENCES [dbo].[Choferes] ([Id])
GO
ALTER TABLE [dbo].[Denuncias] CHECK CONSTRAINT [FK_Chofer]
GO
ALTER TABLE [dbo].[Denuncias]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion] FOREIGN KEY([Id])
REFERENCES [dbo].[Ubicacion] ([Id])
GO
ALTER TABLE [dbo].[Denuncias] CHECK CONSTRAINT [FK_Ubicacion]
GO
ALTER TABLE [dbo].[Denuncias]  WITH CHECK ADD  CONSTRAINT [FK_Usuario] FOREIGN KEY([Id])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Denuncias] CHECK CONSTRAINT [FK_Usuario]
GO
ALTER TABLE [dbo].[RutaxPuntos]  WITH CHECK ADD  CONSTRAINT [FK_puntoReferencia] FOREIGN KEY([Id])
REFERENCES [dbo].[PuntoReferencia] ([Id])
GO
ALTER TABLE [dbo].[RutaxPuntos] CHECK CONSTRAINT [FK_puntoReferencia]
GO
ALTER TABLE [dbo].[RutaxPuntos]  WITH CHECK ADD  CONSTRAINT [FK_Ruta] FOREIGN KEY([Id])
REFERENCES [dbo].[Rutas] ([Id])
GO
ALTER TABLE [dbo].[RutaxPuntos] CHECK CONSTRAINT [FK_Ruta]
GO
/****** Object:  StoredProcedure [dbo].[SPAgregarCamiones]    Script Date: 26/11/2017 04:48:33 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SPAgregarRutas]    Script Date: 26/11/2017 04:48:33 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SPAgregarUsuario]    Script Date: 26/11/2017 04:48:33 p. m. ******/
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
ALTER DATABASE [ProyectoTuTransporte] SET  READ_WRITE 
GO
