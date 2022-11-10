using APC.WebUI.Models;
using APC.WebUI.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace APC.WebUI.ViewModels
{
    public class TypesViewModel : ITypesViewModel
    {
        private readonly IProductTypeService productTypeService;
        private readonly IToastService toastService;
        private readonly IProductCategoryService productCategoryService;

        public TypesViewModel(
            IProductTypeService productTypeService,
            IToastService toastService,
            IProductCategoryService productCategoryService)
        {
            this.productTypeService = productTypeService;
            this.toastService = toastService;
            this.productCategoryService = productCategoryService;

            this.InitializeAsync().GetAwaiter().GetResult();
        }

        public IEnumerable<ProductTypeDTO> ProductTypeDTOs { get; set; }
        public ProductTypeDTO ProductTypeDTO { get; set; }
        public IEnumerable<ProductCategoryDTO> ProductCategoryDTOs { get; set; }
        public bool SaveInProgress { get; set; }
        public string CustomErrorMessage { get; set; }

        public event Action StateChanged;
        public void NotifyStateChanged() => StateChanged?.Invoke();

        public async Task InitializeAsync()
        {
            //once it awaits, all is lost
            this.ProductTypeDTOs = (await this.productTypeService.GetProductTypesAsync())
                .OrderBy(t => t.Name);
            this.ProductCategoryDTOs = await this.productCategoryService.GetProductCategoriesAsync();
        }

        public async Task SaveProductType(EditContext editContext)
        {
            if (!FormIsValid())
            {
                return;
            }

            this.SaveInProgress = true;

            await this.productTypeService.SaveProductTypeAsync(this.ProductTypeDTO);

            this.ProductTypeDTOs = await this.productTypeService.GetProductTypesAsync();

            this.toastService.ShowSuccess(
                message: $"Type ({this.ProductTypeDTO.Name}) has been Saved Successfully.",
                heading: "Success");

            await Task.CompletedTask;

            this.ClearForm();

            this.SaveInProgress = false;
        }

        public bool FormIsValid()
        {
            this.CustomErrorMessage = null;

            if (this.ProductTypeDTO.CategoryId <= 0)
            {
                this.CustomErrorMessage += "<li>Category is required.</li>";
                return false;
            }

            return true;
        }

        public void ClearForm()
        {
            this.ProductTypeDTO = new();
        }
    }
}
