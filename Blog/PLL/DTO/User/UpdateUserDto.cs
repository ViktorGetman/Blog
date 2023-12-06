namespace Blog.PLL.DTO.User
{
    public class UpdateUserDto
    {
        public long Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }

    }
}
