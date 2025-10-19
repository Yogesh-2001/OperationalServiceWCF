using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OperationalService.Models
{
    [DataContract]
    public class ServiceResponse<T>
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public T Data { get; set; }
    }
}