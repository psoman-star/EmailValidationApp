namespace EmailValidationApp
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string IsValid { get; set; }
        public string Result { get; set; }
    }
}
