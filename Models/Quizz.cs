using System.ComponentModel.DataAnnotations.Schema;

namespace App_Quizz.Models
{
    public class Quizz
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        //Many Quiz to One Category
        [ForeignKey("CategoryId")]
        public QuizzCategory? Category { get; set; }
        public int CategoryId { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
