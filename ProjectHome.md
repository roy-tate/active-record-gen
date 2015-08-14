This is a small, simple template-based code generator that connects to an ADO.Net database (currently SQL Server 2000 or 2005), supplies a table + fields context to an NVelocity template engine, and generates one or more templates for each table or view.  I have already built templates for Active Record class in .Net 2.0, partial business support class that pairs with the Active Record class, SQL Server create / update / delete procedures, Data Dump generator that will create a set of insert statements from data in a table (use it to script records from one table and insert them into another table).  As you can see, the code generator is not particularly limited to generating Castle Active Record classes.

As a kindness to those who just want to try it out, I checked in bin/release/executable, so you can grab the exe, config and all templates if you want to try it out.  You are welcome to contribute other templates, patches, etc.  Patches will only be merged if they are generated against the latest source files, and they are compatible with my own direction for the program.

**Updates:**
```
2010-08-19: Just a note ... I'm not dead yet!  :-)
2007-10-01: Added preliminary support for building user interface elements.
                   Tables and Fields now have a GetLabel() method that converts field names
                   with camel-case or underscore separators to spaces.
2007-09-08: Added a template for HasMany with IList support.  Please test it out!
2007-08-10: Added two templates - HNibernate_Mapping_hbm.xml and DataGrid Support
2007-08-04: Released new EXE and SRC zip files.
2007-08-03: Fixed a bug that truncated foreign key class names.
2007-08-02: Added an internal singular/plural word list to assist in class naming.
2007-07-30: Use primary and foreign key details from INFORMATION_SCHEMA.
```

Future plans: support other databases, allow command-line generation.