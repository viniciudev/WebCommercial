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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE TABLE [tb_client] (
        [Id] int NOT NULL IDENTITY,
        [Cpf] nvarchar(14) NULL,
        [Name] nvarchar(150) NULL,
        [Email] nvarchar(100) NULL,
        [CellPhone] nvarchar(15) NULL,
        [ZipCode] nvarchar(max) NULL,
        [Address] nvarchar(150) NULL,
        [Bairro] nvarchar(100) NULL,
        [Complement] nvarchar(150) NULL,
        [NameState] nvarchar(max) NULL,
        [NameCity] nvarchar(max) NULL,
        [BirthDate] datetime2 NOT NULL,
        [Status] int NOT NULL,
        [Sex] int NOT NULL,
        [CnhRecord] nvarchar(max) NULL,
        CONSTRAINT [PK_tb_client] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE TABLE [tb_company] (
        [Id] int NOT NULL IDENTITY,
        [CorporateName] nvarchar(max) NULL,
        CONSTRAINT [PK_tb_company] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE TABLE [tb_descriptionFiles] (
        [Id] int NOT NULL IDENTITY,
        [NameProduct] nvarchar(max) NULL,
        [descriptionProduct] nvarchar(max) NULL,
        [valueProduct] nvarchar(max) NULL,
        [groupItems] int NOT NULL,
        [idCompany] int NOT NULL,
        CONSTRAINT [PK_tb_descriptionFiles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_descriptionFiles_tb_company_idCompany] FOREIGN KEY ([idCompany]) REFERENCES [tb_company] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE TABLE [tb_user] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [Password] nvarchar(150) NULL,
        [Email] nvarchar(100) NULL,
        [BirthDate] datetime2 NULL,
        [Role] nvarchar(max) NULL,
        [IdCompany] int NOT NULL,
        CONSTRAINT [PK_tb_user] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_user_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE TABLE [tb_file] (
        [Id] int NOT NULL IDENTITY,
        [Files] varbinary(max) NULL,
        [IdDescriptionFiles] int NOT NULL,
        [FileName] nvarchar(max) NULL,
        [ContentType] nvarchar(max) NULL,
        CONSTRAINT [PK_tb_file] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_file_tb_descriptionFiles_IdDescriptionFiles] FOREIGN KEY ([IdDescriptionFiles]) REFERENCES [tb_descriptionFiles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CorporateName') AND [object_id] = OBJECT_ID(N'[tb_company]'))
        SET IDENTITY_INSERT [tb_company] ON;
    EXEC(N'INSERT INTO [tb_company] ([Id], [CorporateName])
    VALUES (1, N''Empresa Padrão'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CorporateName') AND [object_id] = OBJECT_ID(N'[tb_company]'))
        SET IDENTITY_INSERT [tb_company] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BirthDate', N'Email', N'IdCompany', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[tb_user]'))
        SET IDENTITY_INSERT [tb_user] ON;
    EXEC(N'INSERT INTO [tb_user] ([Id], [BirthDate], [Email], [IdCompany], [Name], [Password], [Role])
    VALUES (1, ''1983-01-01T00:00:00.0000000'', N''admin@padrao.com.br'', 1, N''Admin'', N''Admin'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BirthDate', N'Email', N'IdCompany', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[tb_user]'))
        SET IDENTITY_INSERT [tb_user] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE INDEX [IX_tb_descriptionFiles_idCompany] ON [tb_descriptionFiles] ([idCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE INDEX [IX_tb_file_IdDescriptionFiles] ON [tb_file] ([IdDescriptionFiles]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    CREATE INDEX [IX_tb_user_IdCompany] ON [tb_user] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210716222007_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210716222007_initial', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802231352_alter cadastro cliente')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_client]') AND [c].[name] = N'Cpf');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [tb_client] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [tb_client] DROP COLUMN [Cpf];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802231352_alter cadastro cliente')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_client]') AND [c].[name] = N'Sex');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [tb_client] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [tb_client] DROP COLUMN [Sex];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802231352_alter cadastro cliente')
BEGIN
    EXEC sp_rename N'[tb_client].[CnhRecord]', N'Documento', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802231352_alter cadastro cliente')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210802231352_alter cadastro cliente', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802233229_alter')
BEGIN
    EXEC sp_rename N'[tb_client].[Documento]', N'Document', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802233229_alter')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210802233229_alter', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    ALTER TABLE [tb_client] ADD [IdCompany] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    CREATE TABLE [tb_product] (
        [Id] int NOT NULL IDENTITY,
        [IdCompany] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Value] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_tb_product] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_product_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    CREATE TABLE [tb_ServiceProvided] (
        [Id] int NOT NULL IDENTITY,
        [IdCompany] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Value] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_tb_ServiceProvided] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_ServiceProvided_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    EXEC(N'UPDATE [tb_user] SET [Password] = N''''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    CREATE INDEX [IX_tb_client_IdCompany] ON [tb_client] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    CREATE INDEX [IX_tb_product_IdCompany] ON [tb_product] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    CREATE INDEX [IX_tb_ServiceProvided_IdCompany] ON [tb_ServiceProvided] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    ALTER TABLE [tb_client] ADD CONSTRAINT [FK_tb_client_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817200726_news tables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210817200726_news tables', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210825210325_tables budget budgetitems')
BEGIN
    CREATE TABLE [tb_budget] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NULL,
        [IdCompany] int NOT NULL,
        CONSTRAINT [PK_tb_budget] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_budget_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210825210325_tables budget budgetitems')
BEGIN
    CREATE TABLE [tb_budgetItems] (
        [Id] int NOT NULL IDENTITY,
        [IdBudget] int NOT NULL,
        [TypeItem] int NOT NULL,
        [IdProduct] int NOT NULL,
        [IdService] int NOT NULL,
        [Value] decimal(18,2) NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Date] datetime2 NOT NULL,
        CONSTRAINT [PK_tb_budgetItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_budgetItems_tb_budget_IdBudget] FOREIGN KEY ([IdBudget]) REFERENCES [tb_budget] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210825210325_tables budget budgetitems')
BEGIN
    CREATE INDEX [IX_tb_budget_IdCompany] ON [tb_budget] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210825210325_tables budget budgetitems')
BEGIN
    CREATE INDEX [IX_tb_budgetItems_IdBudget] ON [tb_budgetItems] ([IdBudget]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210825210325_tables budget budgetitems')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210825210325_tables budget budgetitems', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901223748_alter column')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_budgetItems]') AND [c].[name] = N'IdProduct');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [tb_budgetItems] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [tb_budgetItems] DROP COLUMN [IdProduct];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901223748_alter column')
BEGIN
    EXEC sp_rename N'[tb_budgetItems].[IdService]', N'IdItem', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901223748_alter column')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210901223748_alter column', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210929222243_alter budget')
BEGIN
    ALTER TABLE [tb_budget] ADD [IdClient] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210929222243_alter budget')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210929222243_alter budget', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_budget] DROP CONSTRAINT [FK_tb_budget_tb_company_IdCompany];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_budgetItems] DROP CONSTRAINT [FK_tb_budgetItems_tb_budget_IdBudget];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_client] DROP CONSTRAINT [FK_tb_client_tb_company_IdCompany];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_descriptionFiles] DROP CONSTRAINT [FK_tb_descriptionFiles_tb_company_idCompany];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_file] DROP CONSTRAINT [FK_tb_file_tb_descriptionFiles_IdDescriptionFiles];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_product] DROP CONSTRAINT [FK_tb_product_tb_company_IdCompany];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_ServiceProvided] DROP CONSTRAINT [FK_tb_ServiceProvided_tb_company_IdCompany];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_user] DROP CONSTRAINT [FK_tb_user_tb_company_IdCompany];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    CREATE TABLE [tb_serviceProvision] (
        [Id] int NOT NULL IDENTITY,
        [IdBudget] int NULL,
        [IdClient] int NOT NULL,
        [IdCompany] int NOT NULL,
        CONSTRAINT [PK_tb_serviceProvision] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_serviceProvision_tb_budget_IdBudget] FOREIGN KEY ([IdBudget]) REFERENCES [tb_budget] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_serviceProvision_tb_client_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [tb_client] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_serviceProvision_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    CREATE TABLE [tb_servicesProvisionItems] (
        [Id] int NOT NULL IDENTITY,
        [IdServiceProvision] int NOT NULL,
        [TypeItem] int NOT NULL,
        [IdItem] int NOT NULL,
        [Value] decimal(18,2) NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Date] datetime2 NOT NULL,
        CONSTRAINT [PK_tb_servicesProvisionItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_servicesProvisionItems_tb_serviceProvision_IdServiceProvision] FOREIGN KEY ([IdServiceProvision]) REFERENCES [tb_serviceProvision] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    CREATE INDEX [IX_tb_serviceProvision_IdBudget] ON [tb_serviceProvision] ([IdBudget]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    CREATE INDEX [IX_tb_serviceProvision_IdClient] ON [tb_serviceProvision] ([IdClient]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    CREATE INDEX [IX_tb_serviceProvision_IdCompany] ON [tb_serviceProvision] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    CREATE INDEX [IX_tb_servicesProvisionItems_IdServiceProvision] ON [tb_servicesProvisionItems] ([IdServiceProvision]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_budget] ADD CONSTRAINT [FK_tb_budget_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_budgetItems] ADD CONSTRAINT [FK_tb_budgetItems_tb_budget_IdBudget] FOREIGN KEY ([IdBudget]) REFERENCES [tb_budget] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_client] ADD CONSTRAINT [FK_tb_client_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_descriptionFiles] ADD CONSTRAINT [FK_tb_descriptionFiles_tb_company_idCompany] FOREIGN KEY ([idCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_file] ADD CONSTRAINT [FK_tb_file_tb_descriptionFiles_IdDescriptionFiles] FOREIGN KEY ([IdDescriptionFiles]) REFERENCES [tb_descriptionFiles] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_product] ADD CONSTRAINT [FK_tb_product_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_ServiceProvided] ADD CONSTRAINT [FK_tb_ServiceProvided_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    ALTER TABLE [tb_user] ADD CONSTRAINT [FK_tb_user_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012161238_Services Provision')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211012161238_Services Provision', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012165349_date now')
BEGIN
    ALTER TABLE [tb_serviceProvision] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012165349_date now')
BEGIN
    ALTER TABLE [tb_budget] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211012165349_date now')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211012165349_date now', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211101234320_add column servicesprovision')
BEGIN
    ALTER TABLE [tb_serviceProvision] ADD [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211101234320_add column servicesprovision')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211101234320_add column servicesprovision', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211229210044_alters')
BEGIN
    EXEC(N'DELETE FROM [tb_user]
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211229210044_alters')
BEGIN
    ALTER TABLE [tb_user] ADD [CellPhone] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211229210044_alters')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BirthDate', N'CellPhone', N'Email', N'IdCompany', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[tb_user]'))
        SET IDENTITY_INSERT [tb_user] ON;
    EXEC(N'INSERT INTO [tb_user] ([Id], [BirthDate], [CellPhone], [Email], [IdCompany], [Name], [Password], [Role])
    VALUES (1, ''1983-01-01T00:00:00.0000000'', NULL, N''admin@padrao.com.br'', 1, N''Admin'', N'''', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BirthDate', N'CellPhone', N'Email', N'IdCompany', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[tb_user]'))
        SET IDENTITY_INSERT [tb_user] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211229210044_alters')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211229210044_alters', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220413225021_add collunm tb_file')
BEGIN
    ALTER TABLE [tb_file] ADD [FileThumb] varbinary(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220413225021_add collunm tb_file')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220413225021_add collunm tb_file', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011223300_create table salesman')
BEGIN
    CREATE TABLE [tb_salesman] (
        [Id] int NOT NULL IDENTITY,
        [Name] int NOT NULL,
        [Document] int NOT NULL,
        [ZipCode] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Bairro] nvarchar(max) NULL,
        [NameSate] nvarchar(max) NULL,
        [NameCity] nvarchar(max) NULL,
        [Telephone] int NOT NULL,
        [IdCompany] int NOT NULL,
        CONSTRAINT [PK_tb_salesman] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_salesman_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011223300_create table salesman')
BEGIN
    CREATE INDEX [IX_tb_salesman_IdCompany] ON [tb_salesman] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011223300_create table salesman')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221011223300_create table salesman', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024223311_alter table salesman')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_salesman]') AND [c].[name] = N'Telephone');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [tb_salesman] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [tb_salesman] ALTER COLUMN [Telephone] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024223311_alter table salesman')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_salesman]') AND [c].[name] = N'Name');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [tb_salesman] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [tb_salesman] ALTER COLUMN [Name] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024223311_alter table salesman')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_salesman]') AND [c].[name] = N'Document');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [tb_salesman] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [tb_salesman] ALTER COLUMN [Document] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024223311_alter table salesman')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221024223311_alter table salesman', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221107210152_correction nameState salesman')
