using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Rule.Abstract
{
    public interface IProductRule
    {
        Result CheckIfNameExisted(string name, Guid? id = null);
    }
}
