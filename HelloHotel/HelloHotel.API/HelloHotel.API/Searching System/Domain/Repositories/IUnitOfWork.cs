using System.Threading.Tasks;

namespace HelloHotel.API.Searching_System.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}