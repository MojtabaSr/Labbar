using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Models
{
    public static class DbInitializer
    {
        
        public static void Initialize(APIContext context)
        {
            context.Database.EnsureCreated();
            if (context.Persons.Any())
            {
                return;  //DataBase has been seed.
            }

            var persons = new List<Person>()
            {
                new Person()
                {
                    Name = "Mojtaba Sarvari",
                    Telefonnumber=123456789,
                    PersonIntresse=new List<PersonIntresse>()
                    {
                        new PersonIntresse()
                        {
                            Intresse= new Intresse()
                            {
                                Titel="Gym",
                                Description="Fysisk träning på gym på IronWorks i Sundsvall",
                                IntresseLinks=new List<IntresseLinks>()
                                {
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.bodybuilding.com"
                                        }

                                    },
                                    
                                    new IntresseLinks()
                                    {
                                        Links=new Links()
                                        {
                                            WebLink="www.tnation.com"
                                        }
                                    },

                                    new IntresseLinks()
                                    {
                                        Links=new Links()
                                        {
                                            WebLink="www.gymgrossisten.se"
                                        }
                                    },
                                }
                            }
                        },

                        new PersonIntresse()
                        {
                            Intresse= new Intresse()
                            {
                                Titel="Statistikt inlärning",
                                Description="Att arbeta med statistik för att skapa värde av data",
                                IntresseLinks=new List<IntresseLinks>()
                                {
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.statlearning.com/"
                                        }

                                    },

                                    new IntresseLinks()
                                    {
                                        Links=new Links()
                                        {
                                            WebLink="machinelearningmastery.com"
                                        }
                                    }
                                }
                            }
                        },

                        new PersonIntresse()
                        {
                            Intresse= new Intresse()
                            {
                                Titel="Utveckling",
                                Description="Använda programmering för att skapa system",
                                IntresseLinks=new List<IntresseLinks>()
                                {
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="w3schools.com"
                                        }

                                    }
                                }
                            }
                        },

                    }
                },

                new Person()
                {
                    Name = "Mikael Starefeldt",
                    Telefonnumber=12345679,
                    PersonIntresse=new List<PersonIntresse>()
                    {
                        new PersonIntresse()
                        {
                            Intresse= new Intresse()
                            {
                                Titel="Flippa korv",
                                Description="På somrar brukar jag gilla att flippa korv",
                                IntresseLinks=new List<IntresseLinks>()
                                {
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.hurmanflipparkorv.com"
                                        }

                                    }
                                }
                            }
                        },

                        new PersonIntresse()
                        {
                            Intresse= new Intresse()
                            {
                                Titel="Flippa burgare",
                                Description="På vintrar brukar jag flippa borgare",
                                IntresseLinks=new List<IntresseLinks>()
                                {
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.hurmanflipparborgare.com"
                                        }

                                    }
                                }
                            }
                        },
                    }
                },

                new Person()
                {
                    Name = "Johan Wikström",
                    Telefonnumber=1234579,
                    PersonIntresse=new List<PersonIntresse>()
                    {
                        new PersonIntresse()
                        {
                            Intresse= new Intresse()
                            {
                                Titel="Databasmodellering",
                                Description="Arbetar heltid med att hjälpa kunder med att skapa databassystem",
                                IntresseLinks=new List<IntresseLinks>()
                                {
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.hurmanfixardatabas.com"
                                        }

                                    },
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.hurmanfuskaridatabaser.com"
                                        }

                                    }

                                }
                            }
                        },

                        new PersonIntresse()
                        {
                            Intresse= new Intresse()
                            {
                                Titel="Festa på helger",
                                Description="Varje helg maxar jag festnivån",
                                IntresseLinks=new List<IntresseLinks>()
                                {
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.clubdjsundsvall.com"
                                        }

                                    },
                                    new IntresseLinks()
                                    {
                                        Links= new Links()
                                        {
                                            WebLink="www.kop100percentalkohol.com"
                                        }

                                    },
                                }
                            }
                        },
                    }
                }
            };

            persons.ForEach(person => context.Persons.Add(person));
            context.SaveChanges();
        }
    }
}
