CREATE TABLE [Sample].[SampleTable]
(
[SampleTableId] [int] NOT NULL IDENTITY(1, 1)
) ON [PRIMARY]
GO
ALTER TABLE [Sample].[SampleTable] ADD CONSTRAINT [PK_SampleTable] PRIMARY KEY CLUSTERED  ([SampleTableId]) ON [PRIMARY]
GO
