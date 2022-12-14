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
    public class QuizzReponsesController : ControllerBase
    {
        private readonly IQuizzReponsesServices quizzReponsesServices;
        private readonly IQuizzServices quizzServices;

        public QuizzReponsesController(IQuizzReponsesServices quizzReponsesServices, IQuizzServices quizzServices)
        {
            this.quizzReponsesServices = quizzReponsesServices;
            this.quizzServices = quizzServices;
        }

        // GET: api/QuizzReponses/{id}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizzReponses>>> GetquizzReponses(int questionId)
        {
            return await quizzServices.FindResponses(questionId);
        }

        // GET: api/QuizzReponses/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<QuizzReponses>> GetQuizzReponses(int? id)
        //{
        //    var quizzReponses = await _context.quizzReponses.FindAsync(id);

        //    if (quizzReponses == null)
        //    {
        //        return NotFound();
        //    }

        //    return quizzReponses;
        //}

        // PUT: api/QuizzReponses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizzReponses(int? id, QuizzReponses quizzReponses)
        {
            if (id != quizzReponses.Id)
            {
                return BadRequest();
            }

           

            try
            {
                await quizzReponsesServices.Update(quizzReponses);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (quizzReponsesServices == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuizzReponses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizzReponses>> PostQuizzReponses([FromBody]QuizzReponses quizzReponses)
        {
           await quizzReponsesServices.Save(quizzReponses);
            

            return CreatedAtAction("GetQuizzReponses", new { id = quizzReponses.Id }, quizzReponses);
        }

        // DELETE: api/QuizzReponses/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuizzReponses(int? id)
        //{
        //    var quizzReponses = await _context.quizzReponses.FindAsync(id);
        //    if (quizzReponses == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.quizzReponses.Remove(quizzReponses);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool QuizzReponsesExists(int? id)
        //{
        //    return _context.quizzReponses.Any(e => e.Id == id);
        //}
    }
}
