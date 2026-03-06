CREATE TABLE Platillo (
    IdPlatillo INT IDENTITY(1,1) PRIMARY KEY,
    IdRestaurante INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL CHECK (Precio >= 0),
    Descripcion NVARCHAR(255) NULL,
    CONSTRAINT FK_Platillo_Restaurante FOREIGN KEY (IdRestaurante) REFERENCES Restaurante(Id)
);
