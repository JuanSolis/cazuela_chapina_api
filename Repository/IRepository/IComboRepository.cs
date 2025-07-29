using System;
using cazuela_chapina_core.Models;

namespace cazuela_chapina_core.Repository.IRepository;

public interface IComboRepository
{
    ICollection<Combo> ObtenerCombos();

    Combo? InformacionCombo(int comboId);

}
