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
    ServiceName NVARCHAR(100) NOT NULL
);

CREATE TABLE Medications (
    MedicationID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
	QuantityInStock INT NOT NULL DEFAULT 0
);

CREATE TABLE MedicationSupplies (
    SupplyID INT PRIMARY KEY IDENTITY(1,1),
    MedicationID INT FOREIGN KEY REFERENCES Medications(MedicationID),
    SupplyDate DATE DEFAULT GETDATE(),
    QuantitySupplied INT NOT NULL,
    SupplierName NVARCHAR(100),
    FOREIGN KEY (MedicationID) REFERENCES Medications(MedicationID)
);

CREATE TABLE MedicationUsages (
    MedicationUsageID INT PRIMARY KEY IDENTITY,
    PetID INT FOREIGN KEY REFERENCES Pets(PetID) ON DELETE CASCADE,
    VetID INT FOREIGN KEY REFERENCES Veterinarians(VetID) ON DELETE SET NULL,
    MedicationID INT FOREIGN KEY REFERENCES Medications(MedicationID) ON DELETE SET NULL,
    QuantityUsed INT,
    Purpose NVARCHAR(500)
);

CREATE TABLE ServiceUsages (
    ServiceUsageID INT PRIMARY KEY IDENTITY,
    PetID INT FOREIGN KEY REFERENCES Pets(PetID) ON DELETE CASCADE,
    VetID INT FOREIGN KEY REFERENCES Veterinarians(VetID) ON DELETE SET NULL,
    ServiceID INT FOREIGN KEY REFERENCES Services(ServiceID) ON DELETE SET NULL,
    Purpose NVARCHAR(500)
);

CREATE TABLE Registration (
    RegistrationID INT PRIMARY KEY IDENTITY(1,1),
    UserLogin NVARCHAR(50) NOT NULL,
    UserPassword NVARCHAR(50) NOT NULL,
	IsAdmin BIT DEFAULT 0
);

CREATE TRIGGER trg_MedicationSupply_Insert
ON MedicationSupplies
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE m
    SET m.QuantityInStock = m.QuantityInStock + i.QuantitySupplied
    FROM Medications m
    INNER JOIN inserted i ON m.MedicationID = i.MedicationID;
END;

CREATE TRIGGER trg_MedicationUsage_Insert
ON MedicationUsages
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE m
    SET m.QuantityInStock = m.QuantityInStock - i.QuantityUsed
    FROM Medications m
    INNER JOIN inserted i ON m.MedicationID = i.MedicationID;
    
    -- Проверка на отрицательное количество (опционально)
    IF EXISTS (
        SELECT 1 
        FROM Medications m
        INNER JOIN inserted i ON m.MedicationID = i.MedicationID
        WHERE m.QuantityInStock < 0
    )
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR('Недостаточное количество лекарства на складе', 16, 1);
    END
END;

INSERT INTO Genders (Gender) VALUES 
('Мужской'),
('Женский');

INSERT INTO Posts (Post) VALUES 
('Главный ветеринар'),
('Ветеринар'),
('Младший ветеринар'),
('Администратор'),
('Лаборант');

INSERT INTO Clients (FullName, Phone, Email, Address, RegistrationDate) VALUES 
('Иванов Иван Иванович', '+79161234567', 'ivanov@mail.ru', 'ул. Ленина, д. 10, кв. 5', '2022-01-15'),
('Петрова Анна Сергеевна', '+79162345678', 'petrova@gmail.com', 'ул. Пушкина, д. 25, кв. 12', '2022-02-20'),
('Сидоров Михаил Петрович', '+79163456789', 'sidorov@yandex.ru', 'ул. Гагарина, д. 7, кв. 33', '2022-03-10'),
('Кузнецова Елена Владимировна', '+79164567890', 'kuznetsova@mail.ru', 'ул. Садовая, д. 15, кв. 8', '2022-04-05'),
('Васильев Дмитрий Алексеевич', '+79165678901', 'vasilyev@gmail.com', 'ул. Мира, д. 3, кв. 17', '2022-05-12');

INSERT INTO Pets (Name, Species, Breed, BirthDate, OwnerID) VALUES 
('Барсик', 'Кошка', 'Британская', '2019-05-10', 1),
('Шарик', 'Собака', 'Лабрадор', '2018-07-15', 2),
('Мурка', 'Кошка', 'Дворовая', '2020-02-20', 3),
('Рекс', 'Собака', 'Овчарка', '2017-11-05', 4),
('Чижик', 'Попугай', 'Волнистый', '2021-01-30', 5),
('Тузик', 'Собака', 'Дворняга', '2019-08-12', 1),
('Васька', 'Кошка', 'Сиамская', '2020-04-25', 2);

