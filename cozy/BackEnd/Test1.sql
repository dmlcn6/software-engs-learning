-- Expense Sheet
-- categories, service, price, due dates, income, user(s)
-- user table: columns: id (primary key), name, income
-- services table: columns: id(primary), nameOfServie, category, price, due dates, userID(foreign key)
--CREATE DATABASE expenses;
USE expenses;

--CREATE TABLE Users (
--  Name   VARCHAR (20),
--  Income INT         ,
--  ID     INT          IDENTITY (1, 1) PRIMARY KEY
--);
CREATE TABLE Services (
    ID            INT          IDENTITY (1, 1) PRIMARY KEY,
    NameOfService VARCHAR (50),
    Category      VARCHAR (50),
    Price         INT         ,
    Due           DATE        ,
    UserID        INT         ,
    CONSTRAINT fk_Users FOREIGN KEY (UserID) REFERENCES Users (ID)
);