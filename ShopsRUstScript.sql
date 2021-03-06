IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Discount] (
    [Id] int NOT NULL IDENTITY,
    [CreatedOnUtc] datetime2 NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [DiscountTypeId] int NOT NULL,
    [DiscountValue] decimal(10,2) NOT NULL,
    [DiscountType] int NOT NULL,
    CONSTRAINT [PK_Discount] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ItemType] (
    [Id] int NOT NULL IDENTITY,
    [CreatedOnUtc] datetime2 NOT NULL,
    [Name] nvarchar(15) NOT NULL,
    CONSTRAINT [PK_ItemType] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [CreatedOnUtc] datetime2 NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [IsEmployee] bit NOT NULL,
    [IsAffiliated] bit NOT NULL,
    [AffiliatedOnUtc] datetime2 NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Item] (
    [Id] int NOT NULL IDENTITY,
    [CreatedOnUtc] datetime2 NOT NULL,
    [Name] nvarchar(30) NOT NULL,
    [TypeId] int NOT NULL,
    [UnitPrice] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Item_ItemType_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [ItemType] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Bill] (
    [Id] int NOT NULL IDENTITY,
    [CreatedOnUtc] datetime2 NOT NULL,
    [UserId] int NOT NULL,
    [TotalGrossAmount] decimal(10,2) NOT NULL,
    [DiscountAmount] decimal(10,2) NOT NULL,
    [TotalNetAmount] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Bill] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Bill_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BillDiscount] (
    [Id] int NOT NULL IDENTITY,
    [CreatedOnUtc] datetime2 NOT NULL,
    [BillId] int NOT NULL,
    [DiscountId] int NOT NULL,
    CONSTRAINT [PK_BillDiscount] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BillDiscount_Bill_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bill] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BillDiscount_Discount_DiscountId] FOREIGN KEY ([DiscountId]) REFERENCES [Discount] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BillItem] (
    [Id] int NOT NULL IDENTITY,
    [CreatedOnUtc] datetime2 NOT NULL,
    [BillId] int NOT NULL,
    [ItemId] int NOT NULL,
    [Quantity] int NOT NULL,
    [UnitPrice] decimal(10,2) NOT NULL,
    [SubTotalAmount] decimal(10,2) NOT NULL,
    [SubTotalDiscount] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_BillItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BillItem_Bill_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bill] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BillItem_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Description', N'DiscountType', N'DiscountTypeId', N'DiscountValue', N'Name') AND [object_id] = OBJECT_ID(N'[Discount]'))
    SET IDENTITY_INSERT [Discount] ON;
INSERT INTO [Discount] ([Id], [CreatedOnUtc], [Description], [DiscountType], [DiscountTypeId], [DiscountValue], [Name])
VALUES (1, '2021-05-09T22:30:48.2650690-04:00', N'10% de descuento para clientes afiliados', 1, 1, 10.0, N'10%'),
(2, '2021-05-09T22:30:48.2658081-04:00', N'30% de descuento para empleados', 1, 1, 30.0, N'30%'),
(3, '2021-05-09T22:30:48.2658096-04:00', N'5% de descuento para clientes con más de 2 años en la tienda', 1, 1, 5.0, N'5%'),
(4, '2021-05-09T22:30:48.2658099-04:00', N'$5 dólares por cada $100 dólares en compras', 2, 2, 5.0, N'$5');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Description', N'DiscountType', N'DiscountTypeId', N'DiscountValue', N'Name') AND [object_id] = OBJECT_ID(N'[Discount]'))
    SET IDENTITY_INSERT [Discount] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name') AND [object_id] = OBJECT_ID(N'[ItemType]'))
    SET IDENTITY_INSERT [ItemType] ON;
INSERT INTO [ItemType] ([Id], [CreatedOnUtc], [Name])
VALUES (1, '2021-05-10T02:30:48.2558330Z', N'Comestible'),
(2, '2021-05-10T02:30:48.2558395Z', N'Limpieza'),
(3, '2021-05-10T02:30:48.2558398Z', N'Ropa');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name') AND [object_id] = OBJECT_ID(N'[ItemType]'))
    SET IDENTITY_INSERT [ItemType] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AffiliatedOnUtc', N'CreatedOnUtc', N'IsAffiliated', N'IsEmployee', N'Name') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] ON;
INSERT INTO [User] ([Id], [AffiliatedOnUtc], [CreatedOnUtc], [IsAffiliated], [IsEmployee], [Name])
VALUES (1, '2021-05-10T02:30:48.2458173Z', '2021-05-10T02:30:48.2458864Z', CAST(1 AS bit), CAST(0 AS bit), N'Juan Pérez'),
(2, '2018-05-10T02:30:48.2459482Z', '2018-05-10T02:30:48.2459587Z', CAST(1 AS bit), CAST(1 AS bit), N'María Magdalena'),
(3, NULL, '2021-05-10T02:30:48.2459602Z', CAST(0 AS bit), CAST(0 AS bit), N'Pedro Almonte'),
(4, NULL, '2021-05-10T02:30:48.2459604Z', CAST(0 AS bit), CAST(1 AS bit), N'Rosa Zapata');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AffiliatedOnUtc', N'CreatedOnUtc', N'IsAffiliated', N'IsEmployee', N'Name') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name', N'TypeId', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Item]'))
    SET IDENTITY_INSERT [Item] ON;
INSERT INTO [Item] ([Id], [CreatedOnUtc], [Name], [TypeId], [UnitPrice])
VALUES (1, '2021-05-10T02:30:48.2580209Z', N'Manzana', 1, 24.99);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name', N'TypeId', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Item]'))
    SET IDENTITY_INSERT [Item] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name', N'TypeId', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Item]'))
    SET IDENTITY_INSERT [Item] ON;
INSERT INTO [Item] ([Id], [CreatedOnUtc], [Name], [TypeId], [UnitPrice])
VALUES (3, '2021-05-10T02:30:48.2580303Z', N'Mistolin', 2, 84.99);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name', N'TypeId', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Item]'))
    SET IDENTITY_INSERT [Item] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name', N'TypeId', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Item]'))
    SET IDENTITY_INSERT [Item] ON;
INSERT INTO [Item] ([Id], [CreatedOnUtc], [Name], [TypeId], [UnitPrice])
VALUES (2, '2021-05-10T02:30:48.2580300Z', N'Pantalon', 3, 299.99);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOnUtc', N'Name', N'TypeId', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Item]'))
    SET IDENTITY_INSERT [Item] OFF;

GO

CREATE INDEX [IX_Bill_UserId] ON [Bill] ([UserId]);

GO

CREATE INDEX [IX_BillDiscount_BillId] ON [BillDiscount] ([BillId]);

GO

CREATE INDEX [IX_BillDiscount_DiscountId] ON [BillDiscount] ([DiscountId]);

GO

CREATE INDEX [IX_BillItem_BillId] ON [BillItem] ([BillId]);

GO

CREATE INDEX [IX_BillItem_ItemId] ON [BillItem] ([ItemId]);

GO

CREATE INDEX [IX_Item_TypeId] ON [Item] ([TypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210510023048_InitialMigration', N'3.1.14');

GO

