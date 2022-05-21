using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRExample.WebApi.Med.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductViewModel>
    {
        public Task<GetProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var model = new List<GetProductViewModel>() {
             new GetProductViewModel()
            {
                //Id = Guid.NewGuid(),
                Id= new Guid("9dc705a6-7e97-4271-8b93-4fd0f1fc9dbb"),
                Name = "Laptop 2"
            },
             new GetProductViewModel()
            {
                Id = new Guid("0a0d8cef-b7c4-4352-98b4-a10813b7c82f"),
                Name = "Laptop 3"
            }};
            //Normaly we are using Repository
            return Task.FromResult(model.FirstOrDefault(z => z.Id == request.Id));

        }

    }
}
