use master;

DROP DATABASE IF EXISTS bankAccount

CREATE DATABASE bankAccount
GO
use bankAccount;

CREATE TABLE [user](userId INT IDENTITY(1,1), userName NVARCHAR(32) CHECK(LEN(userName) >= 8), [password] NVARCHAR(32) CHECK(LEN([password]) >= 8), PRIMARY KEY(userId) )
GO

CREATE TABLE bankAccount(bankAccountId INT IDENTITY(1,1), [name] NVARCHAR(32) NOT NULL, balance DECIMAL DEFAULT(0), userId INT ,PRIMARY KEY(bankAccountId), FOREIGN KEY (UserId) REFERENCES [User](UserId))
GO

CREATE TABLE loan(loanId INT IDENTITY(1,1), paymentTime INT NOT NULL, debt DECIMAL DEFAULT(0), userId INT, PRIMARY KEY(loanId),  FOREIGN KEY (UserId) REFERENCES [User](UserId))
GO


CREATE TRIGGER trg_ChildCountCheck
ON BankAccount
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @UserId INT;
    DECLARE @BankAcccountId INT;

    -- Assume only one row is being inserted at a time
    SELECT @UserId = userId FROM inserted;

    -- Count current children
    SELECT @BankAcccountId = COUNT(*)
    FROM bankAccount
    WHERE userId = @UserId;

    -- Check if adding the new child would exceed the limit
    IF @BankAcccountId >= 8
    BEGIN
        RAISERROR('Cannot insert child: Maximum number of children exceeded for this parent.', 16, 1);
    END
    ELSE
    BEGIN
        -- Insert the new child if within limit
        INSERT INTO bankAccount(balance, userId, [name])
        SELECT balance, userId, [name]
        FROM inserted;
    END
END;
GO

INSERT INTO [user](userName, [password]) VALUES('akselSmuk', 'test1234')
GO

INSERT INTO bankAccount([name], balance, userId) VALUES('Opsparing', 500, 1), ('konto', 700, 1)
GO