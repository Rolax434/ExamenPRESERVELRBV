CREATE DATABASE ExamenPRESERVELRBV
GO

Use ExamenPRESERVELRBV
GO

CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    ApellidoPaterno NVARCHAR(100) NOT NULL,
    ApellidoMaterno NVARCHAR(100) NULL,
    Calle NVARCHAR(100),
    NumeroExterior NVARCHAR(10),
    NumeroInterior NVARCHAR(10),
    Colonia NVARCHAR(100),
    Municipio NVARCHAR(100),
    Estado NVARCHAR(100),
    CodigoPostal NVARCHAR(10),
	Contraseña NVARCHAR(100) NOT NULL,
	UserName NVARCHAR (100) NOT NULL
)
GO

CREATE TABLE Tienda (
    IdTienda INT PRIMARY KEY IDENTITY(1,1),
    Sucursal NVARCHAR(100) NOT NULL,
    Calle NVARCHAR(100),
    NumeroExterior NVARCHAR(10),
    NumeroInterior NVARCHAR(10),
    Colonia NVARCHAR(100),
    Municipio NVARCHAR(100),
    Estado NVARCHAR(100),
    CodigoPostal NVARCHAR(10)
)
GO



CREATE TABLE Articulos (
    IdArticulo INT PRIMARY KEY IDENTITY(1,1),
    Codigo NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Imagen VARBINARY(MAX),
    Stock INT NOT NULL
)
GO

CREATE TABLE TiendaArticulo (
    IdTienda INT NOT NULL,
    IdArticulo INT NOT NULL,
    Fecha DATE NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY (IdTienda, IdArticulo),
    FOREIGN KEY (IdTienda) REFERENCES Tienda(IdTienda),
    FOREIGN KEY (IdArticulo) REFERENCES Articulos(IdArticulo)
)
GO

CREATE TABLE ClienteArticulo (
    IdCompra INT PRIMARY KEY IDENTITY(1,1),
    IdCliente INT NOT NULL,
    IdArticulo INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (IdArticulo) REFERENCES Articulos(IdArticulo)
)
GO