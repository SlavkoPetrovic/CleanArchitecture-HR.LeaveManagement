using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails
{
    public class GetLeaveRequestDetailsQuery : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }

}
