using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App_Quizz;
using App_Quizz.Models;
using App_Quizz.Services;

namespace App_Quizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzsController : ControllerBase
    {
        private readonly IQuizzServices quizzServices;

        public QuizzsController(IQuizzServices quizzServices)
        {
            this.quizzServices = quizzServices;
        }

        // GET: api/Quizzs
        [HttpGet]
        public async Task<ActionResult<List<Quizz>>> Getquizzs()
        {
            return await quizzServices.FindQuizzes();
        }

        // GET: api/Quizzs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quizz>> GetQuizz(int id)
        {
            var quizz = await quizzServices.FindQuizById(id);

            if (quizz == null)
            {
                return NotFound();
            }

            return quizz;
        }

        // PUT: api/Quizzs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizz(int? id, Quizz quizz)
        {
            if (id != quizz.Id)
            {
                return BadRequest();
            }

            //await quizzServices.Update(quizz);

            try
            {
                await quizzServices.Update(quizz);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!await QuizzExists(id))
                //{
                //     return NotFound();
                // }
                // else
                // {
                throw;
                // }
            }

            return NoContent();
        }

        // POST: api/Quizzs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quizz>> PostQuizz([FromBody]Quizz quizz)
        {
            await quizzServices.Save(quizz);

            return CreatedAtAction("GetQuizz", new { id = quizz.Id }, quizz);
        }

        // DELETE: api/Quizzs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuizz(int? id)
        //{
        //    var quizz = await quizzServices.quizzs.FindAsync(id);
        //    if (quizz == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.quizzs.Remove(quizz);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool QuizzExists(int? id)
        //{
        //    return _context.quizzs.Any(e => e.Id == id);
        //}
    }
}
