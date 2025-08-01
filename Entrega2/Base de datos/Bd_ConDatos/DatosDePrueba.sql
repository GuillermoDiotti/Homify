USE [master]
GO
/****** Object:  Database [Homify]    Script Date: 21/11/2024 1:01:30 ******/
CREATE DATABASE [Homify]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homify', FILENAME = N'/var/opt/mssql/data/Homify.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Homify_log', FILENAME = N'/var/opt/mssql/data/Homify_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Homify] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homify].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homify] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homify] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homify] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homify] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homify] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homify] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homify] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homify] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homify] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homify] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homify] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homify] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homify] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homify] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homify] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Homify] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homify] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homify] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homify] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homify] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homify] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Homify] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homify] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Homify] SET  MULTI_USER 
GO
ALTER DATABASE [Homify] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [Homify] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homify] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homify] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Homify] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Homify] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homify', N'ON'
GO
ALTER DATABASE [Homify] SET QUERY_STORE = ON
GO
ALTER DATABASE [Homify] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Homify]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cameras]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cameras](
	[Id] [nvarchar](450) NOT NULL,
	[IsExterior] [bit] NULL,
	[IsInterior] [bit] NULL,
 CONSTRAINT [PK_Cameras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [nvarchar](450) NOT NULL,
	[ValidatorType] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LogoUrl] [nvarchar](max) NOT NULL,
	[Rut] [nvarchar](max) NOT NULL,
	[OwnerId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyOwners]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyOwners](
	[Id] [nvarchar](450) NOT NULL,
	[IsIncomplete] [bit] NOT NULL,
 CONSTRAINT [PK_CompanyOwners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Id] [nvarchar](450) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Photos] [nvarchar](max) NOT NULL,
	[PpalPicture] [nvarchar](max) NULL,
	[CompanyId] [nvarchar](450) NOT NULL,
	[MovementDetection] [bit] NULL,
	[PeopleDetection] [bit] NULL,
	[WindowDetection] [bit] NOT NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeDevices]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeDevices](
	[Id] [nvarchar](450) NOT NULL,
	[CustomName] [nvarchar](max) NULL,
	[HomeId] [nvarchar](450) NOT NULL,
	[DeviceId] [nvarchar](450) NOT NULL,
	[Connected] [bit] NOT NULL,
	[HardwareId] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsOn] [bit] NOT NULL,
	[RoomId] [nvarchar](450) NULL,
 CONSTRAINT [PK_HomeDevices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeOwners]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeOwners](
	[Id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_HomeOwners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomePermission]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomePermission](
	[Id] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HomePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Homes]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Homes](
	[Id] [nvarchar](450) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[Alias] [nvarchar](max) NOT NULL,
	[Number] [nvarchar](max) NOT NULL,
	[Latitude] [nvarchar](max) NOT NULL,
	[Longitude] [nvarchar](max) NOT NULL,
	[MaxMembers] [int] NOT NULL,
	[OwnerId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Homes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeUserHomePermission]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeUserHomePermission](
	[Id] [nvarchar](450) NOT NULL,
	[HomeUserId] [nvarchar](450) NOT NULL,
	[HomePermissionId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_HomeUserHomePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeUsers]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeUsers](
	[Id] [nvarchar](450) NOT NULL,
	[HomeId] [nvarchar](450) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[IsNotificable] [bit] NOT NULL,
 CONSTRAINT [PK_HomeUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lamps]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lamps](
	[Id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Lamps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovementSensors]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovementSensors](
	[Id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_MovementSensors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [nvarchar](450) NOT NULL,
	[Event] [nvarchar](max) NULL,
	[HomeDeviceId] [nvarchar](450) NOT NULL,
	[IsRead] [bit] NOT NULL,
	[Date] [nvarchar](max) NULL,
	[HomeUserId] [nvarchar](450) NULL,
	[Detail] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleSystemPermissions]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleSystemPermissions](
	[RoleSystemPermissionId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NULL,
	[PermissionId] [nvarchar](450) NULL,
 CONSTRAINT [PK_RoleSystemPermissions] PRIMARY KEY CLUSTERED 
(
	[RoleSystemPermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[HomeId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [nvarchar](450) NOT NULL,
	[AuthToken] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemPermissions]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemPermissions](
	[Id] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_SystemPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[CreatedAt] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WindowSensors]    Script Date: 21/11/2024 1:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WindowSensors](
	[Id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_WindowSensors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241116225602_InitialMigration', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241117010343_MergeBranches', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241119150755_OwnerTypeChanges', N'8.0.8')
GO
INSERT [dbo].[Admins] ([Id]) VALUES (N'0d6f54b8-1ca6-4cc8-a994-6d9ae7433d39')
INSERT [dbo].[Admins] ([Id]) VALUES (N'6755fc8d-41d3-4ea5-b0f1-dad5d67b2f15')
INSERT [dbo].[Admins] ([Id]) VALUES (N'SeedAdminId')
GO
INSERT [dbo].[Cameras] ([Id], [IsExterior], [IsInterior]) VALUES (N'bfeb952e-7585-4954-a4f7-373b711f22f7', 0, 0)
INSERT [dbo].[Cameras] ([Id], [IsExterior], [IsInterior]) VALUES (N'ef377c15-d840-45f3-842b-7984517766cd', 0, 0)
GO
INSERT [dbo].[Companies] ([Id], [ValidatorType], [Name], [LogoUrl], [Rut], [OwnerId]) VALUES (N'48764e16-53eb-48c5-8fd3-c695285c4a10', N'ValidadorModeloLetrasNumeros', N'Company 1', N'https://sm.ign.com/ign_es/cover/b/bob-the-bu/bob-the-builder-the-movie_r5y4.jpg', N'123', N'SeedCompanyOwnerId')
INSERT [dbo].[Companies] ([Id], [ValidatorType], [Name], [LogoUrl], [Rut], [OwnerId]) VALUES (N'b988f8bd-94ad-4a60-84dd-c9e428919061', N'', N'Lucas SA', N'fdfdsfsdf', N'345', N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647')
INSERT [dbo].[Companies] ([Id], [ValidatorType], [Name], [LogoUrl], [Rut], [OwnerId]) VALUES (N'e4d9e8ec-ebcd-4829-9bb0-fa3bec317685', N'ValidadorModeloLetrasNumeros', N'Prado', N'dade1', N'123', N'903c2c3f-123a-4302-ba89-0dd6970794b3')
GO
INSERT [dbo].[CompanyOwners] ([Id], [IsIncomplete]) VALUES (N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647', 0)
INSERT [dbo].[CompanyOwners] ([Id], [IsIncomplete]) VALUES (N'903c2c3f-123a-4302-ba89-0dd6970794b3', 0)
INSERT [dbo].[CompanyOwners] ([Id], [IsIncomplete]) VALUES (N'SeedCompanyOwnerId', 0)
GO
INSERT [dbo].[Devices] ([Id], [Type], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'1804f090-1a2e-4932-abca-d9ee5f16340f', N'MOVEMENTSENSOR', N'Movement', N'erf214', N'adad3r2r23', N'["https://www.electronica.uy/wp-content/uploads/2024/04/mk0005-1.jpg"]', N'https://www.electronica.uy/wp-content/uploads/2024/04/mk0005-1.jpg', N'48764e16-53eb-48c5-8fd3-c695285c4a10', 1, 0, 0)
INSERT [dbo].[Devices] ([Id], [Type], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'364de186-7a32-45d8-a4f8-988458e3395b', N'MOVEMENTSENSOR', N'Smart H313', N'H313', N'importado', N'["https://http2.mlstatic.com/D_NQ_NP_2X_710567-MLU74978946520_032024-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_901269-MLU75119028651_032024-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_659683-MLU75119028653_032024-F.webp"]', N'https://http2.mlstatic.com/D_NQ_NP_2X_710567-MLU74978946520_032024-F.webp', N'e4d9e8ec-ebcd-4829-9bb0-fa3bec317685', 1, 0, 0)
INSERT [dbo].[Devices] ([Id], [Type], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'68eb367b-4be3-4687-ae41-2b413d950849', N'SENSOR', N'Kasa A540', N'Afv540', N'importado', N'["https://http2.mlstatic.com/D_NQ_NP_2X_737708-MLU75995534252_052024-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_900391-MLU75995534258_052024-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_996743-MLU78617728014_082024-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_665795-MLU78617728018_082024-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_859473-MLU78851895417_082024-F.webp"]', N'https://http2.mlstatic.com/D_NQ_NP_2X_859473-MLU78851895417_082024-F.webp', N'e4d9e8ec-ebcd-4829-9bb0-fa3bec317685', 0, 0, 1)
INSERT [dbo].[Devices] ([Id], [Type], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'7d3e6c23-194c-49cf-bf98-d5ae36ed16f4', N'LAMP', N'Lamparita', N'acf321', N'lampara', N'["dasdas.png"]', N'https://betterware.com.mx/cdn/shop/files/23848-2-Lampara-Delluxe-Betterware-689333.jpg?v=1727125692', N'48764e16-53eb-48c5-8fd3-c695285c4a10', 0, 0, 0)
INSERT [dbo].[Devices] ([Id], [Type], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'bfeb952e-7585-4954-a4f7-373b711f22f7', N'CAMERA', N'Business KKP250', N'KKP250', N'importado', N'["https://http2.mlstatic.com/D_NQ_NP_2X_787853-MLU71131483530_082023-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_603102-MLU71171145159_082023-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_600987-MLU71170963657_082023-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_953692-MLU71132034844_082023-F.webp"]', N'https://http2.mlstatic.com/D_NQ_NP_2X_603102-MLU71171145159_082023-F.webp', N'48764e16-53eb-48c5-8fd3-c695285c4a10', 1, 0, 0)
INSERT [dbo].[Devices] ([Id], [Type], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'ef377c15-d840-45f3-842b-7984517766cd', N'CAMERA', N'Business G235', N'GDL235', N'importado', N'["https://http2.mlstatic.com/D_NQ_NP_2X_787853-MLU71131483530_082023-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_603102-MLU71171145159_082023-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_600987-MLU71170963657_082023-F.webp","https://http2.mlstatic.com/D_NQ_NP_2X_953692-MLU71132034844_082023-F.webp"]', N'https://http2.mlstatic.com/D_NQ_NP_2X_603102-MLU71171145159_082023-F.webp', N'e4d9e8ec-ebcd-4829-9bb0-fa3bec317685', 1, 0, 0)
GO
INSERT [dbo].[HomeDevices] ([Id], [CustomName], [HomeId], [DeviceId], [Connected], [HardwareId], [IsActive], [IsOn], [RoomId]) VALUES (N'89aa24dd-b58e-43f5-a14f-f60c04776fce', N'Smart H313', N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54', N'364de186-7a32-45d8-a4f8-988458e3395b', 1, N'f68e7061-fa70-4bb7-972d-55377e2ca3db', 1, 0, N'039e5b26-80ee-4b85-801b-94a052f8e2d3')
INSERT [dbo].[HomeDevices] ([Id], [CustomName], [HomeId], [DeviceId], [Connected], [HardwareId], [IsActive], [IsOn], [RoomId]) VALUES (N'9994a33d-f647-476f-867c-589b86bfdc7b', N'Renamed_By_Juan', N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54', N'68eb367b-4be3-4687-ae41-2b413d950849', 1, N'57bc7d80-ac06-461d-8530-6983e3069150', 1, 0, N'7b373786-a963-42df-a0bc-fbe08f5899f4')
INSERT [dbo].[HomeDevices] ([Id], [CustomName], [HomeId], [DeviceId], [Connected], [HardwareId], [IsActive], [IsOn], [RoomId]) VALUES (N'fd634c14-a300-46fd-afe5-1f1b014f9a9a', N'Business KKP250', N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54', N'bfeb952e-7585-4954-a4f7-373b711f22f7', 1, N'99e6095d-6501-4695-8ace-60587aa8b8a0', 1, 0, N'039e5b26-80ee-4b85-801b-94a052f8e2d3')
GO
INSERT [dbo].[HomeOwners] ([Id]) VALUES (N'aacc26c7-0fa1-48a6-87af-8bb1ceb7a319')
INSERT [dbo].[HomeOwners] ([Id]) VALUES (N'SeedHomeOwnerId')
GO
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'1', N'AddDevices')
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'2', N'ListDevices')
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'3', N'ChangeDeviceName')
GO
INSERT [dbo].[Homes] ([Id], [Street], [Alias], [Number], [Latitude], [Longitude], [MaxMembers], [OwnerId]) VALUES (N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54', N'Pocitos', N'Casa', N'46', N'124', N'43', 2, N'SeedHomeOwnerId')
INSERT [dbo].[Homes] ([Id], [Street], [Alias], [Number], [Latitude], [Longitude], [MaxMembers], [OwnerId]) VALUES (N'51152ed0-ad66-45f7-8863-61a80b40044a', N'Avellaneda', N'Casa Tevez', N'54', N'234', N'42', 3, N'6755fc8d-41d3-4ea5-b0f1-dad5d67b2f15')
INSERT [dbo].[Homes] ([Id], [Street], [Alias], [Number], [Latitude], [Longitude], [MaxMembers], [OwnerId]) VALUES (N'6dc8be6d-9bc0-4b57-aa05-d346f383d298', N'Av. Siempreviva', N'Casa Lucas', N'742', N'12', N'22', 3, N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647')
INSERT [dbo].[Homes] ([Id], [Street], [Alias], [Number], [Latitude], [Longitude], [MaxMembers], [OwnerId]) VALUES (N'aa98cab4-3f66-4be3-9e57-d2de7577492c', N'Carrasco', N'Casa Guille', N'736', N'14', N'15', 4, N'aacc26c7-0fa1-48a6-87af-8bb1ceb7a319')
GO
INSERT [dbo].[HomeUserHomePermission] ([Id], [HomeUserId], [HomePermissionId]) VALUES (N'3512eff3-e479-4350-96cd-74baf04506e0', N'e61bc4d1-3736-48d8-b839-9a1105bade8a', N'2')
INSERT [dbo].[HomeUserHomePermission] ([Id], [HomeUserId], [HomePermissionId]) VALUES (N'5defc496-efa1-4ee7-8517-55cc19c2bfbd', N'e61bc4d1-3736-48d8-b839-9a1105bade8a', N'1')
INSERT [dbo].[HomeUserHomePermission] ([Id], [HomeUserId], [HomePermissionId]) VALUES (N'9d1a946b-93dc-4149-8ef3-4ebb1edd492b', N'a1b6cb13-952f-4807-9914-06c79a3bd852', N'3')
INSERT [dbo].[HomeUserHomePermission] ([Id], [HomeUserId], [HomePermissionId]) VALUES (N'c62a204b-9810-4f12-bac2-51037d460f06', N'a1b6cb13-952f-4807-9914-06c79a3bd852', N'2')
GO
INSERT [dbo].[HomeUsers] ([Id], [HomeId], [UserId], [IsNotificable]) VALUES (N'a1b6cb13-952f-4807-9914-06c79a3bd852', N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54', N'aacc26c7-0fa1-48a6-87af-8bb1ceb7a319', 1)
INSERT [dbo].[HomeUsers] ([Id], [HomeId], [UserId], [IsNotificable]) VALUES (N'a4e682da-389e-4c8c-ab73-49f3ee3e40b3', N'6dc8be6d-9bc0-4b57-aa05-d346f383d298', N'6755fc8d-41d3-4ea5-b0f1-dad5d67b2f15', 0)
INSERT [dbo].[HomeUsers] ([Id], [HomeId], [UserId], [IsNotificable]) VALUES (N'e61bc4d1-3736-48d8-b839-9a1105bade8a', N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54', N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647', 1)
GO
INSERT [dbo].[Lamps] ([Id]) VALUES (N'7d3e6c23-194c-49cf-bf98-d5ae36ed16f4')
GO
INSERT [dbo].[MovementSensors] ([Id]) VALUES (N'1804f090-1a2e-4932-abca-d9ee5f16340f')
INSERT [dbo].[MovementSensors] ([Id]) VALUES (N'364de186-7a32-45d8-a4f8-988458e3395b')
GO
INSERT [dbo].[Notifications] ([Id], [Event], [HomeDeviceId], [IsRead], [Date], [HomeUserId], [Detail]) VALUES (N'2a12df6a-1438-4aa4-8ab7-e15e28f1e8d5', N'Window Open', N'9994a33d-f647-476f-867c-589b86bfdc7b', 0, N'21/11/2024', N'e61bc4d1-3736-48d8-b839-9a1105bade8a', N'Window state switch detected')
INSERT [dbo].[Notifications] ([Id], [Event], [HomeDeviceId], [IsRead], [Date], [HomeUserId], [Detail]) VALUES (N'2fa4abbe-0722-4962-868e-3c4a00b2ac0f', N'Window Closed', N'9994a33d-f647-476f-867c-589b86bfdc7b', 0, N'21/11/2024', N'e61bc4d1-3736-48d8-b839-9a1105bade8a', N'Window state switch detected')
INSERT [dbo].[Notifications] ([Id], [Event], [HomeDeviceId], [IsRead], [Date], [HomeUserId], [Detail]) VALUES (N'408db558-61cb-477b-82e2-8365f245c18e', N'Window Closed', N'9994a33d-f647-476f-867c-589b86bfdc7b', 1, N'21/11/2024', N'a1b6cb13-952f-4807-9914-06c79a3bd852', N'Window state switch detected')
INSERT [dbo].[Notifications] ([Id], [Event], [HomeDeviceId], [IsRead], [Date], [HomeUserId], [Detail]) VALUES (N'd5a89960-4bf3-4597-9ce1-ff06c745a312', N'Window Open', N'9994a33d-f647-476f-867c-589b86bfdc7b', 1, N'21/11/2024', N'a1b6cb13-952f-4807-9914-06c79a3bd852', N'Window state switch detected')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'AdminId', N'ADMINISTRATOR')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'CompanyOwnerId', N'COMPANYOWNER')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'HomeOwnerId', N'HOMEOWNER')
GO
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'0a17167d-6598-4d9c-a247-9b08fa9ebd7d', N'HomeOwnerId', N'16')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'0e0a0b76-70a6-4420-98e1-22faab5dfbf0', N'CompanyOwnerId', N'8')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'1bc8c721-ff01-4d46-b6ca-4416062d1756', N'AdminId', N'2')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'27a1c650-ce0c-425e-82e8-5de241cbec3c', N'AdminId', N'5')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'310fc077-226c-401e-9a14-a602ec1d3ad2', N'HomeOwnerId', N'11')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'3d2e86a6-aaa4-4dff-8b63-ad24e4d91ad7', N'CompanyOwnerId', N'6')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'4167abf7-702d-461b-82ee-28af5355a186', N'HomeOwnerId', N'9')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'55b51a82-4044-440c-9b0b-f7705e1ef0db', N'HomeOwnerId', N'15')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'55b96a30-2b1d-4304-bfb3-bc5fbd65cc25', N'AdminId', N'3')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'572516d1-beaa-4ca5-9a88-7cca9c852d30', N'AdminId', N'1')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'7bfbeb2b-8b07-4cd2-94f1-ea329db0d936', N'HomeOwnerId', N'14')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'8e3f7292-51ce-469b-ba80-4da5ff665a68', N'HomeOwnerId', N'10')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'8fb054cc-79bf-4d7a-8d69-a9c6d55fcc8b', N'HomeOwnerId', N'13')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'a22068a3-4dd2-4f59-b6b5-6c82eacd035f', N'CompanyOwnerId', N'7')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'ac982990-98e0-4394-9df2-48512b9127af', N'HomeOwnerId', N'12')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'b0d90a14-e545-41d3-a5f2-faca21acc63c', N'AdminId', N'4')
GO
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'039e5b26-80ee-4b85-801b-94a052f8e2d3', N'Cuarto 1', N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54')
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'32df6a52-6bc9-4433-a79f-93c1388b1a60', N'Cuarto', N'51152ed0-ad66-45f7-8863-61a80b40044a')
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'433eb002-49bf-4b54-826c-905eec72528a', N'Cocina', N'51152ed0-ad66-45f7-8863-61a80b40044a')
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'4b004eb3-7fbb-4347-83cf-72a19f00f54c', N'Cuarto de guille', N'aa98cab4-3f66-4be3-9e57-d2de7577492c')
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'7b373786-a963-42df-a0bc-fbe08f5899f4', N'Living', N'0ac032b9-e53c-438f-b1fd-c803c5aa1f54')
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'ab9bfb8e-5923-453f-b794-38ce12fc63bc', N'Cuarto del hermano de guille', N'aa98cab4-3f66-4be3-9e57-d2de7577492c')
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'ccb82021-c505-42e8-b500-e3a1a36504ef', N'Garage', N'aa98cab4-3f66-4be3-9e57-d2de7577492c')
INSERT [dbo].[Rooms] ([Id], [Name], [HomeId]) VALUES (N'f78b6467-50ff-4568-85a1-23c823ca93a2', N'Comedor', N'51152ed0-ad66-45f7-8863-61a80b40044a')
GO
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'2fe28fc7-d3b5-42c8-88cf-0e763bb9db16', N'acb9432a-91b9-408c-80c0-5f4858ebdef5', N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'5a937abc-4f83-4a2a-91ee-0bd174894dff', N'8a5c0c55-bb41-4196-9245-46c986d05923', N'aacc26c7-0fa1-48a6-87af-8bb1ceb7a319')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'69d0a298-f6a6-4ae9-ac7d-0baee8df52c2', N'2cbdd2ad-fb83-4da0-b19b-04bff3a97a03', N'903c2c3f-123a-4302-ba89-0dd6970794b3')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'989637ca-16c7-469b-a330-fe575c2206ac', N'6166f4d3-109b-4e0d-9223-6916040e86d7', N'6755fc8d-41d3-4ea5-b0f1-dad5d67b2f15')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'SeedAdminSessionId', N'SomeAdminToken123', N'SeedAdminId')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'SeedCompanyOwnerSessionId', N'SomeCompanyOwnerToken123', N'SeedCompanyOwnerId')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'SeedHomeOwnerSessionId', N'SomeHomeOwnerToken123', N'SeedHomeOwnerId')
GO
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'1', N'admins-Create')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'10', N'homes-UpdateMembersList')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'11', N'homes-UpdateHomeDevice')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'12', N'homes-ObtainMembers')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'13', N'homes-ObtainHomeDevices')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'14', N'homes-NotificatedMembers')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'15', N'notifications-ObtainNotifications')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'16', N'notifications-UpdateNotification')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'2', N'admins-Delete')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'3', N'admins-AllAccounts')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'4', N'company-owners-Create')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'5', N'homes-ObtainCompanies')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'6', N'companies-Create')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'7', N'devices-RegisterCamera')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'8', N'companies-RegisterSensor')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'9', N'homes-Create')
GO
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'022da7dd-6f76-47f2-8b26-e70c03dee423', N'HomeOwnerId', N'SeedHomeOwnerId')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'23036a55-26cb-465a-8798-97efc0a6c13d', N'CompanyOwnerId', N'SeedCompanyOwnerId')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'23b5c9a5-2a51-443a-929f-201fe327dae8', N'CompanyOwnerId', N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'4f8beffb-0553-4cb7-a6a4-d02436ac222c', N'HomeOwnerId', N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'69e86832-c809-4774-982e-4eef38051ae4', N'HomeOwnerId', N'6755fc8d-41d3-4ea5-b0f1-dad5d67b2f15')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'7793a6e8-f265-4d01-8f17-20786c9aa6e1', N'CompanyOwnerId', N'903c2c3f-123a-4302-ba89-0dd6970794b3')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'7917f645-d7bb-40c6-8cc3-7ddb040ff5f3', N'AdminId', NULL)
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'ad6e86cc-73de-40c4-af98-2a351a276e93', N'AdminId', N'6755fc8d-41d3-4ea5-b0f1-dad5d67b2f15')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'b391d804-8daf-4df0-919e-755b0df9e9ba', N'AdminId', N'SeedAdminId')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'ba055bd9-8fc8-4b00-b2ac-1a0d79d90ebc', N'AdminId', N'0d6f54b8-1ca6-4cc8-a994-6d9ae7433d39')
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'c63957a7-1870-4722-9a8d-b4b2e0936bd6', N'HomeOwnerId', N'aacc26c7-0fa1-48a6-87af-8bb1ceb7a319')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'0d6f54b8-1ca6-4cc8-a994-6d9ae7433d39', N'Guille', N'guille@mail.com', N'123456!', N'G', NULL, N'20/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'6755fc8d-41d3-4ea5-b0f1-dad5d67b2f15', N'Admin w/ home', N'adminhome@mail.com', N'123456!', N'Home', N'https://assets.goal.com/images/v3/bltd9bceaaf9b0cbc21/Carlos_Tevez_Manchester_City.jpg?auto=webp&format=pjpg&width=3840&quality=60', N'21/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'8ff2afc9-8ce6-4c52-8cad-6e09dc707647', N'Lucas', N'lucas@mail.com', N'123456!', N'L', N'https://www.peñarol.org/imgnoticias/202408/W450/26777.jpg', N'21/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'903c2c3f-123a-4302-ba89-0dd6970794b3', N'Nico', N'nico@mail.com', N'123456!', N'N', NULL, N'20/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'aacc26c7-0fa1-48a6-87af-8bb1ceb7a319', N'juan', N'juan@mail.com', N'123456!', N'angular', N'https://peopleenespanol.com/thmb/EAunwX-MJ2hGU9VX5xi3zzuT4Ms=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/rs_ernie-2-70e8ad45f2474312a8f912c8d3bcb41d.jpg', N'20/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'SeedAdminId', N'Admin', N'admin@domain.com', N'.Popso212', N'LastName', NULL, N'19/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'SeedCompanyOwnerId', N'CompanyOwner', N'companyowner@domain.com', N'.Popso212', N'LastName', NULL, N'19/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'SeedHomeOwnerId', N'Homeowner', N'homeowner@domain.com', N'.Popso212', N'LastName', N'picture', N'19/11/2024')
GO
INSERT [dbo].[WindowSensors] ([Id]) VALUES (N'68eb367b-4be3-4687-ae41-2b413d950849')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Companies_OwnerId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Companies_OwnerId] ON [dbo].[Companies]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Devices_CompanyId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_Devices_CompanyId] ON [dbo].[Devices]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_DeviceId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_DeviceId] ON [dbo].[HomeDevices]
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_HomeId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_HomeId] ON [dbo].[HomeDevices]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_RoomId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_RoomId] ON [dbo].[HomeDevices]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Homes_OwnerId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_Homes_OwnerId] ON [dbo].[Homes]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomePermissionId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomePermissionId] ON [dbo].[HomeUserHomePermission]
(
	[HomePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomeUserId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomeUserId] ON [dbo].[HomeUserHomePermission]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_HomeId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_HomeId] ON [dbo].[HomeUsers]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_UserId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_UserId] ON [dbo].[HomeUsers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeDeviceId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeDeviceId] ON [dbo].[Notifications]
