--create database unisysdb;

use unisysdb;
create table products(
product_id int primary key not null identity(100,1),
product_name varchar(50) not null,
product_price decimal(18,2) default(0),
product_desc varchar(MAX),
product_make varchar(50) not null,
product_year varchar(20) not null
);