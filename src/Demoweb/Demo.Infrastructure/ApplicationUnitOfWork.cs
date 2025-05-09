using Demo.Domaiin.Repositories;
using Demo.Domaiin.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public class ApplicationUnitOfWork : UnityOfWork,IApplicationUnitOfWork
    {
        public IBookRepository BookRepository { get; private set; }
        public IAuthorRepository AuthorRepository { get; private  set; }
        public ApplicationUnitOfWork(ApplicationDbContext context,IBookRepository bookRepository,IAuthorRepository repository) : base(context)
        {
            BookRepository = bookRepository;
            AuthorRepository = repository;


        }
    }
}
