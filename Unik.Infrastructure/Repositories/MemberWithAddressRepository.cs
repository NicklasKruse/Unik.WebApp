using SqlServerContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Repositories;
using Unik.Domain.Entities;

namespace Unik.Infrastructure.Repositories
{
    public class MemberWithAddressRepository : IMemberWithAddressRepository
    {
        private readonly BackendDbContext _context;

        public MemberWithAddressRepository(BackendDbContext context)
        {
            _context = context;
        }

        async Task IMemberWithAddressRepository.CreateMemberWithAddress(MemberWithAddress foreningsMedlem)
        {
            await _context.AddAsync(foreningsMedlem);
            await _context.SaveChangesAsync();
        }
    }
}
