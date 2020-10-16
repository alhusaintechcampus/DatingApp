using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
         public int Id { get; set; }
        public string Username { get; set; }
        public string PhotoUrl { get; set; }
        // auto mapper will get value from AppUser GetAge() and assign to Age here
        // why it will see Get and assign value to a varibale named Age as appears on GetAge()
        // for optimal reason, now we do it in mapper configuration.
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } 
        public DateTime LastActive { get; set; } 
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }

    }
}