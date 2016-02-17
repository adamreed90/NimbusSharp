namespace NimbusSharp.Data
{
    [Function("authcap")]
    public class AuthorizeCapture : NimbusFunction
    {
        [Property("amt", true)]
        public decimal Amount { get; set; }
        [Property("ord", false)]
        public string OrderId { get; set; }
        [Property("cUnum", true)]
        public string EmployeeId { get; set; }
        [Property("cd", false)]
        public string Description { get; set; }
        [Property("ct", false)]
        public string EmployeeTeam { get; set; }
        [Property("in", false)]
        public string InvoiceId { get; set; }
        [Property("en", false)]
        public string EmployeeName { get; set; }
        [Property("ip", false)]
        public string IpAddress { get; set; }
    }
}
