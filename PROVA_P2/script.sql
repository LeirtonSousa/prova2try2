USE [master]
GO
/****** Object:  Database [ProvaP2]    Script Date: 14/11/2017 14:54:30 ******/
CREATE DATABASE [ProvaP2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProvaP2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProvaP2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProvaP2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProvaP2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProvaP2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProvaP2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProvaP2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProvaP2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProvaP2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProvaP2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProvaP2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProvaP2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProvaP2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProvaP2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProvaP2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProvaP2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProvaP2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProvaP2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProvaP2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProvaP2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProvaP2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProvaP2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProvaP2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProvaP2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProvaP2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProvaP2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProvaP2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProvaP2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProvaP2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProvaP2] SET  MULTI_USER 
GO
ALTER DATABASE [ProvaP2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProvaP2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProvaP2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProvaP2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProvaP2] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProvaP2]
GO
/****** Object:  Table [dbo].[Aluguel]    Script Date: 14/11/2017 14:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aluguel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idMaterial] [int] NOT NULL,
	[idFuncionario] [int] NOT NULL,
	[valor] [float] NOT NULL,
	[dataEntrega] [varchar](50) NOT NULL,
	[dataDevolucao] [varchar](50) NOT NULL,
	[formaPgmt] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Aluguel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 14/11/2017 14:54:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[endereco] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Despesa]    Script Date: 14/11/2017 14:54:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Despesa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[valor] [float] NOT NULL,
	[descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Despesa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 14/11/2017 14:54:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funcionario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[salario] [float] NOT NULL,
	[login] [varchar](50) NOT NULL,
	[senha] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Material]    Script Date: 14/11/2017 14:54:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Material](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[valor] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Aluguel]  WITH CHECK ADD  CONSTRAINT [FK_Aluguel_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([id])
GO
ALTER TABLE [dbo].[Aluguel] CHECK CONSTRAINT [FK_Aluguel_Cliente]
GO
ALTER TABLE [dbo].[Aluguel]  WITH CHECK ADD  CONSTRAINT [FK_Aluguel_Funcionario] FOREIGN KEY([idFuncionario])
REFERENCES [dbo].[Funcionario] ([id])
GO
ALTER TABLE [dbo].[Aluguel] CHECK CONSTRAINT [FK_Aluguel_Funcionario]
GO
ALTER TABLE [dbo].[Aluguel]  WITH CHECK ADD  CONSTRAINT [FK_Aluguel_Material] FOREIGN KEY([idMaterial])
REFERENCES [dbo].[Material] ([id])
GO
ALTER TABLE [dbo].[Aluguel] CHECK CONSTRAINT [FK_Aluguel_Material]
GO
USE [master]
GO
ALTER DATABASE [ProvaP2] SET  READ_WRITE 
GO
