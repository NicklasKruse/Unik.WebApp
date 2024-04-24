using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Member.DTO;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.Member.Implementation
{
    public class EditMemberCommand : IEditMemberCommand
    {
        private readonly IMemberRepository _memberRepository;
        public EditMemberCommand(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        void IEditMemberCommand.Edit(MemberEditRequestDto editMemberDto)
        {
            var model = _memberRepository.Load(editMemberDto.Id); 
            if (model == null)
            {
                throw new Exception("Member not found");
            }

            model.Edit(editMemberDto.Name , editMemberDto.Address); 

            _memberRepository.Update(model);

        }
    }
}
