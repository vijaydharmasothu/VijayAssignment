using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.ViewModels
{
    [Serializable]
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Contact> Contact { get; set; }
    }
}
