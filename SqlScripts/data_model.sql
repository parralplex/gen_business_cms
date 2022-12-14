USE [master]
GO
/****** Object:  Database [Gen. business model]    Script Date: 30/09/2022 00:10:25 ******/
CREATE DATABASE [Gen. business model]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gen. business model', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Gen. business model.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gen. business model_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Gen. business model_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Gen. business model] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gen. business model].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gen. business model] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gen. business model] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gen. business model] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gen. business model] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gen. business model] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gen. business model] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gen. business model] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gen. business model] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gen. business model] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gen. business model] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gen. business model] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gen. business model] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gen. business model] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gen. business model] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gen. business model] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gen. business model] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gen. business model] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gen. business model] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gen. business model] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gen. business model] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gen. business model] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gen. business model] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gen. business model] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gen. business model] SET  MULTI_USER 
GO
ALTER DATABASE [Gen. business model] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gen. business model] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gen. business model] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gen. business model] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Gen. business model] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Gen. business model] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Gen. business model] SET QUERY_STORE = OFF
GO
USE [Gen. business model]
GO
/****** Object:  Table [dbo].[Business]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Business](
	[business_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](1000) NULL,
 CONSTRAINT [pk_business] PRIMARY KEY CLUSTERED 
(
	[business_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ceo]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ceo](
	[business_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL,
 CONSTRAINT [pk_ceo] PRIMARY KEY CLUSTERED 
(
	[business_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unq_ceo] UNIQUE NONCLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[department_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[division_id] [int] NOT NULL,
	[objective] [nvarchar](1000) NULL,
 CONSTRAINT [pk_department] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentChief]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentChief](
	[department_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL,
 CONSTRAINT [pk_department_chief] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unq_department_chief] UNIQUE NONCLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[division_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL,
 CONSTRAINT [pk_director] PRIMARY KEY CLUSTERED 
(
	[division_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unq_director] UNIQUE NONCLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[division_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[business_id] [int] NOT NULL,
	[objective] [nvarchar](1000) NULL,
 CONSTRAINT [pk_division] PRIMARY KEY CLUSTERED 
(
	[division_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employee_id] [int] NOT NULL,
	[business_id] [int] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[title] [varchar](20) NULL,
	[phone_number] [varchar](25) NOT NULL,
	[email] [varchar](255) NOT NULL,
 CONSTRAINT [pk_employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[project_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[department_id] [int] NOT NULL,
	[product_name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[finishes_at] [date] NULL,
	[starts_at] [date] NOT NULL,
 CONSTRAINT [pk_project] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectManager]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectManager](
	[project_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL,
 CONSTRAINT [pk_project_manager] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unq_project_manager] UNIQUE NONCLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectParticipant]    Script Date: 30/09/2022 00:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectParticipant](
	[project_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL,
 CONSTRAINT [pk_project_participant] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC,
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [idx_department]    Script Date: 30/09/2022 00:10:25 ******/
CREATE NONCLUSTERED INDEX [idx_department] ON [dbo].[Department]
(
	[division_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_division]    Script Date: 30/09/2022 00:10:25 ******/
CREATE NONCLUSTERED INDEX [idx_division] ON [dbo].[Division]
(
	[business_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_project]    Script Date: 30/09/2022 00:10:25 ******/
CREATE NONCLUSTERED INDEX [idx_project] ON [dbo].[Project]
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ceo]  WITH CHECK ADD  CONSTRAINT [fk_ceo_business] FOREIGN KEY([business_id])
REFERENCES [dbo].[Business] ([business_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ceo] CHECK CONSTRAINT [fk_ceo_business]
GO
ALTER TABLE [dbo].[Ceo]  WITH CHECK ADD  CONSTRAINT [fk_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ceo] CHECK CONSTRAINT [fk_employee]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [fk_department_division] FOREIGN KEY([division_id])
REFERENCES [dbo].[Division] ([division_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [fk_department_division]
GO
ALTER TABLE [dbo].[DepartmentChief]  WITH CHECK ADD  CONSTRAINT [fk_department_chief_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartmentChief] CHECK CONSTRAINT [fk_department_chief_department]
GO
ALTER TABLE [dbo].[DepartmentChief]  WITH CHECK ADD  CONSTRAINT [fk_department_chief_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartmentChief] CHECK CONSTRAINT [fk_department_chief_employee]
GO
ALTER TABLE [dbo].[Director]  WITH CHECK ADD  CONSTRAINT [fk_director_division] FOREIGN KEY([division_id])
REFERENCES [dbo].[Division] ([division_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Director] CHECK CONSTRAINT [fk_director_division]
GO
ALTER TABLE [dbo].[Director]  WITH CHECK ADD  CONSTRAINT [fk_director_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Director] CHECK CONSTRAINT [fk_director_employee]
GO
ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [fk_division_business] FOREIGN KEY([business_id])
REFERENCES [dbo].[Business] ([business_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [fk_division_business]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_business] FOREIGN KEY([business_id])
REFERENCES [dbo].[Business] ([business_id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_employee_business]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [fk_project_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([department_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [fk_project_department]
GO
ALTER TABLE [dbo].[ProjectManager]  WITH CHECK ADD  CONSTRAINT [fk_project_manager_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectManager] CHECK CONSTRAINT [fk_project_manager_employee]
GO
ALTER TABLE [dbo].[ProjectManager]  WITH CHECK ADD  CONSTRAINT [fk_project_manager_project] FOREIGN KEY([project_id])
REFERENCES [dbo].[Project] ([project_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectManager] CHECK CONSTRAINT [fk_project_manager_project]
GO
ALTER TABLE [dbo].[ProjectParticipant]  WITH CHECK ADD  CONSTRAINT [fk_project_participant] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectParticipant] CHECK CONSTRAINT [fk_project_participant]
GO
ALTER TABLE [dbo].[ProjectParticipant]  WITH CHECK ADD  CONSTRAINT [fk_project_participant_project] FOREIGN KEY([project_id])
REFERENCES [dbo].[Project] ([project_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectParticipant] CHECK CONSTRAINT [fk_project_participant_project]
GO
USE [master]
GO
ALTER DATABASE [Gen. business model] SET  READ_WRITE 
GO
