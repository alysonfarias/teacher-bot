IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [FileTypes] (
    [id] int NOT NULL,
    [name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_FileTypes] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Subjects] (
    [id] int NOT NULL,
    [name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Subjects] PRIMARY KEY ([id])
);
GO

CREATE TABLE [UserRoles] (
    [id] int NOT NULL,
    [name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserRoleId] int NOT NULL,
    [name] varchar(200) NOT NULL,
    [userName] varchar(200) NOT NULL,
    [email] nvarchar(200) NOT NULL,
    [password] nvarchar(200) NOT NULL,
    [birthDate] datetime2 NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_UserRoles_UserRoleId] FOREIGN KEY ([UserRoleId]) REFERENCES [UserRoles] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [tb_instructor] (
    [Id] int NOT NULL,
    [SubjectId] int NOT NULL,
    CONSTRAINT [PK_tb_instructor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tb_instructor_Subjects_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subjects] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tb_instructor_Users_Id] FOREIGN KEY ([Id]) REFERENCES [Users] ([Id])
);
GO

CREATE TABLE [tb_student] (
    [Id] int NOT NULL,
    [ResponsiblePhones] nvarchar(max) NULL,
    CONSTRAINT [PK_tb_student] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tb_student_Users_Id] FOREIGN KEY ([Id]) REFERENCES [Users] ([Id])
);
GO

CREATE TABLE [tb_classroom] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(200) NOT NULL,
    [description] varchar(400) NOT NULL,
    [InstructorId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL DEFAULT (getDate()),
    [UpdatedAt] datetime2 NOT NULL DEFAULT (getDate()),
    CONSTRAINT [PK_tb_classroom] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_classroom_tb_instructor_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [tb_instructor] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tb_activity] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(200) NOT NULL,
    [description] varchar(400) NOT NULL,
    [ClassRoomId] int NOT NULL,
    [dueDate] datetime2 NOT NULL,
    [CreatedAt] datetime2 NOT NULL DEFAULT (getDate()),
    [UpdatedAt] datetime2 NOT NULL DEFAULT (getDate()),
    CONSTRAINT [PK_tb_activity] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_activity_tb_classroom_ClassRoomId] FOREIGN KEY ([ClassRoomId]) REFERENCES [tb_classroom] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [tb_student_classroom] (
    [id_classroom] int NOT NULL,
    [id_student] int NOT NULL,
    CONSTRAINT [PK_tb_student_classroom] PRIMARY KEY ([id_classroom], [id_student]),
    CONSTRAINT [FK_tb_student_classroom_tb_classroom_id_classroom] FOREIGN KEY ([id_classroom]) REFERENCES [tb_classroom] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tb_student_classroom_tb_student_id_student] FOREIGN KEY ([id_student]) REFERENCES [tb_student] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tb_arquive] (
    [id] int NOT NULL IDENTITY,
    [ClassRoomId] int NOT NULL,
    [FileTypeId] int NOT NULL,
    [dataBase64] nvarchar(max) NOT NULL,
    [ActivityId] int NOT NULL,
    [ActivityId1] int NULL,
    [CreatedAt] datetime2 NOT NULL DEFAULT (getDate()),
    [UpdatedAt] datetime2 NOT NULL DEFAULT (getDate()),
    CONSTRAINT [PK_tb_arquive] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_arquive_FileTypes_FileTypeId] FOREIGN KEY ([FileTypeId]) REFERENCES [FileTypes] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_tb_arquive_tb_activity_ActivityId] FOREIGN KEY ([ActivityId]) REFERENCES [tb_activity] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tb_arquive_tb_activity_ActivityId1] FOREIGN KEY ([ActivityId1]) REFERENCES [tb_activity] ([id]),
    CONSTRAINT [FK_tb_arquive_tb_classroom_ClassRoomId] FOREIGN KEY ([ClassRoomId]) REFERENCES [tb_classroom] ([id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[FileTypes]'))
    SET IDENTITY_INSERT [FileTypes] ON;
INSERT INTO [FileTypes] ([id], [name])
VALUES (1, N'PDF'),
(2, N'PNG'),
(3, N'JPEG'),
(4, N'JPG'),
(5, N'MP3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[FileTypes]'))
    SET IDENTITY_INSERT [FileTypes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[Subjects]'))
    SET IDENTITY_INSERT [Subjects] ON;
INSERT INTO [Subjects] ([id], [name])
VALUES (1, N'Portuguese'),
(2, N'Mathematics'),
(3, N'Programming'),
(4, N'English');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[Subjects]'))
    SET IDENTITY_INSERT [Subjects] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[UserRoles]'))
    SET IDENTITY_INSERT [UserRoles] ON;
INSERT INTO [UserRoles] ([id], [name])
VALUES (1, N'Admin'),
(2, N'Instructor'),
(3, N'Student');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[UserRoles]'))
    SET IDENTITY_INSERT [UserRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'birthDate', N'CreatedAt', N'email', N'name', N'password', N'UpdatedAt', N'UserRoleId', N'userName') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [birthDate], [CreatedAt], [email], [name], [password], [UpdatedAt], [UserRoleId], [userName])
VALUES (1, '2022-06-15T00:00:00.0000000', '2022-06-15T00:00:00.0000000', N'admin@api.com', 'Admin Root Application', N'AQAAAAEAAAPoAAAAEPx+ytbWRKAc+Yjy05HlGh3gHVAl2EN18T99RSjA5WJ2hUDS6mFKq56fSkf+NdP8Og==', '0001-01-01T00:00:00.0000000', 1, 'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'birthDate', N'CreatedAt', N'email', N'name', N'password', N'UpdatedAt', N'UserRoleId', N'userName') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_tb_activity_ClassRoomId] ON [tb_activity] ([ClassRoomId]);
GO

CREATE INDEX [IX_tb_activity_id] ON [tb_activity] ([id]);
GO

CREATE INDEX [IX_tb_arquive_ActivityId] ON [tb_arquive] ([ActivityId]);
GO

CREATE INDEX [IX_tb_arquive_ActivityId1] ON [tb_arquive] ([ActivityId1]);
GO

CREATE INDEX [IX_tb_arquive_ClassRoomId] ON [tb_arquive] ([ClassRoomId]);
GO

CREATE INDEX [IX_tb_arquive_FileTypeId] ON [tb_arquive] ([FileTypeId]);
GO

CREATE INDEX [IX_tb_arquive_id] ON [tb_arquive] ([id]);
GO

CREATE INDEX [IX_tb_classroom_id] ON [tb_classroom] ([id]);
GO

CREATE INDEX [IX_tb_classroom_InstructorId] ON [tb_classroom] ([InstructorId]);
GO

CREATE INDEX [IX_tb_instructor_SubjectId] ON [tb_instructor] ([SubjectId]);
GO

CREATE INDEX [IX_tb_student_classroom_id_student] ON [tb_student_classroom] ([id_student]);
GO

CREATE INDEX [IX_Users_UserRoleId] ON [Users] ([UserRoleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220617200449_first-migration', N'6.0.6');
GO

COMMIT;
GO

