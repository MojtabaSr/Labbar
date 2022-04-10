using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entity_Framework.Models;
using System.Linq;

namespace Entity_Framework
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> Ledighetstyp=new List<string>()
            {
                "Semester",
                "Sjukdom",
                "Cancerbehandling",
                "Pappaledighet"
            };


            
            do
            {
                Console.Clear();
                Console.WriteLine("Enter 1 for administrator options and 2 for employee. Press Q to quit: ");
                string employeeType = Console.ReadLine();
                if (employeeType == "1")
                {
                    using (var db = new EntityFrameworkLab1())
                    {
                        Console.Clear();
                        do
                        {
                            
                            Console.WriteLine("Enter 1 for searching registration for an employee or 2 for getting monthly data" +
                                ". Press E to go back to main menu: ");
                            string optionMenu = Console.ReadLine();
                            if (optionMenu == "1")
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a name: ");
                                string employeeName = Console.ReadLine();
                                string[] nameSplit = employeeName.Split(" ");

                                var allPersonal = db.Personal.Include(p => p.Ledighet).ToList();

                                bool personExist = allPersonal.Any(personal => personal.FirstName == nameSplit[0]
                                && personal.LastName == nameSplit[1]);

                                if (personExist == true)
                                {
                                    var newContext = new EntityFrameworkLab1();
                                    var ledighetsTabell = newContext.Ledighet.ToList();
                                    var personalId = allPersonal.Where(p => p.FirstName == nameSplit[0]
                                    && p.LastName == nameSplit[1]).SingleOrDefault().PersonalId;
                                    bool personLedighetRegistered = ledighetsTabell.Any(p => p.PersonalId == personalId);

                                    if (personLedighetRegistered == true)
                                    {
                                        Console.WriteLine($"{employeeName} has the following previous registrations: ");



                                        var employeeRegistration = ledighetsTabell.Where(p => p.PersonalId == personalId).ToList();


                                        employeeRegistration.ForEach(row => Console.WriteLine($"{row.StartDatum} {row.SlutDatum} " +
                                            $"{row.AppliedAtTime} {row.LedighetsTyp} \n"));


                                    }
                                    else { Console.WriteLine($"{employeeName} hasnt registered anything yet!"); }



                                }
                                else { Console.WriteLine("This person does not exist in the database. Please write the name again!"); break; }

                            }
                            else if (optionMenu == "2")
                            {
                                Console.Clear();
                                Console.WriteLine("Please specify month: ");

                                Dictionary<string, string> months = new Dictionary<string, string>()
                                {
                                    { "january", "01"},
                                    { "february", "02"},
                                    { "march", "03"},
                                    { "april", "04"},
                                    { "may", "05"},
                                    { "june", "06"},
                                    { "july", "07"},
                                    { "august", "08"},
                                    { "september", "09"},
                                    { "october", "10"},
                                    { "november", "11"},
                                    { "december", "12"},
                                };

                                string monthReq = Console.ReadLine();

                                foreach (var month in months)
                                {
                                    if (monthReq.ToLower().Contains(month.Key))
                                    {
                                        var newContext = new EntityFrameworkLab1();
                                        var ledighetsTabell = newContext.Ledighet.ToList();

                                        int thisMonth = Int32.Parse(month.Value);

                                        var ledighetGroupedByMonth = ledighetsTabell.Where(date => date.StartDatum.Month == thisMonth)
                                            .ToList();

                                        var personId = ledighetGroupedByMonth.Select(x => x.PersonalId).FirstOrDefault();
                                        var allPersonal = db.Personal.ToList();
                                        var employeeFirstName = allPersonal.Where(x => x.PersonalId == personId).FirstOrDefault().FirstName;
                                        var employeeLastName = allPersonal.Where(x => x.PersonalId == personId).FirstOrDefault().LastName;

                                        var employeeName = employeeFirstName + " " + employeeLastName;

                                        ledighetGroupedByMonth.ForEach(row => Console.WriteLine($"Total days: " +
                                            $"{(row.SlutDatum.Date - row.StartDatum.Date).Days} \n" +
                                            $"{employeeName} {row.StartDatum.Date} " +
                                            $"{row.SlutDatum.Date} {row.AppliedAtTime} \n"));

                                    }

                                }



                            }
                            else if (optionMenu.ToLower() == "e") { break; }

                        } while (true);
                    }
                    
                    /*
                    */

                }
                else if (employeeType.ToLower() == "q") { break; }

                else if (employeeType=="2"){ RegisterData(Ledighetstyp); }

                //AddData(Ledighetstyp);
                //RegisterData(Ledighetstyp);
            } while (true);



        }

        public static void RegisterData(List<string> Ledighetstyp)
        {
            using (var db = new EntityFrameworkLab1())
            {

                var allPersonal = db.Personal.Include(p => p.Ledighet).ToList();

                Console.WriteLine("Please write your first name");
                string firstName = Console.ReadLine();


                bool personExist = allPersonal.Any(personal => personal.FirstName == firstName);
                if (personExist == true)
                {
                    Console.WriteLine($"Hi {firstName}. Please write the start and stop date for registration");
                    Console.WriteLine("Start date: ");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Stop date");
                    DateTime stopDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Choose one of the following reasons for your application:\n");

                    Ledighetstyp.ForEach(option => Console.WriteLine());
                    string ledighetsTyp= Console.ReadLine();

                    var personalId = allPersonal.Where(p => p.FirstName == firstName).SingleOrDefault().PersonalId;

                    Ledighet ledighet = new Ledighet()
                    {
                        PersonalId = personalId,
                        StartDatum = startDate,
                        SlutDatum = stopDate,
                        LedighetsTyp=ledighetsTyp,
                    };

                    db.AddRange(ledighet);
                    db.SaveChanges();

                }
                else
                {
                    Console.WriteLine("error");
                }


                /**/
            }
        }


        public static void AddData(List<string> Ledighetstyp)
        {
            using (var db = new EntityFrameworkLab1())
            {
                List<Personal> personals = new List<Personal>()
                {
                    new Personal(){
                        FirstName="Olof",
                        LastName="Parhammar",
                        Ledighet= new List<Ledighet> ()
                        {
                            new Ledighet() {
                                StartDatum=new DateTime(2022,03,15),
                                SlutDatum=new DateTime(2022,04,01),
                                LedighetsTyp=Ledighetstyp[0],
                            },
                            new Ledighet() {
                                StartDatum=new DateTime(2021,01,01),
                                SlutDatum=new DateTime(2021,05,13),
                                LedighetsTyp=Ledighetstyp[1],
                            },
                        }
                    },

                    new Personal(){
                        FirstName="Anders",
                        LastName="Svensson",
                        Ledighet= new List<Ledighet> ()
                        {
                            new Ledighet() {
                                StartDatum=new DateTime(2020,02,15),
                                SlutDatum=new DateTime(2020,03,15),
                                LedighetsTyp=Ledighetstyp[0],
                            },
                            new Ledighet() {
                                StartDatum=new DateTime(2021,03,01),
                                SlutDatum=new DateTime(2021,03,11),
                                LedighetsTyp=Ledighetstyp[3]
                            },
                        }
                    },

                    new Personal(){
                        FirstName="Sheila",
                        LastName="Zimic",
                        Ledighet= new List<Ledighet> ()
                        {
                            new Ledighet() {
                                StartDatum=new DateTime(2022,01,16),
                                SlutDatum=new DateTime(2022,04,27),
                                LedighetsTyp=Ledighetstyp[2]
                            },
                            new Ledighet() {
                                StartDatum=new DateTime(2019,02,09),
                                SlutDatum=new DateTime(2019,03,12),
                                LedighetsTyp=Ledighetstyp[3]
                            },
                        }
                    },
                };

                personals.ForEach(personal => db.Add(personal));


                db.SaveChanges();


            }
                
        }
        
    }
}
