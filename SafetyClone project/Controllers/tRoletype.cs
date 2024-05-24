using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafetyClone_project.Models;
using System.Data;

namespace SafetyClone_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tRoletype : ControllerBase
    {
        private readonly DatabaseMethod dbHelper;

        public tRoletype(IConfiguration configuration)
        {
            dbHelper = new DatabaseMethod(configuration);
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = "SELECT * FROM tRoletype";

                var DataTable = await dbHelper.ExecuteQueryAsync(query);

                if (DataTable.Rows.Count > 0)
                {
                    // Convert DataTable to list of City objects
                    var roletypes = new List<Roletype>();
                    foreach (DataRow row in DataTable.Rows)
                    {
                        var roletype = new Roletype
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString()
                        };
                        roletypes.Add(roletype);
                    }

                    return Ok(new { Status = "Success", Message = "roletype retrieved successfully", Data = roletypes });
                }
                else
                {
                    return NotFound(new { Status = "Error", Message = "roletype not found" });
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
