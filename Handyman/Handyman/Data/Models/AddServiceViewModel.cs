using Microsoft.AspNetCore.Mvc.Rendering;

namespace Handyman.ViewModels
{
    public class AddServiceViewModel
    {
        public int ServiceTypeId { get; set; } // Pre-selected Service Type
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        // Dropdown list for Service Types
        public List<SelectListItem> ServiceTypes { get; set; }
    }
}
