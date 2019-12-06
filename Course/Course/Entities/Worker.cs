using Course.Entities.Enums;
using System.Collections.Generic;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; } /*Teremos uma COMPOSIÇÃO que é incluir 
        o nome do departamento aqui, ou seja é uma associação entre duas classes diferentes*/
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();/*Alem do Departamento, o trabalhador também 
        tem uma associação com a Classe Contrato, acesso a *vários contratos, entao o tipo será List. O vou INSTANCIAR para 
        garantir que não ficará Nula */

        public Worker() //Construtor vazio
        {

        }
        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament)//List não adc em Construtores
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(HourContract contract)//Sempre que quiser um contrato para o trab. chamo essa operação:AddContrato
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        //Como calcular a soma de contratos de um determinado ano e mes ?
        //Vou ter que percorrer a lista para acumular a soma dos contratos que eu estou pedindo que no caso é esta dentro do ano/mes.
        public double Income(int year, int month) // Income sig ganho
        {
            double sum = BaseSalary;  // sum não recebe 0 porque o trab tem salario fixo
            foreach (HourContract contract in Contracts)
            {
                if ( contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }

            }
            return sum;
            
        }

        
    }
}
