using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ej03.Controllers
{
    [ApiController]
    [Route("[/api/students]")]

    
    public class StudentController : ControllerBase
    {

        string[] nombres = { "Camila", "Fernando", "Fabricio", "Jose","Andrea","Stephany", "Carlos", "Nicole", "Kiara","Matilde" };
        string[] apellidos = { "Allende", "Gonzales", "Estenssoro", "Jobs", "Sarmiento", "Duran", "Rosales", "Zambrana", "Andrade", "Burgos" };

        public StudentController()
        {
            
        }

        [HttpGet]
        public List<Student> GetStudent()
        {
            Random r = new Random();
            int est = r.Next(5,11);
            List<Student> list = new List<Student>();
            for (int i = 0; i<est; i++) 
            {
                list.Add(new Student()
                {
                    Name = nombres[r.Next(0,11)],
                    LastName = apellidos[r.Next(0, 11)]
                });
            }
            return list;
        }

        [HttpPost]
        public Student CreateStudent([FromBody] string studentName, [FromBody] string studentLastName ) 
        {
            return new Student()
            {
                Name = studentName,
                LastName = studentLastName
            };
        }
        [HttpPut]
        public Student UpdateStudent([FromBody] Student estudiante) 
        {
            estudiante.Name = "NuevoNombre";
            estudiante.LastName = "NuevoApellido";
            return estudiante;
        }

        [HttpDelete]
        public Student DeleteStudent([FromBody] Student estudiante)
        {
            estudiante.Name = "Deleted";
            estudiante.LastName = "Deleted";
            return estudiante;
        }
    }
}
