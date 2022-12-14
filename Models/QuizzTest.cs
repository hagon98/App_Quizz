using System.ComponentModel.DataAnnotations.Schema;

namespace App_Quizz.Models
{
    public class QuizzTest
    {
        public int? Id { get; set; }

        public DateTime CreationDate { get; set; }

        //ManyToOne
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? UserId { get; set; }

        //ManyToOne
        [ForeignKey("QuizId")]
        public Quizz Quiz { get; set; }
        public int? QuizId { get; set; }

        public int Score { get; set; }  //Le score du joueur
    }
}
