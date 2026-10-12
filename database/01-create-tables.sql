SET QUOTED_IDENTIFIER ON;

CREATE TABLE DiningTable (
    Id              int IDENTITY PRIMARY KEY,
    Name            nvarchar(10) NOT NULL UNIQUE,
    SortOrder       int NOT NULL,
    IsDrinksBill    bit NOT NULL DEFAULT 0
);

CREATE TABLE TableOrder (
    Id              int IDENTITY PRIMARY KEY,
    DiningTableId   int NOT NULL REFERENCES DiningTable(Id),
    OpenedAt        datetime2 NOT NULL,
    ClosedAt        datetime2 NULL
);

CREATE UNIQUE INDEX UQ_TableOrder_OneOpenOrderPerTable
    ON TableOrder(DiningTableId)
    WHERE ClosedAt IS NULL;