USE [master]
GO
/****** Object:  Database [Homify]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Admins]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Cameras]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Companies]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[CompanyOwners]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Devices]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[HomeDevices]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[HomeOwners]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[HomePermission]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Homes]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[HomeUserHomePermission]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[HomeUsers]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Notifications]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[RoleSystemPermissions]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Sensors]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[SystemPermissions]    Script Date: 5/10/2024 23:52:49 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 5/10/2024 23:52:49 ******/
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
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Companies_OwnerId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Companies_OwnerId] ON [dbo].[Companies]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Devices_CompanyId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_Devices_CompanyId] ON [dbo].[Devices]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_DeviceId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_DeviceId] ON [dbo].[HomeDevices]
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_HomeId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_HomeId] ON [dbo].[HomeDevices]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Homes_OwnerId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_Homes_OwnerId] ON [dbo].[Homes]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomePermissionId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomePermissionId] ON [dbo].[HomeUserHomePermission]
(
	[HomePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomeUserId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomeUserId] ON [dbo].[HomeUserHomePermission]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_HomeId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_HomeId] ON [dbo].[HomeUsers]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_UserId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_UserId] ON [dbo].[HomeUsers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeDeviceId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeDeviceId] ON [dbo].[Notifications]
(
	[HomeDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeUserId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeUserId] ON [dbo].[Notifications]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_PermissionId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_PermissionId] ON [dbo].[RoleSystemPermissions]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_RoleId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_RoleId] ON [dbo].[RoleSystemPermissions]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Sessions_UserId]    Script Date: 5/10/2024 23:52:49 ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_UserId] ON [dbo].[Sessions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 5/10/2024 23:52:49 ******/
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
