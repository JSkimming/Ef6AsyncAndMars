using System.Data.Entity;
using System.Threading.Tasks;
using Xunit;

namespace Ef6AsyncAndMars
{
    /// <summary>
    /// Defines the properties of a <see cref="User"/> within the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the primary key of the <see cref="User"/>.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the <see cref="User"/>.
        /// </summary>
        public virtual string UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique log-on email address of the <see cref="User"/>.
        /// </summary>
        public virtual string LogonEmailAddress { get; set; }
    }

    /// <summary>
    /// The test context.
    /// </summary>
    public class TestContext : DbContext
    {
        /// <summary>
        /// Gets or sets the entity set for <see cref="User"/> objects.
        /// </summary>
        public DbSet<User> Users { get; set; }

        public static async Task<bool> UserExistsAsync(string userId, string logonEmailAddress)
        {
            var context = new TestContext();

            var results = new Task<User>[2];
            results[0] = context.Users.SingleOrDefaultAsync(u => u.UserId == userId);
            results[1] = context.Users.SingleOrDefaultAsync(u => u.LogonEmailAddress == logonEmailAddress);
            await Task.WhenAll(results);

            return results[0].Result != null && results[0].Result != null;
        }

    }

    public class XunitTestContext
    {
        [Fact]
        public void TestUserExistsSync()
        {
            TestContext.UserExistsAsync("jimskim", "jim@skim.com").Wait();
        }

        [Fact]
        public Task TestUserExistsAsync()
        {
            return TestContext.UserExistsAsync("jimskim", "jim@skim.com");
        }
    }
}
