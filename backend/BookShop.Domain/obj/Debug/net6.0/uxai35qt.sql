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

CREATE TABLE [Authors] (
    [AuthorId] int NOT NULL,
    [FirstName] varchar(45) NOT NULL,
    [MiddleName] varchar(45) NULL,
    [LastName] varchar(45) NULL,
    [PenName] varchar(45) NULL,
    [Telephone] varchar(18) NULL,
    [BirthDate] date NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorId])
);
GO

CREATE TABLE [AvailabilityRef] (
    [AvailabilityId] int NOT NULL IDENTITY,
    [AvailabilityName] varchar(45) NOT NULL,
    CONSTRAINT [PK__Availabi__DA3979B155081618] PRIMARY KEY ([AvailabilityId])
);
GO

CREATE TABLE [CurrencyRef] (
    [CurrencyId] int NOT NULL IDENTITY,
    [CurrencyName] varchar(45) NOT NULL,
    CONSTRAINT [PK__Currency__14470AF0421D2CB1] PRIMARY KEY ([CurrencyId])
);
GO

CREATE TABLE [GenreRef] (
    [GenreId] int NOT NULL IDENTITY,
    [GenreName] varchar(45) NOT NULL,
    CONSTRAINT [PK__GenreRef__0385057EBACAB50B] PRIMARY KEY ([GenreId])
);
GO

CREATE TABLE [LanguageRef] (
    [LanguageId] int NOT NULL IDENTITY,
    [LanguageName] varchar(45) NOT NULL,
    CONSTRAINT [PK__Language__B93855AB662E9D0E] PRIMARY KEY ([LanguageId])
);
GO

CREATE TABLE [OrderStatusRef] (
    [OrderstatusId] int NOT NULL IDENTITY,
    [OrderstatusName] varchar(45) NOT NULL,
    CONSTRAINT [PK__OrderSta__F940B395A07FC836] PRIMARY KEY ([OrderstatusId])
);
GO

CREATE TABLE [Persons] (
    [PersonId] int NOT NULL,
    [FirstName] varchar(45) NOT NULL,
    [MiddleName] varchar(45) NULL,
    [LastName] varchar(45) NULL,
    [Adress] varchar(45) NULL,
    [Telephone] varchar(18) NULL,
    [BirthDate] date NOT NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([PersonId])
);
GO

CREATE TABLE [UserStatusRef] (
    [StatusId] int NOT NULL IDENTITY,
    [StatusName] varchar(45) NOT NULL,
    CONSTRAINT [PK__UserStat__C8EE20631EE8496D] PRIMARY KEY ([StatusId])
);
GO

CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Isbn] varchar(45) NOT NULL,
    [Title] varchar(45) NOT NULL,
    [AuthorId] int NOT NULL,
    [GenreId] int NOT NULL,
    [ReleaseDate] date NOT NULL,
    [LanguageId] int NOT NULL,
    [PageNumber] int NOT NULL,
    [Price] decimal(5,2) NOT NULL,
    [CurrencyId] int NOT NULL,
    [AvailabilityId] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId]),
    CONSTRAINT [FK__Books__AuthorId__44FF419A] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([AuthorId]),
    CONSTRAINT [FK__Books__Availabil__49C3F6B7] FOREIGN KEY ([AvailabilityId]) REFERENCES [AvailabilityRef] ([AvailabilityId]),
    CONSTRAINT [FK__Books__CurrencyI__48CFD27E] FOREIGN KEY ([CurrencyId]) REFERENCES [CurrencyRef] ([CurrencyId]),
    CONSTRAINT [FK__Books__GenreId__45F365D3] FOREIGN KEY ([GenreId]) REFERENCES [GenreRef] ([GenreId]),
    CONSTRAINT [FK__Books__LanguageI__46E78A0C] FOREIGN KEY ([LanguageId]) REFERENCES [LanguageRef] ([LanguageId])
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [CartId] int NOT NULL,
    [Quantity] int NOT NULL,
    [ShippingAdr] varchar(255) NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [OrderstatusId] int NOT NULL,
    [OrderPrice] decimal(8,2) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK__Orders__Ordersta__403A8C7D] FOREIGN KEY ([OrderstatusId]) REFERENCES [OrderStatusRef] ([OrderstatusId])
);
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [PersonId] int NOT NULL,
    [UserstatusId] int NOT NULL,
    [Email] varchar(45) NOT NULL,
    [Parole] varchar(45) NOT NULL,
    [RegistrationDate] date NOT NULL,
    [Username] varchar(45) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK__Users__PersonId__3A81B327] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([PersonId]),
    CONSTRAINT [FK__Users__Userstatu__3B75D760] FOREIGN KEY ([UserstatusId]) REFERENCES [UserStatusRef] ([StatusId])
);
GO

