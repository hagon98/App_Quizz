using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Quizz.Models
{
    public class QuizzReponses
    {
        public int? Id { get; set; }
        public string RespText { get; set; }
        public bool Correct { get; set; }

        //ManyToOne 
        
        public QuizzQuestions? Question { get; set; }
        [Required]
        public int QuizzQuestionsId { get; set; }

        public override string ToString()
        {
            return RespText;
        }
    }
}
