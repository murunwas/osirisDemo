using System;
using System.Collections.Generic;
using System.Text;

namespace OSIRIS.Common.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();


    }

    public class ErrorModel
    {
        public string FieldName { get; set; }

        public string Message { get; set; }
    }
}
