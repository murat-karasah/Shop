using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> repository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> repository, IRepository<AppRole> roleRepository)
        {
            this.repository = repository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.repository.GetByFilter(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user ==null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await this.roleRepository.GetByFilter(x => x.Id == user.AppRoleId);
                dto.Role = role.Definition; 
            }
            return dto;

        }
    }
}
