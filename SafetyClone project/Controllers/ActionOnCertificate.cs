using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SafetyClone_project.Models;

namespace SafetyClone_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionOnCertificate : ControllerBase
    {
        private readonly DatabaseMethod dbHelper;

        public ActionOnCertificate(IConfiguration configuration)
        {
            dbHelper = new DatabaseMethod(configuration);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int certiId,int UserId,string message)
        {
            try
            {
                var query = "sp_HandleCertificateApproval";
                var parameter = new[] { new SqlParameter("@certificate_id", certiId), new SqlParameter("@user_id", UserId), new SqlParameter("@status", message) };

                var table = await dbHelper.ExecuteStoredProcedureQueryAsync(query, parameter);

                return Ok(new { Status = "Success", Message = "certificate approved" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Status = "Error", Message = "Internal Server Error" });
            }
        }

    }
}
