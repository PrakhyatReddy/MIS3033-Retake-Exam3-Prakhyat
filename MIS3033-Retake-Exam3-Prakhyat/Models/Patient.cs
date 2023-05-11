using System.ComponentModel.DataAnnotations;

namespace MIS3033_Retake_Exam3_Prakhyat.Models
{
    public class Patient
    {
        [Key]
        public string ID { get; set; } 
        public string name { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public double BMI { get; set; }
        public string BMILevel { get; set; }

        public Patient()
        {

        }

        public Patient(string ID, string name, int age, double weight, double BMI)
        {
            this.ID = ID;
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.BMI = BMI;
        }

        public string GetBMILevel(double BMI)
        {
            if(BMI >= 0 && BMI <18 ) 
            {
                BMILevel = "Underweight";
            }
            else if (BMI >= 18 && BMI < 25)
            {
                BMILevel = "Healthy weight";
            }
            else if (BMI >= 25 && BMI < 30)
            {
                BMILevel = "Overweight";
            }
            else
            {
                BMILevel = "Obesity";
            }

            return BMILevel;
        }
    }
}
