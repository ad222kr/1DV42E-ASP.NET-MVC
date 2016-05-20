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

The ASP.NET site has really [good documentation/tutorials](https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application) on how to get started with Code First so I'm gonna start there. This tutorial uses DBContext objects directly in the controllers which is not best practice but it's a good start.

Next up is creatting the models which is it's own task.


### 2. Create models
In ASP.NET MVC Models are just regular C# classes with properties. Creating them is pretty straight forward, just drop them in the Models folder created on generating the application.
The first model to be created is the Attendee. To try and simulate many possible uses of migrations, it wont have all the properties on creation, these will be added later.

On creating a model that will be stored as a row in a table in the database, the model needs a property named ID of the type int. This will allow EF to interpret it ass the primary key (ID or classnameID).

Entity Framework uses "navigation properties" for simulating relations in code. These are declared as virtual for EF to use lazy loading. If a model has many of another, this property is declared as an ```public virtual ICollection<Type> Types ```. If a model has only, one, the navigation property is declared like ``` public virtual Type Type ```.

The app will later use Repository Pattern, but in the beginning we will just have a DBContext in the DAL, so this step will not be documented.



