using System;

namespace NOWA.Models
{

    public class Nowa
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string EmailHeader { get; set; }

        public string EmailBody { get; set; }

        public bool IsRunning { get; set; }

        public DateTime Schedule { get; set; }
    }
}