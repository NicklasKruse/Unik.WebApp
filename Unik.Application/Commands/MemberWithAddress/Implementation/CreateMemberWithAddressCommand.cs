using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.MemberWithAddress.RequestModels;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.MemberWithAddress.Implementation
{
    public class CreateMemberWithAddressCommand : ICreateMemberWithAddressCommand
    {
        private readonly IMemberWithAddressRepository _memberWithAddressRepository;

        private readonly IUnitOfWork unitOfWork;

        public CreateMemberWithAddressCommand(IMemberWithAddressRepository memberWithAddressRepository, IUnitOfWork unitOfWork)
        {
            _memberWithAddressRepository = memberWithAddressRepository;
            this.unitOfWork = unitOfWork;
        }

        void ICreateMemberWithAddressCommand.CreateMemberWithAddress(MemberWithAddressRequestDto createMemberWithAddressDto)
        {  
            try
            {
                unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var address = new Domain.ValueObjects.Address();
                address.Street = createMemberWithAddressDto.Address.Street;
                address.City = createMemberWithAddressDto.Address.City;
                address.ZipCode = createMemberWithAddressDto.Address.ZipCode;
                address.Country = createMemberWithAddressDto.Address.Country;


                var memberWithAddress = new Domain.Entities.MemberWithAddress(createMemberWithAddressDto.FirstName, createMemberWithAddressDto.LastName, createMemberWithAddressDto.Email, address);
                _memberWithAddressRepository.CreateMemberWithAddress(memberWithAddress);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
