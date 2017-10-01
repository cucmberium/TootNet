
namespace TootNet.Internal
{
    public abstract class ApiBase
    {
        protected internal Tokens Tokens { get; set; }
        
        internal ApiBase(Tokens tokens)
        {
            Tokens = tokens;
        }
    }
}
