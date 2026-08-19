SET NOCOUNT ON;

IF OBJECT_ID(N'OI_Applications', N'U') IS NULL
BEGIN
    CREATE TABLE OI_Applications
    (
        ApplicationId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        Name NVARCHAR(300) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_Builds', N'U') IS NULL
BEGIN
    CREATE TABLE OI_Builds
    (
        BuildId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        ApplicationId UNIQUEIDENTIFIER NOT NULL,
        Version NVARCHAR(200) NOT NULL,
        CommitSha NVARCHAR(100) NULL,
        SourceSolution NVARCHAR(2000) NOT NULL,
        GeneratedAtUtc DATETIME2(7) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_Projects', N'U') IS NULL
BEGIN
    CREATE TABLE OI_Projects
    (
        ProjectId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        Name NVARCHAR(500) NOT NULL,
        AssemblyName NVARCHAR(500) NULL,
        ProjectPath NVARCHAR(2000) NULL,
        IsSeedProject BIT NOT NULL
    );
END;

IF OBJECT_ID(N'OI_Files', N'U') IS NULL
BEGIN
    CREATE TABLE OI_Files
    (
        FileId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        ProjectId UNIQUEIDENTIFIER NOT NULL,
        RelativePath NVARCHAR(2000) NOT NULL,
        HashSha256 CHAR(64) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_Symbols', N'U') IS NULL
BEGIN
    CREATE TABLE OI_Symbols
    (
        SymbolId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        ProjectId UNIQUEIDENTIFIER NOT NULL,
        ContainingSymbolId UNIQUEIDENTIFIER NULL,
        Kind NVARCHAR(40) NOT NULL,
        Name NVARCHAR(500) NOT NULL,
        QualifiedName NVARCHAR(MAX) NOT NULL,
        SymbolKey NVARCHAR(MAX) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_Declarations', N'U') IS NULL
BEGIN
    CREATE TABLE OI_Declarations
    (
        DeclarationId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        SymbolId UNIQUEIDENTIFIER NOT NULL,
        FileId UNIQUEIDENTIFIER NOT NULL,
        StartLine INT NOT NULL,
        StartColumn INT NOT NULL,
        EndLine INT NOT NULL,
        EndColumn INT NOT NULL
    );
END;

IF OBJECT_ID(N'OI_FieldReferences', N'U') IS NULL
BEGIN
    CREATE TABLE OI_FieldReferences
    (
        FieldReferenceId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        FieldSymbolId UNIQUEIDENTIFIER NOT NULL,
        ContainingFunctionId UNIQUEIDENTIFIER NULL,
        FileId UNIQUEIDENTIFIER NOT NULL,
        AccessKind NVARCHAR(20) NOT NULL,
        Line INT NOT NULL,
        ColumnNumber INT NOT NULL,
        ResolutionKind NVARCHAR(50) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_ClassInstantiations', N'U') IS NULL
BEGIN
    CREATE TABLE OI_ClassInstantiations
    (
        InstantiationId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        ClassSymbolId UNIQUEIDENTIFIER NOT NULL,
        ConstructorSymbolId UNIQUEIDENTIFIER NULL,
        ContainingFunctionId UNIQUEIDENTIFIER NULL,
        FileId UNIQUEIDENTIFIER NOT NULL,
        Line INT NOT NULL,
        ColumnNumber INT NOT NULL,
        ResolutionKind NVARCHAR(50) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_FunctionCalls', N'U') IS NULL
BEGIN
    CREATE TABLE OI_FunctionCalls
    (
        FunctionCallId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        BuildId UNIQUEIDENTIFIER NOT NULL,
        CallerFunctionId UNIQUEIDENTIFIER NOT NULL,
        CalledFunctionId UNIQUEIDENTIFIER NOT NULL,
        FileId UNIQUEIDENTIFIER NULL,
        Line INT NULL,
        ColumnNumber INT NULL,
        ResolutionKind NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_OI_Applications_Name' AND object_id = OBJECT_ID(N'OI_Applications'))
    CREATE UNIQUE INDEX UX_OI_Applications_Name ON OI_Applications(Name);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_Builds_Application_Version' AND object_id = OBJECT_ID(N'OI_Builds'))
    CREATE INDEX IX_OI_Builds_Application_Version ON OI_Builds(ApplicationId, Version, GeneratedAtUtc DESC);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_Files_Build_Project' AND object_id = OBJECT_ID(N'OI_Files'))
    CREATE INDEX IX_OI_Files_Build_Project ON OI_Files(BuildId, ProjectId);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_Symbols_Build_Kind_Name' AND object_id = OBJECT_ID(N'OI_Symbols'))
    CREATE INDEX IX_OI_Symbols_Build_Kind_Name ON OI_Symbols(BuildId, Kind, Name);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_Declarations_Symbol' AND object_id = OBJECT_ID(N'OI_Declarations'))
    CREATE INDEX IX_OI_Declarations_Symbol ON OI_Declarations(BuildId, SymbolId);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_FieldReferences_Field_Access' AND object_id = OBJECT_ID(N'OI_FieldReferences'))
    CREATE INDEX IX_OI_FieldReferences_Field_Access ON OI_FieldReferences(BuildId, FieldSymbolId, AccessKind);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_ClassInstantiations_Class' AND object_id = OBJECT_ID(N'OI_ClassInstantiations'))
    CREATE INDEX IX_OI_ClassInstantiations_Class ON OI_ClassInstantiations(BuildId, ClassSymbolId);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_FunctionCalls_Called' AND object_id = OBJECT_ID(N'OI_FunctionCalls'))
    CREATE INDEX IX_OI_FunctionCalls_Called ON OI_FunctionCalls(BuildId, CalledFunctionId);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_FunctionCalls_Caller' AND object_id = OBJECT_ID(N'OI_FunctionCalls'))
    CREATE INDEX IX_OI_FunctionCalls_Caller ON OI_FunctionCalls(BuildId, CallerFunctionId);
