using Demo.Domaiin.Entities;
using Demo.Domaiin.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Books.Commands
{

    public class BookAddCommandHandler : IRequestHandler<BookAddCommand>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork1;
        public BookAddCommandHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork1 = applicationUnitOfWork;

        }

        public async Task Handle(BookAddCommand request, CancellationToken cancellationToken)
        {
           await _applicationUnitOfWork1.BookRepository.AddAsync(new Book { Title = request.Title , AuthorId= request.AuthorId});
            await _applicationUnitOfWork1.SaveAsync();
        }
    }
}
