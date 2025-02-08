using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.model
{
    public class Application
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string Resume { get; set; }
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
    }
}
