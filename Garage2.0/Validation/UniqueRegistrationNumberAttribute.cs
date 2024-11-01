using Garage2._0.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Validation
{
    public class UniqueRegistrationNumberAttribute : ValidationAttribute
    {
        private readonly Type _dbContextType;

        public UniqueRegistrationNumberAttribute(Type dbContextType)
        {
            _dbContextType = dbContextType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext? validationContext)
        {
            var vehicleIdProperty = validationContext.ObjectType.GetProperty("Id");
            var vehicleId = vehicleIdProperty?.GetValue(validationContext.ObjectInstance, null) as int?;
            if (value == null || vehicleId !=0)
                return ValidationResult.Success;
           else 
            {
                var registrationNumber = value.ToString();

                // Get the DbContext from the validation context
                var dbContext = (DbContext)validationContext.GetService(_dbContextType);

                if (dbContext == null)
                    throw new InvalidOperationException("DbContext could not be obtained from validation context.");

                // Check if the registration number exists
                var isDuplicate = dbContext.Set<ParkedVehicle>()
                    .Any(v => v.RegistrationNumber == registrationNumber);

                return isDuplicate ? new ValidationResult("Registration number must be unique.") : ValidationResult.Success;
            }
        }
    }
}
  