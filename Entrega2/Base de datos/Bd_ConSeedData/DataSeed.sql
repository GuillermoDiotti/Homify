USE [master]
GO
/****** Object:  Database [Homify]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Admins]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Cameras]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Companies]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[CompanyOwners]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Devices]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[HomeDevices]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[HomeOwners]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[HomePermission]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Homes]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[HomeUserHomePermission]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[HomeUsers]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Lamps]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[MovementSensors]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Notifications]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[RoleSystemPermissions]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Rooms]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[SystemPermissions]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[UserRoles]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 21/11/2024 1:55:47 ******/
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
/****** Object:  Table [dbo].[WindowSensors]    Script Date: 21/11/2024 1:55:47 ******/
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
INSERT [dbo].[Admins] ([Id]) VALUES (N'SeedAdminId')
GO
INSERT [dbo].[CompanyOwners] ([Id], [IsIncomplete]) VALUES (N'SeedCompanyOwnerId', 1)
GO
INSERT [dbo].[HomeOwners] ([Id]) VALUES (N'SeedHomeOwnerId')
GO
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'1', N'AddDevices')
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'2', N'ListDevices')
INSERT [dbo].[HomePermission] ([Id], [Value]) VALUES (N'3', N'ChangeDeviceName')
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
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (N'b391d804-8daf-4df0-919e-755b0df9e9ba', N'AdminId', N'SeedAdminId')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'SeedAdminId', N'Admin', N'admin@domain.com', N'.Popso212', N'LastName', NULL, N'19/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'SeedCompanyOwnerId', N'CompanyOwner', N'companyowner@domain.com', N'.Popso212', N'LastName', NULL, N'19/11/2024')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [LastName], [ProfilePicture], [CreatedAt]) VALUES (N'SeedHomeOwnerId', N'Homeowner', N'homeowner@domain.com', N'.Popso212', N'LastName', N'picture', N'19/11/2024')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Companies_OwnerId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Companies_OwnerId] ON [dbo].[Companies]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Devices_CompanyId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_Devices_CompanyId] ON [dbo].[Devices]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_DeviceId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_DeviceId] ON [dbo].[HomeDevices]
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_HomeId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_HomeId] ON [dbo].[HomeDevices]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeDevices_RoomId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_HomeDevices_RoomId] ON [dbo].[HomeDevices]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Homes_OwnerId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_Homes_OwnerId] ON [dbo].[Homes]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomePermissionId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomePermissionId] ON [dbo].[HomeUserHomePermission]
(
	[HomePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUserHomePermission_HomeUserId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUserHomePermission_HomeUserId] ON [dbo].[HomeUserHomePermission]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_HomeId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_HomeId] ON [dbo].[HomeUsers]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HomeUsers_UserId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_HomeUsers_UserId] ON [dbo].[HomeUsers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeDeviceId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeDeviceId] ON [dbo].[Notifications]
(
	[HomeDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notifications_HomeUserId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_HomeUserId] ON [dbo].[Notifications]
(
	[HomeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_PermissionId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_PermissionId] ON [dbo].[RoleSystemPermissions]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleSystemPermissions_RoleId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_RoleSystemPermissions_RoleId] ON [dbo].[RoleSystemPermissions]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Rooms_HomeId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_Rooms_HomeId] ON [dbo].[Rooms]
(
	[HomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Sessions_UserId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_UserId] ON [dbo].[Sessions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 21/11/2024 1:55:47 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 21/11/2024 1:55:47 ******/
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
