using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileSystemGlobbing;
using SafetyClone_project.Controllers;
using SafetyClone_project.Models;
using System.Data;

namespace SafetyClone_project.Pages
{
    public class LoginFormModel : PageModel
    {

        public List<SelectListItem> organisation = new List<SelectListItem>();
        private readonly IConfiguration configuration1;

        private readonly DatabaseMethod dbHelper;

        public LoginFormModel(IConfiguration configuration)
        {
            dbHelper = new DatabaseMethod(configuration);
        }


     
        public async Task OnGet()
        {
            await dropdown();
        }
        public async Task<List<SelectListItem>> dropdown()
        {
            try {

                var query = "select Id,Name from tRoletype";
                var DataTable= await dbHelper.ExecuteQueryAsync(query);

               ;
                foreach (DataRow row in DataTable.Rows)
                {
                     organisation.Add (new SelectListItem
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString()
                    });
                  
                }

            }
            catch (Exception ex) { }
            return organisation;
        }
    }
}
