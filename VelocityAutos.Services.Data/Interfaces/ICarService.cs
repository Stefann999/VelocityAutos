namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<bool> ExistsByIdAsync(string carId);
    }
}
