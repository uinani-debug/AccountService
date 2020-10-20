using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountLibrary.API.Entities
{
    public class Account
    {
        public string account_identifier { get; set; }
        public string sort_code { get; set; }

        public double current_balance { get; set; }
        public double interest_rate { get; set; }
        public double available_balance { get; set; }
        public double ladger_balance { get; set; }

        public string account_type { get; set; }

        [Required]
        public string account_sub_type { get; set; }
               
        public string account_status { get; set; }

        public string account_holder_name { get; set; }

        public string open_date { get; set; }

        public string product_name { get; set; }
        public string nick_name { get; set; }

    }
}
