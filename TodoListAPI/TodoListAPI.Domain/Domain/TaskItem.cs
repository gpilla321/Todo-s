using TodoListAPI.Core.Validators;

namespace TodoListAPI.Core.Domain
{
    public class TaskItem : DomainBase
    {
        public TaskItem() { }
        public TaskItem(int id) : base(id) { }

        public TaskItem(string title, string? descrption = null) 
        {
            SetTitle(title);
            SetDescription(descrption);
        }

        public TaskItem(string title, DateTime? startTime, string? descrption = null)
        {
            SetTitle(title);
            SetStartTime(startTime);
            SetDescription(descrption);
        }

        public TaskItem(string title, DateTime? startTime, DateTime? endTime, string? descrption = null)
        {
            SetTitle(title);
            SetStartTime(startTime);
            SetEndTime(endTime);
            SetDescription(descrption);
        }

        #region Private Props
        private string _title;
        private string? _description;
        private DateTime? _startTime;
        private DateTime? _endTime;
        #endregion

        #region Public Props
        public string Title { get => _title; set => SetTitle(value); }
        public string? Description { get => _description; set => SetDescription(value); }
        public DateTime? StartTime { get => _startTime; set => SetStartTime(value); }
        public DateTime? EndTime { get => _endTime; set => SetEndTime(value); }
        #endregion

        #region Sets
        public void SetTitle(string title) => _title = title;
        public void SetDescription(string? description) => _description = description;
        public void SetStartTime(DateTime? startTime) => _startTime = startTime;
        public void SetEndTime(DateTime? endTime) => _endTime = endTime;

        #endregion

        #region Validators
        public override bool InsertIsValid()
        {
            var validator = new InsertTaskItemValidator();

            var validate = validator.Validate(this);

            if (validate.Errors.Any())
                SetErrors(validate.Errors);

            return validate.IsValid;
        }

        public override bool UpdateIsValid()
        {
            var validator = new UpdateTaskItemValidator();

            var validate = validator.Validate(this);

            if (validate.Errors.Any())
                SetErrors(validate.Errors);

            return validate.IsValid;
        }
        #endregion
    }
}
