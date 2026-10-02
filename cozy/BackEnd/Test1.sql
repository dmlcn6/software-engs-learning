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
--INSERT  INTO Users
--VALUES ('user4', 0, 'Student');
--ALTER TABLE Users
--    ADD Occupation VARCHAR (50);
--UPDATE users
--SET    Occupation = 'Influencer'
--WHERE  ID = 1;
--ALTER TABLE users ALTER COLUMN Occupation VARCHAR (50) NOT NULL;
--SELECT id,
--       name,
--       income
--FROM   Users;
--CREATE TABLE Services (
--    ID            INT          IDENTITY (1, 1) PRIMARY KEY,
--    NameOfService VARCHAR (50),
--    Category      VARCHAR (50),
--    Price         INT         ,
--    Due           DATE        ,
--    UserID        INT         ,
--    CONSTRAINT fk_Users FOREIGN KEY (UserID) REFERENCES Users (ID)
--);
--INSERT  INTO Services
--VALUES ('YouTube Premium', 'Entertainment', 17, '2026 - 10 - 25', 1),
--       ('Internet', 'Utility', 150, '2026 - 11 - 1', 1),
--       ('Rent', 'Utility', 1250, '2026 - 11 - 1', 1),
--       ('Rent', 'Utility', 1250, '2026 - 11 - 1', 2),
--       ('Rent', 'Utility', 1250, '2026 - 11 - 1', 3),
--       ('Party Favors', 'Leisure', 3000, '2026 - 10 - 31', 3);
--DELETE Services
--WHERE  ID > 6;
SELECT *
FROM   Users;

SELECT *
FROM   Services;

SELECT u.Name,
       u.Income,
       s.NameOfService,
       s.Category,
       s.Price
FROM   Services AS s
       INNER JOIN
       users AS u
       ON s.UserID = u.ID;