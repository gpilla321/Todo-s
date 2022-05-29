using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListAPI.Core.Domain;
using TodoListAPI.Resources;

namespace TodoListAPI.Core.Validators
{
    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator() { }

        #region Validator Methods
        public void ValidateId()
        {
            RuleFor(taskItem => taskItem.Id).NotNull().WithMessage(ErrorMessage_TaskItem._006_Id);
        }
        public void ValidateTitle()
        {
            RuleFor(taskItem => taskItem.Title).NotEmpty()
                                              .WithMessage(ErrorMessage_TaskItem._001_Title)
                                              .Length(3, 20)
                                              .WithMessage(ErrorMessage_TaskItem._002_Title);
        }
        public void ValidateDescription()
        {
            RuleFor(taskItem => taskItem.Description).MaximumLength(100)
                                                     .WithMessage(ErrorMessage_TaskItem._003_Description);
        }

        public void ValidateStartTime()
        {
            RuleFor(taskItem => taskItem.StartTime).LessThan(new DateTime(2030, 12, 31))
                                                   .When(taskItem => taskItem.StartTime is not null)
                                                   .WithMessage(ErrorMessage_TaskItem._004_StartTime);
        }
        public void ValidateEndTime()
        {
            RuleFor(taskItem => taskItem.EndTime).GreaterThan(taskItem => taskItem.StartTime)
                                                 .When(taskItem => taskItem.StartTime is not null)
                                                 .WithMessage(ErrorMessage_TaskItem._005_EndTime);
        }
        #endregion
    }
}
