using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase54
{
    class Schoolar
    {
        public string name { get; set; }
        public string surname { get; set; }
        [Key]
        public string iin { get;set; }
        public string grade { get; set; }
    }
}
