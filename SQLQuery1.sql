CREATE DATABASE Mebel;
USE Mebel;
GO

CREATE TABLE Shourum (
	ID_Shourum int primary key identity (1,1),
	NameShourum varchar (100) not null,
	AddressS varchar (100) not null
);
GO

INSERT INTO Shourum (NameShourum, AddressS)
VALUES 
	('Отличная мебель', 'ул. Грибоедова, д.12'),
	('Ого какая мебель', 'ул. Пушкина, д.1');
GO

CREATE TABLE ShourumContent (
	ID_ShourumContent int primary key identity (1,1),
	ID_Shourum int not null,
	ID_Furniture int not null,
	Kolichestvo int not null,
	FOREIGN KEY (ID_Shourum) REFERENCES Shourum (ID_Shourum),
	FOREIGN KEY (ID_Furniture) REFERENCES Furniture (ID_Furniture)
);
GO

INSERT INTO ShourumContent (ID_Shourum, ID_Furniture, Kolichestvo)
VALUES
(1, 3, 30),
(2, 1, 10),
(1, 4, 15);
GO


CREATE TABLE FurnitureType (
	ID_FurnitureType int primary key identity (1,1),
	NameFT varchar (100) not null
);
GO

INSERT INTO FurnitureType(NameFT)
VALUES 
	('Мягкая мебель'),
	('Твердая мебель'),
	('Уличная мебель'),
	('Кухонная мебель'),
	('Спальная мебель');
GO


CREATE TABLE Furniture (
	ID_Furniture int primary key identity (1,1),
	NameF varchar (100) not null,
	ID_FurnitureType int not null,
	FOREIGN KEY (ID_FurnitureType) REFERENCES FurnitureType (ID_FurnitureType)
);
GO

INSERT INTO Furniture (NameF, ID_FurnitureType) 
VALUES 
	('Диван', 1), 
	('Кровать', 2),
	('Стул', 3),
	('Шкаф', 4),
	('Табуретка', 5);
GO


CREATE TABLE Client (
	ID_Client int primary key identity (1,1),
	NameC varchar (100) not null,
	MiddleName varchar (100) not null,
	AddressC varchar (100) not null,
	PhoneNumberC varchar (100) not null
);
GO

INSERT INTO Client (NameC, MiddleName, AddressC, PhoneNumberC) 
VALUES 
('Иван', 'Иванович', 'ул. УгаЮга, д. 2, кв. 23', '777-77-77'),
('Мария', 'Петровна', 'пр. ТумбаЮбма, д. 1, кв. 432', '999-99-99'),
('Алексей', 'Сергеевич', 'ул. Алахимей, д. 3, кв. 15', '888-99-99');
GO


CREATE TABLE Zakaz (
	ID_Zakaz int primary key identity (1,1),
	ID_ShourumContent int not null,
	ID_Client int not null,
	DataZ Date not null,
	TimeZ Time not null,
	FOREIGN KEY (ID_ShourumContent) REFERENCES ShourumContent (ID_ShourumContent),
	FOREIGN KEY (ID_Client) REFERENCES Client (ID_Client)
);
GO


CREATE TABLE Dolznostb (
	ID_Dolznostb int primary key identity (1,1),
	NameD varchar (100) not null
);
GO

INSERT INTO Dolznostb (NameD) VALUES 
('Продавец-консультант'),
('Менеджер по продажам'),
('Дизайнер интерьера'),
('Мастер по мебели'),
('Бухгалтер'),
('Администратор магазина');
GO


CREATE TABLE Sotrudnik (
	ID_Sotrudnik int primary key identity (1,1),
	NameS varchar (100) not null,
	MiddleNameS varchar (100) not null,
	ID_Dolznostb int not null,
	FOREIGN KEY (ID_Dolznostb) REFERENCES Dolznostb (ID_Dolznostb)
);
GO

INSERT INTO Sotrudnik (NameS, MiddleNameS, ID_Dolznostb) 
VALUES 
('Иван', 'Иванов', 1),
('Петр', 'Петров', 2),
('Мария', 'Сидорова', 3);
GO


CREATE TABLE FinalOrder (
	ID_FinalOrder int primary key identity (1,1),
	ID_Zakaz int not null,
	Summa DECIMAL (10, 2),
	FOREIGN KEY (ID_Zakaz) REFERENCES Zakaz (ID_Zakaz)
);
GO


CREATE TABLE Delivery (
	ID_Delivery int primary key identity (1,1),
	ID_Zakaz int not null,
	ID_Sotrudnik int not null,
	AddressD varchar (100) not null,
	DataD varchar (100) not null,
	TimeD varchar (100) not null,
	FOREIGN KEY (ID_Zakaz) REFERENCES Zakaz (ID_Zakaz),
	FOREIGN KEY (ID_Sotrudnik) REFERENCES Sotrudnik (ID_Sotrudnik)
);
GO
