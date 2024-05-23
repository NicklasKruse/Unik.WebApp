using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Invitation.RequestModels;
using Unik.Application.Repositories;

namespace Unik.Application.Commands.Invitation.Implementation
{
    public class CreateInvitationCommand : ICreateInvitationCommand
       
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateInvitationCommand(IInvitationRepository invitationRepository, IUnitOfWork unitOfWork)
        {
            _invitationRepository = invitationRepository;
            _unitOfWork = unitOfWork;
        }

        void ICreateInvitationCommand.CreateInvitation(InvitationRequestDto invitationRequestDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var invitation = new Domain.Entities.Invitation(invitationRequestDto.Description, invitationRequestDto.Date) 
                { 
                    CreatedBy = invitationRequestDto.CreatedBy, DateOfCreation = invitationRequestDto.DateOfCreation 
                };
                _invitationRepository.Create(invitation);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
