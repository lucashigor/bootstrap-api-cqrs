USE {{cookiecutter.project_name}}Principal;
GO

INSERT INTO [dbo].[Configurations]
           ([Id]
           ,[Name]
           ,[Value]
           ,[Description])
     VALUES
           ('8fcf1426-cd64-4e0c-98a4-82b9be7ccc06'
           ,'environment'
           ,'development'
           ,'Key to define what environment are running')
GO