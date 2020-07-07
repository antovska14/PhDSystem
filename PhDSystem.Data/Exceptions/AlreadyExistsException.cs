using System;

namespace PhDSystem.Data.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string entityName, string duplicateProperty, object propertyValue) : base($"Entity - {entityName} with property - {duplicateProperty} and value - {propertyValue} already exists.")
        {

        }
    }
}
