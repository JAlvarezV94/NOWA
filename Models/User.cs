using System.Collections.Generic;

namespace NOWA.Models
{

    public class User
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Nowa> NowaList { get; set; }
    }
}