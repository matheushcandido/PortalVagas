using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Job.Update
{
    public class UpdateJobCommand : IRequest<UseCaseResponse<bool>>
    {
        public required JobDTO JobDTO { get; set; }
        public Guid JobId { get; set; }
    }
}
