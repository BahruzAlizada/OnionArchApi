using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;
using OnionArch.Application.Parametres.ResponseParametres;
using OnionArch.Application.Rule.Abstract;

namespace OnionArch.Application.Rule.Concrete
{
    public class ProductRule : IProductRule
    {
        private readonly IProductReadRepository productReadRepository;
        public ProductRule(IProductReadRepository productReadRepository)
        {
            this.productReadRepository = productReadRepository;
        }

        //public Result CheckIfNameExisted(string name)
        //{
        //    var products = productReadRepository.GetAll(false).Any(x => x.Name == name);
        //    if (products)
        //        return new Result { Success = false, Message = Messages.CheckIfNameExisted };

        //    return new Result { Success = true };
        //}

        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var productExists = productReadRepository.GetAll(false)
                    .Any(x => x.Name == name && x.Id != id.Value);

                if (productExists)
                {
                    return new Result { Success = false, Message = Messages.CheckIfNameExisted };
                }
            }
            else
            {
                var productExists = productReadRepository.GetAll(false)
                    .Any(x => x.Name == name);

                if (productExists)
                {
                    return new Result { Success = false, Message = Messages.CheckIfNameExisted };
                }
            }

            return new Result { Success = true };
        }
    }
}
