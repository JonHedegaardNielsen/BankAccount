DROP DATABASE IF EXISTS bankAccount

CREATE DATABASE bankAccount
GO
use bankAccount;

CREATE TABLE [user](userId INT IDENTITY(1,1), userName NVARCHAR(32) CHECK(LEN(userName) >= 8), [password] NVARCHAR(32) CHECK(LEN([password]) >= 8), PRIMARY KEY(userId) )
GO

CREATE TABLE bankAccount(bankAccountId INT IDENTITY(1,1), balance DECIMAL DEFAULT(0), userId INT ,PRIMARY KEY(bankAccountId))
GO

ALTER TABLE bankAccount ADD CONSTRAINT FK_UserId FOREIGN KEY (userId) REFERENCES [user](userId)

CREATE TABLE loan(loanId INT IDENTITY(1,1), paymentTime INT NOT NULL, debt DECIMAL DEFAULT(0), userId INT, PRIMARY KEY(loanId))
GO

ALTER TABLE loan ADD CONSTRAINT	FK_UserId_Loan FOREIGN KEY (userId) REFERENCES [user](userId)
