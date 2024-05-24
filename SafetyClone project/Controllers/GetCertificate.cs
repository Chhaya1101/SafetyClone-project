using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafetyClone_project.Models;
using System.Data;

namespace SafetyClone_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCertificate : ControllerBase
    {
        private readonly DatabaseMethod dbHelper;

        public GetCertificate(IConfiguration configuration)
        {
            dbHelper = new DatabaseMethod(configuration);
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = "SELECT Id,StudentName,Description,IssueDate,ReceivedApproval FROM tCertificate";

                var DataTable = await dbHelper.ExecuteQueryAsync(query);

                if (DataTable.Rows.Count > 0)
                {
                    // Convert DataTable to list of City objects
                    var roletypes = new List<GetCertificates>();
                    foreach (DataRow row in DataTable.Rows)
                    {
                        var roletype = new GetCertificates
                        {
                            CertificateID = Convert.ToInt32(row["Id"]),
                            StudentName = row["StudentName"].ToString(),
                            Description = row["Description"].ToString(),
                            CreatedDate = Convert.ToDateTime(row["IssueDate"]),
                            Status = row["ReceivedApproval"].ToString()

                        };
                        roletypes.Add(roletype);
                    }

                    return Ok(new { Status = "Success", Message = "certificate retrieved successfully", Data = roletypes });
                }
                else
                {
                    return NotFound(new { Status = "Error", Message = "certificate not found" });
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
