CREATE DATABASE FinPortfolio;

USE FinPortfolio;

IF OBJECT_ID('FinantialRule') IS NOT NULL
BEGIN
	DROP TABLE FinantialRule;
END;

CREATE TABLE FinantialRule
(
	ID			int primary key identity(1,1),
	Name		varchar(50) not null,
	MinValue	numeric(18,2) null,
	MaxValue	numeric(18,2) null
);

INSERT INTO FinantialRule(Name, MinValue, MaxValue)
VALUES ('Low Value', null, 999999), ('Medium Value', 1000000, 5000000), ('High Value', 5000001, null);

IF OBJECT_ID('FinantialInstrument') IS NOT NULL
BEGIN
	DROP TABLE FinantialInstrument;
END;

CREATE TABLE FinantialInstrument
(
	ID			int primary key identity(1,1),
	MarketValue	numeric(18,2),
	Type		varchar(50)
);

INSERT INTO FinantialInstrument(MarketValue, Type)
VALUES (800000, 'Stock'), (1500000, 'Bond'), (6000000, 'Derivative'), (300000, 'Stock'), (300000, 'Should not appear');
