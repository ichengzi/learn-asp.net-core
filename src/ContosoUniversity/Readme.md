[https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro)

## asp.net mvc + ef core

### 2017-3-7

- By default, the Entity Framework interprets（解析） a property that's named ID or classnameID as the primary key.
- using ID without classname makes it easier to implement inheritance in the data model.
- （navigation属性，即数据库中的一对一，一对多属性）The StudentID property is a foreign key, and the corresponding navigation property is Student. An Enrollment entity is associated with one Student entity, so the property can only hold a single Student entity (unlike the Student.Enrollments navigation property you saw earlier, which can hold multiple Enrollment entities).
- （ef中外键字段的判定）Entity Framework interprets a property as a foreign key property if it's named `<navigation property name><primary key property name>` (for example, `StudentID` for the `Student` navigation property since the `Student` entity's primary key is `ID`). Foreign key properties can also be named simply `<primary key property name>` (for example, `CourseID` since the `Course` entity's primary key is `CourseID`).
- If you specify ICollection<T>, EF creates a `HashSet<T>` collection by default.
- （DatabaseGenerated 特性标识）Basically, this attribute lets you enter the primary key for the course rather than having the database generate it.
- （使用ef的主要目标就是根据model生成dbContext）The main class that coordinates Entity Framework functionality for a given data model is the database context class. You create this class by deriving from the System.Data.Entity.DbContext class
- （dbContext中包含 dbSet<T>）This code creates a DbSet property for each entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.
- （一个dbSet对应一个数据库table，取dbSet的名字）When the database is created, EF creates tables that have names the same as the DbSet property names. Property names for collections are typically plural (Students rather than Student), but developers disagree about whether table names should be pluralized or not. For these tutorials you'll override the default behavior by specifying singular table names in the DbContext. 
- （services 通过DI在程序启动时进行注册，需要使用这些services 的模块通过其构造函数的参数进行调用）ASP.NET Core implements dependency injection by default. Services (such as the EF database context) are registered with dependency injection during application startup. Components that require these services (such as MVC controllers) are provided these services via constructor parameters.
- （LocalDB）LocalDB starts on demand and runs in user mode, so there is no complex configuration. By default, LocalDB creates .mdf database files in the C:/Users/<user> directory.
- （通过构造函数参数，使用依赖注入初始化dbContext）First, add the context to the method signature so that ASP.NET dependency injection can provide it to your DbInitializer class.
- （ef搭建脚手架action和view）The automatic creation of CRUD action methods and views is known as scaffolding. Scaffolding differs from code generation in that the scaffolded code is a starting point that you can modify to suit your own requirements, whereas you typically don't modify generated code. When you need to customize generated code, you use partial classes or you regenerate the code when things change.
- （注意： DbInitializer 使用的是 Models名称空间）
- （如果没有创建dbContext，使用脚手架时可以自动创建）(The scaffolding engine can also create the database context for you if you don't create it manually first as you did earlier for this tutorial. You can specify a new context class in the Add Controller box by clicking the plus sign to the right of Data context class. Visual Studio will then create your DbContext class as well as the controller and views.)