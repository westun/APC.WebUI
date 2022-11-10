using APC.WebUI.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace APC.WebUI.ViewModels
{
    public interface ITypesViewModel
    {
        IEnumerable<ProductTypeDTO> ProductTypeDTOs { get; set; }
        ProductTypeDTO ProductTypeDTO { get; set; }
        IEnumerable<ProductCategoryDTO> ProductCategoryDTOs { get; set; }

        event Action StateChanged;
        void NotifyStateChanged();

        Task InitializeAsync();
        Task SaveProductType(EditContext editContext);
        bool FormIsValid();
        void ClearForm();

        bool SaveInProgress { get; set; }
        string CustomErrorMessage { get; set; }
    }
}
