using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using MySchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Data
{
    public class DbOperations
    {
        private readonly SqlConnection connection;

        public DbOperations(SqlConnection connection, AppDbContext context)
        {
            
            this.connection = connection;
            Context = context;

            
        }

        public AppDbContext Context { get; }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            string sql = "INSERT INTO CustomUsers " +
              "VALUES (@id, @Email, @EmailConfirmed, @PasswordHash, @UserName)";


            int rows = await connection.ExecuteAsync(sql, new { user.Id, user.Email, user.EmailConfirmed, user.PasswordHash, user.UserName });

           // await Context.CustomUsers.AddAsync(new CustomUser { Id = user.Id, Email = user.Email, EmailConfirmed = user.EmailConfirmed, UserName = user.UserName, PasswordHash = user.PasswordHash });


           //var r =  await Context.SaveChangesAsync();


           
            


            if (rows > 0)
            {
                return IdentityResult.Success;
            }


            //CustomUser custom = new CustomUser
            //{
            //    Id = user.Id,
            //    Email = user.Email,
            //    EmailConfirmed = user.EmailConfirmed,
            //    PasswordHash = user.PasswordHash,
            //    UserName = user.Email
            //};

            ////var result = await connection.InsertAsync();

            ////if (result > 0)
            ////{
            ////    return IdentityResult.Success;
            ////}

            //var result = connection.Insert(custom);
            //if(result > 0)
            //{
            //    return IdentityResult.Success;
            //}

            return IdentityResult.Failed(new IdentityError { Description = $"could not insert {user.Email}" });
        }



        public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            string sql = "DELETE FROM CustomUsers WHERE Id = @Id";
            int rows = await connection.ExecuteAsync(sql, new { user.Id });

            if (rows > 0)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = $"Could not delete user {user.Email}." });
        }

        public async Task<ApplicationUser> FindByIdAsync(Guid userId)
        {


            string sql = "SELECT * " +
                        "FROM CustomUsers " +
                        "WHERE Id = @Id;";

            
            return await connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new
            {
                Id = userId
            });
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            string sql = "SELECT * " +
                        "FROM CustomUsers " +
                        "WHERE UserName = @UserName;";

            return await connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new
            {
                UserName = userName
            });
        }


        public async Task<IdentityResult> IsUserAdmittedAsync(string email)
        {
            string sql = "Select Email from AdmissionLists where email  = @email";
            var rows  = await connection.ExecuteAsync(sql, new { Email = email });
            if(rows > 0 )
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = $"Sorry, you have not been given admission" });
        }


    }

}
