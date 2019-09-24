using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.Models
{
    public class GeneralError : IBaseError
    {
        public string PropertyName { get { return string.Empty; } }
        public string PropertyExceptionMessage { get; set; }
        public GeneralError(string errorMessage)
        {
            PropertyExceptionMessage = errorMessage;
        }
    }
    public class ValidationErrors : Exception
    {
        public List<IBaseError> Errors { get; set; }
        public ValidationErrors()
        {
            Errors = new List<IBaseError>();
        }
        public ValidationErrors(IBaseError error) : this()
        {
            Errors.Add(error);
        }
    }
    public interface IBaseError
    {
        string PropertyName { get; }
        string PropertyExceptionMessage { get; }
    }
}