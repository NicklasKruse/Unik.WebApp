using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Addresses;

namespace WebAppFront.Pages.Addresses
{
    /// <summary>
    /// Page til at oprette en foreningsmedlem med adresse
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly IAddressService _AddressService;

        public IndexModel(IAddressService addressService)
        {
            _AddressService = addressService;
        }

        [BindProperty]
        public ForeningsMedlemViewModel ForeningsMedlem { get; set; } = new ForeningsMedlemViewModel();

        [BindProperty]
        public AddressViewModel Address { get; set; } = new AddressViewModel();

        public async Task<IActionResult> OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //    foreach (var error in errors)
            //    {
            //        Console.WriteLine(error.ErrorMessage);
            //    }
            //    return Page();
            //}
            var medlem = new ForeningsMedlemCreateRequestDto
            {
                FirstName = ForeningsMedlem.FirstName,
                LastName = ForeningsMedlem.LastName,
                Email = ForeningsMedlem.Email,
                CreatedBy = User.Identity.Name,
                DateOfCreation = DateTime.Now,
                Address = new AddressCreateRequestDto
                {
                    Street = Address.Street,
                    City = Address.City,
                    ZipCode = Address.ZipCode,
                    Country = Address.Country
                }
            };

            await _AddressService.CreateMemberWithAddress(medlem);
            return RedirectToPage("Index");
        }

        public void OnGet()
        {
        }
    }
}

