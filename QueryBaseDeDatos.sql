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
GO



