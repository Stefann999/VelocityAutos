namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<string> AddAdminAsync(string userId);

        Task<string> RemoveAdminAsync(string userId);
    }
}
