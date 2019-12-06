using System;


namespace Course.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; } //Data do Contrato
        public double ValuePerHour { get; set; } //Valor por hora

        public int Hours { get; set; } //Duracao/hora do Contrato


        public HourContract() //Construtor vazio
        {

        }

        public HourContract(DateTime date, double valuePerHour, int hours) //Construtor Com todos os atributos
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }

    }
}
