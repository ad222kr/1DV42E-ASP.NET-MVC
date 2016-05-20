# 1DV42E-ASP.NET-MVC

## Tasks for both
- [ ] Set up application for migrations
- [ ] Create models
- [ ] Generate a migrations
- [ ] Migrate a simple migration
- [ ] Create a one-to-many relationship migration
- [ ] Create a many-to-many relationship migration
- [ ] Remove attributes from a model and migrate

## ASP.NET MVC specific tasks
- [ ] Setup application for Code First
- [ ] Implement the repository pattern

## Task documentation

### 1. Setup application for Code First
First thing to notice is that when you create an ASP.NET MVC application it isn't shipped with an ORM, you have to install entity framework yourself. Pretty straightforward, open the NuGet Package Manager Console in VS2015 and type ```Install-Package EntityFramework```. This installs Entity Framework 6.1.3, might want to document it in the paper later.

The ASP.NET site has really [good documentation/tutorials](https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application) on how to get started with Code First so I'm gonna start there. This tutorial uses DBContext objects directly in the controllers which is not best practice but it's a good start. Therefor 
Repository pattern with Unit of work will be implemented

Next up is creatting the models which is it's own task.

### 2. Repository Pattern with Unit of Work  



Repository/Unit of work are an abstraction layer between the DAL and 
business logic layer. ASP.NET site has good documentation/tutorial on how
to implement both just the Repository pattern where each entity has
it's own repository class and a generic repository with Unit of Work.
http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application 

To use Entity Framework you need to create a Database Context. This is
the class that coordinates Entity Framework functionality, and derives from DbContext.

We need to specify the connectionstring. Entity Framework looks for 
a connection string namned the same as the DbContext class (CONVENTION OVER CONFIG!)
This is done in the web.config file and is clear from the tutorial. It is not
clear however where in the web.config it should be. I am using a local database,
but for connecting to a remote db it was also documented, not on asp.net though but on 
[msdn.microsoft.com]](https://msdn.microsoft.com/en-us/library/jj653752%28v=vs.110%29.aspx) 
You dont even need to specify a connection string if you are going to use the localdb for dev.

Implementing the Generic repository was pretty straight forward since the code
is given to you fully. Some things like the Get method are pretty hard to
understand but most methods are straight forward. Pretty much every row is 
explained in a good way so you get a basic understanding of what is going on

Next is the Unit of Work class which makes sure multiple repositories share
a single db context. The this tutorial has a fully written UoW and
its documented to give the developer some understanding.

This step was easy to find information about and the tutorials on ASP.NET
are very well written and documented. It takes some time to write though and 
without the tutorial it would probably take very long time to figure out
how it should work. It was pretty much boilerplate to write and would be nice
to have it generated with a command, especially the GenericRepository since 
there is no model-specific code there. You could just use the DbContext-object directly
from the controller but this couples the code to much and does not allow for
mocking objects when testing.


### 3. Create models
In ASP.NET MVC Models are just regular C# classes with properties. Creating them is pretty straight forward, just drop them in the Models folder created on generating the application.
The first model to be created is the Attendee. To try and simulate many possible uses of migrations, it wont have all the properties on creation, these will be added later.

On creating a model that will be stored as a row in a table in the database, the model needs a property named ID of the type int. This will allow EF to interpret it ass the primary key (ID or classnameID).

Entity Framework uses "navigation properties" for simulating relations in code. These are declared as virtual for EF to use lazy loading. If a model has many of another, this property is declared as an ```public virtual ICollection<Type> Types ```. If a model has only, one, the navigation property is declared like ``` public virtual Type Type ```.

### 4. Creating a simple migration
To enable migrations you need to write a command in the Package Manager Console
```enable migrations -contexttypename TheContextClassName ```

After this, a folder named migrations is generated and a configuration class containing
the seed-method.

After filling the seed-method with some example data its time to create a migration.
this is done with two commands, one creates and one updates the database.
```
   add-migration InitialCreate
   update-database
```

The first command creates a class named InitialCreate that inherits from DbMigration.
If we take a look inside it we see some code for creating a table with rows mapping directly
to our Models, with foreign keys and everything, also adding index on them.
The syntax is pretty easy to read.

The second command gave an error that a network related error occured.
The error message was very helpful and said that i probably dont have SQL Server Express
installed on my machine, which is required to run LocalDb.
I chose to install Sql Express LocalDb which only was 43 mb to download, but this
should really come pre-installed with Visual Studio.

After installing the update-database command worked as intended, though I
dont know where my database ended up. I ended up with a local db in the 
App_Data folder. Inspecting the tables i see that they are direct representations
of my Model classes and are filled with data from the seeds.

To see how migrations work after modifying my entities I added a DateTime property
to the event and generated a new migration.











