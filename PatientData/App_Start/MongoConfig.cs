using MongoDB.Driver.Linq;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData
{
    public class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();

            if (!patients.AsQueryable().Any(p => patients.Name == "Scott"))
            {
                var data = new List<Patient>()
                {
                    new Patient { Name = "Scott",
                                  Ailments = new List<Ailment>() { new Ailment { Name="Funny" } },
                                  Medications = new List<Medication> { new Medication { Name="Laughter", Doses=2 } }
                    },
                    new Patient { Name = "Ryan",
                                  Ailments = new List<Ailment>() { new Ailment { Name="Crazy" } },
                                  Medications = new List<Medication> { new Medication { Name="GoofyPills", Doses=1 } }
                    },
                    new Patient { Name = "Chris",
                                  Ailments = new List<Ailment>() { new Ailment { Name="Cranky"} },
                                  Medications = new List<Medication> { new Medication { Name="ChillPills", Doses=3 } }
                    }
                };

                patients.InsertBatch(data);
            }
        }
    }
}