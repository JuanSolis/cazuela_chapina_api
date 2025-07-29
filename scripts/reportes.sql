
-- =========================================
-- REPORTES PARA SISTEMA DE TAMALES Y BEBIDAS
-- =========================================

-- 

use cazuela_chapina_db

--Ventas diarias
--check 
SELECT 
    CONVERT(DATE, Fecha) AS FechaVenta,
    COUNT(*) AS TotalVentas,
    SUM(Precio) AS TotalIngresos
FROM Ventas
GROUP BY CONVERT(DATE, Fecha)
ORDER BY TotalVentas;

-- Ventas por Mes
--Check
SELECT 
    YEAR(Fecha) AS año,
    MONTH(Fecha) AS Mes,
    COUNT(*) AS TotalVentas,
    SUM(Precio) AS TotalIngresos
FROM Ventas
GROUP BY YEAR(Fecha),MONTH(Fecha)
ORDER BY TotalVentas;

-- Gestión y reportes por sucursales - ingresos
--Check
SELECT 
    s.Nombre AS Sucursal,
    COUNT(v.VentaID) AS TotalVentas,
    SUM(v.Precio) AS TotalIngresos
FROM Ventas v
JOIN Sucursales s ON v.SucursalID = s.SucursalID
GROUP BY s.Nombre
ORDER By TotalVentas;
-- Tamales más vendidos
--Check
SELECT 
    Relleno,
    COUNT(*) AS TotalVendidos
FROM DetalleTamales
GROUP BY Relleno
ORDER BY TotalVendidos DESC;

select  * from DetalleTamales

--Bebidas preferidas por horario
--Check
SELECT 
    v.Horario,
    d.Nombre AS Bebida,
    COUNT(*) AS TotalVendidos
FROM DetalleBebidas d
JOIN Ventas v ON d.VentaID = v.VentaID
GROUP BY v.Horario, d.Nombre
ORDER BY v.Horario, TotalVendidos DESC;

select * from DetalleBebidas

--Proporción picante vs no picante
--Check
SELECT 
    Picante,
    COUNT(*) AS Cantidad
FROM DetalleTamales
GROUP BY Picante
ORDER BY Cantidad 

-- 5. Utilidades por línea - Tamales
SELECT 
    'Tamal' AS Linea,
    COUNT(*) AS CantidadVendida,
    SUM(v.Precio) AS IngresoTotal,
    SUM(ri.CostoUnitario * r.CantidadPorUnidad) AS CostoTotal,
    SUM(v.Precio) - SUM(ri.CostoUnitario * r.CantidadPorUnidad) AS Utilidad
FROM DetalleTamales dt
JOIN Ventas v ON dt.VentaID = v.VentaID
JOIN Recetas r ON r.TipoProducto = 'Tamal'
JOIN Inventario ri ON r.ItemID = ri.ItemID
GROUP BY r.TipoProducto;

-- 5. Utilidades por línea - Bebidas
SELECT 
    'Bebida' AS Linea,
    COUNT(*) AS CantidadVendida,
    SUM(v.Precio) AS IngresoTotal,
    SUM(ri.CostoUnitario * r.CantidadPorUnidad) AS CostoTotal,
    SUM(v.Precio) - SUM(ri.CostoUnitario * r.CantidadPorUnidad) AS Utilidad
FROM DetalleBebidas db
JOIN Ventas v ON db.VentaID = v.VentaID
JOIN Recetas r ON r.TipoProducto = 'Bebida'
JOIN Inventario ri ON r.ItemID = ri.ItemID
GROUP BY r.TipoProducto;

-- 6. Desperdicio de materias primas
SELECT 
    i.Nombre,
    SUM(mi.Cantidad) AS TotalMerma,
    i.Unidad
FROM MovimientosInventario mi
JOIN Inventario i ON mi.ItemID = i.ItemID
WHERE mi.TipoMovimiento = 'Merma'
GROUP BY i.Nombre, i.Unidad
ORDER BY TotalMerma DESC;

-- 7. Productos más vendidos por sucursal
SELECT 
    s.Nombre AS Sucursal,
    d.Relleno,
    COUNT(*) AS Cantidad
FROM Ventas v
JOIN DetalleTamales d ON v.VentaID = d.VentaID
JOIN Sucursales s ON v.SucursalID = s.SucursalID
GROUP BY s.Nombre, d.Relleno
ORDER BY s.Nombre, Cantidad DESC;


-- Ventas de combos
SELECT 
    c.Nombre,
    COUNT(vc.VentaComboID) AS VecesVendido,
    SUM(vc.Precio) AS IngresoGenerado
FROM VentasCombos vc
JOIN Combos c ON vc.ComboID = c.ComboID
GROUP BY c.Nombre;

select * from Combos