CREATE TABLE [BooksOrders] (
    [BookId] int NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [FK__BooksOrde__BookI__4E88ABD4] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]),
    CONSTRAINT [FK__BooksOrde__Order__4F7CD00D] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId])
);
GO

CREATE TABLE [UsersOrders] (
    [UserId] int NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [FK__UsersOrde__Order__4CA06362] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]),
    CONSTRAINT [FK__UsersOrde__UserI__4BAC3F29] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
);
GO

CREATE UNIQUE INDEX [UQ__Availabi__86FED021E4D7B2C2] ON [AvailabilityRef] ([AvailabilityName]);
GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO

CREATE INDEX [IX_Books_AvailabilityId] ON [Books] ([AvailabilityId]);
GO

CREATE INDEX [IX_Books_CurrencyId] ON [Books] ([CurrencyId]);
GO

CREATE INDEX [IX_Books_GenreId] ON [Books] ([GenreId]);
GO

CREATE INDEX [IX_Books_LanguageId] ON [Books] ([LanguageId]);
GO

CREATE UNIQUE INDEX [UQ__Books__9271CED05E09F6F7] ON [Books] ([Isbn]);
GO

CREATE INDEX [IX_BooksOrders_BookId] ON [BooksOrders] ([BookId]);
GO

CREATE INDEX [IX_BooksOrders_OrderId] ON [BooksOrders] ([OrderId]);
GO

CREATE UNIQUE INDEX [UQ__Currency__3D13D298CF5F79FF] ON [CurrencyRef] ([CurrencyName]);
GO

CREATE UNIQUE INDEX [UQ__GenreRef__BBE1C3398C7BB20C] ON [GenreRef] ([GenreName]);
GO

CREATE UNIQUE INDEX [UQ__Language__E89C4A6A1B581A56] ON [LanguageRef] ([LanguageName]);
GO

CREATE INDEX [IX_Orders_OrderstatusId] ON [Orders] ([OrderstatusId]);
GO

CREATE UNIQUE INDEX [UQ__Orders__7680024B39D5ACE9] ON [Orders] ([OrderDate]);
GO

CREATE UNIQUE INDEX [UQ__OrderSta__A612D39AFDA69D44] ON [OrderStatusRef] ([OrderstatusName]);
GO

CREATE INDEX [IX_Users_PersonId] ON [Users] ([PersonId]);
GO

CREATE INDEX [IX_Users_UserstatusId] ON [Users] ([UserstatusId]);
GO

CREATE UNIQUE INDEX [UQ__Users__A9D10534256BCB0B] ON [Users] ([Email]);
GO

CREATE INDEX [IX_UsersOrders_OrderId] ON [UsersOrders] ([OrderId]);
GO

CREATE INDEX [IX_UsersOrders_UserId] ON [UsersOrders] ([UserId]);
GO

CREATE UNIQUE INDEX [UQ__UserStat__05E7698A9B49331C] ON [UserStatusRef] ([StatusName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220914163034_CreateProjectDB', N'6.0.9');
GO

COMMIT;
GO

