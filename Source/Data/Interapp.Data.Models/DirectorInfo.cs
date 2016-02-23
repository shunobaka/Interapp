namespace Interapp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class DirectorInfo : BaseModel
    {
        private ICollection<University> universities;

        public DirectorInfo()
        {
            this.universities = new HashSet<University>();
        }

        [Key]
        [Required]
        public string DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public virtual User Director { get; set; }

        [InverseProperty("Director")]
        public virtual ICollection<University> Universities
        {
            get
            {
                return this.universities;
            }

            set
            {
                this.universities = value;
            }
        }
    }
}
