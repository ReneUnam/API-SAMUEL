Create Database DBApiSamuel

CREATE TABLE Cultivos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    EstacionCrecimiento NVARCHAR(50) NOT NULL, 
    TiempoCrecimiento INT NOT NULL, 
    EstadoCrecimiento NVARCHAR(50) NOT NULL, 
    FrecuenciaRiego INT NOT NULL, 
    FertilizanteUsado NVARCHAR(100), -- Puede ser NULL si no se usa
    ValorVenta DECIMAL(10, 2) NOT NULL, 
    FechaSiembra DATE NOT NULL,
    FechaCosecha DATE
);
