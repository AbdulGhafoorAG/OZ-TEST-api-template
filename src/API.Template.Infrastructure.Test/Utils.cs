using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using API.Template.Infrastructure.Concrete.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace API.Template.Infrastructure.Test
{
    public static class Utils
    {
        public static IEnumerable<PropertyInfo> GetDifferences(object source, object compareTo)
        {
			if (source == null || compareTo == null)
			{
				throw new ArgumentNullException(nameof(GetDifferences));
			}

			var sourceObjProps = source.GetType().GetProperties();
			var compareToObjProps = compareTo.GetType().GetProperties().ToDictionary(x => x.Name);

			// include all properties that exist in source which do not exist in compareTo
			var differences = sourceObjProps
				.Where(x => !compareToObjProps.ContainsKey(x.Name))
				.ToList();

			// simple ToString comparison should be sufficient for all dto field types
			bool compare(object obj1, object obj2)
			{
				if (obj1 == null || obj2 == null)
				{
					return (obj1??obj2) == null;
				}

				return obj1.ToString().Equals(obj2.ToString());
			}

			// then include all properties that differ, ignoring arrays
			differences.AddRange(sourceObjProps
				.Where(x => compareToObjProps.ContainsKey(x.Name) && 
							!x.GetType().IsArray &&
							!compare(x.GetValue(source, null), compareToObjProps[x.Name].GetValue(compareTo, null))));

			// and last, recursively include arrays assuming same order
			sourceObjProps
				.Where(x => compareToObjProps.ContainsKey(x.Name) && x.GetType().IsArray)
				.ToList().ForEach(x =>
				{
					var sourceArray = (Array)x.GetValue(source, null);
					var destArray = (Array)compareToObjProps[x.Name].GetValue(compareTo, null);

					if (sourceArray.Length != destArray.Length)
					{
						differences.Add(x);
						return;
					}

					for (var i = 0; i < sourceArray.Length; i++)
					{
						differences.AddRange(GetDifferences(sourceArray.GetValue(i), destArray.GetValue(i)));
					}
				});

			return differences;
		}

		public static InMemoryContext GetContextWithData()
		{
			var options = new DbContextOptionsBuilder<InMemoryContext>()
							  .UseInMemoryDatabase(Guid.NewGuid().ToString())
							  .Options;

			return new InMemoryContext(options);
		}
    }
}
