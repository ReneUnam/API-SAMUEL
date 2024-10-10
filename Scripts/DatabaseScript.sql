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

INSERT INTO Cultivos (Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha)
VALUES ('Trigo', 'Otoño', 10, 'Creciendo', 2, 'Fertilizante Básico', 150.50, '2024-09-01', NULL);

INSERT INTO Cultivos (Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha)
VALUES ('Zanahoria', 'Primavera', 7, 'Listo para cosechar', 1, 'Fertilizante Avanzado', 200.75, '2024-09-15', '2024-09-22');

INSERT INTO Cultivos (Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha)
VALUES ('Maíz', 'Verano', 14, 'Creciendo', 3, NULL, 300.00, '2024-08-25', NULL);

INSERT INTO Cultivos (Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha)
VALUES ('Fresa', 'Primavera', 5, 'Creciendo', 1, 'Fertilizante Premium', 250.00, '2024-09-10', NULL);

INSERT INTO Cultivos (Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha)
VALUES ('Papa', 'Invierno', 12, 'Listo para cosechar', 4, 'Fertilizante Básico', 180.25, '2024-09-01', '2024-09-13');

