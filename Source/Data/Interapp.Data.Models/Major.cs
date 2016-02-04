namespace Interapp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;

    public class Major
    {
        private ICollection<Application> applications;
        private ICollection<User> students;

        public Major()
        {
            this.applications = new HashSet<Application>();
            this.students = new HashSet<User>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ModelConstants.MajorNameMinLength)]
        [MaxLength(ModelConstants.MajorNameMaxLength)]
        public string Name { get; set; }

        [InverseProperty("Major")]
        public virtual ICollection<Application> Applications
        {
            get
            {
                return this.applications;
            }

            set
            {
                this.applications = value;
            }
        }

        [InverseProperty("Major")]
        public virtual ICollection<User> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }
    }
}
