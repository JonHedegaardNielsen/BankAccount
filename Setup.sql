use master;use master;

DROP DATABASE IF EXISTS bankAccount

CREATE DATABASE bankAccount
GO
use bankAccount;

CREATE TABLE [user](userId INT IDENTITY(1,1), userName NVARCHAR(32) CHECK(LEN(userName) >= 8), [password] NVARCHAR(32) CHECK(LEN([password]) >= 8), PRIMARY KEY(userId) )
GO

CREATE TABLE bankAccount(bankAccountId INT IDENTITY(1,1), [name] NVARCHAR(32) NOT NULL, balance DECIMAL DEFAULT(0), userId INT ,PRIMARY KEY(bankAccountId), FOREIGN KEY (UserId) REFERENCES [User](UserId))
GO

CREATE TABLE loan(loanId INT IDENTITY(1,1), CostForEachPayment DECIMAL NOT NULL, Interest DECIMAL NOT NULL, paymentTime INT NOT NULL, debt DECIMAL DEFAULT(0), userId INT, PRIMARY KEY(loanId),  FOREIGN KEY (UserId) REFERENCES [User](UserId))
GO

INSERT INTO [user](userName, [password]) VALUES('akselSmuk', 'test1234')
GO

INSERT INTO bankAccount([name], balance, userId) VALUES('Opsparing', 500, 1), ('konto', 700, 1)
GO

--INSERT INTO loan(paymentTime, debt, userId, CostForEachPayment, Interest) VALUES(2, 400, 1, 1, 500, 0,2), (1, 400, 1, 2, 30, 0,5)
--GO


