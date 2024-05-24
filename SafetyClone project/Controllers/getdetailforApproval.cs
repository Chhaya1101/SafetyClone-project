using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SafetyClone_project.Models;
using System.Data;

namespace SafetyClone_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class getdetailforApproval : ControllerBase
    {
        private readonly DatabaseMethod dbHelper;

        public getdetailforApproval(IConfiguration configuration)
        {
            dbHelper = new DatabaseMethod(configuration);
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var query = "select cert.Id,cert.StudentName,cert.Description,ActionDate from tCertificateLog logs join tCertificate cert on cert.Id=logs.CertificateId join tUser us on us.Id=logs.UserId where Status='Pending' and userId=@userId";
                var parameter = new[] { new SqlParameter("@userId", userId) };
                var DataTable = await dbHelper.ExecuteQueryAsync(query, parameter);

                if (DataTable.Rows.Count > 0)
                {
                    // Convert DataTable to list of City objects
                    var roletypes = new List<GetCreatedCertificates>();
                    foreach (DataRow row in DataTable.Rows)
                    {
                        var roletype = new GetCreatedCertificates
                        {
                            CertificateID = Convert.ToInt32(row["Id"]),
                            StudentName = row["StudentName"].ToString(),
                            Description = row["Description"].ToString(),
                            Date = Convert.ToDateTime(row["ActionDate"]),
                          

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
