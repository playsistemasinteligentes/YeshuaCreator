SET NOCOUNT ON;
SET XACT_ABORT ON;

/*
    Renomeia colunas de permissao que conflitam com palavras reservadas do SQL Server.

    Tabelas:
      - yPerfilGrant
      - yUserGrant

    De:
      Grant, Create, Read, Update, Delete

    Para:
      CanGrant, CanCreate, CanRead, CanUpdate, CanDelete

    Execute no banco correto antes de subir a API gerada com os novos nomes.
*/

DECLARE @Changes TABLE
(
    TableName sysname NOT NULL,
    OldName sysname NOT NULL,
    NewName sysname NOT NULL
);

INSERT INTO @Changes (TableName, OldName, NewName)
VALUES
    (N'yPerfilGrant', N'Grant',  N'CanGrant'),
    (N'yPerfilGrant', N'Create', N'CanCreate'),
    (N'yPerfilGrant', N'Read',   N'CanRead'),
    (N'yPerfilGrant', N'Update', N'CanUpdate'),
    (N'yPerfilGrant', N'Delete', N'CanDelete'),
    (N'yUserGrant',   N'Grant',  N'CanGrant'),
    (N'yUserGrant',   N'Create', N'CanCreate'),
    (N'yUserGrant',   N'Read',   N'CanRead'),
    (N'yUserGrant',   N'Update', N'CanUpdate'),
    (N'yUserGrant',   N'Delete', N'CanDelete');

DECLARE
    @TableName sysname,
    @OldName sysname,
    @NewName sysname,
    @SchemaName sysname,
    @ObjectId int,
    @QualifiedColumn nvarchar(776),
    @Message nvarchar(4000);

BEGIN TRANSACTION;

DECLARE RenameColumns CURSOR LOCAL FAST_FORWARD FOR
    SELECT TableName, OldName, NewName
    FROM @Changes
    ORDER BY TableName, OldName;

OPEN RenameColumns;

FETCH NEXT FROM RenameColumns INTO @TableName, @OldName, @NewName;

WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT TOP (1)
        @SchemaName = s.name,
        @ObjectId = t.object_id
    FROM sys.tables t
    INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
    WHERE t.name = @TableName
    ORDER BY CASE WHEN s.name = N'dbo' THEN 0 ELSE 1 END, s.name;

    IF @ObjectId IS NULL
    BEGIN
        SET @Message = FORMATMESSAGE(N'Tabela %s nao encontrada.', @TableName);
        THROW 51000, @Message, 1;
    END;

    IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = @ObjectId AND name = @OldName)
       AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = @ObjectId AND name = @NewName)
    BEGIN
        SET @Message = FORMATMESSAGE(
            N'A tabela %s.%s possui as duas colunas: %s e %s. Resolva manualmente antes de continuar.',
            @SchemaName,
            @TableName,
            @OldName,
            @NewName);
        THROW 51001, @Message, 1;
    END;

    IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = @ObjectId AND name = @OldName)
    BEGIN
        SET @QualifiedColumn = QUOTENAME(@SchemaName) + N'.' + QUOTENAME(@TableName) + N'.' + QUOTENAME(@OldName);
        SET @Message = FORMATMESSAGE(N'Renomeando %s.%s.%s para %s.', @SchemaName, @TableName, @OldName, @NewName);
        PRINT @Message;

        EXEC sys.sp_rename
            @objname = @QualifiedColumn,
            @newname = @NewName,
            @objtype = N'COLUMN';
    END
    ELSE IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = @ObjectId AND name = @NewName)
    BEGIN
        SET @Message = FORMATMESSAGE(N'Coluna %s.%s.%s ja esta renomeada.', @SchemaName, @TableName, @NewName);
        PRINT @Message;
    END
    ELSE
    BEGIN
        SET @Message = FORMATMESSAGE(
            N'Coluna %s.%s.%s nao encontrada e %s tambem nao existe.',
            @SchemaName,
            @TableName,
            @OldName,
            @NewName);
        THROW 51002, @Message, 1;
    END;

    SET @SchemaName = NULL;
    SET @ObjectId = NULL;

    FETCH NEXT FROM RenameColumns INTO @TableName, @OldName, @NewName;
END;

CLOSE RenameColumns;
DEALLOCATE RenameColumns;

COMMIT TRANSACTION;

SELECT
    s.name AS SchemaName,
    t.name AS TableName,
    c.column_id AS ColumnId,
    c.name AS ColumnName
FROM sys.tables t
INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
INNER JOIN sys.columns c ON c.object_id = t.object_id
WHERE t.name IN (N'yPerfilGrant', N'yUserGrant')
  AND c.name IN
  (
      N'Grant', N'Create', N'Read', N'Update', N'Delete',
      N'CanGrant', N'CanCreate', N'CanRead', N'CanUpdate', N'CanDelete'
  )
ORDER BY t.name, c.column_id;
