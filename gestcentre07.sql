USE [master]
GO
create database [GestCentre07]
GO

/****** Object:  Database [GestCentre07]    Script Date: 5/22/2017 12:32:07 PM ******/
ALTER DATABASE [GestCentre07] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestCentre07].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestCentre07] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestCentre07] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestCentre07] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestCentre07] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestCentre07] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestCentre07] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GestCentre07] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestCentre07] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestCentre07] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestCentre07] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestCentre07] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestCentre07] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestCentre07] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestCentre07] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestCentre07] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestCentre07] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestCentre07] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestCentre07] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestCentre07] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestCentre07] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestCentre07] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestCentre07] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestCentre07] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GestCentre07] SET  MULTI_USER 
GO
ALTER DATABASE [GestCentre07] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestCentre07] SET DB_CHAINING OFF 
GO
USE [GestCentre07]
GO
/****** Object:  Table [dbo].[Administrateur]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrateur](
	[Cin] [varchar](7) NOT NULL,
	[Nom] [varchar](30) NULL,
	[Prenom] [varchar](30) NULL,
	[Tel] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[DateNaissance] [datetime] NULL,
	[Adresse] [varchar](90) NULL,
	[sexe] [char](1) NULL,
	[DateEmbauche] [datetime] NULL,
	[MotDePasse] [varchar](30) NULL,
	[Question] [varchar](100) NULL,
	[Reponse] [varchar](100) NULL,
	[poste] [varchar](20) NULL,
	[photo] [image] NULL,
 CONSTRAINT [PK_Adminstrateur] PRIMARY KEY CLUSTERED 
(
	[Cin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cours]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cours](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idprof] [varchar](7) NULL,
	[idmodule] [varchar](20) NULL,
	[idgroupe] [int] NULL,
	[DateDebut] [date] NULL,
	[DateFin] [date] NULL,
	[AnneCours] [char](4) NULL DEFAULT (datepart(year,getdate())),
 CONSTRAINT [PK_Cours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Groupe]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Groupe](
	[IdGroupe] [int] IDENTITY(1,1) NOT NULL,
	[NomGroupe] [varchar](50) NOT NULL,
	[Gdescription] [varchar](500) NULL,
	[Annee] [char](4) NULL DEFAULT (datepart(year,getdate())),
	[NiveauGroupe] [int] NULL DEFAULT ((1)),
	[idspecialite] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Grouep] PRIMARY KEY CLUSTERED 
(
	[IdGroupe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Messagerie]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Messagerie](
	[IdMessage] [int] IDENTITY(1,1) NOT NULL,
	[IdEmetteur] [varchar](7) NULL,
	[IdRecepteur] [varchar](7) NULL,
	[Message] [varchar](max) NULL,
	[DateEnvoi] [datetime] NULL,
	[Etat] [int] NULL DEFAULT ((0)),
	[DeleteByEmet] [int] NULL DEFAULT ((0)),
	[DeleteByRecep] [int] NULL DEFAULT ((0)),
 CONSTRAINT [PK_Messagerie] PRIMARY KEY CLUSTERED 
(
	[IdMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Module]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[IdModule] [varchar](20) NOT NULL,
	[NomModule] [varchar](20) NULL,
	[NiveauModule] [int] NULL,
	[Mdescription] [varchar](1000) NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[IdModule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personne]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personne](
	[Cin] [varchar](7) NOT NULL,
	[Nom] [varchar](30) NULL,
	[Prenom] [varchar](30) NULL,
	[Tel] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[DateNaissance] [datetime] NULL,
	[Adresse] [varchar](90) NULL,
	[sexe] [char](1) NULL,
	[photo] [image] NULL,
 CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED 
(
	[Cin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Professeur]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Professeur](
	[Cin] [varchar](7) NOT NULL,
	[Nom] [varchar](30) NULL,
	[Prenom] [varchar](30) NULL,
	[Tel] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[DateNaissance] [datetime] NULL,
	[Adresse] [varchar](90) NULL,
	[sexe] [char](1) NULL,
	[DateEmbauche] [datetime] NULL,
	[MotDePasse] [varchar](30) NULL,
	[Question] [varchar](100) NULL,
	[Reponse] [varchar](100) NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_Professeur] PRIMARY KEY CLUSTERED 
(
	[Cin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[seance]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[seance](
	[idcours] [int] NULL,
	[salle] [varchar](10) NULL,
	[HeureDebut] [time](7) NULL,
	[HeureFin] [time](7) NULL,
	[Jour] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Specialite]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Specialite](
	[IdSpecialite] [varchar](30) NOT NULL,
	[Designation] [varchar](100) NULL,
	[Sdescription] [varchar](500) NULL,
	[idprofchef] [varchar](7) NULL,
 CONSTRAINT [PK_Specialite] PRIMARY KEY CLUSTERED 
(
	[IdSpecialite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SpecModule]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SpecModule](
	[idspecialite] [varchar](30) NULL,
	[idmodule] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stagiaire]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stagiaire](
	[IdStagiaire] [int] IDENTITY(100,1) NOT NULL,
	[cin] [varchar](7) NULL,
	[DateInscription] [datetime] NULL DEFAULT (getdate()),
	[idspecialite] [varchar](30) NULL,
	[idgroupe] [int] NULL,
	[Question] [varchar](100) NULL,
	[Reponse] [varchar](100) NULL,
	[AnneInscription] [char](4) NULL DEFAULT (datepart(year,getdate())),
 CONSTRAINT [PK_Stagiaire_IdStagiaire] PRIMARY KEY CLUSTERED 
(
	[IdStagiaire] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Administrateur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [poste], [photo]) VALUES (N'a', N'Zakaria', N'Kasmi', N'0610855151', N'zakaria_kasmi@hotmail.fr', CAST(N'1996-03-13 00:00:00.000' AS DateTime), N'Oujda lazaret', N'H', CAST(N'1990-02-02 00:00:00.000' AS DateTime), N'a', N'Quelle est votre nourriture préférée ?', N'ordinateur', N'Admin', NULL)
INSERT [dbo].[Administrateur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [poste], [photo]) VALUES (N's1', N'elmansari', N'youssef', N'0610855151', N'elmansariyoussef@hotmail.com', CAST(N'1996-03-13 00:00:00.000' AS DateTime), N'Oujda lazaret', N'H', CAST(N'1990-02-02 00:00:00.000' AS DateTime), N'azerty1', N'Quelle est votre nourriture préférée ?', N'helloworld', N'Admin', NULL)
INSERT [dbo].[Administrateur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [poste], [photo]) VALUES (N'S123', N'Youssef', N'BelAsri', N'0618311123', N'YoussefBEl@hotmail.Fr', CAST(N'1996-03-13 00:00:00.000' AS DateTime), N'Oujda andalous', N'H', CAST(N'2015-02-19 00:00:00.000' AS DateTime), N'azerty3', N'Quelle est votre ville de naissance ?', N'pc', N'Admin', NULL)
INSERT [dbo].[Administrateur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [poste], [photo]) VALUES (N's2', N'yasser', N'hassan', N'0618311811', N'Zakaria_kasmi@hotmail.Fr', CAST(N'1996-03-13 00:00:00.000' AS DateTime), N'Oujda  lazaret', N'H', CAST(N'2015-02-19 00:00:00.000' AS DateTime), N'azerty2', N'Quelle est votre ville de naissance ?', N'animal', N'Admin', NULL)
SET IDENTITY_INSERT [dbo].[Cours] ON 

INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (1, N's3', N'OOP', 1, CAST(N'2017-04-01' AS Date), CAST(N'2017-04-15' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (2, N's3', N'C', 1, CAST(N'2017-04-16' AS Date), CAST(N'2017-04-18' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (3, N's3', N'Merise', 8, CAST(N'2017-04-19' AS Date), CAST(N'2017-04-25' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (8, N'Pro12', N'Assistance tech', 8, CAST(N'2017-03-01' AS Date), CAST(N'2017-03-05' AS Date), N'2016')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (10, N's3', N'C', 10, CAST(N'2017-03-01' AS Date), CAST(N'2017-03-09' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (14, N'Pro12', N'French', 8, CAST(N'2017-03-01' AS Date), CAST(N'2017-03-10' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (16, N's5', N'C', 9, CAST(N'2017-04-20' AS Date), CAST(N'2017-07-21' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (18, N's3', N'Assistance tech', 9, CAST(N'2017-03-01' AS Date), CAST(N'2017-03-22' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (19, N'Pro12', N'OOP', 8, CAST(N'2017-04-13' AS Date), CAST(N'2017-04-29' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (21, N's3', N'French', 9, CAST(N'2017-04-01' AS Date), CAST(N'2017-05-24' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (22, N's4', N'Merise', 9, CAST(N'2017-04-06' AS Date), CAST(N'2017-04-21' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (23, N's4', N'Web', 8, CAST(N'2017-04-06' AS Date), CAST(N'2017-04-21' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (31, N's4', N'Web', 10, CAST(N'2017-04-08' AS Date), CAST(N'2017-04-21' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (32, N's4', N'Web', 9, CAST(N'2017-04-06' AS Date), CAST(N'2017-04-21' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (34, N's3', N'French', 10, CAST(N'2017-04-01' AS Date), CAST(N'2017-05-24' AS Date), N'2017')
INSERT [dbo].[Cours] ([ID], [idprof], [idmodule], [idgroupe], [DateDebut], [DateFin], [AnneCours]) VALUES (36, N'Pro12', N'French', 11, CAST(N'2017-03-01' AS Date), CAST(N'2017-03-10' AS Date), N'2017')
SET IDENTITY_INSERT [dbo].[Cours] OFF
SET IDENTITY_INSERT [dbo].[Groupe] ON 

INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (1, N'TDI A1', N'technique de developpement informatique', N'2017', 1, N'TDI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (2, N'TDI A2', N'technique de developpement informatique', N'2017', 2, N'TDI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (3, N'TRI A1', N'TEEEEEEEEEE', N'2015', 1, N'TRI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (4, N'TRI A2', N'technique de Reseau informatique', N'2017', 2, N'TRI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (5, N'TDDDDI S1', N'technique de GEstion Entreprise', N'2017', 2, N'TDI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (6, N'TSGE A2', N'technique de GEstion Entreprise', N'2015', 2, N'TSGE')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (7, N'TDI A3', N'technique de developpement informatique', N'2017', 1, N'TDI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (8, N'TDI A1', N'technique de developpement informatique', N'2016', 1, N'TDI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (9, N'TDI B2', N'technique de developpement informatique', N'2016', 1, N'TDI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (10, N'TRI A1', N'technique de Reseau informatique', N'2016', 1, N'TRI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (11, N'TRI A2', N'technique de Reseau informatique', N'2016', 2, N'TRI')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (12, N'TSGE A1', N'technique de GEstion Entreprise', N'2016', 1, N'TSGE')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (54, N'er1', N'AZEAZE', N'2017', 1, N'TCM')
INSERT [dbo].[Groupe] ([IdGroupe], [NomGroupe], [Gdescription], [Annee], [NiveauGroupe], [idspecialite]) VALUES (58, N'er5', N'AZEAZE', N'2017', 1, N'TCM')
SET IDENTITY_INSERT [dbo].[Groupe] OFF
SET IDENTITY_INSERT [dbo].[Messagerie] ON 

INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (1, N's1', N's2', N'Un outil utile pour établir des priorités claires qui tiennent compte à la fois de l’urgence et de l’importance est la matrice de priorité (Principe d’Eisenhower', CAST(N'2017-04-07 00:00:00.000' AS DateTime), 0, 0, 1)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (2, N's2', N's1', N'Le temps doit d’abord être consacré à des tâches prioritaires entrant de façon certaine dans le champ des objectifs fixés. Il est donc important de connaître l’emploi de son temps afin de savoir ', CAST(N'2017-04-08 00:00:00.000' AS DateTime), 0, 1, 1)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (3, N's1', N's2', N'Un outil utile pour établir des priorités claires qui tiennent compte à la fois de l’urgence et de l’importance est la matrice de priorité (Principe d’Eisenhower', CAST(N'2017-04-08 00:00:00.000' AS DateTime), 1, 1, 1)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (4, N's2', N's1', N'Le temps doit d’abord être consacré à des tâches prioritaires entrant de façon certaine dans le champ des objectifs fixés. Il est donc important de connaître l’emploi de son temps afin de savoir ', CAST(N'2017-04-08 00:00:00.000' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (5, N's1', N's2', N'Le temps doit d’abord être consacré à des tâches prioritaires entrant de façon certaine dans le champ des objectifs fixés. Il est donc important de connaître l’emploi de son temps afin de savoir ', CAST(N'2017-04-08 00:00:00.000' AS DateTime), 1, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (6, N's1', N's2', N'Le temps doit d’abord être consacré à des tâches prioritaires entrant de façon certaine dans le champ des objectifs fixés. Il est donc important de connaître l’emploi de son temps afin de savoir ', CAST(N'2017-04-08 00:00:00.000' AS DateTime), 1, 1, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (10, N's2', N'AA1', N'Un outil utile pour établir des priorités claires qui tiennent compte à la fois de l’urgence et de l’importance est la matrice de priorité (Principe d’Eisenhower', CAST(N'2017-04-07 16:25:38.183' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (11, N's2', N'AB13', N'Un outil utile pour établir des priorités claires qui tiennent compte à la fois de l’urgence et de l’importance est la matrice de priorité (Principe d’Eisenhower', CAST(N'2017-04-07 16:25:38.183' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (12, N's2', N'Pro12', N'Un outil utile pour établir des priorités claires qui tiennent compte à la fois de l’urgence et de l’importance est la matrice de priorité (Principe d’Eisenhower', CAST(N'2017-04-07 16:25:38.183' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (13, N's2', N's1', N'Un outil utile pour établir des priorités claires qui tiennent compte à la fois de l’urgence et de l’importance est la matrice de priorité (Principe d’Eisenhower', CAST(N'2017-04-07 16:26:09.853' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (14, N's2', N's2', N'Pour le responsable il faut distinguer l’importance de l’urgence.
En classant les tâches selon leur priorité, on s’assure 
', CAST(N'2017-04-07 16:26:09.853' AS DateTime), 1, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (15, N's2', N'177', N'Pour le responsable il faut distinguer l’importance de l’urgence.
En classant les tâches selon leur priorité, on s’assure 
', CAST(N'2017-04-07 17:24:16.253' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (16, N's2', N'178', N'Pour le responsable il faut distinguer l’importance de l’urgence.
En classant les tâches selon leur priorité, on s’assure 
', CAST(N'2017-04-07 17:24:16.253' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (17, N's2', N's1', N'Pour le responsable il faut distinguer l’importance de l’urgence.
En classant les tâches selon leur priorité, on s’assure 
', CAST(N'2017-04-08 00:50:40.407' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (18, N's2', N's2', N'Pour le responsable il faut distinguer l’importance de l’urgence.
En classant les tâches selon leur priorité, on s’assure 
', CAST(N'2017-04-08 00:50:40.407' AS DateTime), 1, 0, 1)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (19, N's2', N'173', N'Le principe de Pareto affirme qu’au sein d’un groupe ou d’une population définie, une faible partie représente un poids bien plus élevé comparé à sa propre proportion correspondante dans ce groupe ou cette population', CAST(N'2017-04-08 00:54:50.880' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (20, N's2', N'177', N'Le principe de Pareto affirme qu’au sein d’un groupe ou d’une population définie, une faible partie représente un poids bien plus élevé comparé à sa propre proportion correspondante dans ce groupe ou cette population', CAST(N'2017-04-08 00:54:50.880' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (21, N's2', N'178', N'Le principe de Pareto affirme qu’au sein d’un groupe ou d’une population définie, une faible partie représente un poids bien plus élevé comparé à sa propre proportion correspondante dans ce groupe ou cette population', CAST(N'2017-04-08 00:54:50.880' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (22, N's2', N'179', N'Le principe de Pareto affirme qu’au sein d’un groupe ou d’une population définie, une faible partie représente un poids bien plus élevé comparé à sa propre proportion correspondante dans ce groupe ou cette population', CAST(N'2017-04-08 00:54:50.880' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (23, N's2', N'180', N'Le principe de Pareto affirme qu’au sein d’un groupe ou d’une population définie, une faible partie représente un poids bien plus élevé comparé à sa propre proportion correspondante dans ce groupe ou cette population', CAST(N'2017-04-08 00:54:50.880' AS DateTime), 1, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (24, N's2', N'185', N'Le principe de Pareto affirme qu’au sein d’un groupe ou d’une population définie, une faible partie représente un poids bien plus élevé comparé à sa propre proportion correspondante dans ce groupe ou cette population', CAST(N'2017-04-08 00:54:50.880' AS DateTime), 1, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (25, N's2', N's1', N'Il y a de nombreuses choses qui nous empêchent de nous organiser et de gérer notre temps efficacement. Voici les 5 plus gros obstacles dans la gestion du temps, et ce que vous pouvez faire pour les surmonter', CAST(N'2017-04-11 10:30:00.727' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (26, N's2', N'S123', N'Il y a de nombreuses choses qui nous empêchent de nous organiser et de gérer notre temps efficacement. Voici les 5 plus gros obstacles dans la gestion du temps, et ce que vous pouvez faire pour les surmonter', CAST(N'2017-04-11 10:30:00.727' AS DateTime), 1, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (27, N's2', N's2', N'Il y a de nombreuses choses qui nous empêchent de nous organiser et de gérer notre temps efficacement. Voici les 5 plus gros obstacles dans la gestion du temps, et ce que vous pouvez faire pour les surmonter', CAST(N'2017-04-11 10:30:00.727' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (28, N'S123', N'AA1', N'Il y a de nombreuses choses qui nous empêchent de nous organiser et de gérer notre temps efficacement. Voici les 5 plus gros obstacles dans la gestion du temps, et ce que vous pouvez faire pour les surmonter', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (29, N'S123', N'AAAZ', N'Il y a de nombreuses choses qui nous empêchent de nous organiser et de gérer notre temps efficacement. Voici les 5 plus gros obstacles dans la gestion du temps, et ce que vous pouvez faire pour les surmonter', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (30, N'S123', N'Pro12', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (31, N'S123', N's10', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (32, N'S123', N'S11', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (33, N'S123', N's12', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (34, N'S123', N's13', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (35, N'S123', N's3', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (36, N'S123', N's4', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (37, N'S123', N's5', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (38, N'S123', N's8', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
INSERT [dbo].[Messagerie] ([IdMessage], [IdEmetteur], [IdRecepteur], [Message], [DateEnvoi], [Etat], [DeleteByEmet], [DeleteByRecep]) VALUES (39, N'S123', N's9', N'Nous préférons tous mieux faire quelque chose d''amusant, non? Si j''ai le choix entre organiser des fichiers et regarder une émission de télévision préférée, il est assez clair que la plupart des gens choisiraient la télé', CAST(N'2017-04-12 21:10:35.100' AS DateTime), 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Messagerie] OFF
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'anglais tech', N'anglaa', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'Assistance tech', N'tech', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'C', N'language c', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'English', N'English grammar', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'French', N'Communication fran', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'Linux', N'Linux system', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'Merise', N'conception merise', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'OOP', N'oriented ', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'Reseau', N'Res 1', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'SGBD1', N'gestion des bas', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'SGBD2', N'base 2', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'TCP IP', N'protocol', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Module] ([IdModule], [NomModule], [NiveauModule], [Mdescription]) VALUES (N'Web', N'web dynamique', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor')
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'888q', N'ronaldo', N'Cristiano', N'0621564543', N'Cristiano@gmail.com', CAST(N'2017-03-16 04:06:31.000' AS DateTime), N'oujda', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'A1', N'hamza', N'aymen', N'0678564532', N'aymen@hotmail.fr', CAST(N'2017-03-23 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'abcd', N'Zakaria', N'AMINE', N'0621564534', N'AMINE@gmail.com', CAST(N'2017-03-15 04:06:31.000' AS DateTime), N'Ukraine Kievh', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'd87', N'lionel', N'messi', N'0621564538', N'messi@gmail.com', CAST(N'2017-03-04 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'ds', N'Zakaria', N'samir', N'0621564534', N'samir@gmail.com', CAST(N'2017-03-14 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'F2', N'kasmi', N'ahmadi', N'0621564523', N'ahmadi@gmail.com', CAST(N'2017-03-16 04:06:31.000' AS DateTime), N'Ukraine Kievh', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'F3', N'Zakaria', N'nabil', N'0621564676', N'nabil@gmail.com', CAST(N'2017-03-08 04:06:31.000' AS DateTime), N'Ukraine Kievh', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'ghh54', N'kygo', N'abderahmen', N'0678984532', N'abderahmen@gmail.com', CAST(N'2017-03-02 04:06:31.000' AS DateTime), N'Ukraine Kievh', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'HH11', N'graffin', N'Hazard', N'0612450006', N'Hazard@gmail.com', CAST(N'2017-03-08 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'KBB123', N'jone', N'mohammed', N'0621564754', N'mohammed@gmail.com', CAST(N'2017-03-30 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'LOL', N'hamza', N'yasser', N'0621564542', N'yasser@gmail.com', CAST(N'2017-03-03 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'qqq', N'kygo', N'fessi', N'0678564532', N'fessi@gmail.com', CAST(N'2017-03-09 04:06:31.000' AS DateTime), N'Ukraine Kievh', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'R22', N'selena', N'remy', N'0678566532', N'remy@gmail.com', CAST(N'2017-03-16 04:06:31.000' AS DateTime), N'honolopulou', N'F', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'rrz36', N'kygo', N'Hazard', N'0678564532', N'Hazard@gmail.com', CAST(N'2017-03-10 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's100', N'hamza', N'mohammed', N'0621564594', N'mohammed@gmail.com', CAST(N'2017-03-12 04:06:31.000' AS DateTime), N'oujda andalous', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's15', N'yasser', N'samir', N'0678576732', N'samir@hotmail.com', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'Tanegr Alfath', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's16', N'graffin', N'elbachir', N'0678564532', N'elbachir@hotmail.com', CAST(N'1998-02-02 00:00:00.000' AS DateTime), N'Tanger Alfath', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's17', N'khadija', N'fatima', N'0603450230', N'fatima@hotmail.com', CAST(N'1998-02-02 00:00:00.000' AS DateTime), N'oujda andalous', N'F', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's18', N'soufiane', N'salim', N'0621564594', N'soufiane@hotmail.com', CAST(N'1994-02-02 00:00:00.000' AS DateTime), N'OUJDA Alfath', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's19', N'karima', N'ahmadi', N'0621564594', N'karimahmadil@hotmail.com', CAST(N'1990-02-26 00:00:00.000' AS DateTime), N'Nador Alfath', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's2', N'Hamza', N'Jalal', N'0621564594', N'hamzajalal@hotmail.com', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'OUJDA Alfath', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's20', N'graffin', N'boubid', N'0678564554', N'boubid@hotmail.com', CAST(N'1987-02-02 00:00:00.000' AS DateTime), N'Tanger Alfath', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's201', N'hamza', N'samir', N'0678564532', N'samir@gmail.com', CAST(N'2017-03-16 04:06:31.000' AS DateTime), N'Tanger Alfath', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's21', N'graffin', N'boubid', N'0675345532', N'boubid@hotmail.com', CAST(N'1999-02-02 00:00:00.000' AS DateTime), N'Juventus Juvi', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's22', N'hamza', N'samir', N'0678564532', N'Mariasharapoval@hotmail.com', CAST(N'1989-08-12 00:00:00.000' AS DateTime), N'Ukraine Kievh', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's23', N'aymen', N'oujdi', N'0678867532', N'Williams@hotmail.com', CAST(N'1987-02-02 00:00:00.000' AS DateTime), N'Denver Colorado Alfath', N'F', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N's24', N'Arda', N'Turan', N'0603454870', N'Arda@hotmail.fr', CAST(N'1989-02-02 00:00:00.000' AS DateTime), N'Barcelona Andalou', N'M', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'S30', N'ara', N'Geek', N'0603454870', N'Arda@hotmail.fr', CAST(N'1989-02-02 00:00:00.000' AS DateTime), N'Barcelona Andalou', N'H', NULL)
INSERT [dbo].[Personne] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [photo]) VALUES (N'sdf', N'move', N'move2', N'sdf', N'sdf', CAST(N'2017-03-09 04:06:31.000' AS DateTime), N'sdf', N'M', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N'AA1', N'ahmed', N'yasser', N'0674968573', N'Ron@gmail.com', CAST(N'2017-04-03 04:06:31.000' AS DateTime), N'barcelona', N'M', CAST(N'2017-03-22 04:06:31.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'pizza', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N'AAAZ', N'yasser', N'jalal', N'0612345678', N'jalal@gmail.com', CAST(N'2017-03-26 04:06:31.000' AS DateTime), N'sdfsdf', N'M', CAST(N'2017-03-26 04:06:31.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'pizza', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N'Pro12', N'ali', N'ait cheikh', N'0610834543', N'zzz@gmail.com', CAST(N'2017-03-30 04:06:31.000' AS DateTime), N'zaeaze', N'F', CAST(N'2017-03-26 04:06:31.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'pizza', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's10', N'james', N'klarkson', N'0610834552', N'klarkson@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'oujda lazaret', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'chien', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N'S11', N'yassine', N'hamid', N'0610834552', N'hamid@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'al andalous oujda', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'cat', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's12', N'khalid', N'anouar', N'0610834552', N'anouar@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'koulouj oujda', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'cat', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's13', N'samir', N'soufian', N'0610834552', N'soufian@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'fes salam', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'cat', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's3', N'rachid', N'el oujdi', N'0610855152', N'el oujdi@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'agdal rabat', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'chien', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's4', N'soufiane', N'hamza', N'061082342352', N'hamza@yahoo.fr', CAST(N'1990-02-02 00:00:00.000' AS DateTime), N'wayee3', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'chien', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's5', N'omar', N'sebti', N'0610834552', N'sebti@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'salam casa', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'chien', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's8', N'ahmed', N'stiane', N'0610834552', N'stiane@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'nour tanger', N'M', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'chien', NULL)
INSERT [dbo].[Professeur] ([Cin], [Nom], [Prenom], [Tel], [Email], [DateNaissance], [Adresse], [sexe], [DateEmbauche], [MotDePasse], [Question], [Reponse], [Photo]) VALUES (N's9', N'karima', N'fasi', N'0610834552', N'fasi@yahoo.fr', CAST(N'1964-02-02 00:00:00.000' AS DateTime), N'merchan tangier', N'F', CAST(N'1991-02-02 00:00:00.000' AS DateTime), N'123456789', N'Quel est le prénom de votre premier animal?', N'dog', NULL)
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (3, N'AT', CAST(N'17:00:00' AS Time), CAST(N'18:04:07' AS Time), N'Mercredi')
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (3, N'AT13', CAST(N'22:12:00' AS Time), CAST(N'23:34:07' AS Time), N'Mardi')
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (3, N'AT2', CAST(N'16:00:00' AS Time), CAST(N'20:33:07' AS Time), N'Mercredi')
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (3, N'AT5', CAST(N'15:22:00' AS Time), CAST(N'22:33:00' AS Time), N'Dimanche')
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (3, N'AT6', CAST(N'17:22:00' AS Time), CAST(N'20:33:00' AS Time), N'Mardi')
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (3, N'AT6', CAST(N'15:22:00' AS Time), CAST(N'16:33:00' AS Time), N'Jeudi')
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (18, N'AT6', CAST(N'11:25:00' AS Time), CAST(N'12:25:00' AS Time), N'Mardi')
INSERT [dbo].[seance] ([idcours], [salle], [HeureDebut], [HeureFin], [Jour]) VALUES (14, N'AT6', CAST(N'05:24:00' AS Time), CAST(N'09:24:00' AS Time), N'Lundi')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'EFR', N'Economie', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N's5')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'FFF', N'comptabilite', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N'Pro12')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'TCM', N'bureautique', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N'Pro12')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'TDI', N'developpement informatique', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N's3')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'TRE', N'securite informatique', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N's11')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'TRI', N'Reseau informatique', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N's4')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'TSF', N'Technicien specialisé en cuisine', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N's12')
INSERT [dbo].[Specialite] ([IdSpecialite], [Designation], [Sdescription], [idprofchef]) VALUES (N'TSGE', N'Gestion ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor', N's5')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'EFR', N'Merise')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'EFR', N'TCP IP')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'FFF', N'C')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'anglais tech')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'C')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'English')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'French')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'Linux')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'Merise')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'OOP')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'Reseau')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'SGBD1')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'SGBD2')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TDI', N'Web')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRE', N'anglais tech')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRE', N'Linux')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRE', N'Merise')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRE', N'OOP')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRI', N'anglais tech')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRI', N'Assistance tech')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRI', N'C')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRI', N'French')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRI', N'Linux')
INSERT [dbo].[SpecModule] ([idspecialite], [idmodule]) VALUES (N'TRI', N'SGBD2')
SET IDENTITY_INSERT [dbo].[Stagiaire] ON 

INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (148, N'S19', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TDI', 9, N'Quel est le prénom de votre premier animal?', N'Python', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (150, N'S21', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TDI', 9, N'Quelle est votre ville de naissance ?', N'Renault R4', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (151, N'S22', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TDI', 9, N'Quel est le prénom de votre premier animal?', N'Renault R4', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (152, N'S23', CAST(N'1992-02-12 00:00:00.000' AS DateTime), N'TDI', 9, N'Quel est le prénom de votre premier animal?', N'Motorola', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (153, N'S24', CAST(N'2001-02-11 00:00:00.000' AS DateTime), N'TRI', 10, N'Quelle est votre ville de naissance ?', N'Alienware', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (154, N'S17', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TRI', 3, N'Quelle est votre ville de naissance ?', N'Renault R4', N'2015')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (155, N'S15', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TSGE', 5, N'Quel est le prénom de votre premier animal?', N'niche', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (156, N'S18', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TDI', 1, N'Quelle est votre ville de naissance ?', N'redo', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (157, N'S2', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TDI', 1, N'Quel est le prénom de votre premier animal?', N'kotlin', N'2015')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (158, N'S15', CAST(N'1992-02-12 00:00:00.000' AS DateTime), N'TDI', 2, N'ta mere ?', N'hello', N'2015')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (159, N'S16', CAST(N'2001-02-11 00:00:00.000' AS DateTime), N'TRI', 3, N'Quel est le prénom de votre premier animal?', N'java', N'2015')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (160, N'S17', CAST(N'1996-02-02 00:00:00.000' AS DateTime), N'TSGE', 5, N'Quel est le prénom de votre premier animal?', N'hello', N'2015')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (164, N'ds', CAST(N'2017-03-26 04:34:13.783' AS DateTime), N'TDI', 9, N'Quelle est votre nourriture préférée ?', N'hello', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (166, N'sdf', CAST(N'2017-03-26 04:35:44.617' AS DateTime), N'TDI', 9, N'Quelle est votre nourriture préférée ?', N'VS', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (173, N's201', CAST(N'2017-03-26 04:54:18.213' AS DateTime), N'TDI', 8, N'Quelle est votre nourriture préférée ?', N'assembly', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (174, N's201', CAST(N'2017-03-26 04:55:30.573' AS DateTime), N'TRI', 4, N'Quelle est votre nourriture préférée ?', N'session', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (177, N'F2', CAST(N'2017-03-26 05:01:08.127' AS DateTime), N'TDI', 8, N'Quel est le prénom de votre premier animal?', N'asp', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (179, N'ghh54', CAST(N'2017-03-26 05:11:57.887' AS DateTime), N'TDI', 8, N'Quelle est votre nourriture préférée ?', N'com', N'2017')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (190, N's100', CAST(N'2017-03-28 02:42:57.733' AS DateTime), N'TRI', 11, N'Quel est le prénom de votre premier animal?', N'jomla', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (194, N's20', CAST(N'2017-03-31 04:50:01.933' AS DateTime), N'TRI', 10, N'Quelle est votre nourriture préférée ?', N'wordpress', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (197, N's23', CAST(N'2017-03-31 04:50:01.933' AS DateTime), N'TRI', 10, N'Quel est le prénom de votre premier animal?', N'bloger', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (205, N's21', CAST(N'2017-03-31 04:50:01.933' AS DateTime), N'TSGE', 12, N'Quelle est votre nourriture préférée ?', N'google', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (206, N'S30', CAST(N'2017-03-31 04:50:01.933' AS DateTime), N'TSGE', 12, N'Quel est le prénom de votre premier animal?', N'python', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (207, N's19', CAST(N'2017-03-31 04:50:01.933' AS DateTime), N'TRI', 10, N'Quelle est votre nourriture préférée ?', N'ecran', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (209, N's21', CAST(N'2017-03-31 04:50:01.933' AS DateTime), N'TRI', 10, N'Quel est le prénom de votre premier animal?', N'keyboard', N'2016')
INSERT [dbo].[Stagiaire] ([IdStagiaire], [cin], [DateInscription], [idspecialite], [idgroupe], [Question], [Reponse], [AnneInscription]) VALUES (211, N'S19', CAST(N'2017-04-12 19:05:26.347' AS DateTime), N'TCM', 54, N'Quel est le prénom de votre premier animal?', N'samsung', N'2017')
SET IDENTITY_INSERT [dbo].[Stagiaire] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [unique_Prof_Module]    Script Date: 5/22/2017 12:32:07 PM ******/
ALTER TABLE [dbo].[Cours] ADD  CONSTRAINT [unique_Prof_Module] UNIQUE NONCLUSTERED 
(
	[idmodule] ASC,
	[idgroupe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [NomGroupe_AnneScolaire]    Script Date: 5/22/2017 12:32:07 PM ******/
ALTER TABLE [dbo].[Groupe] ADD  CONSTRAINT [NomGroupe_AnneScolaire] UNIQUE NONCLUSTERED 
(
	[NomGroupe] ASC,
	[Annee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [unique_HD_HF_Jour_idcours]    Script Date: 5/22/2017 12:32:07 PM ******/
ALTER TABLE [dbo].[seance] ADD  CONSTRAINT [unique_HD_HF_Jour_idcours] UNIQUE NONCLUSTERED 
(
	[HeureDebut] ASC,
	[HeureFin] ASC,
	[Jour] ASC,
	[idcours] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Unique_salle_HD_HF_Jour]    Script Date: 5/22/2017 12:32:07 PM ******/
ALTER TABLE [dbo].[seance] ADD  CONSTRAINT [Unique_salle_HD_HF_Jour] UNIQUE NONCLUSTERED 
(
	[salle] ASC,
	[HeureDebut] ASC,
	[HeureFin] ASC,
	[Jour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UNique_IdSpec_Idmodul]    Script Date: 5/22/2017 12:32:07 PM ******/
ALTER TABLE [dbo].[SpecModule] ADD  CONSTRAINT [UNique_IdSpec_Idmodul] UNIQUE NONCLUSTERED 
(
	[idspecialite] ASC,
	[idmodule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [unique_Stagiaire_CinAndSpecialite]    Script Date: 5/22/2017 12:32:07 PM ******/
ALTER TABLE [dbo].[Stagiaire] ADD  CONSTRAINT [unique_Stagiaire_CinAndSpecialite] UNIQUE NONCLUSTERED 
(
	[cin] ASC,
	[idspecialite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cours]  WITH CHECK ADD  CONSTRAINT [FK_Cours_Groupe] FOREIGN KEY([idgroupe])
REFERENCES [dbo].[Groupe] ([IdGroupe])
GO
ALTER TABLE [dbo].[Cours] CHECK CONSTRAINT [FK_Cours_Groupe]
GO
ALTER TABLE [dbo].[Cours]  WITH CHECK ADD  CONSTRAINT [FK_Cours_Module] FOREIGN KEY([idmodule])
REFERENCES [dbo].[Module] ([IdModule])
GO
ALTER TABLE [dbo].[Cours] CHECK CONSTRAINT [FK_Cours_Module]
GO
ALTER TABLE [dbo].[Cours]  WITH CHECK ADD  CONSTRAINT [FK_Cours_Professeur] FOREIGN KEY([idprof])
REFERENCES [dbo].[Professeur] ([Cin])
GO
ALTER TABLE [dbo].[Cours] CHECK CONSTRAINT [FK_Cours_Professeur]
GO
ALTER TABLE [dbo].[Groupe]  WITH CHECK ADD  CONSTRAINT [FK_Specialite_IdSpecialite] FOREIGN KEY([idspecialite])
REFERENCES [dbo].[Specialite] ([IdSpecialite])
GO
ALTER TABLE [dbo].[Groupe] CHECK CONSTRAINT [FK_Specialite_IdSpecialite]
GO
ALTER TABLE [dbo].[seance]  WITH CHECK ADD  CONSTRAINT [FK_Seance_Cours] FOREIGN KEY([idcours])
REFERENCES [dbo].[Cours] ([ID])
GO
ALTER TABLE [dbo].[seance] CHECK CONSTRAINT [FK_Seance_Cours]
GO
ALTER TABLE [dbo].[Specialite]  WITH CHECK ADD  CONSTRAINT [FK_Specialite_Professeur_Cin] FOREIGN KEY([idprofchef])
REFERENCES [dbo].[Professeur] ([Cin])
GO
ALTER TABLE [dbo].[Specialite] CHECK CONSTRAINT [FK_Specialite_Professeur_Cin]
GO
ALTER TABLE [dbo].[SpecModule]  WITH CHECK ADD  CONSTRAINT [FK_SoecModule_Module] FOREIGN KEY([idmodule])
REFERENCES [dbo].[Module] ([IdModule])
GO
ALTER TABLE [dbo].[SpecModule] CHECK CONSTRAINT [FK_SoecModule_Module]
GO
ALTER TABLE [dbo].[SpecModule]  WITH CHECK ADD  CONSTRAINT [FK_SpecModule_Specialite] FOREIGN KEY([idspecialite])
REFERENCES [dbo].[Specialite] ([IdSpecialite])
GO
ALTER TABLE [dbo].[SpecModule] CHECK CONSTRAINT [FK_SpecModule_Specialite]
GO
ALTER TABLE [dbo].[Stagiaire]  WITH CHECK ADD  CONSTRAINT [FK_Groupe_Stagiaire_idgroupe] FOREIGN KEY([idgroupe])
REFERENCES [dbo].[Groupe] ([IdGroupe])
GO
ALTER TABLE [dbo].[Stagiaire] CHECK CONSTRAINT [FK_Groupe_Stagiaire_idgroupe]
GO
ALTER TABLE [dbo].[Stagiaire]  WITH CHECK ADD  CONSTRAINT [FK_Personne_Stagiaire_cin] FOREIGN KEY([cin])
REFERENCES [dbo].[Personne] ([Cin])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stagiaire] CHECK CONSTRAINT [FK_Personne_Stagiaire_cin]
GO
ALTER TABLE [dbo].[Stagiaire]  WITH CHECK ADD  CONSTRAINT [FK_Specialite_Stagiaire_idspecialite] FOREIGN KEY([idspecialite])
REFERENCES [dbo].[Specialite] ([IdSpecialite])
GO
ALTER TABLE [dbo].[Stagiaire] CHECK CONSTRAINT [FK_Specialite_Stagiaire_idspecialite]
GO
ALTER TABLE [dbo].[Groupe]  WITH CHECK ADD  CONSTRAINT [Check_Niveu] CHECK  (([NiveauGroupe]=(2) OR [NiveauGroupe]=(1)))
GO
ALTER TABLE [dbo].[Groupe] CHECK CONSTRAINT [Check_Niveu]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [Check_Niveu_Module] CHECK  (([NiveauModule]=(2) OR [NiveauModule]=(1)))
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [Check_Niveu_Module]
GO
/****** Object:  StoredProcedure [dbo].[AddGroupe]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddGroupe] 
@NomGroupe varchar(50),@Gdescription varchar(500),@NiveauGroupe int ,@idspecialite varchar(30),
@IdGroupe int output
As 
Begin
insert into Groupe(NomGroupe,Gdescription,NiveauGroupe,idspecialite)  values(@NomGroupe,@Gdescription,@NiveauGroupe,@idspecialite)
set @IdGroupe =SCOPE_IDENTITY() 
End 



GO
/****** Object:  StoredProcedure [dbo].[AjouterCours]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AjouterCours] @idprof varchar(7),@idmodule varchar(20),@idgroupe int,@DateDebut Date,@DateFin Date,@AnneCours char(4),@idcours int output 
as begin
insert into Cours(idprof,idmodule,idgroupe,DateDebut,DateFin) values (@idprof,@idmodule,@idgroupe,@DateDebut,@DateFin) 
set @idcours = Scope_Identity()
End


GO
/****** Object:  StoredProcedure [dbo].[AjouterStagiaire]    Script Date: 5/22/2017 12:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  Procedure [dbo].[AjouterStagiaire] @Cin varchar(7),@Nom varchar(30),@Prenom varchar(30),@Tel varchar(20),@Email varchar(50),@DateNaissance datetime,@Adresse varchar(90),@sexe char(1),@idspecialite varchar(30),@idgroupe int,@Question varchar(100),@Reponse varchar(100)
,@IdStagiaire int output 
As 
begin 
		Begin TrY
			 Begin Transaction Hello1
			declare @x int 
			set  @x=(select count(*) from Personne where Cin=@Cin)
			if  (@x > 0)
				 begin 
				  insert into Stagiaire(cin,idspecialite,idgroupe,Question,Reponse)  values(@Cin,@idspecialite,@idgroupe,@Question,@Reponse)
				 Commit Transaction Hello1
				 print 'ajouter just Stagiaire'
				   End
				else 
				 begin 
				 insert into Personne(Cin,Nom,Prenom,Tel,Email,DateNaissance,Adresse,sexe)  values(@Cin,@Nom,@Prenom,@Tel,@Email,@DateNaissance,@Adresse,@sexe)
				  insert into Stagiaire(cin,idspecialite,idgroupe,Question,Reponse)  values(@Cin,@idspecialite,@idgroupe,@Question,@Reponse)
				   Commit Transaction Hello1
				   print ' les deux sont ajouter '
				 end 
			 set @IdStagiaire =SCOPE_IDENTITY() 
			 END TRY
	 BEGIN catch 
	 Rollback Transaction Hello1
	 declare @ErrorMessage nvarchar(500)
	 Declare @ErrorSeverity int 
	 Declare @ErrorState int 
	 select @ErrorMessage=Error_Message()
	 select @ErrorSeverity = Error_Severity()
	 Select @ErrorState = ERROR_STATE()
	RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState)
	 End Catch 
End 



GO
USE [master]
GO
ALTER DATABASE [GestCentre07] SET  READ_WRITE 
GO
