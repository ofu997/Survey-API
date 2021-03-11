using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Models;

namespace SurveyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyItemsController : ControllerBase
    {
        private readonly SurveyContext _context;

        public SurveyItemsController(SurveyContext context)
        {
            _context = context;
        }

        // GET: api/SurveyItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyItem>>> GetSurveyItems()
        {
            return await _context.SurveyItems.ToListAsync();
        }

        // GET: api/SurveyItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyItem>> GetSurveyItem(long id)
        {
            var surveyItem = await _context.SurveyItems.FindAsync(id);

            if (surveyItem == null)
            {
                return NotFound();
            }

            return surveyItem;
        }

        // PUT: api/SurveyItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurveyItem(long id, SurveyItem surveyItem)
        {
            if (id != surveyItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(surveyItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyItemExists(id))
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

        // POST: api/SurveyItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SurveyItem>> PostSurveyItem(SurveyItem surveyItem)
        {
            _context.SurveyItems.Add(surveyItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurveyItem", new { id = surveyItem.Id }, surveyItem);
        }

        // DELETE: api/SurveyItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SurveyItem>> DeleteSurveyItem(long id)
        {
            var surveyItem = await _context.SurveyItems.FindAsync(id);
            if (surveyItem == null)
            {
                return NotFound();
            }

            _context.SurveyItems.Remove(surveyItem);
            await _context.SaveChangesAsync();

            return surveyItem;
        }

        private bool SurveyItemExists(long id)
        {
            return _context.SurveyItems.Any(e => e.Id == id);
        }
    }
}
