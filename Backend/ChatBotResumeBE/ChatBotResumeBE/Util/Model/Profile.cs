using System.ComponentModel.DataAnnotations;

namespace ChatBotResumeBE.Util.Model
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Summary { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Certifications { get; set; }

        // Navigation properties
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Education> Educations { get; set; } = new List<Education>();
        
    }

    public class Experience
    {
        [Key]
        public int ExpId { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        // Foreign key
        public int ProfileId { get; set; }
        // Navigation property
        public Profile Profile { get; set; } = null!;
    }

    public class Education
    {
        [Key]
        public int EduId { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        // Foreign key
        public int ProfileId { get; set; }
        // Navigation property
        public Profile Profile { get; set; } = null!;
    }
}
