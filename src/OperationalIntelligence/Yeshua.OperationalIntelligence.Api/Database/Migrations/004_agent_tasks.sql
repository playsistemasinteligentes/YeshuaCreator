CREATE TABLE OI_AgentTasks
(
    TaskId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Title NVARCHAR(160) NOT NULL,
    Status VARCHAR(20) NOT NULL,
    ThreadId NVARCHAR(100) NULL,
    CreatedAtUtc DATETIME2(7) NOT NULL,
    UpdatedAtUtc DATETIME2(7) NOT NULL
);

CREATE TABLE OI_AgentTaskMessages
(
    MessageId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TaskId UNIQUEIDENTIFIER NOT NULL REFERENCES OI_AgentTasks(TaskId),
    RequestId NVARCHAR(100) COLLATE Latin1_General_100_BIN2 NOT NULL UNIQUE,
    Message NVARCHAR(MAX) NOT NULL,
    Mode VARCHAR(20) NOT NULL,
    Status VARCHAR(20) NOT NULL,
    Response NVARCHAR(MAX) NULL,
    Progress NVARCHAR(300) NULL,
    CreatedAtUtc DATETIME2(7) NOT NULL,
    UpdatedAtUtc DATETIME2(7) NOT NULL,
    CONSTRAINT CK_OI_AgentTaskMessages_Mode CHECK (Mode IN ('observe', 'workspace-write')),
    CONSTRAINT CK_OI_AgentTaskMessages_Status CHECK (Status IN ('Queued', 'Running', 'Completed', 'Failed', 'Interrupted'))
);

CREATE INDEX IX_OI_AgentTaskMessages_Queue ON OI_AgentTaskMessages(Status, MessageId);
CREATE INDEX IX_OI_AgentTaskMessages_Task ON OI_AgentTaskMessages(TaskId, MessageId DESC);
