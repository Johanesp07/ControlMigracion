-- Crear la base de datos y usarla
CREATE DATABASE ControlMigracion;
go
USE ControlMigracion;
go



 
-- Crear la tabla Paises
CREATE TABLE Paises (
    IDPais INT IDENTITY(1,1) PRIMARY KEY,
    NombrePais VARCHAR(100) NOT NULL,
    CodigoISO CHAR(3) NOT NULL
);
 
-- Crear la tabla Viajeros
CREATE TABLE Viajeros (
    IDViajero INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    NroPasaporte VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Nacionalidad INT,
    CONSTRAINT FK_Viajeros_Paises FOREIGN KEY (Nacionalidad) REFERENCES Paises(IDPais)
);
 
-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
    CorreoElectronico VARCHAR(100) NOT NULL,
    Contraseña VARCHAR(256) NOT NULL,
    Rol VARCHAR(50) NOT NULL
);
 
-- Crear la tabla Entradas
CREATE TABLE Entradas (
    IDEntrada INT IDENTITY(1,1) PRIMARY KEY,
    IDViajero INT NOT NULL,
    FechaEntrada DATETIME NOT NULL,
    IDPaisOrigen INT NOT NULL,
    IDUsuarioRegistro INT NOT NULL,
    CONSTRAINT FK_Entradas_Viajeros FOREIGN KEY (IDViajero) REFERENCES Viajeros(IDViajero),
    CONSTRAINT FK_Entradas_Paises FOREIGN KEY (IDPaisOrigen) REFERENCES Paises(IDPais),
    CONSTRAINT FK_Entradas_Usuarios FOREIGN KEY (IDUsuarioRegistro) REFERENCES Usuarios(IDUsuario)
);
 
-- Crear la tabla Salidas
CREATE TABLE Salidas (
    IDSalida INT IDENTITY(1,1) PRIMARY KEY,
    IDViajero INT NOT NULL,
    FechaSalida DATETIME NOT NULL,
    IDPaisDestino INT NOT NULL,
    IDUsuarioRegistro INT NOT NULL,
    CONSTRAINT FK_Salidas_Viajeros FOREIGN KEY (IDViajero) REFERENCES Viajeros(IDViajero),
    CONSTRAINT FK_Salidas_Paises FOREIGN KEY (IDPaisDestino) REFERENCES Paises(IDPais),
    CONSTRAINT FK_Salidas_Usuarios FOREIGN KEY (IDUsuarioRegistro) REFERENCES Usuarios(IDUsuario)
);

-- sp para login 
CREATE PROCEDURE sp_ValidarUsuario
    @CorreoElectronico VARCHAR(100),
    @Contraseña VARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
 
    SELECT 
        IDUsuario,
        CorreoElectronico,
        Rol
    FROM 
        Usuarios
    WHERE 
        CorreoElectronico = @CorreoElectronico 
        AND Contraseña = @Contraseña;
END;

INSERT INTO Usuarios (CorreoElectronico, Contraseña, Rol) 
VALUES 
('johan@gmail.com', '12345', 'Admin'),
('maria.lopez@example.com', 'ContraseñaHash2', 'Usuario'),
('carlos.garcia@example.com', 'ContraseñaHash3', 'Usuario');

select * from Usuarios

CREATE PROCEDURE GestionarViajeros
    @accion NVARCHAR(10),
    @IDViajero INT = NULL,
    @Nombre VARCHAR(100) = NULL,
    @Apellido VARCHAR(100) = NULL,
    @NroPasaporte VARCHAR(50) = NULL,
    @FechaNacimiento DATE = NULL,
    @Nacionalidad INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
 
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO Viajeros (Nombre, Apellido, NroPasaporte, FechaNacimiento, Nacionalidad) 
        VALUES (@Nombre, @Apellido, @NroPasaporte, @FechaNacimiento, @Nacionalidad);
        SELECT SCOPE_IDENTITY() AS IDViajero;
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM Viajeros WHERE IDViajero = @IDViajero;
        
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE Viajeros SET 
            Nombre = @Nombre,
            Apellido = @Apellido,
            NroPasaporte = @NroPasaporte,
            FechaNacimiento = @FechaNacimiento,
            Nacionalidad = @Nacionalidad
        WHERE IDViajero = @IDViajero;
        SELECT @@ROWCOUNT AS FilasAfectadas;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT IDViajero, Nombre, Apellido, NroPasaporte, FechaNacimiento, Nacionalidad
        FROM Viajeros
        WHERE IDViajero = @IDViajero;
    END
    ELSE
    BEGIN
        RAISERROR('Acción no válida', 16, 1);
        RETURN;
    END
END;

INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Costa Rica', 'CRI');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Estados Unidos', 'USA');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('México', 'MEX');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Canadá', 'CAN');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Brasil', 'BRA');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Argentina', 'ARG');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('España', 'ESP');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Francia', 'FRA');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Alemania', 'DEU');
INSERT INTO Paises (NombrePais, CodigoISO) VALUES ('Japón', 'JPN');

select * from Viajeros

CREATE PROCEDURE RegistrarSalida
    @IDViajero INT,
    @FechaSalida DATETIME,
    @IDPaisDestino INT,
    @IDUsuarioRegistro INT
AS
BEGIN
    INSERT INTO Salidas (IDViajero, FechaSalida, IDPaisDestino, IDUsuarioRegistro)
    VALUES (@IDViajero, @FechaSalida, @IDPaisDestino, @IDUsuarioRegistro);
END;
 
CREATE PROCEDURE RegistrarEntrada
    @IDViajero INT,
    @FechaEntrada DATETIME,
    @IDPaisOrigen INT,
    @IDUsuarioRegistro INT
AS
BEGIN
    INSERT INTO Entradas (IDViajero, FechaEntrada, IDPaisOrigen, IDUsuarioRegistro)
    VALUES (@IDViajero, @FechaEntrada, @IDPaisOrigen, @IDUsuarioRegistro);
END;

select * from Viajeros

