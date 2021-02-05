using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebAPI.Util
{
    public class ErrorModel
    {
        public ErrorModel(ModelStateDictionary.ValueEnumerable errors)
        {
            var message = errors.Select(x => x.Errors[0].ErrorMessage).ToArray();
            Messages = message;
        }
        public ErrorModel()
        {

        }
        public string[] Messages { get; set; }
    }
}
