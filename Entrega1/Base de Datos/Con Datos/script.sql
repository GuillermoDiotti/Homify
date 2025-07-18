USE [master]
GO
/****** Object:  Database [Homify]    Script Date: 5/10/2024 23:37:42 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[Admins]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[Cameras]    Script Date: 5/10/2024 23:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cameras](
	[Id] [nvarchar](450) NOT NULL,
	[IsExterior] [bit] NOT NULL,
	[IsInterior] [bit] NOT NULL,
 CONSTRAINT [PK_Cameras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 5/10/2024 23:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [nvarchar](450) NOT NULL,
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
/****** Object:  Table [dbo].[CompanyOwners]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[Devices]    Script Date: 5/10/2024 23:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Photos] [nvarchar](max) NOT NULL,
	[PpalPicture] [nvarchar](max) NULL,
	[CompanyId] [nvarchar](450) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[MovementDetection] [bit] NOT NULL,
	[PeopleDetection] [bit] NOT NULL,
	[WindowDetection] [bit] NOT NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeDevices]    Script Date: 5/10/2024 23:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeDevices](
	[HomeId] [nvarchar](450) NOT NULL,
	[DeviceId] [nvarchar](450) NOT NULL,
	[Connected] [bit] NOT NULL,
	[HardwareId] [nvarchar](max) NOT NULL,
	[Id] [nvarchar](450) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_HomeDevices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeOwners]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[HomePermission]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[Homes]    Script Date: 5/10/2024 23:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Homes](
	[Id] [nvarchar](450) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
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
/****** Object:  Table [dbo].[HomeUserHomePermission]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[HomeUsers]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[Notifications]    Script Date: 5/10/2024 23:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [nvarchar](450) NOT NULL,
	[Event] [nvarchar](max) NULL,
	[IsRead] [bit] NOT NULL,
	[Date] [datetimeoffset](7) NULL,
	[HomeDeviceId] [nvarchar](450) NOT NULL,
	[Detail] [nvarchar](max) NULL,
	[HomeUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[RoleSystemPermissions]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[Sensors]    Script Date: 5/10/2024 23:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sensors](
	[Id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Sensors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[SystemPermissions]    Script Date: 5/10/2024 23:37:43 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 5/10/2024 23:37:43 ******/
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
	[RoleId] [nvarchar](450) NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003174738_MigrationFixx', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241004000407_SessionSeed', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241004001705_HomeDeviceFix', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241004014503_UserPhoto', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241004134945_DeviceType', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241004143711_NotificationHomeUserId', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241004151503_DeviceProps', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241004153821_HomeDeviceProps', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241005045729_NotificationDetail', N'8.0.8')
