using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unik.Application.Commands.Member.DTO;
using Unik.Application.Repositories;
using Unik.Domain.Ínterfaces;
using Unik.Domain.ValueObjects;

namespace Unik.Application.Commands.Member.Implementation
{
    public class CreateMemberCommand : ICreateMemberCommand
    {
        private readonly IMemberRepository _memberRepository;
        //private readonly IMemberDomainService memberDomainService
        private readonly IUnitOfWork unitOfWork;
        public CreateMemberCommand(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            this.unitOfWork = unitOfWork;
        }
        void ICreateMemberCommand.CreateMember(MemberCreateRequestDto createMemberDto)
        {

            unitOfWork.BeginTransaction(IsolationLevel.Serializable);

            var member = new Domain.Entities.Member(createMemberDto.Name, createMemberDto.Address);
            _memberRepository.Add(member);
            unitOfWork.Commit();
        }
    }
}
