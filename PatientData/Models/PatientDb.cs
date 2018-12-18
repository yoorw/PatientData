using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData.Models
{
    public static class PatientDb
    {
        public static IMongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost");
            //var server = client.GetServer();
            var db = client.GetDatabase("PatientDb");
            var collection = db.GetCollection<Patient>("Patients");
            return collection;
        }
    }
}