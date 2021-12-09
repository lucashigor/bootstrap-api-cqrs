USE {{cookiecutter.project_name}}Principal;
GO

CREATE TABLE [dbo].[Configurations](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL
) ON [PRIMARY]
GO