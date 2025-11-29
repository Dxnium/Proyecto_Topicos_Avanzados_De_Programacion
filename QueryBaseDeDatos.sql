-- Crear base de datos
CREATE DATABASE Proyecto_TopicosDB;
GO

-- Usar la base de datos creada
USE Proyecto_TopicosDB;
GO

-- Crear tabla Persona
CREATE TABLE Persona (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cedula INT NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    Edad INT NOT NULL,
    Telefono INT NOT NULL,
    salario FLOAT NOT NULL
);

-- Crear table Vehiculo
CREATE TABLE Vehiculo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PersonaId INT NULL,
    CONSTRAINT FK_Vehiculo_Persona FOREIGN KEY (PersonaId) REFERENCES Persona(Id),
    Placa NVARCHAR(10) NOT NULL,
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    Anio INT NOT NULL
); 
GO

-- Crear table Usuario
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(40) NOT NULL,
    Codigo NVARCHAR(40) NOT NULL,
    Contrasena NVARCHAR(40) NOT NULL
); 
GO