(
	[HomeDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeUserId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeUserId] ON [dbo].[Notifications]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_PermissionId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_PermissionId] ON [dbo].[RoleSystemPermissions]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_RoleId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_RoleId] ON [dbo].[RoleSystemPermissions]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Rooms_HomeId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_Rooms_HomeId] ON [dbo].[Rooms]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Sessions_UserId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_UserId] ON [dbo].[Sessions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 21/11/2024 1:01:30 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_Users_Id]
GO
ALTER TABLE [dbo].[Cameras]  WITH CHECK ADD  CONSTRAINT [FK_Cameras_Devices_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Devices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cameras] CHECK CONSTRAINT [FK_Cameras_Devices_Id]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_CompanyOwners_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[CompanyOwners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_CompanyOwners_OwnerId]
GO
ALTER TABLE [dbo].[CompanyOwners]  WITH CHECK ADD  CONSTRAINT [FK_CompanyOwners_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyOwners] CHECK CONSTRAINT [FK_CompanyOwners_Users_Id]
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_Devices_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_Devices_Companies_CompanyId]
GO
ALTER TABLE [dbo].[HomeDevices]  WITH CHECK ADD  CONSTRAINT [FK_HomeDevices_Devices_DeviceId] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Devices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HomeDevices] CHECK CONSTRAINT [FK_HomeDevices_Devices_DeviceId]
GO
ALTER TABLE [dbo].[HomeDevices]  WITH CHECK ADD  CONSTRAINT [FK_HomeDevices_Homes_HomeId] FOREIGN KEY([HomeId])
REFERENCES [dbo].[Homes] ([Id])
GO
ALTER TABLE [dbo].[HomeDevices] CHECK CONSTRAINT [FK_HomeDevices_Homes_HomeId]
GO
ALTER TABLE [dbo].[HomeDevices]  WITH CHECK ADD  CONSTRAINT [FK_HomeDevices_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[HomeDevices] CHECK CONSTRAINT [FK_HomeDevices_Rooms_RoomId]
GO
ALTER TABLE [dbo].[HomeOwners]  WITH CHECK ADD  CONSTRAINT [FK_HomeOwners_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HomeOwners] CHECK CONSTRAINT [FK_HomeOwners_Users_Id]
GO
ALTER TABLE [dbo].[Homes]  WITH CHECK ADD  CONSTRAINT [FK_Homes_Users_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Homes] CHECK CONSTRAINT [FK_Homes_Users_OwnerId]
GO
ALTER TABLE [dbo].[HomeUserHomePermission]  WITH CHECK ADD  CONSTRAINT [FK_HomeUserHomePermission_HomePermission_HomePermissionId] FOREIGN KEY([HomePermissionId])
REFERENCES [dbo].[HomePermission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HomeUserHomePermission] CHECK CONSTRAINT [FK_HomeUserHomePermission_HomePermission_HomePermissionId]
GO
ALTER TABLE [dbo].[HomeUserHomePermission]  WITH CHECK ADD  CONSTRAINT [FK_HomeUserHomePermission_HomeUsers_HomeUserId] FOREIGN KEY([HomeUserId])
REFERENCES [dbo].[HomeUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HomeUserHomePermission] CHECK CONSTRAINT [FK_HomeUserHomePermission_HomeUsers_HomeUserId]
GO
ALTER TABLE [dbo].[HomeUsers]  WITH CHECK ADD  CONSTRAINT [FK_HomeUsers_Homes_HomeId] FOREIGN KEY([HomeId])
REFERENCES [dbo].[Homes] ([Id])
GO
ALTER TABLE [dbo].[HomeUsers] CHECK CONSTRAINT [FK_HomeUsers_Homes_HomeId]
GO
ALTER TABLE [dbo].[HomeUsers]  WITH CHECK ADD  CONSTRAINT [FK_HomeUsers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[HomeUsers] CHECK CONSTRAINT [FK_HomeUsers_Users_UserId]
GO
ALTER TABLE [dbo].[Lamps]  WITH CHECK ADD  CONSTRAINT [FK_Lamps_Devices_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Devices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lamps] CHECK CONSTRAINT [FK_Lamps_Devices_Id]
GO
ALTER TABLE [dbo].[MovementSensors]  WITH CHECK ADD  CONSTRAINT [FK_MovementSensors_Devices_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Devices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovementSensors] CHECK CONSTRAINT [FK_MovementSensors_Devices_Id]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_HomeDevices_HomeDeviceId] FOREIGN KEY([HomeDeviceId])
REFERENCES [dbo].[HomeDevices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_HomeDevices_HomeDeviceId]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_HomeUsers_HomeUserId] FOREIGN KEY([HomeUserId])
REFERENCES [dbo].[HomeUsers] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_HomeUsers_HomeUserId]
GO
ALTER TABLE [dbo].[RoleSystemPermissions]  WITH CHECK ADD  CONSTRAINT [FK_RoleSystemPermissions_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RoleSystemPermissions] CHECK CONSTRAINT [FK_RoleSystemPermissions_Roles_RoleId]
GO
ALTER TABLE [dbo].[RoleSystemPermissions]  WITH CHECK ADD  CONSTRAINT [FK_RoleSystemPermissions_SystemPermissions_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[SystemPermissions] ([Id])
GO
ALTER TABLE [dbo].[RoleSystemPermissions] CHECK CONSTRAINT [FK_RoleSystemPermissions_SystemPermissions_PermissionId]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Homes_HomeId] FOREIGN KEY([HomeId])
REFERENCES [dbo].[Homes] ([Id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Homes_HomeId]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[WindowSensors]  WITH CHECK ADD  CONSTRAINT [FK_WindowSensors_Devices_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Devices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WindowSensors] CHECK CONSTRAINT [FK_WindowSensors_Devices_Id]
GO
USE [master]
GO
ALTER DATABASE [Homify] SET  READ_WRITE 
GO
