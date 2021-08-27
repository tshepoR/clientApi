using System;
namespace client.Dtos
{
    public class ReponseDto<T>
    {
        public T payload { get; set; }
        public bool Success { get; set; }
    }
}
