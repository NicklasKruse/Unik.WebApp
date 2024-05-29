using Microsoft.EntityFrameworkCore;
using SqlServerContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Queries.MemberWithAddress.DTO;
using Unik.Application.Repositories;
using Unik.Domain.Entities;
using Unik.Domain.ValueObjects;

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
            catch(Exception ex)
            {
                throw ex;
            }
        }

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

        IEnumerable<MemberWithAddressQueryResultDto> IMemberWithAddressRepository.GetAllMemberWithAddress()
        {
            foreach(var memberWithAddress in _context.MemberWithAddress.Include(x => x.Address).AsNoTracking())
            {
                yield return new MemberWithAddressQueryResultDto
                {
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
    }
}
