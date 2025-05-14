namespace NRG3.Bliss.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
        Task CompleteAsync();
}