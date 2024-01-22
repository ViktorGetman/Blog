namespace Blog.DAL.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Photo { get; set; } 
        public ICollection<UserRoleEntity> Roles { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<PostEntity> Posts { get; set; }


    }
}
