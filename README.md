# BlogService

#This Project CRUD REST Service using ASP.NET CORE with JWT Token Authentication These repositories contain the blog REST service, built with ASP.NET Core 3.1 and dapper to illustrate creating REST API to performing CRUD actions and, how to create JWT token and secure API.

#Prerequisites Visual Studio 2019 16.4.0 ASP.NET Core 3.1 SQL Server 2017 Postman

#How to run the project Checkout this project to a location in your disk. Open the solution file using the Visual Studio 2019. Restore the NuGet packages by rebuilding the solution. Run the project.


Create Sql Db

USE [master]
GO
/****** Object:  Database [BlogDb]    Script Date: 1/16/2021 6:46:14 PM ******/
CREATE DATABASE [BlogDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BlogDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BlogDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BlogDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogDb] SET  MULTI_USER 
GO
ALTER DATABASE [BlogDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlogDb] SET QUERY_STORE = OFF
GO
USE [BlogDb]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 1/16/2021 6:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](250) NOT NULL,
	[Description] [varchar](max) NULL,
	[Author] [varchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/16/2021 6:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([BlogId], [Title], [Description], [Author], [CreatedDate]) VALUES (1, N'title', N'description', N'Eren Öztürk', CAST(N'2021-01-15T10:23:26.513' AS DateTime))
SET IDENTITY_INSERT [dbo].[Blogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Email], [Password], [CreatedDate]) VALUES (1, N'Kai', N'Zen', N'sample_kaisen', N'kaizen@tech.com', N'samplekaizen@', CAST(N'2021-01-14T21:34:49.150' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Blogs] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteBlogByBlogId]    Script Date: 1/16/2021 6:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create Proc [dbo].[sp_deleteBlogByBlogId]
(@BlogId int) 
As

Begin

delete b from Blogs b where b.BlogId=@BlogId 
End

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllBlogs]    Script Date: 1/16/2021 6:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getAllBlogs] 
AS
SELECT * FROM Blogs 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_getBlogById]    Script Date: 1/16/2021 6:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create Proc [dbo].[sp_getBlogById]
(@BlogId int) 
As

Begin

select * from Blogs b where b.BlogId=@BlogId 
End

GO
/****** Object:  StoredProcedure [dbo].[sp_getUser]    Script Date: 1/16/2021 6:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[sp_getUser]
(@email nvarchar(50),@password nvarchar(50)) 
As

Begin 
select * from Users u where u.Email=@email and  u.Password=@password
End

GO
/****** Object:  StoredProcedure [dbo].[sp_insertBlogItem]    Script Date: 1/16/2021 6:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create Proc [dbo].[sp_insertBlogItem]
(	@Author nvarchar(50),
	@Description nvarchar(50),
	@Title nvarchar(50),
	@CreatedDate datetime
) 
As

Begin

insert into Blogs(Author,Description,Title,CreatedDate)
select @Author,@Description,@Title,@CreatedDate
End

GO
USE [master]
GO
ALTER DATABASE [BlogDb] SET  READ_WRITE 
GO
