using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.MemberWithAddress.Implementation
{
    public class DeleteMemberWithAddressCommand : IDeleteMemberWithAddressCommand
    {
        private readonly IMemberWithAddressRepository _memberWithAddressRepository;

        public DeleteMemberWithAddressCommand(IMemberWithAddressRepository memberWithAddressRepository)
        {
            _memberWithAddressRepository = memberWithAddressRepository;
        }

        void IDeleteMemberWithAddressCommand.Delete(int id)
        {
            var model = _memberWithAddressRepository.Load(id);
            if (model == null)
            {
                throw new Exception("Member with address not found");
            }
            _memberWithAddressRepository.DeleteMemberWithAddress(model);
        }
    }
}
