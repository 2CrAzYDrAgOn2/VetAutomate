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
    
    -- �������� �� ������������� ���������� (�����������)
    IF EXISTS (
        SELECT 1 
        FROM Medications m
        INNER JOIN inserted i ON m.MedicationID = i.MedicationID
        WHERE m.QuantityInStock < 0
    )
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR('������������� ���������� ��������� �� ������', 16, 1);
    END
END;

INSERT INTO Genders (Gender) VALUES 
('�������'),
('�������');

INSERT INTO Posts (Post) VALUES 
('������� ���������'),
('���������'),
('������� ���������'),
('�������������'),
('��������');

INSERT INTO Clients (FullName, Phone, Email, Address, RegistrationDate) VALUES 
('������ ���� ��������', '+79161234567', 'ivanov@mail.ru', '��. ������, �. 10, ��. 5', '2022-01-15'),
('������� ���� ���������', '+79162345678', 'petrova@gmail.com', '��. �������, �. 25, ��. 12', '2022-02-20'),
('������� ������ ��������', '+79163456789', 'sidorov@yandex.ru', '��. ��������, �. 7, ��. 33', '2022-03-10'),
('��������� ����� ������������', '+79164567890', 'kuznetsova@mail.ru', '��. �������, �. 15, ��. 8', '2022-04-05'),
('�������� ������� ����������', '+79165678901', 'vasilyev@gmail.com', '��. ����, �. 3, ��. 17', '2022-05-12');

INSERT INTO Pets (Name, Species, Breed, BirthDate, OwnerID) VALUES 
('������', '�����', '����������', '2019-05-10', 1),
('�����', '������', '��������', '2018-07-15', 2),
('�����', '�����', '��������', '2020-02-20', 3),
('����', '������', '�������', '2017-11-05', 4),
('�����', '�������', '���������', '2021-01-30', 5),
('�����', '������', '��������', '2019-08-12', 1),
('������', '�����', '��������', '2020-04-25', 2);

INSERT INTO Veterinarians (FullName, BirthDate, BirthPlace, PassportSeries, PassportNumber, Phone, Email, INN, DateOfEmployment, PostID, GenderID) VALUES 
('������� ������� ����������', '1985-03-15', '�. ������', '1234', '567890', '+79166789012', 'smirnov@vetclinic.ru', '123456789012', '2020-01-10', 1, 1),
('�������� ����� ����������', '1990-07-22', '�. �����-���������', '2345', '678901', '+79167890123', 'kovaleva@vetclinic.ru', '234567890123', '2020-06-15', 2, 2),
('������� ������ ��������', '1988-11-30', '�. ������ ��������', '3456', '789012', '+79168901234', 'nikitin@vetclinic.ru', '345678901234', '2021-02-20', 2, 1),
('������� ������ ��������', '1995-05-18', '�. ������', '4567', '890123', '+79169012345', 'zaitseva@vetclinic.ru', '456789012345', '2021-09-05', 3, 2),
('������� ������ ����������', '1992-09-25', '�. ������������', '5678', '901234', '+79160123456', 'fedorov@vetclinic.ru', '567890123456', '2022-03-12', 3, 1);

INSERT INTO Services (ServiceName) VALUES 
('������������'),
('����������'),
('������������'),
('���������'),
('������������� ������ �����'),
('���'),
('�������'),
('������ �����'),
('��������� �� ���������'),
('������������� ��������');

INSERT INTO Medications (Name, Description, QuantityInStock) VALUES 
('������������', '���������� �������� ������� ��������', 50),
('�����������', '����������������� ��������', 30),
('��-���', '�����������', 100),
('���������', '���������� ��������', 40),
('�������', '���������������', 25),
('��������', '������� �����', 35),
('����-���', '������������� ��������', 20),
('����������', '��������������� ��������', 45),
('���������', '�������� �� ���� � ������', 30),
('�����������', '����������������', 15);

INSERT INTO MedicationSupplies (MedicationID, SupplyDate, QuantitySupplied, SupplierName) VALUES 
(1, '2023-01-10', 50, '��������'),
(2, '2023-01-12', 30, '��������'),
(3, '2023-01-15', 100, '�������'),
(4, '2023-01-20', 40, '�������'),
(5, '2023-02-05', 25, '�������'),
(6, '2023-02-10', 35, '�������'),
(7, '2023-02-15', 20, '��������'),
(8, '2023-02-20', 45, '�������'),
(9, '2023-03-01', 30, '�������'),
(10, '2023-03-05', 15, '��������');

INSERT INTO MedicationUsages (PetID, VetID, MedicationID, QuantityUsed, Purpose) VALUES 
(1, 1, 1, 2, '������� �������� ����������� �����'),
(2, 2, 8, 1, '������������ ������������'),
(3, 3, 9, 1, '��������� �� ����'),
(4, 1, 5, 1, '��������� ���������� ����� ��������'),
(5, 4, 6, 1, '������� �������������'),
(6, 2, 7, 1, '���������� ���� ����� ������������� �������'),
(7, 3, 3, 1, '������ ������� ��� ������������ �������');

INSERT INTO ServiceUsages (PetID, VetID, ServiceID, Purpose) VALUES 
(1, 1, 1, '�������� ������'),
(2, 2, 2, '��������� ����������'),
(3, 3, 9, '��������� �� ���������'),
(4, 1, 10, '�������� �������'),
(5, 4, 5, '����������� ���������'),
(6, 2, 3, '������������'),
(7, 3, 4, '���������');

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