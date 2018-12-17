using MongoDB.Driver;
using PatientData.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
    public class PatientsController : ApiController
    {
        private IMongoCollection<Patient> Patients;

        public PatientsController()
        {
            Patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            return Patients.Find(new BsonDocument()).ToEnumerable<Patient>();
        }

        //public HttpResponseMessage Get(string id)
        //{
        //    var patient = Patients.Find(ObjectId.Parse(id));
        //}
        //// GET api/Patients/
        //public IEnumerable<Patient> Get()
        //{
        //    return Patients.Find(new BsonDocument()).ToEnumerable<Patient>();
        //}

        // GET api/Patients/id
        public IHttpActionResult Get(string id)
        {
            var Patient = Patients.Find(f => f.Id == id);
            if (Patient == null)
                return NotFound();

            return Ok(Patient.ToList());
        }

        // GET api/Patients/id/Medications
        [Route("api/Patients/{id}/Medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var Patient = Patients.Find(x => x.Id == id);

            if (Patient == null)
                return NotFound();

            var Medication = Patient.FirstOrDefault().Medications;

            if (Medication == null)
                return NotFound();

            return Ok(Medication.ToList());
        }
    }
}
