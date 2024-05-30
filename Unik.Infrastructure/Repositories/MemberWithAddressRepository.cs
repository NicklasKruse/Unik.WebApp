using Microsoft.EntityFrameworkCore;
using SqlServerContext;
using Unik.Application.Queries.MemberWithAddress.DTO;
using Unik.Application.Repositories;
using Unik.Domain.Entities;

namespace Unik.Infrastructure.Repositories
{
    /// <summary>
    /// MemberWithAddress Repository
    /// </summary>
    public class MemberWithAddressRepository : IMemberWithAddressRepository
    {
        private readonly BackendDbContext _context;

        public MemberWithAddressRepository(BackendDbContext context)
        {
            _context = context;
        }

        async Task IMemberWithAddressRepository.CreateMemberWithAddress(MemberWithAddress foreningsMedlem)
        {
            try
            {
                _context.Add(foreningsMedlem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Load med int id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        MemberWithAddress IMemberWithAddressRepository.Load(int id)
        {
            var MWA = _context.MemberWithAddress
                .Include(x => x.Address)
                .FirstOrDefault(x => x.Id == id) ?? throw new Exception("Member with address not found");
            return MWA;

        }
        /// <summary>
        /// Load med adresse info
        /// </summary>
        /// <param name="Street"></param>
        /// <param name="City"></param>
        /// <param name="ZipCode"></param>
        /// <param name="Country"></param>
        /// <returns></returns>
        MemberWithAddress IMemberWithAddressRepository.Load(string Street, string City, string ZipCode, string Country)
        {
            var memberWithAddress = _context.MemberWithAddress
                .Include(x => x.Address)
                .FirstOrDefault(x => x.Address.Street == Street && x.Address.City == City && x.Address.ZipCode == ZipCode && x.Address.Country == Country);
            if (memberWithAddress == null)
            {
                return null;
            }
            return memberWithAddress;
        }

        GetAddressQueryResultDto IMemberWithAddressRepository.GetAddressByStreetCityZipCodeCountry(string street, string city, string zipCode, string country)
        {
            var address = _context.MemberWithAddress
                .AsNoTracking()
                .Include(x => x.Address)
                .FirstOrDefault(x => x.Address.Street == street && x.Address.City == city && x.Address.ZipCode == zipCode && x.Address.Country == country);

            if (address == null)
            {
                return null;
            }

            return new GetAddressQueryResultDto
            {
                Id = address.Id,
                City = address.Address.City,
                Country = address.Address.Country,
                Street = address.Address.Street,
                ZipCode = address.Address.ZipCode
            };

        }

        void IMemberWithAddressRepository.UpdateMemberWithAddress(MemberWithAddress MWA)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Async til email service
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<MemberWithAddressQueryResultDto>> IMemberWithAddressRepository.GetAllMemberWithAddressAsync()
        {
            var memberWithAddressList = await _context.MemberWithAddress
        .Include(x => x.Address)
        .Select(memberWithAddress => new MemberWithAddressQueryResultDto
        {
            id = memberWithAddress.Id,
            FirstName = memberWithAddress.FirstName,
            LastName = memberWithAddress.LastName,
            Email = memberWithAddress.Email,
            Address = new GetAddressQueryResultDto
            {
                City = memberWithAddress.Address.City,
                Country = memberWithAddress.Address.Country,
                Street = memberWithAddress.Address.Street,
                ZipCode = memberWithAddress.Address.ZipCode
            },
            DateOfCreation = memberWithAddress.DateOfCreation,
            CreatedBy = memberWithAddress.CreatedBy,
            LastModifiedDate = memberWithAddress.LastModifiedDate
        })
        .ToListAsync();

            return memberWithAddressList;
        }

        IEnumerable<MemberWithAddressQueryResultDto> IMemberWithAddressRepository.GetAllMemberWithAddress()
        {
            foreach (var memberWithAddress in _context.MemberWithAddress.Include(x => x.Address).AsNoTracking())
            {
                yield return new MemberWithAddressQueryResultDto
                {
                    id = memberWithAddress.Id,
                    FirstName = memberWithAddress.FirstName,
                    LastName = memberWithAddress.LastName,
                    Email = memberWithAddress.Email,
                    Address = new GetAddressQueryResultDto
                    {
                        City = memberWithAddress.Address.City,
                        Country = memberWithAddress.Address.Country,
                        Street = memberWithAddress.Address.Street,
                        ZipCode = memberWithAddress.Address.ZipCode
                    },
                    DateOfCreation = memberWithAddress.DateOfCreation,
                    CreatedBy = memberWithAddress.CreatedBy,
                    LastModifiedDate = memberWithAddress.LastModifiedDate
                };
            }
        }

        void IMemberWithAddressRepository.DeleteMemberWithAddress(MemberWithAddress MWA)
        {
            _context.Remove(MWA);
            _context.SaveChanges();
        }
    }
}

