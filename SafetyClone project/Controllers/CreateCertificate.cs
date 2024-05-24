using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using SafetyClone_project.Models;
using System.Data;

namespace SafetyClone_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateCertificate : ControllerBase
    {
        private readonly DatabaseMethod dbHelper;

        public CreateCertificate(IConfiguration configuration)
        {
            dbHelper = new DatabaseMethod(configuration);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Certificate cert)
        {
            try
            {
               
                            
                var query = "sp_CreateCertificateStage1";
                var parameter = new[] { new SqlParameter("@student_name", cert.StudentName),new SqlParameter("@description",cert.Description), new SqlParameter("@user_id", cert.UserID) };

                var table = await dbHelper.ExecuteStoredProcedureQueryAsync(query, parameter);
                
                return Ok(new { Status = "Success", Message = "Certificate Created successfully" });
               

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Status = "Error", Message = "Internal Server Error" });
            }
        }
        
    }
}
