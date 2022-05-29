namespace TodoListAPI.Core.Validators
{
    public class InsertTaskItemValidator : TaskItemValidator
    {
        public InsertTaskItemValidator()
        {
            ValidateTitle();
            ValidateDescription();
            ValidateStartTime();
            ValidateEndTime();
        }
    }
}
