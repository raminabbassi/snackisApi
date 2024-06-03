using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubjectAPISnackis.Models;

namespace SubjectAPISnackis.Data
{
	public class SubjectAPISnackisContext : DbContext
	{
		public SubjectAPISnackisContext(DbContextOptions<SubjectAPISnackisContext> options)
			: base(options)
		{
		}

		public DbSet<Subject> Subjects { get; set; }
	}
}
