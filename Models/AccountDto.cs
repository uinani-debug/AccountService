﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountLibrary.API.Models
{
    public class AccountDto
    {
        public string AccountIdentifier { get; set; }
        public string SortCode { get; set; }
        public string AccountType { get; set; }
        public string AccountSubType { get; set; }
        public double InterestRate { get; set; }
        public AvailableBalance AvailableBalance { get; set; }
        public string AccountStatus { get; set; }

    }

}
