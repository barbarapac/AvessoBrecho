using System.Runtime.Serialization;

namespace EcommerceAvessoBrecho.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; private set; }

    }
}
