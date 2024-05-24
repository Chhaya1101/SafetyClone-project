using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SafetyClone_project.Models;

namespace SafetyClone_project.Pages.College
{
    public class CreateCertificateModel : PageModel
    {

        //private readonly IConfiguration configuration1;

        //private readonly dataAcessLayer _dataAccessLayer;


        //public CreateCertificateModel(IConfiguration configuration)
        //{
        //    configuration1 = configuration;
         
        //    _dataAccessLayer = new dataAcessLayer(configuration1);


        //}
        //[BindProperty]
        //public Certificate cert { get; set; }
        //public async Task<IActionResult> OnGet()
        //{
        //    cert = new Certificate();
        //    if (cert == null)
        //    {
        //        // Handle null Student object
        //        return NotFound();
        //    }
        //    return Page();
        //}

        //public async Task<ActionResult> OnPostxyzAsync(Models.Certificate cert)
        //{
        //    if (cert == null && !ModelState.IsValid)
        //    {
        //        if (cert.StudentName == null && cert.Description ==null)
        //        {
        //            Console.Write("found Error");
        //        }
        //        return Page();
        //    }

        //    _dataAccessLayer.AddCertificate(cert);
        //    return RedirectToPage("./College/ManageCertificate");

        //}
       
    }
}
