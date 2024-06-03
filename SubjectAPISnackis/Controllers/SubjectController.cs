using Microsoft.AspNetCore.Mvc;
using SubjectAPISnackis.Data;
using SubjectAPISnackis.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SubjectAPISnackis.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SubjectController : ControllerBase
	{
		private readonly SubjectAPISnackisContext _context;

		public SubjectController(SubjectAPISnackisContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Subject>>> Get()
		{
			return await _context.Subjects.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Subject>> Post([FromBody] Subject newSubject)
		{
			_context.Subjects.Add(newSubject);
			await _context.SaveChangesAsync();

			return CreatedAtAction("Get", new { id = newSubject.Id }, newSubject);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var subject = await _context.Subjects.FindAsync(id);
			if (subject == null)
			{
				return NotFound();
			}

			_context.Subjects.Remove(subject);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] Subject updatedSubject)
		{
			var subject = await _context.Subjects.FindAsync(id);
			if (subject == null)
			{
				return NotFound();
			}

			subject.Category = updatedSubject.Category;
			_context.Entry(subject).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SubjectExists(id))
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

		private bool SubjectExists(int id)
		{
			return _context.Subjects.Any(e => e.Id == id);
		}
	}
}
