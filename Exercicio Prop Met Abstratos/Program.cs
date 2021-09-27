using System;
using System.Globalization;
using System.Collections.Generic;
using Exercicio_Prop_Met_Abstratos.Entities;

namespace Exercicio_Prop_Met_Abstratos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Tax payer #" + i + " data:");
                Console.Write("Individual or company (i/c)? ");
                char resp = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anual_income = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (resp == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double health_exp = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anual_income, health_exp));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int employees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anual_income, employees));
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            foreach(TaxPayer payer in list)
            {
                Console.WriteLine(payer.Name + ": $" + payer.Tax().ToString("F2", CultureInfo.InvariantCulture));
            }
            double sum = 0.0;
            
            foreach(TaxPayer payer in list)
            {
                sum += payer.Tax();
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $" + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
