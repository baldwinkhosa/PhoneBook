namespace PhoneBook.Domain.Model
{
    public  class ContactDetail
    {
        public int ContactDetailId { get; set; }
        public int ContactId { get; set; }
        public string ContactDetailType { get; set; }
        public string ContactDetailValue { get; set; }

        public Contact Contact;
    }
}