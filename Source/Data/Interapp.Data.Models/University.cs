namespace Interapp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class University
    {
        private ICollection<User> students { get; set; }

        public University()
        {
            this.students = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Range(0, 100000)]
        public int TuitionFee { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Required]
        public string DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public virtual User Director { get; set; }

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
