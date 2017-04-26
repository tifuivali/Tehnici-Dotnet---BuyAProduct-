namespace Store.ConsoleServiceClient
{
    public class CezaraClass
    {
        public string FirstName { get; set; }

        public string UpperFirstName()
        {
            return FirstName.ToUpper();
        }
    }
}
