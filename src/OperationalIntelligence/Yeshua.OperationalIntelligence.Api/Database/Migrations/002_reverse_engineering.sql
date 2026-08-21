SET NOCOUNT ON;

IF COL_LENGTH(N'OI_Applications', N'SystemType') IS NULL
    ALTER TABLE OI_Applications ADD SystemType NVARCHAR(30) NOT NULL
        CONSTRAINT DF_OI_Applications_SystemType DEFAULT N'LEGACY';

IF COL_LENGTH(N'OI_Builds', N'ManifestHashSha256') IS NULL
    ALTER TABLE OI_Builds ADD ManifestHashSha256 CHAR(64) NULL;

IF COL_LENGTH(N'OI_Projects', N'SourceDirectory') IS NULL
    ALTER TABLE OI_Projects ADD SourceDirectory NVARCHAR(2000) NULL;

IF COL_LENGTH(N'OI_Files', N'ArtifactKind') IS NULL
    ALTER TABLE OI_Files ADD ArtifactKind NVARCHAR(80) NOT NULL
        CONSTRAINT DF_OI_Files_ArtifactKind DEFAULT N'UNKNOWN';
IF COL_LENGTH(N'OI_Files', N'SourceRole') IS NULL
    ALTER TABLE OI_Files ADD SourceRole NVARCHAR(80) NOT NULL
        CONSTRAINT DF_OI_Files_SourceRole DEFAULT N'APPLICATION_SOURCE';
IF COL_LENGTH(N'OI_Files', N'Ownership') IS NULL
    ALTER TABLE OI_Files ADD Ownership NVARCHAR(40) NOT NULL
        CONSTRAINT DF_OI_Files_Ownership DEFAULT N'UNKNOWN';
IF COL_LENGTH(N'OI_Files', N'Editable') IS NULL
    ALTER TABLE OI_Files ADD Editable BIT NOT NULL
        CONSTRAINT DF_OI_Files_Editable DEFAULT 1;
IF COL_LENGTH(N'OI_Files', N'SourceOfTruth') IS NULL
    ALTER TABLE OI_Files ADD SourceOfTruth NVARCHAR(2000) NOT NULL
        CONSTRAINT DF_OI_Files_SourceOfTruth DEFAULT N'THIS_FILE';

IF OBJECT_ID(N'OI_SourceContents', N'U') IS NULL
BEGIN
    CREATE TABLE OI_SourceContents
    (
        HashSha256 CHAR(64) NOT NULL PRIMARY KEY,
        Compression NVARCHAR(20) NOT NULL,
        Content VARBINARY(MAX) NOT NULL,
        OriginalByteLength INT NOT NULL,
        StoredByteLength INT NOT NULL,
        CreatedAtUtc DATETIME2(7) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_GitRepositories', N'U') IS NULL
BEGIN
    CREATE TABLE OI_GitRepositories
    (
        RepositoryId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        ApplicationId UNIQUEIDENTIFIER NOT NULL,
        RootPath NVARCHAR(2000) NOT NULL,
        RemoteUrl NVARCHAR(2000) NULL,
        LastImportedCommitSha CHAR(40) NULL,
        UpdatedAtUtc DATETIME2(7) NOT NULL
    );
END;

IF OBJECT_ID(N'OI_GitCommits', N'U') IS NULL
BEGIN
    CREATE TABLE OI_GitCommits
    (
        CommitId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        RepositoryId UNIQUEIDENTIFIER NOT NULL,
        CommitSha CHAR(40) NOT NULL,
        ParentShas NVARCHAR(500) NULL,
        AuthorName NVARCHAR(500) NULL,
        AuthorEmail NVARCHAR(500) NULL,
        CommittedAtUtc DATETIME2(7) NOT NULL,
        Message NVARCHAR(MAX) NULL
    );
END;

IF OBJECT_ID(N'OI_GitFileChanges', N'U') IS NULL
BEGIN
    CREATE TABLE OI_GitFileChanges
    (
        ChangeId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        CommitId UNIQUEIDENTIFIER NOT NULL,
        ChangeType NVARCHAR(20) NOT NULL,
        OldPath NVARCHAR(2000) NULL,
        NewPath NVARCHAR(2000) NULL,
        Additions INT NULL,
        Deletions INT NULL,
        PatchCompression NVARCHAR(20) NULL,
        Patch VARBINARY(MAX) NULL
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_Files_Build_Path' AND object_id = OBJECT_ID(N'OI_Files'))
    CREATE INDEX IX_OI_Files_Build_Path ON OI_Files(BuildId, RelativePath);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_OI_GitCommits_Repository_Sha' AND object_id = OBJECT_ID(N'OI_GitCommits'))
    CREATE UNIQUE INDEX UX_OI_GitCommits_Repository_Sha ON OI_GitCommits(RepositoryId, CommitSha);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_OI_GitFileChanges_NewPath' AND object_id = OBJECT_ID(N'OI_GitFileChanges'))
    CREATE INDEX IX_OI_GitFileChanges_NewPath ON OI_GitFileChanges(NewPath, CommitId);
