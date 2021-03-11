using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SurveyApi.Models
{
    public class SurveyItem
    {
        public long Id { get; set; }
        public string Review { get; set; }

        [Range(0, 10,
        ErrorMessage = "Value for rating must be 0 - 10")]
        public int ProductRating { get; set; }

        [Range(0, 10,
        ErrorMessage = "Value for rating must be 0 - 10")]
        public int CompanyRating { get; set; }
        public bool ResearchedBefore { get; set; }

        public bool ArrivedOnTime { get; set; }
    }
}
