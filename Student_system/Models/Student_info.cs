using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_system.Models
{
    public class Student_info
    {
        
        [DisplayName("รหัสนักเรียน")]
        public int ID { get; set; }
 
        [DisplayName("ชื่อจริง")]
        [Required(ErrorMessage = "ต้องระบุชื่อจริง")]
        public String Fname { get; set; }
        [DisplayName("นามสกุล")]
        [Required(ErrorMessage = "ต้องระบุนามสกุล")]
        public string Lname { get; set; }

        [DisplayName("อีเมลล์")]
        [Required(ErrorMessage = "ต้องระบุอีเมลล์")]
        public string Email { get; set; }

        [DisplayName("เบอร์โทรศัพท์")]
        [Required(ErrorMessage = "ต้องระบุเบอร์โทรศัพท์")]
        public string Tel { get; set; }

    
    
    
    }
}
