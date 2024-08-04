# BC2SQL
replicate data from odata api into sql tables.
it is not usable for ANY automation yet.

# BC2SQL Explore
This program creates libraries and allows configuration - such as recording data sources or data bases or managing scraper and schedulers.

# BC2SQL Configure
This program allows configuration for schedulers and scrapers in particular.

# BC2SQL Scrape
This program is responsible for issuing sql statements according to their assigned data source and database.

# BC2SQL Shared
This library does all heavy lifting.
It defines workspace management, odata requests and so on...

# next thing to do:
- implement altering of tables and conditional creation of tables
- store merge results into a table
- create user interface for configuring scrapers ($select, merge strategy, etc.)
- implement OAuth2 authentification for OData Sources
- create windowing of tables (create SQL and ODATA where clause / filters based on PKs to reduce table locking)
- determine migrations