GO
INSERT [dbo].[Admins] ([Id]) VALUES (N'SeedAdminId')
GO
INSERT [dbo].[Cameras] ([Id], [IsExterior], [IsInterior]) VALUES (N'b6eb344b-ff03-44ae-9e28-6ebf99485561', 1, 0)
GO
INSERT [dbo].[Companies] ([Id], [Name], [LogoUrl], [Rut], [OwnerId]) VALUES (N'3077b18c-bd80-4d9d-9d4c-f57b8c93ac93', N'Empresa1', N'./logo.jpg', N'12345', N'SeedCompanyOwnerId')
GO
INSERT [dbo].[CompanyOwners] ([Id], [IsIncomplete]) VALUES (N'225d6e27-c73b-4967-9aa3-774b359a35ac', 1)
INSERT [dbo].[CompanyOwners] ([Id], [IsIncomplete]) VALUES (N'SeedCompanyOwnerId', 0)
GO
INSERT [dbo].[Devices] ([Id], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [Type], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'9ae6834e-f0f6-4d2b-9e63-cfa613e371a4', N'Sensor', N'1234', N'sensor de afuera', N'["foto1","foto2"]', N'foto1', N'3077b18c-bd80-4d9d-9d4c-f57b8c93ac93', N'SENSOR', 0, 0, 1)
INSERT [dbo].[Devices] ([Id], [Name], [Model], [Description], [Photos], [PpalPicture], [CompanyId], [Type], [MovementDetection], [PeopleDetection], [WindowDetection]) VALUES (N'b6eb344b-ff03-44ae-9e28-6ebf99485561', N'Camara', N'1234', N'camara de afuera', N'["foto1","foto2"]', N'foto1', N'3077b18c-bd80-4d9d-9d4c-f57b8c93ac93', N'CAMERA', 1, 1, 0)
GO
INSERT [dbo].[HomeDevices] ([HomeId], [DeviceId], [Connected], [HardwareId], [Id], [IsActive]) VALUES (N'51b8b67d-1d85-4d83-85d1-621174175f52', N'b6eb344b-ff03-44ae-9e28-6ebf99485561', 1, N'297e528f-b615-42b4-93cb-c2fd1598ba43', N'300a08ce-cff2-4eb5-8582-e983eebdefb3', 1)
INSERT [dbo].[HomeDevices] ([HomeId], [DeviceId], [Connected], [HardwareId], [Id], [IsActive]) VALUES (N'7cae7aef-e3cb-48e4-8f84-59201ef5e715', N'b6eb344b-ff03-44ae-9e28-6ebf99485561', 1, N'3a83e826-09c0-40a7-b23a-926250efc45c', N'57476ff1-27a5-4999-84cc-1b2853bcfaf9', 1)
INSERT [dbo].[HomeDevices] ([HomeId], [DeviceId], [Connected], [HardwareId], [Id], [IsActive]) VALUES (N'7cae7aef-e3cb-48e4-8f84-59201ef5e715', N'9ae6834e-f0f6-4d2b-9e63-cfa613e371a4', 1, N'758b1f96-e833-4e7a-b439-22f15cee8f10', N'b01f75e5-25f2-4834-9467-8ac71bdae346', 1)
GO
INSERT [dbo].[HomeOwners] ([Id]) VALUES (N'4087d055-156d-498a-b348-acd0edb387ce')
INSERT [dbo].[HomeOwners] ([Id]) VALUES (N'98d98f28-9d82-4a15-b2cb-2457591c6f22')
INSERT [dbo].[HomeOwners] ([Id]) VALUES (N'SeedHomeOwnerId')
GO
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'2', N'AddDevices')
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'3', N'ListDevices')
GO
INSERT [dbo].[Homes] ([Id], [Street], [Number], [Latitude], [Longitude], [MaxMembers], [OwnerId]) VALUES (N'51b8b67d-1d85-4d83-85d1-621174175f52', N'Calle 2', N'20', N'23523', N'15124', 1, N'SeedHomeOwnerId')
INSERT [dbo].[Homes] ([Id], [Street], [Number], [Latitude], [Longitude], [MaxMembers], [OwnerId]) VALUES (N'7cae7aef-e3cb-48e4-8f84-59201ef5e715', N'Calle 5', N'201', N'23', N'15', 5, N'SeedHomeOwnerId')
GO
INSERT [dbo].[HomeUserHomePermission] ([Id], [HomeUserId], [HomePermissionId]) VALUES (N'95aad0c1-48c3-43a3-9564-36f063ba629f', N'49def461-5475-42f1-9bf1-5704b3bbfb15', N'2')
GO
INSERT [dbo].[HomeUsers] ([Id], [HomeId], [UserId], [IsNotificable]) VALUES (N'49def461-5475-42f1-9bf1-5704b3bbfb15', N'51b8b67d-1d85-4d83-85d1-621174175f52', N'98d98f28-9d82-4a15-b2cb-2457591c6f22', 0)
INSERT [dbo].[HomeUsers] ([Id], [HomeId], [UserId], [IsNotificable]) VALUES (N'80e0bd59-39cd-46a8-8574-3d9f9c415ca3', N'7cae7aef-e3cb-48e4-8f84-59201ef5e715', N'4087d055-156d-498a-b348-acd0edb387ce', 0)
INSERT [dbo].[HomeUsers] ([Id], [HomeId], [UserId], [IsNotificable]) VALUES (N'8b093e37-a833-4b91-978e-8a6227466246', N'7cae7aef-e3cb-48e4-8f84-59201ef5e715', N'98d98f28-9d82-4a15-b2cb-2457591c6f22', 1)
GO
INSERT [dbo].[Notifications] ([Id], [Event], [IsRead], [Date], [HomeDeviceId], [Detail], [HomeUserId]) VALUES (N'220e0a71-3e45-4b06-84d6-30ff1fbc9e49', N'Movement detected in home', 1, CAST(N'2024-10-05T13:28:09.9739869-03:00' AS DateTimeOffset), N'57476ff1-27a5-4999-84cc-1b2853bcfaf9', N'Movimiento en pasillo', N'8b093e37-a833-4b91-978e-8a6227466246')
INSERT [dbo].[Notifications] ([Id], [Event], [IsRead], [Date], [HomeDeviceId], [Detail], [HomeUserId]) VALUES (N'415578bb-d8a8-493e-93b8-f6a96a9628ca', N'Person Detected', 1, CAST(N'2024-10-05T13:37:01.2980908-03:00' AS DateTimeOffset), N'57476ff1-27a5-4999-84cc-1b2853bcfaf9', N'Lionel Messi', N'8b093e37-a833-4b91-978e-8a6227466246')
INSERT [dbo].[Notifications] ([Id], [Event], [IsRead], [Date], [HomeDeviceId], [Detail], [HomeUserId]) VALUES (N'96e1515c-dbc0-4f14-852b-53cc3e67ccde', N'Window state switch detected', 0, CAST(N'2024-10-05T13:34:57.2830089-03:00' AS DateTimeOffset), N'b01f75e5-25f2-4834-9467-8ac71bdae346', N'La ventana se ha cerrado', N'8b093e37-a833-4b91-978e-8a6227466246')
INSERT [dbo].[Notifications] ([Id], [Event], [IsRead], [Date], [HomeDeviceId], [Detail], [HomeUserId]) VALUES (N'e443950a-d69c-4c07-b4ad-7dfee6e03b9e', N'Window state switch detected', 0, CAST(N'2024-10-05T13:35:14.0781146-03:00' AS DateTimeOffset), N'b01f75e5-25f2-4834-9467-8ac71bdae346', NULL, N'8b093e37-a833-4b91-978e-8a6227466246')
INSERT [dbo].[Notifications] ([Id], [Event], [IsRead], [Date], [HomeDeviceId], [Detail], [HomeUserId]) VALUES (N'e5fed8db-57f4-438d-8db8-a90a511c9ead', N'Person Detected', 0, CAST(N'2024-10-05T13:36:29.6832991-03:00' AS DateTimeOffset), N'57476ff1-27a5-4999-84cc-1b2853bcfaf9', NULL, N'8b093e37-a833-4b91-978e-8a6227466246')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'AdminId', N'ADMINISTRATOR')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'CompanyOwnerId', N'COMPANYOWNER')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'HomeOwnerId', N'HOMEOWNER')
GO
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'02401a72-c0d9-49a2-8454-61ff1a6c1fee', N'CompanyOwnerId', N'6')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'024faf50-abc4-4146-9272-70a0ae68dec0', N'HomeOwnerId', N'17')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'0a488e5c-c2fd-43e1-a1b5-d055033f12fd', N'HomeOwnerId', N'16')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'0c49ec80-82b9-4bb2-8b42-4599ff2b50fb', N'CompanyOwnerId', N'7')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'2bf6d901-b1e7-4f82-9082-a41379eef878', N'AdminId', N'4')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'2f0089a9-9d8f-488f-b4b1-0293fcba5cf9', N'HomeOwnerId', N'15')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'300f6b32-cfac-428d-a018-20a41078c5d4', N'AdminId', N'2')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'39a2ab93-500e-4402-b424-7b1b226a0fd8', N'HomeOwnerId', N'19')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'553e4616-bff1-4b28-b128-e1147e97b279', N'HomeOwnerId', N'10')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'6145cf18-ee41-4306-aad9-38619d6d25ff', N'HomeOwnerId', N'13')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'6a157f9b-07a7-4e4d-b6d4-ac305c6e5492', N'HomeOwnerId', N'9')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'6a3950b7-c773-4281-b491-ff4e2bc03200', N'CompanyOwnerId', N'8')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'6c53daea-ef6a-498f-ac32-a5ec2be12a1d', N'AdminId', N'1')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'6dd98b4b-1e66-46cf-8557-caec32e62e18', N'AdminId', N'5')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'7520b7a3-0512-472f-81c7-95648a82ffe2', N'HomeOwnerId', N'12')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'7b10d490-5c89-4a39-b2d4-d0fab18990d7', N'AdminId', N'3')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'93bcca9c-015d-4aaa-8a5a-39b7b3647b79', N'HomeOwnerId', N'14')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'acfc31ff-8821-409c-af38-a67e97542515', N'HomeOwnerId', N'18')
INSERT [dbo].[RoleSystemPermissions] ([RoleSystemPermissionId], [RoleId], [PermissionId]) VALUES (N'aead5c08-fb7b-4b9e-a7f3-018a7528d84b', N'HomeOwnerId', N'11')
GO
INSERT [dbo].[Sensors] ([Id]) VALUES (N'9ae6834e-f0f6-4d2b-9e63-cfa613e371a4')
GO
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'7865f9ce-f69a-4030-8a9c-af4d64125e51', N'3c1e0f54-3a1a-43cd-8ff6-7f306b861a95', N'4087d055-156d-498a-b348-acd0edb387ce')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'872a6366-f33c-4c3f-b29a-14c7c1359845', N'4ebf2fac-c041-402e-9308-38d7262c3792', N'98d98f28-9d82-4a15-b2cb-2457591c6f22')
INSERT [dbo].[Sessions] ([Id], [AuthToken], [UserId]) VALUES (N'8f912843-f801-49b6-97e8-1a7172038733', N'7a332c45-f7cc-4f90-90c4-ff1f91c02c3f', N'225d6e27-c73b-4967-9aa3-774b359a35ac')
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
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'17', N'devices-ViewRegistered')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'18', N'companies-ViewSupported')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'19', N'notifications-Create')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'2', N'admins-Delete')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'3', N'admins-AllAccounts')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'4', N'company-owners-Create')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'5', N'homes-ObtainCompanies')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'6', N'companies-Create')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'7', N'devices-RegisterCamera')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'8', N'companies-RegisterSensor')
INSERT [dbo].[SystemPermissions] ([Id], [Value]) VALUES (N'9', N'homes-Create')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [RoleId], [CreatedAt], [ProfilePicture]) VALUES (N'225d6e27-c73b-4967-9aa3-774b359a35ac', N'Lionel', N'lionel@gmail.com', N'Password!', N'Messi', N'CompanyOwnerId', CAST(N'2024-10-05T11:47:10.0491769-03:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [RoleId], [CreatedAt], [ProfilePicture]) VALUES (N'4087d055-156d-498a-b348-acd0edb387ce', N'franco', N'franco@gmail.com', N'Password!', N'Suarez', N'HomeOwnerId', CAST(N'2024-10-05T12:25:19.5954768-03:00' AS DateTimeOffset), N'./hola.jpg')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [RoleId], [CreatedAt], [ProfilePicture]) VALUES (N'98d98f28-9d82-4a15-b2cb-2457591c6f22', N'Luis', N'luis@gmail.com', N'Password!', N'Suarez', N'HomeOwnerId', CAST(N'2024-10-05T11:52:58.3250031-03:00' AS DateTimeOffset), N'./hola.jpg')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [RoleId], [CreatedAt], [ProfilePicture]) VALUES (N'SeedAdminId', N'Admin', N'admin@domain.com', N'.Popso212', N'LastName', N'AdminId', CAST(N'2024-10-05T04:57:28.4654505+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [RoleId], [CreatedAt], [ProfilePicture]) VALUES (N'SeedCompanyOwnerId', N'CompanyOwner', N'companyowner@domain.com', N'.Popso212', N'LastName', N'CompanyOwnerId', CAST(N'2024-10-05T04:57:28.4654525+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [RoleId], [CreatedAt], [ProfilePicture]) VALUES (N'SeedHomeOwnerId', N'Homeowner', N'homeowner@domain.com', N'.Popso212', N'LastName', N'HomeOwnerId', CAST(N'2024-10-05T04:57:28.4654516+00:00' AS DateTimeOffset), N'picture')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Companies_OwnerId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Companies_OwnerId] ON [dbo].[Companies]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Devices_CompanyId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_Devices_CompanyId] ON [dbo].[Devices]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_DeviceId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_DeviceId] ON [dbo].[HomeDevices]
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_HomeId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_HomeId] ON [dbo].[HomeDevices]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Homes_OwnerId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_Homes_OwnerId] ON [dbo].[Homes]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomePermissionId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomePermissionId] ON [dbo].[HomeUserHomePermission]
(
	[HomePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomeUserId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomeUserId] ON [dbo].[HomeUserHomePermission]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_HomeId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_HomeId] ON [dbo].[HomeUsers]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_UserId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_UserId] ON [dbo].[HomeUsers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeDeviceId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeDeviceId] ON [dbo].[Notifications]
