USE RestaurantManagement_Lab6_7;
GO

SELECT name FROM sys.procedures;


-- Tạo thủ tục lấy tất cả Category
CREATE PROCEDURE [dbo].[Category_GetALL]
AS
BEGIN
    SELECT * FROM Category;
END
GO

-- Tạo thủ tục lấy tất cả Food
CREATE PROCEDURE [dbo].[Food_GetAll]
AS
BEGIN
    SELECT * FROM Food;
END
GO

-- Tạo hoặc sửa thủ tục thêm / sửa / xóa Category
CREATE OR ALTER PROCEDURE [dbo].[Category_InsertUpdateDelete]
    @ID INT OUTPUT,
    @Name NVARCHAR(200),
    @Type INT,
    @Action INT
AS
BEGIN
    IF @Action = 0
    BEGIN
        INSERT INTO [Category] ([Name], [Type])
        VALUES (@Name, @Type);
        SET @ID = SCOPE_IDENTITY();
    END
    ELSE IF @Action = 1
    BEGIN
        UPDATE [Category]
        SET [Name] = @Name,
            [Type] = @Type
        WHERE [ID] = @ID;
    END
    ELSE IF @Action = 2
    BEGIN
        DELETE FROM [Category]
        WHERE [ID] = @ID;
    END
END
GO

-- Tạo hoặc sửa thủ tục thêm / sửa / xóa Food
CREATE OR ALTER PROCEDURE [dbo].[Food_InsertUpdateDelete]
    @ID INT OUTPUT,
    @Name NVARCHAR(1000),
    @Unit NVARCHAR(100),
    @FoodCategoryID INT,
    @Price INT,
    @Notes NVARCHAR(3000),
    @Action INT
AS
BEGIN
    IF @Action = 0
    BEGIN
        INSERT INTO [Food] ([Name], [Unit], [FoodCategoryID], [Price], [Notes])
        VALUES (@Name, @Unit, @FoodCategoryID, @Price, @Notes);
        SET @ID = SCOPE_IDENTITY();
    END
    ELSE IF @Action = 1
    BEGIN
        UPDATE [Food]
        SET [Name] = @Name,
            [Unit] = @Unit,
            [FoodCategoryID] = @FoodCategoryID,
            [Price] = @Price,
            [Notes] = @Notes
        WHERE [ID] = @ID;
    END
    ELSE IF @Action = 2
    BEGIN
        DELETE FROM [Food]
        WHERE [ID] = @ID;
    END
END
GO
