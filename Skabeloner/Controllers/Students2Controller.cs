using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rest.Controllers
{
    [Route("api/[controller]")]
    public class Students2Controller : Controller
    {
        private static List<Student> _students;
        private static int _idCounter = 1;


        public Students2Controller()
        {
            if (_students == null) _students = new List<Student>();

            if (_students.Count == 0)
            {
                Post(new Student());
                Post(new Student());
                Post(new Student());
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public List<Student> Get()
        {
            return _students;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            if (_students != null)
            {
                return _students.Find(item => item.Id == id);
            }

            return null;
        }

        // POST api/<controller>
        [HttpPost]
        public Student Post([FromBody]Student value)
        {
            Student s = new Student();
            if (value != null)
            {
                s.Age = value.Age;
                s.Name = value.Name;
                s.Id = _idCounter;
                _idCounter++;
                _students.Add(s);
            }

            return s;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody]Student value)
        {
            Student s = Get(id);
            s.Name = value.Name;
            s.Age = value.Age;

            return s;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public Student Delete(int id)
        {
            Student s = _students.Find(i => i.Id == id);
            if (s != null)
            {
                _students.Remove(s);
            }

            return s;
        }
    }
}
