﻿using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductTypeDTO>> GetProductTypesAsync();
    }
}