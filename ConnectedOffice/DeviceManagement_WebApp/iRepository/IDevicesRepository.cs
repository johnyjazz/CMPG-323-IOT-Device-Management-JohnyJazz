using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.iRepository
{
    public interface IDevicesRepository : IGenericRepository<Device>
    {
        Device GetMostRecentDevice();
    }
}
