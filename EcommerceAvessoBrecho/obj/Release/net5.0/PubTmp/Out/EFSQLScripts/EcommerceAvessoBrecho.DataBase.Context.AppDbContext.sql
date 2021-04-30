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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE TABLE [Categoria] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(40) NOT NULL,
        CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE TABLE [Cliente] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(100) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [CPF] nvarchar(11) NOT NULL,
        [Endereco] nvarchar(200) NOT NULL,
        [Bairro] nvarchar(100) NOT NULL,
        [Complemento] nvarchar(max) NULL,
        [Municipio] nvarchar(max) NOT NULL,
        [UF] nvarchar(2) NOT NULL,
        [Telefone] nvarchar(max) NOT NULL,
        [CEP] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE TABLE [Produto] (
        [Id] int NOT NULL IDENTITY,
        [Codigo] nvarchar(max) NOT NULL,
        [Nome] nvarchar(80) NOT NULL,
        [Descricao] nvarchar(300) NOT NULL,
        [Preco] decimal(8,2) NOT NULL,
        [DataCadastro] datetime2 NOT NULL,
        [CategoriaId] int NULL,
        CONSTRAINT [PK_Produto] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Produto_Categoria_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE TABLE [Pedido] (
        [Id] int NOT NULL IDENTITY,
        [VlTotalPedido] decimal(8,2) NOT NULL,
        [DataCadastro] datetime2 NOT NULL,
        [ClienteId] int NOT NULL,
        CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE TABLE [ItemPedido] (
        [Id] int NOT NULL IDENTITY,
        [PedidoId] int NOT NULL,
        [ProdutoId] int NULL,
        [PrecoUnitario] decimal(8,2) NOT NULL,
        [Quantidade] int NOT NULL,
        CONSTRAINT [PK_ItemPedido] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ItemPedido_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedido] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ItemPedido_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE INDEX [IX_ItemPedido_PedidoId] ON [ItemPedido] ([PedidoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE INDEX [IX_ItemPedido_ProdutoId] ON [ItemPedido] ([ProdutoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE UNIQUE INDEX [IX_Pedido_ClienteId] ON [Pedido] ([ClienteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    CREATE INDEX [IX_Produto_CategoriaId] ON [Produto] ([CategoriaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210313174353_InicialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210313174353_InicialMigration', N'6.0.0-preview.1.21102.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210317233257_ajusteTabelaProduto')
BEGIN
    ALTER TABLE [Produto] ADD [Disponivel] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210317233257_ajusteTabelaProduto')
BEGIN
    ALTER TABLE [Produto] ADD [Promocao] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210317233257_ajusteTabelaProduto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210317233257_ajusteTabelaProduto', N'6.0.0-preview.1.21102.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320143440_ajusteProduto')
BEGIN
    ALTER TABLE [Produto] ADD [Marca] nvarchar(60) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320143440_ajusteProduto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210320143440_ajusteProduto', N'6.0.0-preview.1.21102.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210328224711_ajustePromocaoProduto')
BEGIN
    ALTER TABLE [Produto] ADD [PrecoPromocional] decimal(8,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210328224711_ajustePromocaoProduto')
BEGIN
    ALTER TABLE [Produto] ADD [SubDescricao] nvarchar(300) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210328224711_ajustePromocaoProduto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210328224711_ajustePromocaoProduto', N'6.0.0-preview.1.21102.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210418204408_AjustePedido')
BEGIN
    ALTER TABLE [Pedido] ADD [VlDesconto] decimal(8,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210418204408_AjustePedido')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210418204408_AjustePedido', N'6.0.0-preview.1.21102.2');
END;
GO

COMMIT;
GO

