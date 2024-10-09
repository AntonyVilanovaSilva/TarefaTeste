USE [DBTarefaTeste]
GO
/****** Object:  Table [dbo].[StatusTarefa]    Script Date: 09/10/2024 16:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTarefa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
 CONSTRAINT [PK_StatusTarefa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarefas]    Script Date: 09/10/2024 16:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarefas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](1000) NOT NULL,
	[Data] [datetime] NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDStatusTarefas] [int] NOT NULL,
 CONSTRAINT [PK_Tarefas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuário]    Script Date: 09/10/2024 16:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuário](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Usuário] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tarefas]  WITH CHECK ADD  CONSTRAINT [FK_Tarefas_StatusTarefa] FOREIGN KEY([IDStatusTarefas])
REFERENCES [dbo].[StatusTarefa] ([ID])
GO
ALTER TABLE [dbo].[Tarefas] CHECK CONSTRAINT [FK_Tarefas_StatusTarefa]
GO
ALTER TABLE [dbo].[Tarefas]  WITH CHECK ADD  CONSTRAINT [FK_Tarefas_Usuário] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuário] ([ID])
GO
ALTER TABLE [dbo].[Tarefas] CHECK CONSTRAINT [FK_Tarefas_Usuário]
GO
