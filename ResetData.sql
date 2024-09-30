use bankAccount;
DELETE FROM shopUser;
DELETE FROM loan;
DELETE FROM bankAccount;
DELETE FROM bankUser;

INSERT INTO bankUser(userName, [password]) VALUES('akselSmuk', 'test1234')
GO

DECLARE @UserId INT;

SELECT TOP(1) @UserId = userID FROM bankUser;

INSERT INTO bankAccount([name], balance, userId) VALUES('Opsparing', 500, @UserId), ('konto', 700, @UserId)

DECLARE @BankAccountId INT;

SELECT TOP(1) @BankAccountId = bankAccountId FROM bankAccount

INSERT INTO loan(paymentTime, debt, userId, bankAccountId, CostForEachPayment, Interest, [name], payDate) VALUES(2, 400, @UserId, @BankAccountId, 500, 0.2, 'Quick loan', GETDATE()), (1, 400, @UserId, @BankAccountId, 30, 0.5, 'Carloan', GETDATE())

INSERT INTO shopUser(userName, [password], bankAccountId) VALUES('akselSmuk', 'test1234', @BankAccountId)
GO