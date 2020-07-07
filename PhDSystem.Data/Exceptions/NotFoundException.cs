using System;

namespace PhDSystem.Data.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object id) : base($"Entity - {entityName} with id - {id} could not be found.")
        {

        }
    }
}
