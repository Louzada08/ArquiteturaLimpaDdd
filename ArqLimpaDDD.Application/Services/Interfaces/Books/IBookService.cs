﻿using ArqLimpaDDD.Domain.ValueObjects;

namespace ArqLimpaDDD.Application.Services.Interfaces.Books;
public interface IBookService
{
    Task<BookVO> Create(BookVO book);
    Task<BookVO> FindById(Guid id);
    Task<IList<BookVO>> GetAll();
    Task<BookVO> Update(BookVO book);
    Task Delete(Guid id);
}
