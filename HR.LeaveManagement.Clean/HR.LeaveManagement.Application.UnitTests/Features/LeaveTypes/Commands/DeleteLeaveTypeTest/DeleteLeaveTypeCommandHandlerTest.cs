using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Commands.DeleteLeaveTypeTest;

public class DeleteLeaveTypeCommandHandlerTest
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;

    public DeleteLeaveTypeCommandHandlerTest()
    {
        _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

    }

    [Fact]
    public async Task DeleteLeaveType()
    {
        var handler = new DeleteLeaveTypeCommandHandler(_mockRepo.Object);

        await handler.Handle(new DeleteLeaveTypeCommand { Id = 1 }, CancellationToken.None);

        var leaveTypes = await _mockRepo.Object.GetAsync();

        var deletedType = await _mockRepo.Object.GetByIdAsync(1);

        deletedType.ShouldBeNull();
        leaveTypes.Count.ShouldBe(2);
       

    }
}
