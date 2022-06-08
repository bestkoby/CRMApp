### HW Questions

**Diff between IEnumerable and List**  
 IEnumerable is simply an interface and dList can inherits ftom IEnumerable.  IEnumerable is read-only and List is not.Use IEnumerable when only wants to iterate over, use List when need modify.

**Diff between IEnumerable and IQueryable**  
IQueryable queries out-of-memory data stores, while IEnumerable queries in-memory data. Moreover, IQueryable is part of .NET's System.LINQ namespace, while IEnumerable is in System.
IQueryable is a better choice when query data collection which is connected with database
IQueryable inherits IEnumerable, so IQueryable does everything that IEnumerable does. IQueryable extends the IEnumerable with logic for querying data.

**database first approach and code first approach**  
In Code First approach, entities or classes are created first with the primary focus on the domain of an application.
In Database First approach, database and the related tables are created first. After that, you can create an entity data models using database.