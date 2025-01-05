using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Rule.Abstract
{
    public interface IRoleRule
    {
        Result CheckIfNameExisted(string name, Guid? id = null);
    }
}
