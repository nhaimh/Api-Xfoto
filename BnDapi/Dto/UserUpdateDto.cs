namespace BnDapi.Dto
{
    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean EmailConfirmed { get; set; }
        public Boolean PhoneNumberConfirmed { get; set; }
        public List<string> Roles { get; set; }
    }
}
