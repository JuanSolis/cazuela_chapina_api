using System;

namespace cazuela_chapina_core.Repository.IRepository;

public interface ISucursalRepository
{
    ICollection<Sucursal> ObtenerSucursales();
    Sucursal? ObtenerSucursal(int id);
    bool ExisteSucursal(int id);
    bool ExisteSucursal(string nombreSucursal);

    bool CrearSucursal(Sucursal sucursal);

    bool Guardar();


}
