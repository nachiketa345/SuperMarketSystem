﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.PluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Execute(Product product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}
