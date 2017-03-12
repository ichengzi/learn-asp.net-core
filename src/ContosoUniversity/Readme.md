[https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro)

## asp.net mvc + ef core

### 2017-3-7

* By default, the Entity Framework interprets（解析） a property that's named ID or classnameID as the primary key.

* using ID without classname makes it easier to implement inheritance in the data model.

* （navigation属性，即数据库中的一对一，一对多属性）The StudentID property is a foreign key, and the corresponding navigation property is Student. An Enrollment entity is associated with one Student entity, so the property can only hold a single Student entity (unlike the Student.Enrollments navigation property you saw earlier, which can hold multiple Enrollment entities).

* （ef中外键字段的判定）Entity Framework interprets a property as a foreign key property if it's named `<navigation property name><primary key property name>` (for example, `StudentID` for the `Student` navigation property since the `Student` entity's primary key is `ID`). Foreign key properties can also be named simply `<primary key property name>` (for example, `CourseID` since the `Course` entity's primary key is `CourseID`).

* If you specify ICollection<T>, EF creates a `HashSet<T>` collection by default.

* （DatabaseGenerated 特性标识）Basically, this attribute lets you enter the primary key for the course rather than having the database generate it.

* （使用ef的主要目标就是根据model生成dbContext）The main class that coordinates Entity Framework functionality for a given data model is the database context class. You create this class by deriving from the System.Data.Entity.DbContext class

* （dbContext中包含 dbSet<T>）This code creates a DbSet property for each entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.

* （一个dbSet对应一个数据库table，取dbSet的名字）When the database is created, EF creates tables that have names the same as the DbSet property names. Property names for collections are typically plural (Students rather than Student), but developers disagree about whether table names should be pluralized or not. For these tutorials you'll override the default behavior by specifying singular table names in the DbContext. 

* （services 通过DI在程序启动时进行注册，需要使用这些services 的模块通过其构造函数的参数进行调用）ASP.NET Core implements dependency injection by default. Services (such as the EF database context) are registered with dependency injection during application startup. Components that require these services (such as MVC controllers) are provided these services via constructor parameters.

* （LocalDB）LocalDB starts on demand and runs in user mode, so there is no complex configuration. By default, LocalDB creates .mdf database files in the C:/Users/<user> directory.

* （通过构造函数参数，使用依赖注入初始化dbContext）First, add the context to the method signature so that ASP.NET dependency injection can provide it to your DbInitializer class.

* （ef搭建脚手架action和view）The automatic creation of CRUD action methods and views is known as scaffolding. Scaffolding differs from code generation in that the scaffolded code is a starting point that you can modify to suit your own requirements, whereas you typically don't modify generated code. When you need to customize generated code, you use partial classes or you regenerate the code when things change.

* （注意： DbInitializer 使用的是 Models名称空间）
* （如果没有创建dbContext，使用脚手架时可以自动创建）(The scaffolding engine can also create the database context for you if you don't create it manually first as you did earlier for this tutorial. You can specify a new context class in the Add Controller box by clicking the plus sign to the right of Data context class. Visual Studio will then create your DbContext class as well as the controller and views.)

------------
EnsureCreated（未创建数据库的话，保证创建）

When you started the application, the DbInitializer.Initialize method calls EnsureCreated. EF saw that there was no database and so it created one

-----------
## Conventions(约定或假设)

property, navigation property, 主键定义，外键定义

The amount of code you had to write in order for the Entity Framework to be able to create a complete database for you is minimal because of the use of conventions, or assumptions that the Entity Framework makes.

* The names of `DbSet` properties are used as table names. For entities not referenced by a `DbSet` property, entity class names are used as table names.

* Entity property names are used for column names.

* Entity properties that are named ID or classnameID are recognized as primary key properties.

* A property is interpreted as a foreign key property if it's named *<navigation property name><primary key property name>* (for example, `StudentID` for the `Student` navigation property since the `Student` entity's primary key is `ID`). Foreign key properties can also be named simply *<primary key property name>* (for example, `EnrollmentID` since the `Enrollment` entity's primary key is `EnrollmentID`).

Conventional behavior can be overridden. For example, you can explicitly specify table names, as you saw earlier in this tutorial. And you can set column names and set any property as primary key or foreign key, as you'll see in a [later tutorial](complex-data-model.md) in this series.


-------------
## Async

**（编译器把一个方法分成多个部分，当一部分完成后，通过callback 调用下一个部分）**

* The `async` keyword tells the compiler to generate callbacks for parts of the method body and to automatically create the `Task<IActionResult>` object that is returned.

* The return type `Task<IActionResult>` represents ongoing work with a result of type `IActionResult`.

* The `await` keyword causes **the compiler to split the method into two parts**. The first part ends with the operation that is started asynchronously. The second part is put into a callback method that is called when the operation completes.

* `ToListAsync` is the asynchronous version of the `ToList` extension method.


---------------
## `<span>`标签
The HTML `<span>` element is a generic inline container for phrasing content, which does not inherently represent anything. 
It can be used to group elements for styling purposes (using the class or id attributes), or because they share attribute values, such as lang. 
It should be used only when no other semantic element is appropriate. 
`<span>` is very much like a `<div>` element, but `<div>` is a block-level element whereas a `<span>` is an inline element.

`<span>`无实际含义， 同div功能一样。但是div是块元素，span是行元素

## Route data and Query string

![Route Data  And Query String](Images/route data  and query string.png)

## model binder

a `model binder` converts posted form values to CLR types and passes them to the action method in parameters

## validateAntiForgeryToken

The `ValidateAntiForgeryToken` attribute helps prevent cross-site request forgery (CSRF) attacks. 
The token is `automatically injected` into the view by the [FormTagHelper](https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.TagHelpers/FormTagHelper.cs) 
and is included when the form is submitted by the user. 
The token is validated by the `ValidateAntiForgeryToken` attribute. 

## overPosting

```csharp
public class Student
{
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Secret { get; set; }
}
```

Even if you don't have a `Secret` field on the web page, 
a hacker could use a tool such as Fiddler, or write some JavaScript, to post a `Secret` form value. 
Without the `Bind` attribute limiting the fields that `the model binder` uses when it creates a Student instance, 
the model binder would pick up that `Secret` form value and use it to create the Student entity instance. 
Then whatever value the hacker specified for the `Secret` form field would be updated in your database. 

It's a security best practice to use the `Include` parameter with the Bind attribute to whitelist fields.
It's also possible to use the `Exclude` parameter to blacklist fields you want to exclude. 
The reason `Include` is more secure is that when you add a new property to the entity, 
the new field is not automatically protected by an `Exclude` list.

`Bind[''']`的方式会清除其中未包含的字段，不适合只修改部分字段值的场景。

The scaffolder generated a `Bind` attribute and added the entity created by the model binder to the entity set with a `Modified` flag. 
That code is not recommended for many scenarios because the `Bind` attribute 
clears out `any pre-existing data` in fields not listed in the `Include` parameter.

## Entity States

The database context `keeps track of whether entities in memory` are in sync with their corresponding rows in the database, 
and this information determines what happens when you call the `SaveChanges` method.

1. Added
2. Unchanged
3. Modified
4. Deleted
5. Detached(分离的) -- The entity isn't being tracked by the database context.

## dbContext( desktop vs web application)

In a desktop application, state changes are typically set automatically. 
You read an entity and make changes to some of its property values. 
This causes its entity state to automatically be changed to `Modified`. 
Then when you call `SaveChanges`, the Entity Framework generates a SQL UPDATE statement that updates only the actual properties that you changed.

In a web app, the `DbContext` that initially reads an entity 
and displays its data to be edited is disposed after a page is rendered. 
When the HttpPost `Edit` action method is called,  `a new web request` is made and you have `a new instance` of the `DbContext`. 
If you re-read the entity in that new context, you simulate desktop processing.

每一次新的请求都会生成新的 controller，也即新 dbContext。

## Delete

You'll add a try-catch block to the HttpPost Delete method to handle 
any errors that might occur when the database is updated. 
If an error occurs, the HttpPost Delete method calls the HttpGet Delete method, 
passing it a parameter that indicates that an error has occurred. 
The HttpGet Delete method then redisplays the confirmation page along with the error message,
 giving the user an opportunity to cancel or try again.

## Closing database connection

In *Startup.cs* you call the `AddDbContext extension method` to provision(供给) the `DbContext` class in the ASP.NET DI container. 
That method sets the service lifetime to `Scoped` by default. 
`Scoped` means the context object lifetime **coincides（相一致）** with the web request life time, 
and the `Dispose` method will be called automatically at the end of the web request.

## transaction - 事务

By default the Entity Framework implicitly implements transactions. 
In scenarios where you make changes to multiple rows or tables and then call `SaveChanges`, 
the Entity Framework automatically makes sure that either 
all of your changes succeed or they all fail. 
If some changes are done first and then an error happens, those changes are automatically rolled back. 

