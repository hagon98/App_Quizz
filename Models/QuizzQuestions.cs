using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Quizz.Models
{
    public class QuizzQuestions
    {
        public int Id { get; set; }

        public string QstText { get; set; }

        public bool MultipleChoice { get; set; }

        public int NumOrder { get; set; }  //Ordre : Numero de la question


        
        
        public Quizz? Quiz { get; set; }
        // manytoOne
        [Required]
        public int QuizzId { get; set; }
    }
}