(
	[HomeDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeUserId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeUserId] ON [dbo].[Notifications]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_PermissionId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_PermissionId] ON [dbo].[RoleSystemPermissions]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_RoleId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_RoleId] ON [dbo].[RoleSystemPermissions]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Sessions_UserId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_UserId] ON [dbo].[Sessions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 5/10/2024 23:37:43 ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Devices] ADD  DEFAULT (CONVERT([bit],(0))) FOR [MovementDetection]
GO
ALTER TABLE [dbo].[Devices] ADD  DEFAULT (CONVERT([bit],(0))) FOR [PeopleDetection]
GO
ALTER TABLE [dbo].[Devices] ADD  DEFAULT (CONVERT([bit],(0))) FOR [WindowDetection]
GO
ALTER TABLE [dbo].[HomeDevices] ADD  DEFAULT (N'') FOR [Id]
GO
ALTER TABLE [dbo].[HomeDevices] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT (N'') FOR [HomeDeviceId]
GO
ALTER TABLE [dbo].[Sessions] ADD  DEFAULT (N'') FOR [UserId]
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
ALTER TABLE [dbo].[HomeOwners]  WITH CHECK ADD  CONSTRAINT [FK_HomeOwners_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HomeOwners] CHECK CONSTRAINT [FK_HomeOwners_Users_Id]
GO
ALTER TABLE [dbo].[Homes]  WITH CHECK ADD  CONSTRAINT [FK_Homes_HomeOwners_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[HomeOwners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Homes] CHECK CONSTRAINT [FK_Homes_HomeOwners_OwnerId]
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
ALTER TABLE [dbo].[Sensors]  WITH CHECK ADD  CONSTRAINT [FK_Sensors_Devices_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Devices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sensors] CHECK CONSTRAINT [FK_Sensors_Devices_Id]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [Homify] SET  READ_WRITE 
GO
