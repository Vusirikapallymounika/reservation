using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    
        public partial class Student
        {
            public Nullable<int> stu_id { get; set; }
            public string stu_name { get; set; }
            public Nullable<decimal> stu_phoneno { get; set; }
            public string stu_email_id { get; set; }
            public Nullable<int> stu_ranking { get; set; }
            public string stu_branch { get; set; }
            public Nullable<int> empid { get; set; }
        }
    
}