namespace Interapp.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

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
