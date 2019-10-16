using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    /// <summary>
    ///   Entity class to hold Contact properies
    /// </summary>
    [Serializable]
    public class Contact
    {     
        public int ContactId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FisrtName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LattName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        public long PhoneNumber { get; set; }
        
        public string Status { get; set; }
    }
}
