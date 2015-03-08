
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/05/2015 23:44:33
-- Generated from EDMX file: D:\User\Documents\GitHub\SoftUni\Database Applications\01.Entity Framework\01.SoftUniDesigner\SoftUniContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SoftUniDesigner];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AddressTown]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_AddressTown];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_AddressEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_DepartmentEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Deaprtments] DROP CONSTRAINT [FK_DepartmentManager];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectEmployee_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectEmployee] DROP CONSTRAINT [FK_ProjectEmployee_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectEmployee_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectEmployee] DROP CONSTRAINT [FK_ProjectEmployee_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_EmployeeManager];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Towns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Towns];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Deaprtments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Deaprtments];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[ProjectEmployee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectEmployee];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Towns'
CREATE TABLE [dbo].[Towns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [AddressText] nvarchar(max)  NOT NULL,
    [TownId] int  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [HireDate] datetime  NOT NULL,
    [Salary] decimal(18,0)  NOT NULL,
    [AddressId] int  NULL,
    [DepartmentId] int  NOT NULL,
    [ManagerId] nvarchar(max)  NOT NULL,
    [EmployeeManager_Employee_Id] int  NOT NULL
);
GO

-- Creating table 'Deaprtments'
CREATE TABLE [dbo].[Deaprtments] (
    [DepartmentId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ManagerId] int  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL
);
GO

-- Creating table 'ProjectEmployee'
CREATE TABLE [dbo].[ProjectEmployee] (
    [Projects_ProjectId] int  NOT NULL,
    [Employees_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Towns'
ALTER TABLE [dbo].[Towns]
ADD CONSTRAINT [PK_Towns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [DepartmentId] in table 'Deaprtments'
ALTER TABLE [dbo].[Deaprtments]
ADD CONSTRAINT [PK_Deaprtments]
    PRIMARY KEY CLUSTERED ([DepartmentId] ASC);
GO

-- Creating primary key on [ProjectId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectId] ASC);
GO

-- Creating primary key on [Projects_ProjectId], [Employees_Id] in table 'ProjectEmployee'
ALTER TABLE [dbo].[ProjectEmployee]
ADD CONSTRAINT [PK_ProjectEmployee]
    PRIMARY KEY CLUSTERED ([Projects_ProjectId], [Employees_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TownId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_AddressTown]
    FOREIGN KEY ([TownId])
    REFERENCES [dbo].[Towns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressTown'
CREATE INDEX [IX_FK_AddressTown]
ON [dbo].[Addresses]
    ([TownId]);
GO

-- Creating foreign key on [AddressId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_AddressEmployee]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressEmployee'
CREATE INDEX [IX_FK_AddressEmployee]
ON [dbo].[Employees]
    ([AddressId]);
GO

-- Creating foreign key on [DepartmentId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_DepartmentEmployee]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[Deaprtments]
        ([DepartmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentEmployee'
CREATE INDEX [IX_FK_DepartmentEmployee]
ON [dbo].[Employees]
    ([DepartmentId]);
GO

-- Creating foreign key on [ManagerId] in table 'Deaprtments'
ALTER TABLE [dbo].[Deaprtments]
ADD CONSTRAINT [FK_DepartmentManager]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentManager'
CREATE INDEX [IX_FK_DepartmentManager]
ON [dbo].[Deaprtments]
    ([ManagerId]);
GO

-- Creating foreign key on [Projects_ProjectId] in table 'ProjectEmployee'
ALTER TABLE [dbo].[ProjectEmployee]
ADD CONSTRAINT [FK_ProjectEmployee_Project]
    FOREIGN KEY ([Projects_ProjectId])
    REFERENCES [dbo].[Projects]
        ([ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Employees_Id] in table 'ProjectEmployee'
ALTER TABLE [dbo].[ProjectEmployee]
ADD CONSTRAINT [FK_ProjectEmployee_Employee]
    FOREIGN KEY ([Employees_Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectEmployee_Employee'
CREATE INDEX [IX_FK_ProjectEmployee_Employee]
ON [dbo].[ProjectEmployee]
    ([Employees_Id]);
GO

-- Creating foreign key on [EmployeeManager_Employee_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeManager]
    FOREIGN KEY ([EmployeeManager_Employee_Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeManager'
CREATE INDEX [IX_FK_EmployeeManager]
ON [dbo].[Employees]
    ([EmployeeManager_Employee_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------