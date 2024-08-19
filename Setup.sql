use master;

DROP DATABASE IF EXISTS babyArchive

CREATE DATABASE babyArchive
GO
use babyArchive;

CREATE TABLE [user](userId Int IDENTITY(1,1), userName NVARCHAR(32) CHECK(LEN(userName) >= 8), password NVARCHAR(32) CHECK(LEN([password]) >= 8), PRIMARY KEY(userId) )
GO