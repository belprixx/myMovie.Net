
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/14/2016 15:43:53
-- Generated from EDMX file: C:\dev\ETNA\Movie.net\DatabaseMovie\DatabaseMovie\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DatabaseMov];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FilmAvis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AvisSet] DROP CONSTRAINT [FK_FilmAvis];
GO
IF OBJECT_ID(N'[dbo].[FK_AvisUtilisateur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AvisSet] DROP CONSTRAINT [FK_AvisUtilisateur];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FilmSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilmSet];
GO
IF OBJECT_ID(N'[dbo].[UtilisateurSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilisateurSet];
GO
IF OBJECT_ID(N'[dbo].[AvisSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AvisSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FilmSet'
CREATE TABLE [dbo].[FilmSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Resume] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UtilisateurSet'
CREATE TABLE [dbo].[UtilisateurSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [login] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AvisSet'
CREATE TABLE [dbo].[AvisSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [Commentaire] nvarchar(max)  NOT NULL,
    [Film_Id] int  NOT NULL,
    [Utilisateur_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FilmSet'
ALTER TABLE [dbo].[FilmSet]
ADD CONSTRAINT [PK_FilmSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UtilisateurSet'
ALTER TABLE [dbo].[UtilisateurSet]
ADD CONSTRAINT [PK_UtilisateurSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AvisSet'
ALTER TABLE [dbo].[AvisSet]
ADD CONSTRAINT [PK_AvisSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Film_Id] in table 'AvisSet'
ALTER TABLE [dbo].[AvisSet]
ADD CONSTRAINT [FK_FilmAvis]
    FOREIGN KEY ([Film_Id])
    REFERENCES [dbo].[FilmSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmAvis'
CREATE INDEX [IX_FK_FilmAvis]
ON [dbo].[AvisSet]
    ([Film_Id]);
GO

-- Creating foreign key on [Utilisateur_Id] in table 'AvisSet'
ALTER TABLE [dbo].[AvisSet]
ADD CONSTRAINT [FK_AvisUtilisateur]
    FOREIGN KEY ([Utilisateur_Id])
    REFERENCES [dbo].[UtilisateurSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AvisUtilisateur'
CREATE INDEX [IX_FK_AvisUtilisateur]
ON [dbo].[AvisSet]
    ([Utilisateur_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------