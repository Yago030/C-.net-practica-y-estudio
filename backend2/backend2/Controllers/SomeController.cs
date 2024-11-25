using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {

        [HttpGet("sync")]
        public IActionResult GetSync()
        {

            Stopwatch stopwatch = Stopwatch.StartNew(); //usamos chronos for timer
            stopwatch.Start();
            Thread.Sleep(1000); //inica the chronos
            Console.WriteLine("Conexion a base de datos  terminada");

            Thread.Sleep(1000);
            Console.WriteLine("Envio mail terminado");

            Console.WriteLine("Todo a  terminado");

            stopwatch.Stop(); //para el cronometro

            return Ok(stopwatch.Elapsed); //nos deveulve el tiempo transcurrido
        }
   

    [HttpGet("async")]
    public async Task<IActionResult> GetAsync()
    {

            Stopwatch stopwatch = Stopwatch.StartNew(); //usamos chronos for timer
            stopwatch.Start();
            var task1 = new Task<int>(() => //esto se ejecutara en un subproceso
        {
            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos terminada");
            return 1;
        });

            var task2 = new Task<int>(() => //esto se ejecutara en un subproceso
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio mail terminado");
                return 2;
            });


            task1.Start(); //iniciamos la tarea
            task2.Start(); //iniciamos la tarea

            Console.WriteLine("Hago otra cosa ");

        var result1 = await task1;  //traemos el resultado de la task
        var result2 = await task2;  //traemos el resultado de la task

            Console.WriteLine("Todo a terminado");
            stopwatch.Stop(); //para el cronometro

            return Ok(result1+ " "+ result2+" " + stopwatch.Elapsed);

    }

    }

}
