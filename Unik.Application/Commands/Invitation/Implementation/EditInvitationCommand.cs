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
    public class EditInvitationCommand : IEditInvitationCommand
    {
        //Load Edit Update
        private readonly IInvitationRepository _invitationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditInvitationCommand(IInvitationRepository invitationRepository, IUnitOfWork unitOfWork)
        {
            _invitationRepository = invitationRepository;
            _unitOfWork = unitOfWork;
        }

        void IEditInvitationCommand.EditInvitation(InvitationEditRequestDto invitationEditRequestDto)
        {
            var model = _invitationRepository.Load(invitationEditRequestDto.Id);
            model.Edit(invitationEditRequestDto.Description, invitationEditRequestDto.Date);

            _invitationRepository.Update(model);
        }
    }
}
