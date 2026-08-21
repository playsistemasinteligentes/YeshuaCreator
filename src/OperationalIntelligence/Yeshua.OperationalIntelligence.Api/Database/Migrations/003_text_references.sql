SET NOCOUNT ON;

IF OBJECT_ID(N'OI_TextReferences', N'U') IS NULL
BEGIN
    CREATE TABLE OI_TextReferences
    (
        TextReferenceId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        FileId UNIQUEIDENTIFIER NOT NULL,
        Token NVARCHAR(200) NOT NULL,
        ReferenceKind NVARCHAR(50) NOT NULL,
        Line INT NOT NULL,
        ColumnNumber INT NOT NULL,
        ContextSnippet NVARCHAR(500) NOT NULL
    );
END;

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_OI_TextReferences_Build_Token'
      AND object_id = OBJECT_ID(N'OI_TextReferences')
)
    CREATE INDEX IX_OI_TextReferences_Build_Token
        ON OI_TextReferences(BuildId, Token)
        INCLUDE (FileId, ReferenceKind, Line, ColumnNumber);
