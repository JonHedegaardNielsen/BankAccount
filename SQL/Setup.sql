use master;

DROP DATABASE IF EXISTS bankAccount

CREATE DATABASE bankAccount
GO
use bankAccount;

CREATE TABLE bankUser(userId INT IDENTITY(1,1), userName NVARCHAR(32) UNIQUE CHECK(LEN(userName) >= 8), [password] NVARCHAR(32) CHECK(LEN([password]) >= 8), PRIMARY KEY(userId))
GO

CREATE TABLE bankAccount(bankAccountId INT IDENTITY(1,1), [name] NVARCHAR(32) NOT NULL, balance DECIMAL DEFAULT(0), userId INT ,PRIMARY KEY(bankAccountId), FOREIGN KEY (UserId) REFERENCES bankUser(UserId),
CONSTRAINT UQ_Name_UserId UNIQUE ([name], userId) )
GO

CREATE TABLE loan(loanId INT IDENTITY(1,1), [name] NVARCHAR(32) NOT NULL, CostForEachPayment DECIMAL NOT NULL, Interest DECIMAL NOT NULL, paymentTime INT NOT NULL, debt DECIMAL DEFAULT(0), payDate DATE, userId INT NOT NULL, 
PRIMARY KEY(loanId), bankAccountId INT NOT NULL, FOREIGN KEY (bankAccountId) REFERENCES bankAccount(bankAccountId), FOREIGN KEY (UserId) REFERENCES bankUser(UserId))
GO

CREATE TABLE shopUser(userId INT IDENTITY(1,1), userName NVARCHAR(32) UNIQUE CHECK(LEN(userName) >= 8), [password] NVARCHAR(32) CHECK(LEN([password]) >= 8), bankAccountId INT NOT NULL, PRIMARY KEY(userId), FOREIGN KEY (bankAccountId) REFERENCES bankAccount(bankAccountId))
GO

CREATE TABLE shopItem(itemId INT IDENTITY(1,1), [name] NVARCHAR(32) NOT NULL, price DECIMAL NOT NULL, userId INT, category INT NOT NULL, PRIMARY KEY(itemId), FOREIGN KEY (userId) REFERENCES shopUser(userId))
GO

CREATE TABLE casinoUser(userId INT IDENTITY(1,1), username NVARCHAR(32) CHECK(LEN(username) >= 8), [password] NVARCHAR(32) CHECK(LEN([password]) >= 8), bankAccountId DECIMAL NOT NULL, amountToWinBack DECIMAL DEFAULT(0), PRIMARY KEY(userId), FOREIGN KEY(bankAccountId) REFERENCES bankAccount(bankAccountId))
GO

CREATE TABLE casinoWins(winId INT IDENTITY(1,1), reward DECIMAL NOT NULL, userId INT NOT NULL, PRIMARY KEY(winId), FOREIGN KEY(userId) REFERENCES casinoUser(userId))
GO

CREATE TABLE transactions(transactionId INT IDENTITY(1,1), category INT NOT NULL, price DECIMAL NOT NULL, userId INT NOT NULL, PRIMARY KEY(transactionId), FOREIGN KEY(userId) REFERENCES BankUser(userId))
GO

INSERT INTO bankUser(userName, [password]) VALUES('akselSmuk', 'test1234')
GO

INSERT INTO bankAccount([name], balance, userId) VALUES('Opsparing', 500, 1), ('konto', 700, 1)
GO

INSERT INTO loan(paymentTime, debt, userId, bankAccountId, CostForEachPayment, Interest, [name], payDate) VALUES(2, 400, 1, 1, 500, 0.2, 'Quick loan', GETDATE()), (1, 400, 1, 2, 30, 0.5, 'Carloan', GETDATE())
GO

INSERT INTO shopUser(userName, [password], bankAccountId) VALUES('akselSmuk', 'test1234', 1)
GO

INSERT INTO casinoUser(username, [password], bankAccountId) VALUES('akselSmuk', 'test1234', 1)
GO
