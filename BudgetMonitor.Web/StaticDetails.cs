namespace BudgetMonitor.Web
{
    public static class StaticDetails
    {
        public const string APIBaseURL = @"https://localhost:44325/";
        public const string UserAPIPath =APIBaseURL+  @"api/v1/Account/";
        public const string TransactionAPIPath = APIBaseURL + @"api/v1/Transaction/";

    }
}
