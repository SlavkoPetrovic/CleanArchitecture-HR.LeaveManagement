﻿using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidatior : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidatior(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
        RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");
        RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists");
        this._leaveTypeRepository = leaveTypeRepository;
    }
    private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
