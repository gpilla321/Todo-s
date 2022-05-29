namespace TodoListAPI.Core.Validators
{
    public class UpdateTaskItemValidator : TaskItemValidator
    {
        public UpdateTaskItemValidator()
        {
            ValidateId();
            ValidateTitle();
            ValidateDescription();
            ValidateStartTime();
            ValidateEndTime();
        }
    }
}
