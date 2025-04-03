CREATE DATABASE VetAutomate;
USE VetAutomate;

CREATE TABLE Genders(
	GenderID INT PRIMARY KEY IDENTITY(1,1),
	Gender NVARCHAR(150) NOT NULL
);

CREATE TABLE Posts(
	PostID INT PRIMARY KEY IDENTITY(1,1),
	Post NVARCHAR(150) NOT NULL
);

CREATE TABLE Clients (
    ClientID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(255),
	INN NVARCHAR(10) DEFAULT '',
    RegistrationDate DATE DEFAULT GETDATE()
);

CREATE TABLE Pets (
    PetID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Species NVARCHAR(50),
    Breed NVARCHAR(50),
    BirthDate DATE,
    OwnerID INT FOREIGN KEY REFERENCES Clients(ClientID) ON DELETE CASCADE
);

CREATE TABLE Veterinarians (
    VetID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
	BirthDate DATE,
	BirthPlace NVARCHAR(150),
	PassportSeries NVARCHAR(4) CHECK (PassportSeries LIKE '[0-9][0-9][0-9][0-9]'),
	PassportNumber NVARCHAR(6) CHECK (PassportNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
	INN NVARCHAR(12) UNIQUE,
	DateOfEmployment DATE DEFAULT GETDATE(),
	PostID INT DEFAULT 0,
	GenderID INT DEFAULT 0,
	FOREIGN KEY (GenderID) REFERENCES Genders(GenderID),
	FOREIGN KEY (PostID) REFERENCES Posts(PostID)
);

CREATE TABLE Services (
    ServiceID INT PRIMARY KEY IDENTITY,
    ServiceName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY IDENTITY,
    ClientID INT FOREIGN KEY REFERENCES Clients(ClientID) ON DELETE CASCADE,
    TotalAmount DECIMAL(10,2) NOT NULL,
    InvoiceDate DATETIME DEFAULT GETDATE(),
    Paid BIT DEFAULT 0
);

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY,
    InvoiceID INT FOREIGN KEY REFERENCES Invoices(InvoiceID) ON DELETE CASCADE,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50)
);

CREATE TABLE Medications (
    MedicationID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10,2)
);

CREATE TABLE Prescriptions (
    PrescriptionID INT PRIMARY KEY IDENTITY,
    PetID INT FOREIGN KEY REFERENCES Pets(PetID) ON DELETE CASCADE,
    VetID INT FOREIGN KEY REFERENCES Veterinarians(VetID) ON DELETE SET NULL,
    MedicationID INT FOREIGN KEY REFERENCES Medications(MedicationID) ON DELETE SET NULL,
    Dosage NVARCHAR(100),
    Instructions NVARCHAR(500)
);

CREATE TABLE Registration (
    RegistrationID INT PRIMARY KEY IDENTITY(1,1),
    UserLogin NVARCHAR(50) NOT NULL,
    UserPassword NVARCHAR(50) NOT NULL,
	IsAdmin BIT DEFAULT 0
);

INSERT INTO Genders (Gender) VALUES
('Мужской'),
('Женский');

INSERT INTO Posts (Post) VALUES
('Ветеринар'),
('Ассистент ветеринара'),
('Менеджер по работе с клиентами'),
('Администратор');

INSERT INTO Clients (FullName, Phone, Email, Address, INN) VALUES
('Иванов Иван Иванович', '+7 900 123 4567', 'ivanov@mail.ru', 'г. Москва, ул. Ленина, 1', '1234567890'),
('Петрова Ольга Васильевна', '+7 900 234 5678', 'petrova@mail.ru', 'г. Санкт-Петербург, ул. Пушкина, 2', '2345678901');

INSERT INTO Pets (Name, Species, Breed, BirthDate, OwnerID) VALUES
('Барсик', 'Кошка', 'Мейн-кун', '1985-05-12', 1),
('Шарик', 'Собака', 'Лабрадор', '1985-05-12', 2);

INSERT INTO Veterinarians (FullName, BirthDate, BirthPlace, PassportSeries, PassportNumber, Phone, Email, INN, DateOfEmployment, PostID, GenderID) VALUES
('Сидоров Сергей Петрович', '1985-05-12', 'г. Москва', '1234', '567890', '+7 900 345 6789', 'sidorov@mail.ru', '987654321098', '2020-01-15', 1, 1),
('Кузнецова Мария Ивановна', '1990-07-20', 'г. Санкт-Петербург', '2345', '123456', '+7 900 456 7890', 'kuznetsova@mail.ru', '876543210987', '2022-06-10', 2, 2);

INSERT INTO Services (ServiceName, Price) VALUES
('Консультация', 1000.00),
('Прививка', 500.00),
('Чистка зубов', 1500.00);

INSERT INTO Invoices (ClientID, TotalAmount, Paid) VALUES
(1, 2000.00, 0),
(2, 1500.00, 1);

INSERT INTO Payments (InvoiceID, Amount, PaymentMethod) VALUES
(2, 1500.00, 'Карта');

INSERT INTO Medications (Name, Description, Price) VALUES
('Антибиотик', 'Применяется для лечения инфекций', 300.00),
('Витамины для кошек', 'Для поддержания здоровья шерсти', 250.00);

INSERT INTO Prescriptions (PetID, VetID, MedicationID, Dosage, Instructions) VALUES
(1, 1, 1, '2 таблетки 2 раза в день', 'Принимать во время еды'),
(2, 2, 2, '1 таблетка в день', 'Давать после кормления');

INSERT INTO Registration (UserLogin, UserPassword, IsAdmin) VALUES
('admin', 'admin', 1),
('user', 'user', 0);

SELECT * FROM Genders;
SELECT * FROM Posts;
SELECT * FROM Clients;
SELECT * FROM Pets;
SELECT * FROM Veterinarians;
SELECT * FROM Services;
SELECT * FROM Invoices;
SELECT * FROM Payments;
SELECT * FROM Medications;
SELECT * FROM Prescriptions;
SELECT * FROM Registration;

DROP DATABASE VetAutomate;

use w;