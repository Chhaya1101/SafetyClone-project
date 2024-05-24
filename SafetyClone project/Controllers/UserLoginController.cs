using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SafetyClone_project.Models;
using System.Data;

namespace SafetyClone_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly DatabaseMethod dbHelper;

        public UserLoginController(IConfiguration configuration)
        {
            dbHelper = new DatabaseMethod(configuration);
        }
        
        [HttpGet]
        [Route("GetValue")]
        public async Task<IActionResult> GetValue(string email,string password,int org)
        {
            try
            {
                var query = "select us.Id,email,password,RoleName from tUser us join tRole r on r.RoleId=us.RoleId  join tRoletype rt  on rt.Id= r.TypeId where rt.Id=@org and us.Email=@email and us.Password=@password";
                var parameters = new[] { new SqlParameter("@org", org),new SqlParameter("@email", email), new SqlParameter("@password", password) };

                var table = await dbHelper.ExecuteQueryAsync(query,  parameters );
                if (table.Rows.Count > 0)
                {

                    var user1 = new List<UserLogin>();
                    foreach (DataRow row in table.Rows)
                    {
                        var userlog = new UserLogin
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Email = row["Email"].ToString(),
                            Password = row["Password"].ToString(),
                            RoleName = row["RoleName"].ToString(),

                        };
                        user1.Add(userlog);
                    }

                    return Ok(new { Status = "Success", Message = " user  retrieved successfully", Data = user1 });
                }
                else
                {
                    return NotFound(new { Status = "Error", Message = "user not found" });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Status = "Error", Message = "Internal Server Error" });
            }
        }
        

    }
}
