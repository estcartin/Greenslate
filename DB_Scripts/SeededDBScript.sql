USE [master]
GO
/****** Object:  Database [Greenslate]    Script Date: 15-Dec-19 7:17:02 PM ******/
CREATE DATABASE [Greenslate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Greenslate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Greenslate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Greenslate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Greenslate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Greenslate] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Greenslate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Greenslate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Greenslate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Greenslate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Greenslate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Greenslate] SET ARITHABORT OFF 
GO
ALTER DATABASE [Greenslate] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Greenslate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Greenslate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Greenslate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Greenslate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Greenslate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Greenslate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Greenslate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Greenslate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Greenslate] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Greenslate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Greenslate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Greenslate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Greenslate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Greenslate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Greenslate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Greenslate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Greenslate] SET RECOVERY FULL 
GO
ALTER DATABASE [Greenslate] SET  MULTI_USER 
GO
ALTER DATABASE [Greenslate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Greenslate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Greenslate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Greenslate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Greenslate] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Greenslate', N'ON'
GO
ALTER DATABASE [Greenslate] SET QUERY_STORE = OFF
GO
USE [Greenslate]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 15-Dec-19 7:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Credits] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15-Dec-19 7:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProject]    Script Date: 15-Dec-19 7:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProject](
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[AssignedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (1, CAST(N'2019-10-29T00:00:00.000' AS DateTime), CAST(N'2020-10-29T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (2, CAST(N'2019-09-30T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (3, CAST(N'2018-03-05T00:00:00.000' AS DateTime), CAST(N'2020-12-31T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (4, CAST(N'2017-05-05T00:00:00.000' AS DateTime), CAST(N'2030-01-01T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (5, CAST(N'2010-06-30T00:00:00.000' AS DateTime), CAST(N'2022-01-31T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (6, CAST(N'2012-11-11T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (7, CAST(N'2009-10-13T00:00:00.000' AS DateTime), CAST(N'2020-02-01T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (8, CAST(N'2005-09-26T00:00:00.000' AS DateTime), CAST(N'2009-10-09T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (9, CAST(N'2000-10-10T00:00:00.000' AS DateTime), CAST(N'2030-10-10T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (10, CAST(N'2003-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-01T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (1, N'Esteban', N'Varela')
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (2, N'Alex', N'Ujueta')
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (3, N'Carlos', N'Mendez')
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 1, 1, CAST(N'2010-11-30T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 3, 0, CAST(N'2019-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 5, 1, CAST(N'2011-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 7, 1, CAST(N'2009-10-13T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 9, 0, CAST(N'2001-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (2, 2, 1, CAST(N'2019-10-30T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (2, 4, 1, CAST(N'2018-05-05T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (2, 6, 0, CAST(N'2012-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (2, 8, 1, CAST(N'2006-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (2, 10, 0, CAST(N'2002-08-16T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (3, 3, 1, CAST(N'2018-03-06T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (3, 4, 1, CAST(N'2016-03-06T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (3, 5, 0, CAST(N'2011-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (3, 6, 0, CAST(N'2013-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (3, 7, 1, CAST(N'2014-01-01T00:00:00.000' AS DateTime))
ALTER TABLE [dbo].[UserProject]  WITH CHECK ADD  CONSTRAINT [FK_UserProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[UserProject] CHECK CONSTRAINT [FK_UserProject_Project]
GO
ALTER TABLE [dbo].[UserProject]  WITH CHECK ADD  CONSTRAINT [FK_UserProject_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserProject] CHECK CONSTRAINT [FK_UserProject_User]
GO
/****** Object:  StoredProcedure [dbo].[GetUserProjectData]    Script Date: 15-Dec-19 7:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserProjectData] @UserId int
AS
SELECT	Project.Id AS 'ProjectId', 
		Project.StartDate AS 'StartDate',
		CASE 
			WHEN DATEDIFF(DAY, Project.StartDate, UserProject.AssignedDate) >= 0 
			THEN CONVERT(VARCHAR(11), DATEDIFF(DAY, Project.StartDate, UserProject.AssignedDate)) 
			ELSE 'Started' END AS 'TimeToStart',
		Project.EndDate AS 'EndDate',
		Project.Credits,
		CASE WHEN UserProject.IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status
FROM Project
INNER JOIN UserProject ON Project.Id = UserProject.ProjectId
INNER JOIN [User] ON [User].Id = UserProject.UserId
WHERE [User].Id = @UserId
GO
USE [master]
GO
ALTER DATABASE [Greenslate] SET  READ_WRITE 
GO
