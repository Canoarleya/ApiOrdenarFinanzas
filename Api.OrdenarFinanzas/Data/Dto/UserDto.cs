﻿using Api.OrdenarFinanzas.Data.Models;

namespace Api.OrdenarFinanzas.Data.Dto
{
    public class UserDto
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public virtual UserRole Role { get; set; }

        public string Token { get; set; }
    }

}
