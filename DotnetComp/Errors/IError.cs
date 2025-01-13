namespace DotnetComp.Errors
{
    public interface IError
    {
        public string Code { get; }
        public string Description { get; }
    }
}