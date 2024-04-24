using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.Member.Implementation
{
    public class DeleteMemberCommand : IDeleteMemberCommand
    {
        private readonly IMemberRepository _memberRepository;
        public DeleteMemberCommand(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        void IDeleteMemberCommand.Delete(int id)
        {
           var model = _memberRepository.Load(id);
            if (model == null)
            {
                throw new Exception("Member not found");
            }
            _memberRepository.Delete(model);
        }
    }
}
