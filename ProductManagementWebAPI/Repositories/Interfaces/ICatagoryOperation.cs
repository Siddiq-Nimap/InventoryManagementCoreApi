using ProductManagementWebAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ICatagoryOperation
    {
        Task<bool> ActivateAsync(int id);

        Task<bool> DeactivateAsync(int id);

        Task<bool> InsertProductInCatagoryAsync(int productId, int CatagoryId);

        Task<IEnumerable<ReportDto>> ReportAsync(int id);
        Task<IEnumerable<ReportDto>> ReportAllAsync();



    }
}
