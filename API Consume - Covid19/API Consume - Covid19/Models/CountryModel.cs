using System;
using System.ComponentModel.DataAnnotations;

namespace API_Consume___Covid19.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
