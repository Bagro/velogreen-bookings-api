using System.Threading.Tasks;
using VeloGreen.Bookings.Api.Entities;

namespace VeloGreen.Bookings.Api.Handlers
{
    public interface IBookableHandler
    {
        Task Create(Bookable bookable);
    }
}
