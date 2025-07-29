--Crear Base de Datos
create database cazuela_chapina_db
use cazuela_chapina_db

CREATE TABLE Usuarios (
    UsuarioId INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(max),
    NombreUsuario NVARCHAR(max),
    Password NVARCHAR(max),
    Role NVARCHAR(max),
);

-- Usuario genérica para los datos simulados
INSERT INTO Usuarios (Nombre, NombreUsuario, Password, Role) VALUES ('Admin', 'admin', '$2a$11$PZqiH/Z01JrwYZDgmYIzb.SlVHaVOVZNfGbyUL2n8vxX8GoF8oW6.', 'Admin');
DECLARE @UsuarioId INT = SCOPE_IDENTITY();


-- Tabla de Sucursales
CREATE TABLE Sucursales (
    SucursalID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Ubicacion NVARCHAR(255),
    FechaCreacion DATETIME,
     Estatus VARCHAR(20)
);
select * from Sucursales

-- Sucursal genérica para los datos simulados
INSERT INTO Sucursales (Nombre, Ubicacion, FechaCreacion, Estatus) VALUES ('Sucursal Central', 'Zona 1, Ciudad de Guatemala', '2021-03-01', 'Activo');
DECLARE @SucursalID INT = SCOPE_IDENTITY();

--Crear tabla ventas

CREATE TABLE Ventas (
    VentaID INT PRIMARY KEY IDENTITY,
    Fecha DATETIME NOT NULL,
    Horario NVARCHAR(20),
    Tipo NVARCHAR(10), -- Tamal o Bebida
    Precio DECIMAL(10,2),
    SucursalID INT FOREIGN KEY REFERENCES Sucursales(SucursalID)
);

select * from Sucursales

-- Detalle de Tamales
CREATE TABLE DetalleTamales (
    TamalID INT PRIMARY KEY IDENTITY,
    VentaID INT FOREIGN KEY REFERENCES Ventas(VentaID),
    Masa NVARCHAR(50),
    Relleno NVARCHAR(100),
    Envoltura NVARCHAR(50),
    Picante NVARCHAR(50)
);

-- Detalle de Bebidas
CREATE TABLE DetalleBebidas (
    BebidaID INT PRIMARY KEY IDENTITY,
    VentaID INT FOREIGN KEY REFERENCES Ventas(VentaID),
    Nombre NVARCHAR(100),
    Endulzante NVARCHAR(50),
    Topping NVARCHAR(50)
);

select * from DetalleBebidas;


-- Tabla de Inventario
CREATE TABLE Inventario (
    ItemID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Tipo NVARCHAR(50), -- Ej. Masa, Hoja, Azúcar
    Unidad NVARCHAR(20),
    Stock DECIMAL(10,2),
    CostoUnitario DECIMAL(10,2),
    FechaUltimoMovimiento DATETIME
);

 --Tabla de Movimientos de Inventario
CREATE TABLE MovimientosInventario (
    MovimientoID INT PRIMARY KEY IDENTITY,
    ItemID INT FOREIGN KEY REFERENCES Inventario(ItemID),
    VentaID INT NULL FOREIGN KEY REFERENCES Ventas(VentaID),
    TipoMovimiento NVARCHAR(20), -- Entrada, Salida, Merma
    Cantidad DECIMAL(10,2),
    Fecha DATETIME,
    Comentario NVARCHAR(255)
);

-- Define los insumos requeridos por cada tipo de tamal o bebida
CREATE TABLE Recetas (
    RecetaID INT PRIMARY KEY IDENTITY,
    TipoProducto NVARCHAR(10), -- 'Tamal' o 'Bebida'
    Descripcion NVARCHAR(255), -- Ej. 'Tamal Maíz Amarillo con Cerdo'
    ItemID INT FOREIGN KEY REFERENCES Inventario(ItemID),
    CantidadPorUnidad DECIMAL(10,2), -- Por unidad vendida
    Unidad NVARCHAR(20)
);

CREATE TABLE Combos (
    ComboID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Tipo NVARCHAR(50), -- 'Familiar', 'Eventos', 'Estacional'
    Descripcion NVARCHAR(255),
    DisponibleDesde DATE NULL,
    DisponibleHasta DATE NULL,
    Activo BIT DEFAULT 1,
    Precio int Not NULL
);


CREATE TABLE ComboItems (
    ComboItemID INT PRIMARY KEY IDENTITY,
    ComboID INT FOREIGN KEY REFERENCES Combos(ComboID),
    TipoProducto NVARCHAR(50), -- 'Tamal', 'Bebida', 'Extra'
    Cantidad INT,
    Detalle NVARCHAR(100) -- Ej: 'Docena surtida', 'Jarro 1L', 'Termo de barro'
);


CREATE TABLE VentasCombos (
    VentaComboID INT PRIMARY KEY IDENTITY,
    VentaID INT FOREIGN KEY REFERENCES Ventas(VentaID),
    ComboID INT FOREIGN KEY REFERENCES Combos(ComboID),
    Precio DECIMAL(10,2)
); 

 --Combo 1: Fiesta Patronal
INSERT INTO Combos (Nombre, Tipo, Descripcion)
VALUES ('Fiesta Patronal', 'Familiar', '1 docena surtida de tamales y 2 jarros de bebida');

 --Combo 1: Fiesta Patronal Contenido
INSERT INTO ComboItems (ComboID, TipoProducto, Cantidad, Detalle)
VALUES 
(1, 'Tamal', 12, 'Docena surtida'),
(1, 'Bebida', 2, 'Jarro 1L');


 --Combo 2: Madrugada del 24
INSERT INTO Combos (Nombre, Tipo, Descripcion)
VALUES ('Madrugada del 24', 'Eventos', '3 docenas de tamales, 4 jarros y termo de barro');

 --Combo 2 : Madrugada del 24 Contenido

 INSERT INTO ComboItems (ComboID, TipoProducto, Cantidad, Detalle)
VALUES 
(2, 'Tamal', 36, 'Tres docenas surtidas'),
(2, 'Bebida', 4, 'Jarro 1L'),
(2, 'Extra', 1, 'Termo de barro conmemorativo');


 --Combo 2: Quema del Diabl0
INSERT INTO Combos (Nombre, Tipo, Descripcion, DisponibleDesde, DisponibleHasta)
VALUES ('Quema del Diablo', 'Estacional', 'Tamales picantes y cacao batido', '2024-12-01', '2024-12-08');

 --Combo 2 :Quema del Diabl0

INSERT INTO ComboItems (ComboID, TipoProducto, Cantidad, Detalle)
VALUES 
(3, 'Tamal', 6, 'Tamales picantes surtidos'),
(3, 'Bebida', 2, 'Cacao batido');

select * from VentasCombos 

