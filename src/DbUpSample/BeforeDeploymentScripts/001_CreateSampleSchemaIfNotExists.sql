IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'Sample' )
  EXEC('CREATE SCHEMA [Sample] AUTHORIZATION [dbo]');
GO