INSERT INTO Veterinarians (FullName, BirthDate, BirthPlace, PassportSeries, PassportNumber, Phone, Email, INN, DateOfEmployment, PostID, GenderID) VALUES 
('Смирнов Алексей Викторович', '1985-03-15', 'г. Москва', '1234', '567890', '+79166789012', 'smirnov@vetclinic.ru', '123456789012', '2020-01-10', 1, 1),
('Ковалева Ольга Николаевна', '1990-07-22', 'г. Санкт-Петербург', '2345', '678901', '+79167890123', 'kovaleva@vetclinic.ru', '234567890123', '2020-06-15', 2, 2),
('Никитин Сергей Иванович', '1988-11-30', 'г. Нижний Новгород', '3456', '789012', '+79168901234', 'nikitin@vetclinic.ru', '345678901234', '2021-02-20', 2, 1),
('Зайцева Марина Петровна', '1995-05-18', 'г. Казань', '4567', '890123', '+79169012345', 'zaitseva@vetclinic.ru', '456789012345', '2021-09-05', 3, 2),
('Федоров Андрей Дмитриевич', '1992-09-25', 'г. Екатеринбург', '5678', '901234', '+79160123456', 'fedorov@vetclinic.ru', '567890123456', '2022-03-12', 3, 1);

INSERT INTO Services (ServiceName) VALUES 
('Консультация'),
('Вакцинация'),
('Стерилизация'),
('Кастрация'),
('Чиохимический анализ крови'),
('УЗИ'),
('Рентген'),
('Чистка зубов'),
('Обработка от паразитов'),
('Хирургическая операция');

INSERT INTO Medications (Name, Description, QuantityInStock) VALUES 
('Амоксициллин', 'Антибиотик широкого спектра действия', 50),
('Цефтриаксон', 'Антибактериальный препарат', 30),
('Но-шпа', 'Спазмолитик', 100),
('Фуросемид', 'Мочегонное средство', 40),
('Гамавит', 'Иммуномодулятор', 25),
('Ципровет', 'Глазные капли', 35),
('Стоп-зуд', 'Противозудное средство', 20),
('Мильбемакс', 'Антигельминтный препарат', 45),
('Фронтлайн', 'Средство от блох и клещей', 30),
('Ронколейкин', 'Иммуностимулятор', 15);

INSERT INTO MedicationSupplies (MedicationID, SupplyDate, QuantitySupplied, SupplierName) VALUES 
(1, '2023-01-10', 50, 'ФармаМед'),
(2, '2023-01-12', 30, 'ФармаМед'),
(3, '2023-01-15', 100, 'ВетСнаб'),
(4, '2023-01-20', 40, 'ВетСнаб'),
(5, '2023-02-05', 25, 'ЗооФарм'),
(6, '2023-02-10', 35, 'ЗооФарм'),
(7, '2023-02-15', 20, 'ФармаМед'),
(8, '2023-02-20', 45, 'ВетСнаб'),
(9, '2023-03-01', 30, 'ЗооФарм'),
(10, '2023-03-05', 15, 'ФармаМед');

INSERT INTO MedicationUsages (PetID, VetID, MedicationID, QuantityUsed, Purpose) VALUES 
(1, 1, 1, 2, 'Лечение инфекции дыхательных путей'),
(2, 2, 8, 1, 'Профилактика гельминтозов'),
(3, 3, 9, 1, 'Обработка от блох'),
(4, 1, 5, 1, 'Поддержка иммунитета после операции'),
(5, 4, 6, 1, 'Лечение конъюнктивита'),
(6, 2, 7, 1, 'Устранение зуда после аллергической реакции'),
(7, 3, 3, 1, 'Снятие спазмов при мочекаменной болезни');

INSERT INTO ServiceUsages (PetID, VetID, ServiceID, Purpose) VALUES 
(1, 1, 1, 'Плановый осмотр'),
(2, 2, 2, 'Ежегодная вакцинация'),
(3, 3, 9, 'Обработка от паразитов'),
(4, 1, 10, 'Удаление опухоли'),
(5, 4, 5, 'Диагностика состояния'),
(6, 2, 3, 'Стерилизация'),
(7, 3, 4, 'Кастрация');

INSERT INTO Registration (UserLogin, UserPassword, IsAdmin) VALUES
('admin', 'admin', 1),
('user', 'user', 0);

SELECT * FROM Genders;
SELECT * FROM Posts;
SELECT * FROM Clients;
SELECT * FROM Pets;
SELECT * FROM Veterinarians;
SELECT * FROM Services;
SELECT * FROM Medications;
SELECT * FROM MedicationSupplies;
SELECT * FROM MedicationUsages;
SELECT * FROM ServiceUsages;
SELECT * FROM Registration;

DROP DATABASE VetAutomate;

use w;