namespace App_Quizz.Models
{
    public class User
    {
        public int? Id { get; set; }  //int? ce champs peut accepter des valeurs null        

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
