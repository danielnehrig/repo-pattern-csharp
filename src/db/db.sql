USE [master]
GO
DROP DATABASE [master2]
GO
CREATE DATABASE [master2]
GO
USE [master2]
GO

CREATE TABLE [dbo].[Student](
	[id] [int] NOT NULL IDENTITY(1,1),
	[firstName] [date] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Teacher](
	[id] [int] NOT NULL IDENTITY(1,1),
	[firstName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/** Test Data **/

INSERT INTO [dbo].[Student] (firstName) VALUES
('Bjarne'),
('Daniel'),
('Fischer'),
('Lukas'),
('Ahmet'),
('Yannis')
GO

INSERT INTO [dbo].[Teacher] (firstName) VALUES
('Weachter'),
('Hueller'),
('Tinken')
GO

USE [master]
GO
