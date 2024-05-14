using Shared;
using System.Data;
using Unik.Application.Commands.Member.DTO;
using Unik.Application.Repositories;

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

            try
            {
                unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var member = new Domain.Entities.Member(createMemberDto.Name, createMemberDto.Address);
                _memberRepository.Create(member);
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
