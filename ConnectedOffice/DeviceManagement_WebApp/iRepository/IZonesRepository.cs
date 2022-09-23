using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.iRepository
{
    public interface IZonesRepository : IGenericRepository<Zone>
    {
        Zone GetMostRecentZone();
    }
}
