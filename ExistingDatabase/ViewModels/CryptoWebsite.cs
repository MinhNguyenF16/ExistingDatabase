using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ExistingDatabase.Models;

namespace ExistingDatabase.ViewModels
{
    public class CryptoWebsite
    {
        public int RankCount { get; set; }
        public int Rank { get; set; }

        public int Id { get; set; }
        public string WebsiteName { get; set; }
        public string Description { get; set; }
       // public Nullable<int> Rank { get; set; }
        public string Country { get; set; }

        public string CryptoName { get; set; }
        public string Type { get; set; }

        public Website WebsiteVM { get; set; }
        //public Crypto CryptoVM { get; set; }
    }
}