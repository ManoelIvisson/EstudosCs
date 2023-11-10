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

CREATE TABLE [Categoria] (
    [Id] int NOT NULL IDENTITY,
    [Nome] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Perfil] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Slug] nvarchar(max) NULL,
    CONSTRAINT [PK_Perfil] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tag] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Slug] nvarchar(max) NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] nvarchar(450) NULL,
    [SenhaHash] nvarchar(max) NULL,
    [Bio] nvarchar(max) NULL,
    [Imagem] nvarchar(max) NULL,
    [GitHub] nvarchar(max) NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Postagem] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NULL,
    [Resumo] nvarchar(max) NULL,
    [Corpo] nvarchar(max) NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [DataCriacao] SMALLDATETIME NOT NULL DEFAULT (GETDATE()),
    [DataUltimaAtualizacao] SMALLDATETIME NOT NULL DEFAULT (GETDATE()),
    [CategoriaId] int NULL,
    [AutorId] int NULL,
    CONSTRAINT [PK_Postagem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Postagem_Autor] FOREIGN KEY ([AutorId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Postagem_Categoria] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UsuarioPerfil] (
    [PerfilId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_UsuarioPerfil] PRIMARY KEY ([PerfilId], [UsuarioId]),
    CONSTRAINT [FK_UsuarioPerfil_PerfilId] FOREIGN KEY ([PerfilId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsuarioPerfil_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Perfil] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PostagemTag] (
    [PostagemId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_PostagemTag] PRIMARY KEY ([PostagemId], [TagId]),
    CONSTRAINT [FK_PostagemTag_PostagemId] FOREIGN KEY ([PostagemId]) REFERENCES [Tag] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostagemTag_TagId] FOREIGN KEY ([TagId]) REFERENCES [Postagem] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Categoria_Slug] ON [Categoria] ([Slug]);
GO

CREATE INDEX [IX_Postagem_AutorId] ON [Postagem] ([AutorId]);
GO

CREATE INDEX [IX_Postagem_CategoriaId] ON [Postagem] ([CategoriaId]);
GO

CREATE INDEX [IX_PostagemTag_TagId] ON [PostagemTag] ([TagId]);
GO

CREATE UNIQUE INDEX [IX_Usuario_Email] ON [Usuario] ([Email]) WHERE [Email] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_Usuario_Slug] ON [Usuario] ([Slug]);
GO

CREATE INDEX [IX_UsuarioPerfil_UsuarioId] ON [UsuarioPerfil] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230901142257_MigracaoInicial', N'7.0.10');
GO

COMMIT;
GO

