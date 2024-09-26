﻿using Shop.UserRegistrationService.Enum;

namespace Shop.UserRegistrationService.DTO
{
    [Serializable]
    public class UserModelDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
