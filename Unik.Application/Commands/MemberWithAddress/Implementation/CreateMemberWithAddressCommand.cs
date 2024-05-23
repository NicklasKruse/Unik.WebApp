using Shared;
using System.Data;
using Unik.Application.Commands.MemberWithAddress.RequestModels;
using Unik.Application.Repositories;
using Unik.Domain.ValueObjects;

namespace Unik.Application.Commands.MemberWithAddress.Implementation
{
    /// <summary>
    /// Opret medlem med adresse
    /// </summary>
    public class CreateMemberWithAddressCommand : ICreateMemberWithAddressCommand
    {
        private readonly IMemberWithAddressRepository _memberWithAddressRepository;

        private readonly IUnitOfWork unitOfWork;

        public CreateMemberWithAddressCommand(IMemberWithAddressRepository memberWithAddressRepository, IUnitOfWork unitOfWork)
        {
            _memberWithAddressRepository = memberWithAddressRepository;
            this.unitOfWork = unitOfWork;
        }


        async Task ICreateMemberWithAddressCommand.CreateMemberWithAddress(MemberWithAddressRequestDto createMemberWithAddressDto)
        {
            try
            {
                unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var address = new Address
                {
                    Street = createMemberWithAddressDto.Address.Street,
                    City = createMemberWithAddressDto.Address.City,
                    ZipCode = createMemberWithAddressDto.Address.ZipCode,
                    Country = createMemberWithAddressDto.Address.Country
                };

                var memberWithAddress = new Domain.Entities.MemberWithAddress(createMemberWithAddressDto.FirstName, createMemberWithAddressDto.LastName, createMemberWithAddressDto.Email, address)
                { 
                    CreatedBy = createMemberWithAddressDto.CreatedBy, LastModifiedDate = createMemberWithAddressDto.LastModifiedDate, DateOfCreation = createMemberWithAddressDto.DateOfCreation 
                };
                await _memberWithAddressRepository.CreateMemberWithAddress(memberWithAddress);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                unitOfWork.Rollback();
            }
        }
    }
}

//public async Task CreateMemberWithAddress(MemberWithAddressRequestDto createMemberWithAddressDto)
//{
//    try
//    {
//        unitOfWork.BeginTransaction(IsolationLevel.Serializable);

//        // Check if the address already exists
//        var existingAddress = _memberWithAddressRepository.Load(createMemberWithAddressDto.Address.Street, createMemberWithAddressDto.Address.City, createMemberWithAddressDto.Address.ZipCode, createMemberWithAddressDto.Address.Country);

//        if (existingAddress == null)
//        {
//            var address = new Address
//            {
//                Street = createMemberWithAddressDto.Address.Street,
//                City = createMemberWithAddressDto.Address.City,
//                ZipCode = createMemberWithAddressDto.Address.ZipCode,
//                Country = createMemberWithAddressDto.Address.Country
//            };
//            var memberWithNewAddress = new Domain.Entities.MemberWithAddress(createMemberWithAddressDto.FirstName, createMemberWithAddressDto.LastName, createMemberWithAddressDto.Email, address);
//            await _memberWithAddressRepository.CreateMemberWithAddress(memberWithNewAddress);

//        }
//        else
//        {
//            var memberWithExistingAddress = new Domain.Entities.MemberWithAddress(createMemberWithAddressDto.FirstName, createMemberWithAddressDto.LastName, createMemberWithAddressDto.Email, existingAddress.Address);
//            await _memberWithAddressRepository.CreateMemberWithAddress(memberWithExistingAddress);
//        }

//        unitOfWork.Commit();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//        unitOfWork.Rollback();
//    }
//}