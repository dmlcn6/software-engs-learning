-- Expense sheets
-- categories, service, price, due dates, income, user(s)
-- user table: columns: id(primary key), name, income
-- services table: columns: id(primary key), nameOfService, category, price, due date, userID(foreign key)
--CREATE DATABASE expenses;
USE expenses;

--CREATE TABLE users (
--    name   VARCHAR (20),
--    Income INT         ,
--    ID     INT          IDENTITY (1, 1) PRIMARY KEY
--);
CREATE TABLE services (
    name     VARCHAR (50),
    category VARCHAR (50),
    price    INT         ,
    dueDate  DATE        ,
    UserID   INT         ,
    CONSTRAINT fk_users FOREIGN KEY (userID) REFERENCES users (ID)
);