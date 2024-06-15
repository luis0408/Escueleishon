using System.Reflection.Metadata;

namespace Escueleishon.Server.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Exception =new List<string>();
            Entity=  new List<object>();
        }  
        public string Code {  get; set; }   
        public string Message { get; set; }
        public List<object> Entity { get; set; }
        public List <String> Exception { get; set; }
    }
}
