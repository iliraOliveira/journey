namespace Journey.Communication.Responses
{
    public class ResponseErrosJSon
    {
        public IList<string> Errors { get; set; } = [];

        public ResponseErrosJSon(IList<string> erros)
        {
            Errors = erros;
        }
    }
}
