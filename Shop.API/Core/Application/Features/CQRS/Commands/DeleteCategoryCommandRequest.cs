﻿using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteCategoryCommandRequest(int id)
        {
            Id= id; 
        }
    }
}
