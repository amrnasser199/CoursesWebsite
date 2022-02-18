
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2021 15:46:28
-- Generated from EDMX file: C:\Users\amrel\source\repos\CoursesWebsite\CoursesWebsite\Data\Courses_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Courses_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Category_Category_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_Category_Category_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_Course_Category_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course] DROP CONSTRAINT [FK_Course_Category_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_Course_Lessons_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course_Lessons] DROP CONSTRAINT [FK_Course_Lessons_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_Course_Trainer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course] DROP CONSTRAINT [FK_Course_Trainer];
GO
IF OBJECT_ID(N'[dbo].[FK_Course_Units_Course_Units]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course_Units] DROP CONSTRAINT [FK_Course_Units_Course_Units];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Trainee_Courses_Course_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trainee_Courses] DROP CONSTRAINT [FK_Trainee_Courses_Course_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_Trainee_Courses_Trainee_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trainee_Courses] DROP CONSTRAINT [FK_Trainee_Courses_Trainee_ID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admin];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[Course_Lessons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course_Lessons];
GO
IF OBJECT_ID(N'[dbo].[Course_Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course_Units];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Trainee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainee];
GO
IF OBJECT_ID(N'[dbo].[Trainee_Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainee_Courses];
GO
IF OBJECT_ID(N'[dbo].[Trainer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Email] nvarchar(150)  NOT NULL,
    [Password] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Parent_ID] int  NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Creation_Date] datetime  NOT NULL,
    [Desciption] nvarchar(max)  NULL,
    [Category_ID] int  NOT NULL,
    [Trainer_ID] int  NULL,
    [Image_ID] nvarchar(200)  NULL
);
GO

-- Creating table 'Course_Lessons'
CREATE TABLE [dbo].[Course_Lessons] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(200)  NOT NULL,
    [Course_ID] int  NOT NULL,
    [Order_Number] int  NULL,
    [Unit_Id] int  NOT NULL,
    [Type] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Trainees'
CREATE TABLE [dbo].[Trainees] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Email] nvarchar(150)  NOT NULL,
    [Password] nvarchar(200)  NULL,
    [Creation_Date] datetime  NOT NULL,
    [Is_Active] bit  NULL
);
GO

-- Creating table 'Trainee_Courses'
CREATE TABLE [dbo].[Trainee_Courses] (
    [Trainee_ID] int  NOT NULL,
    [Course_ID] int  NOT NULL,
    [Registeration_Date] datetime  NOT NULL
);
GO

-- Creating table 'Trainers'
CREATE TABLE [dbo].[Trainers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(150)  NOT NULL,
    [Email] nvarchar(100)  NULL,
    [Description] nvarchar(max)  NULL,
    [Website] nvarchar(250)  NULL,
    [Creation_Date] datetime  NOT NULL
);
GO

-- Creating table 'Course_Units'
CREATE TABLE [dbo].[Course_Units] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Course_Id] int  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Course_Lessons'
ALTER TABLE [dbo].[Course_Lessons]
ADD CONSTRAINT [PK_Course_Lessons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Trainees'
ALTER TABLE [dbo].[Trainees]
ADD CONSTRAINT [PK_Trainees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Trainee_ID], [Course_ID] in table 'Trainee_Courses'
ALTER TABLE [dbo].[Trainee_Courses]
ADD CONSTRAINT [PK_Trainee_Courses]
    PRIMARY KEY CLUSTERED ([Trainee_ID], [Course_ID] ASC);
GO

-- Creating primary key on [ID] in table 'Trainers'
ALTER TABLE [dbo].[Trainers]
ADD CONSTRAINT [PK_Trainers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'Course_Units'
ALTER TABLE [dbo].[Course_Units]
ADD CONSTRAINT [PK_Course_Units]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Parent_ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_Category_Category_ID]
    FOREIGN KEY ([Parent_ID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Category_Category_ID'
CREATE INDEX [IX_FK_Category_Category_ID]
ON [dbo].[Categories]
    ([Parent_ID]);
GO

-- Creating foreign key on [Category_ID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_Course_Category_ID]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_Category_ID'
CREATE INDEX [IX_FK_Course_Category_ID]
ON [dbo].[Courses]
    ([Category_ID]);
GO

-- Creating foreign key on [Course_ID] in table 'Course_Lessons'
ALTER TABLE [dbo].[Course_Lessons]
ADD CONSTRAINT [FK_Course_Lessons_Course]
    FOREIGN KEY ([Course_ID])
    REFERENCES [dbo].[Courses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_Lessons_Course'
CREATE INDEX [IX_FK_Course_Lessons_Course]
ON [dbo].[Course_Lessons]
    ([Course_ID]);
GO

-- Creating foreign key on [Trainer_ID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_Course_Trainer]
    FOREIGN KEY ([Trainer_ID])
    REFERENCES [dbo].[Trainers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_Trainer'
CREATE INDEX [IX_FK_Course_Trainer]
ON [dbo].[Courses]
    ([Trainer_ID]);
GO

-- Creating foreign key on [Course_ID] in table 'Trainee_Courses'
ALTER TABLE [dbo].[Trainee_Courses]
ADD CONSTRAINT [FK_Trainee_Courses_Course_ID]
    FOREIGN KEY ([Course_ID])
    REFERENCES [dbo].[Courses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainee_Courses_Course_ID'
CREATE INDEX [IX_FK_Trainee_Courses_Course_ID]
ON [dbo].[Trainee_Courses]
    ([Course_ID]);
GO

-- Creating foreign key on [Trainee_ID] in table 'Trainee_Courses'
ALTER TABLE [dbo].[Trainee_Courses]
ADD CONSTRAINT [FK_Trainee_Courses_Trainee_ID]
    FOREIGN KEY ([Trainee_ID])
    REFERENCES [dbo].[Trainees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Course_Id] in table 'Course_Units'
ALTER TABLE [dbo].[Course_Units]
ADD CONSTRAINT [FK_Course_Units_Course_Units]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[Courses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_Units_Course_Units'
CREATE INDEX [IX_FK_Course_Units_Course_Units]
ON [dbo].[Course_Units]
    ([Course_Id]);
GO

-- Creating foreign key on [Unit_Id] in table 'Course_Lessons'
ALTER TABLE [dbo].[Course_Lessons]
ADD CONSTRAINT [FK_Course_Lessons_Course1]
    FOREIGN KEY ([Unit_Id])
    REFERENCES [dbo].[Course_Units]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_Lessons_Course1'
CREATE INDEX [IX_FK_Course_Lessons_Course1]
ON [dbo].[Course_Lessons]
    ([Unit_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------