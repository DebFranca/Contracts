using Course.Entities;
using Course.Entities.Enums;
using System.Globalization;
using System;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();    //instanciar "separado" pois sua origem é de outra classe.
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //entrada de dado ORIGEM LISTA
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //instanciando.. usando o construtar após ter recebido os dados acima.
            Departament dept = new Departament(deptName);
            Worker worker = new Worker(name, level, salary, dept); //repare como é feita a associação entre classes/COMPOSIÇÂO DE OBJ.

            
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for ( int i= 1; i <= n; i++)
            {

                Console.WriteLine($"Enter #{i} contract data: ");//interpolação com {i} para contagem
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHours = double.Parse(Console.ReadLine());
                Console.Write(" Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHours, hours); //Instanciar dentro do for,o retorna gera dentro dele
                worker.AddContract(contract); //add para gerar o objeto contrato. 

            }
            Console.WriteLine( );
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");//Mes e Ano em String RECORTE
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Departament.Name);
            Console.WriteLine("Income for " + monthAndYear + " : " + worker.Income(year, month).ToString("F2",CultureInfo.InvariantCulture));


            Console.ReadKey();



        }
    }
}
