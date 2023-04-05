using MatchScore.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchScore.Web.ViewModels.EventViewModels
{
    public class ParticipantsLessThanAttribute : ValidationAttribute
    {
        private readonly string referentProperty;

        public ParticipantsLessThanAttribute(string referentProperty)
        {
            this.referentProperty = referentProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (int)value;

            var property = validationContext.ObjectType.GetProperty(this.referentProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var referentValue = (EventTypes)property.GetValue(validationContext.ObjectInstance);

            if(referentValue == EventTypes.League)
            {
                if(currentValue < 4)
                    return new ValidationResult(ErrorMessage);
            }               

            return ValidationResult.Success;
        }
    }
}
