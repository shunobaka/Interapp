namespace Interapp.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class InterappDbContext : IdentityDbContext<User>
    {
        public InterappDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static InterappDbContext Create()
        {
            return new InterappDbContext();
        }
    }
}
