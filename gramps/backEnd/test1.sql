-- ALT HIGHPOINT MARKER DATA
-- Altitude, coords, state and cities, country
-- altitude table: columns: id(primary key), alt, lat, long, locationId (foreign key)
-- Location table: columns: id(primary key), city, state, country

-- Expense sheets
-- categories, service, price, due dates, income, user(s) 
-- users table: columns: id(primary key), name, income 
-- services table: columns: id(primary key), name, category, price, due date, userId(foreign key)

--CREATE DATABASE expenses;

USE expenses;
--CREATE TABLE users (
--    name varchar(20),
--    income int,
--    id int IDENTITY(1,1) PRIMARY KEY
--);


-- INSERT INTO users 
-- VALUES ('user4', 1000000, 'CTO');

-- ALTER TABLE users
-- ADD occupation varchar(50);

-- UPDATE users
-- SET occupation = 'Plumber'
-- WHERE id = 1

--ALTER TABLE users
--ALTER COLUMN occupation VARCHAR(50) NOT NULL;

-- SELECT * FROM users


-- CREATE TABLE services (
--     id int IDENTITY(1,1) PRIMARY KEY,
--     name varchar(50),
--     category varchar(50),
--     price int,
--     dueDate DATE,
--     userId int,
--     CONSTRAINT fk_Users
--     FOREIGN KEY (userId)
--     REFERENCES users(id)
-- );

-- INSERT INTO services
-- VALUES ('Yearly Swedish Spa', 'Health', 2000, '2026-12-04' , 4),
--         ('\"Party Favors \"', 'Leisure', 200, '2026-01-01' , 3);


select * from services;
select * from users;

SELECT  u.name,
        u.income,
        s.name,
        s.category,
        s.price FROM SERVICES AS s
INNER JOIN users AS u ON s.userId = u.id
WHERE u.id = 4;
