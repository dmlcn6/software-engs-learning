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

CREATE TABLE services (
    id int IDENTITY(1,1) PRIMARY KEY,
    name varchar(50),
    category varchar(50),
    price int,
    dueDate DATE,
    userId int,
    CONSTRAINT fk_Users
    FOREIGN KEY (userId)
    REFERENCES users(id)
);
