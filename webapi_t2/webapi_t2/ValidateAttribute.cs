using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using webapi_t2.Models;
using System;

namespace webapi_t2
{
    public class ValidateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            NewItem item = (NewItem)validationContext.ObjectInstance;

            if (DateTime.Compare(item.CreationTime, DateTime.Now) > 0) {
                //Console.WriteLine("incorrect stuff");
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
        private string GetErrorMessage()
    {
        return "itemi on luotu tulevaisuudessa.";
    }
        
    }
    

}