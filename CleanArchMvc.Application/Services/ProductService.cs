using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new Exception("Entity could not be found.");
            }

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null) return null;
            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
            {
                throw new Exception("Entity could not be found.");
            }
            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productUpdateHandler = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateHandler);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
            {
                return null;
            }

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(productByIdQuery);
        }
    }
}
