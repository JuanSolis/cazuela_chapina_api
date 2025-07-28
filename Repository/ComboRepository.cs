using System;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Repository.IRepository;

namespace cazuela_chapina_core.Repository;

public class ComboRepository : IComboRepository
{
    private readonly ApplicationDbContext _db;

    public ComboRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public Combo? InformacionCombo(int comboId)
    {
        return _db.Combos.FirstOrDefault(combo => combo.ComboID == comboId);
    }

    public ICollection<Combo> ObtenerCombos()
    {
        return _db.Combos.OrderBy(combo => combo.Nombre).ToList();
    }

}
