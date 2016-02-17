namespace NimbusSharp.Data
{
    [Function("verify")]
    public class Verify : NimbusFunction
    {
        [Property("cUnum", true)]
        public string EmployeeId { get; set; }

    }
}
