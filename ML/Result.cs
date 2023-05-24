namespace ML
{
    public class Result
    {
        public bool Correct { get; set; }
        public string ErrorMessage { get; set; } = default!;
        public Exception Ex { get; set; } = default!;
        public object Object { get; set; } = default!;
        public List<object> Objects { get; set; } = default!;
    }
}