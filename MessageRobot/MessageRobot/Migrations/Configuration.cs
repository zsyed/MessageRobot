namespace MessageRobot.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<MessageRobot.Models.MessageRobotDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MessageRobot.Models.MessageRobotDb context)
        {

            WebSecurity.InitializeDatabaseConnection(
         "DefaultConnection",
         "UserProfile",
         "UserId",
         "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!WebSecurity.UserExists("zsyed"))
                WebSecurity.CreateUserAndAccount(
                    "zsyed",
                    "password",
                    new { Mobile = "+17144691491", IsSmsVerified =false });

            if (!Roles.GetRolesForUser("zsyed").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "zsyed" }, new[] { "Administrator" });


        }
    }
}
