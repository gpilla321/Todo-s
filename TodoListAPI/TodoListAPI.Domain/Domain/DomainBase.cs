using FluentValidation.Results;

namespace TodoListAPI.Core.Domain
{
    public abstract class DomainBase
    {
        public DomainBase()
        {
            Errors = new List<ValidationFailure>();
        }

        public DomainBase(int id)
        {
            Errors = new List<ValidationFailure>();
            SetId(id);
        }

        private List<ValidationFailure> Errors { get; set; }

        
        private int _id;
        public int Id { get => _id; }

        public void SetId(int id)
        {
            _id = id;
        }

        public void SetErrors(List<ValidationFailure> errors) => Errors = errors;

        public string GetErrorsConcat() => string.Concat(Errors.Select(error => error.ErrorMessage));
        public List<string> GetErrors() => Errors.Select(error => error.ErrorMessage).ToList();
        public abstract bool InsertIsValid();
        public abstract bool UpdateIsValid();
    }
}