BEGIN
    EXEC sp_rename N'[tb_salesman].[NameSate]', N'NameState', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221107210152_correction nameState salesman')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221107210152_correction nameState salesman', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE TABLE [tb_sale] (
        [Id] int NOT NULL IDENTITY,
        [IdCompany] int NOT NULL,
        [ReleaseDate] datetime2 NOT NULL,
        [SaleDate] datetime2 NOT NULL,
        [IdClient] int NOT NULL,
        [IdSeller] int NULL,
        CONSTRAINT [PK_tb_sale] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_sale_tb_client_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [tb_client] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_sale_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_sale_tb_salesman_IdSeller] FOREIGN KEY ([IdSeller]) REFERENCES [tb_salesman] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE TABLE [tb_saleItems] (
        [Id] int NOT NULL IDENTITY,
        [Value] decimal(18,2) NOT NULL,
        [Amount] int NOT NULL,
        [InclusionDate] datetime2 NOT NULL,
        [IdSale] int NOT NULL,
        [IdProduct] int NULL,
        [IdService] int NULL,
        CONSTRAINT [PK_tb_saleItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_saleItems_tb_product_IdProduct] FOREIGN KEY ([IdProduct]) REFERENCES [tb_product] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_saleItems_tb_sale_IdSale] FOREIGN KEY ([IdSale]) REFERENCES [tb_sale] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_saleItems_tb_ServiceProvided_IdService] FOREIGN KEY ([IdService]) REFERENCES [tb_ServiceProvided] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE INDEX [IX_tb_sale_IdClient] ON [tb_sale] ([IdClient]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE INDEX [IX_tb_sale_IdCompany] ON [tb_sale] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE INDEX [IX_tb_sale_IdSeller] ON [tb_sale] ([IdSeller]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE INDEX [IX_tb_saleItems_IdProduct] ON [tb_saleItems] ([IdProduct]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE INDEX [IX_tb_saleItems_IdSale] ON [tb_saleItems] ([IdSale]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    CREATE INDEX [IX_tb_saleItems_IdService] ON [tb_saleItems] ([IdService]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110212553_Add Tables sale and saleitems')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221110212553_Add Tables sale and saleitems', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112132224_add tb_commission')
BEGIN
    CREATE TABLE [CostCenter] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_CostCenter] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112132224_add tb_commission')
BEGIN
    CREATE TABLE [Commission] (
        [Id] int NOT NULL IDENTITY,
        [IdService] int NULL,
        [ServiceProvidedId] int NULL,
        [IdProduct] int NULL,
        [ProductId] int NULL,
        [IdSalesman] int NOT NULL,
        [SalesmanId] int NULL,
        [Percentage] int NOT NULL,
        [Status] int NOT NULL,
        [CommissionDay] int NOT NULL,
        [TypeDay] int NOT NULL,
        [IdCostCenter] int NOT NULL,
        [CostCenterId] int NULL,
        CONSTRAINT [PK_Commission] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Commission_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [CostCenter] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Commission_tb_product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [tb_product] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Commission_tb_salesman_SalesmanId] FOREIGN KEY ([SalesmanId]) REFERENCES [tb_salesman] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Commission_tb_ServiceProvided_ServiceProvidedId] FOREIGN KEY ([ServiceProvidedId]) REFERENCES [tb_ServiceProvided] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112132224_add tb_commission')
BEGIN
    CREATE INDEX [IX_Commission_CostCenterId] ON [Commission] ([CostCenterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112132224_add tb_commission')
BEGIN
    CREATE INDEX [IX_Commission_ProductId] ON [Commission] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112132224_add tb_commission')
BEGIN
    CREATE INDEX [IX_Commission_SalesmanId] ON [Commission] ([SalesmanId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112132224_add tb_commission')
BEGIN
    CREATE INDEX [IX_Commission_ServiceProvidedId] ON [Commission] ([ServiceProvidedId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112132224_add tb_commission')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230112132224_add tb_commission', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [Commission] DROP CONSTRAINT [FK_Commission_CostCenter_CostCenterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [Commission] DROP CONSTRAINT [FK_Commission_tb_product_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [Commission] DROP CONSTRAINT [FK_Commission_tb_salesman_SalesmanId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [Commission] DROP CONSTRAINT [FK_Commission_tb_ServiceProvided_ServiceProvidedId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [CostCenter] DROP CONSTRAINT [PK_CostCenter];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [Commission] DROP CONSTRAINT [PK_Commission];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DROP INDEX [IX_Commission_CostCenterId] ON [Commission];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DROP INDEX [IX_Commission_ProductId] ON [Commission];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DROP INDEX [IX_Commission_SalesmanId] ON [Commission];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DROP INDEX [IX_Commission_ServiceProvidedId] ON [Commission];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Commission]') AND [c].[name] = N'CostCenterId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Commission] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Commission] DROP COLUMN [CostCenterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Commission]') AND [c].[name] = N'ProductId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Commission] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Commission] DROP COLUMN [ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Commission]') AND [c].[name] = N'SalesmanId');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Commission] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Commission] DROP COLUMN [SalesmanId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Commission]') AND [c].[name] = N'ServiceProvidedId');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Commission] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Commission] DROP COLUMN [ServiceProvidedId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    EXEC sp_rename N'[CostCenter]', N'tb_costCenter';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    EXEC sp_rename N'[Commission]', N'tb_commission';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_costCenter] ADD [IdCompany] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_costCenter] ADD CONSTRAINT [PK_tb_costCenter] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_commission] ADD CONSTRAINT [PK_tb_commission] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    CREATE INDEX [IX_tb_costCenter_IdCompany] ON [tb_costCenter] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    CREATE INDEX [IX_tb_commission_IdCostCenter] ON [tb_commission] ([IdCostCenter]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    CREATE INDEX [IX_tb_commission_IdProduct] ON [tb_commission] ([IdProduct]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    CREATE INDEX [IX_tb_commission_IdSalesman] ON [tb_commission] ([IdSalesman]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    CREATE INDEX [IX_tb_commission_IdService] ON [tb_commission] ([IdService]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_commission] ADD CONSTRAINT [FK_tb_commission_tb_costCenter_IdCostCenter] FOREIGN KEY ([IdCostCenter]) REFERENCES [tb_costCenter] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_commission] ADD CONSTRAINT [FK_tb_commission_tb_product_IdProduct] FOREIGN KEY ([IdProduct]) REFERENCES [tb_product] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_commission] ADD CONSTRAINT [FK_tb_commission_tb_salesman_IdSalesman] FOREIGN KEY ([IdSalesman]) REFERENCES [tb_salesman] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_commission] ADD CONSTRAINT [FK_tb_commission_tb_ServiceProvided_IdService] FOREIGN KEY ([IdService]) REFERENCES [tb_ServiceProvided] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    ALTER TABLE [tb_costCenter] ADD CONSTRAINT [FK_tb_costCenter_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230112134533_add tb_costcenter')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230112134533_add tb_costcenter', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203212327_create financial model')
BEGIN
    CREATE TABLE [tb_financial] (
        [Id] int NOT NULL IDENTITY,
        [IdCompany] int NOT NULL,
        [CreationDate] datetime2 NOT NULL,
        [Description] nvarchar(max) NULL,
        [FinancialType] int NOT NULL,
        [IdCostCenter] int NOT NULL,
        [FinancialStatus] int NOT NULL,
        [DueDate] datetime2 NOT NULL,
        [Value] decimal(18,2) NOT NULL,
        [PaymentType] int NOT NULL,
        CONSTRAINT [PK_tb_financial] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_financial_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_financial_tb_costCenter_IdCostCenter] FOREIGN KEY ([IdCostCenter]) REFERENCES [tb_costCenter] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203212327_create financial model')
BEGIN
    CREATE INDEX [IX_tb_financial_IdCompany] ON [tb_financial] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203212327_create financial model')
BEGIN
    CREATE INDEX [IX_tb_financial_IdCostCenter] ON [tb_financial] ([IdCostCenter]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203212327_create financial model')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230203212327_create financial model', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD [IdProduct] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD [IdSale] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD [IdSalesman] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD [IdService] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    CREATE INDEX [IX_tb_financial_IdProduct] ON [tb_financial] ([IdProduct]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    CREATE INDEX [IX_tb_financial_IdSale] ON [tb_financial] ([IdSale]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    CREATE INDEX [IX_tb_financial_IdSalesman] ON [tb_financial] ([IdSalesman]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    CREATE INDEX [IX_tb_financial_IdService] ON [tb_financial] ([IdService]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD CONSTRAINT [FK_tb_financial_tb_product_IdProduct] FOREIGN KEY ([IdProduct]) REFERENCES [tb_product] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD CONSTRAINT [FK_tb_financial_tb_sale_IdSale] FOREIGN KEY ([IdSale]) REFERENCES [tb_sale] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD CONSTRAINT [FK_tb_financial_tb_salesman_IdSalesman] FOREIGN KEY ([IdSalesman]) REFERENCES [tb_salesman] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    ALTER TABLE [tb_financial] ADD CONSTRAINT [FK_tb_financial_tb_ServiceProvided_IdService] FOREIGN KEY ([IdService]) REFERENCES [tb_ServiceProvided] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206222755_add colunas fin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230206222755_add colunas fin', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207185431_add colluns')
BEGIN
    ALTER TABLE [tb_saleItems] ADD [TypeItem] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207185431_add colluns')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230207185431_add colluns', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207193702_add collun fk')
BEGIN
    ALTER TABLE [tb_financial] ADD [IdSaleItems] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207193702_add collun fk')
BEGIN
    CREATE INDEX [IX_tb_financial_IdSaleItems] ON [tb_financial] ([IdSaleItems]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207193702_add collun fk')
BEGIN
    ALTER TABLE [tb_financial] ADD CONSTRAINT [FK_tb_financial_tb_saleItems_IdSaleItems] FOREIGN KEY ([IdSaleItems]) REFERENCES [tb_saleItems] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207193702_add collun fk')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230207193702_add collun fk', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230208134059_add collum percentage in tb_financial')
BEGIN
    ALTER TABLE [tb_financial] ADD [Percentage] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230208134059_add collum percentage in tb_financial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230208134059_add collum percentage in tb_financial', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230214194130_add tb_plan')
BEGIN
    CREATE TABLE [tb_planCompany] (
        [Id] int NOT NULL IDENTITY,
        [DateRegister] datetime2 NOT NULL,
        [ExpirationDate] datetime2 NOT NULL,
        CONSTRAINT [PK_tb_planCompany] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230214194130_add tb_plan')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230214194130_add tb_plan', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230216160423_new table plan')
BEGIN
    ALTER TABLE [tb_planCompany] ADD [IdCompany] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230216160423_new table plan')
BEGIN
    ALTER TABLE [tb_planCompany] ADD [LastPayment] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230216160423_new table plan')
BEGIN
    ALTER TABLE [tb_planCompany] ADD [Status] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230216160423_new table plan')
BEGIN
    ALTER TABLE [tb_company] ADD [Guid] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230216160423_new table plan')
BEGIN
    CREATE UNIQUE INDEX [IX_tb_planCompany_IdCompany] ON [tb_planCompany] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230216160423_new table plan')
BEGIN
    ALTER TABLE [tb_planCompany] ADD CONSTRAINT [FK_tb_planCompany_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230216160423_new table plan')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230216160423_new table plan', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230224215104_Create table prospects')
BEGIN
    CREATE TABLE [tb_prospects] (
        [Id] int NOT NULL IDENTITY,
        [IdCompany] int NOT NULL,
        [RegisterDate] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [CellPhone] nvarchar(max) NULL,
        CONSTRAINT [PK_tb_prospects] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_prospects_tb_company_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [tb_company] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230224215104_Create table prospects')
BEGIN
    CREATE INDEX [IX_tb_prospects_IdCompany] ON [tb_prospects] ([IdCompany]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230224215104_Create table prospects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230224215104_Create table prospects', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230227151825_create table phasesProspects')
BEGIN
    CREATE TABLE [tb_phasesProspects] (
        [Id] int NOT NULL IDENTITY,
        [IdProspects] int NOT NULL,
        [Info] nvarchar(max) NULL,
        CONSTRAINT [PK_tb_phasesProspects] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_phasesProspects_tb_prospects_IdProspects] FOREIGN KEY ([IdProspects]) REFERENCES [tb_prospects] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230227151825_create table phasesProspects')
BEGIN
    CREATE INDEX [IX_tb_phasesProspects_IdProspects] ON [tb_phasesProspects] ([IdProspects]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230227151825_create table phasesProspects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230227151825_create table phasesProspects', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303122444_add colluns saleitems')
BEGIN
    ALTER TABLE [tb_saleItems] ADD [EnableRecurrence] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303122444_add colluns saleitems')
BEGIN
    ALTER TABLE [tb_saleItems] ADD [RecurringAmount] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303122444_add colluns saleitems')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303122444_add colluns saleitems', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303125027_add colluns saleitems alter recurringAmount to int')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_saleItems]') AND [c].[name] = N'RecurringAmount');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [tb_saleItems] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [tb_saleItems] ALTER COLUMN [RecurringAmount] int NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303125027_add colluns saleitems alter recurringAmount to int')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303125027_add colluns saleitems alter recurringAmount to int', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303190627_add table SharedCommission')
BEGIN
    CREATE TABLE [tb_sharedCommission] (
        [Id] int NOT NULL IDENTITY,
        [IdSaleItems] int NOT NULL,
        [IdSalesman] int NOT NULL,
        [Percentage] int NOT NULL,
        [Status] int NOT NULL,
        [CommissionDay] int NOT NULL,
        [TypeDay] int NOT NULL,
        [IdCostCenter] int NOT NULL,
        CONSTRAINT [PK_tb_sharedCommission] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_tb_sharedCommission_tb_costCenter_IdCostCenter] FOREIGN KEY ([IdCostCenter]) REFERENCES [tb_costCenter] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_sharedCommission_tb_saleItems_IdSaleItems] FOREIGN KEY ([IdSaleItems]) REFERENCES [tb_saleItems] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tb_sharedCommission_tb_salesman_IdSalesman] FOREIGN KEY ([IdSalesman]) REFERENCES [tb_salesman] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303190627_add table SharedCommission')
BEGIN
    CREATE INDEX [IX_tb_sharedCommission_IdCostCenter] ON [tb_sharedCommission] ([IdCostCenter]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303190627_add table SharedCommission')
BEGIN
    CREATE INDEX [IX_tb_sharedCommission_IdSaleItems] ON [tb_sharedCommission] ([IdSaleItems]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303190627_add table SharedCommission')
BEGIN
    CREATE INDEX [IX_tb_sharedCommission_IdSalesman] ON [tb_sharedCommission] ([IdSalesman]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303190627_add table SharedCommission')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303190627_add table SharedCommission', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303195312_add new colluns SharedCommission')
BEGIN
    EXEC sp_rename N'[tb_sharedCommission].[Status]', N'RecurringAmount', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303195312_add new colluns SharedCommission')
BEGIN
    ALTER TABLE [tb_sharedCommission] ADD [EnableSharedCommission] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230303195312_add new colluns SharedCommission')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230303195312_add new colluns SharedCommission', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307210041_create new collun sharedCommission')
BEGIN
    ALTER TABLE [tb_sharedCommission] ADD [NameSeller] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307210041_create new collun sharedCommission')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230307210041_create new collun sharedCommission', N'6.0.13');
END;
GO

COMMIT;
GO

