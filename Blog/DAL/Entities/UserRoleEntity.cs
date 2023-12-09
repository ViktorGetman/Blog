namespace Blog.DAL.Entities
{
    public class UserRoleEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }  
        public long RoleId { get; set; }
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
