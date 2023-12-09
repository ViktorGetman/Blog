﻿namespace Blog.DAL.Entities
{
    public class RoleEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserRoleEntity> Users { get; set; }
    }
}
