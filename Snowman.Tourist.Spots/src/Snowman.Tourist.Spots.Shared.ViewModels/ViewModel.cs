using FluentValidation;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Snowman.Tourist.Spots.Shared.ViewModels
{
    public abstract class ViewModel
    {
        [JsonIgnore]
        public bool Valid { get; private set; }        
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }        
        [JsonIgnore]
        public bool Invalid => !Valid;

        protected bool ViewModelIsValid() => Valid == ValidationResult.IsValid;
        protected void InsertValidation<TViewModel>(TViewModel model, AbstractValidator<TViewModel> validator) where TViewModel : ViewModel
            => ValidationResult = validator.Validate(model);

        public abstract bool Validate();
    }
}
