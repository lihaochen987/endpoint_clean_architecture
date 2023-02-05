[![Ardalis.CleanArchitecture.Template on NuGet](https://img.shields.io/nuget/v/Ardalis.CleanArchitecture.Template?label=Ardalis.CleanArchitecture.Template)](https://www.nuget.org/packages/Ardalis.CleanArchitecture.Template/)

# Clean Architecture

The template was cloned, digested and understood from the link below. The README houses personal notes and understandings of the author.

_A starting point for Clean Architecture with ASP.NET Core. [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html) is just the latest in a series of names for the same loosely-coupled, dependency-inverted architecture. You will also find it named [hexagonal](http://alistair.cockburn.us/Hexagonal+architecture), [ports-and-adapters](http://www.dossier-andreas.net/software_architecture/ports_and_adapters.html), or [onion architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/)._

## Table Of Contents

- [Clean Architecture](#clean-architecture)
  - [Table Of Contents](#table-of-contents)
  - [The Core Project](#the-core-project)
    - [MediatR and Handlers???](#mediatr-and-handlers)
  - [The SharedKernel Project](#the-sharedkernel-project)
  - [The Infrastructure Project](#the-infrastructure-project)
  - [The Web Project](#the-web-project)
    - [ProjectRecord and ContributorRecord???](#projectrecord-and-contributorrecord)
    - [Fast Endpoints](#fast-endpoints)
  - [The Test Projects](#the-test-projects)
    - [Builder Patterns](#builder-patterns)
    - [How tf is DbContext being populated during tests?](#how-tf-is-dbcontext-being-populated-during-tests)
    - [Why aren't we testing POST(and variants) to the endpoints?](#why-arent-we-testing-postand-variants-to-the-endpoints)
- [Patterns Used](#patterns-used)
  - [Domain Events](#domain-events)
  - [Cancellation Tokens?](#cancellation-tokens)
  - [Separation of DeleteContributor Service.](#separation-of-deletecontributor-service)
  - [Separating Queries?](#separating-queries)
  - [Handlers?](#handlers)
  - [Aggregates and Entity Base](#aggregates-and-entity-base)

## The Core Project

- Service layers for the interface are housed here.

_The Core project is the center of the Clean Architecture design, and all other project dependencies should point toward it. As such, it has very few external dependencies. The one exception in this case is the `System.Reflection.TypeExtensions` package, which is used by `ValueObject` to help implement its `IEquatable<>` interface. The Core project should include things like:_

- _Entities_
- _Aggregates_
- _Domain Events_
- _DTOs_
- _Interfaces_
- _Event Handlers_
- _Domain Services_
- _Specifications_

Very DDD centric approach. I think the biggest takeaway is to **DESIGN YOUR DOMAIN MODEL FIRST**. The secondary (and perhaps more controversial) takeaways are:

- Use `Domain Services` as a last resort. Typically we use them as an interface with the `Infrastructure` layer (for example accessing the repository).

### MediatR and Handlers???

## The SharedKernel Project

_Many solutions will also reference a separate **Shared Kernel** project/package. I recommend creating a separate SharedKernel project and solution if you will require sharing code between multiple [bounded contexts](https://ardalis.com/encapsulation-boundaries-large-and-small/) (see [DDD Fundamentals](https://www.pluralsight.com/courses/domain-driven-design-fundamentals)). I further recommend this be published as a NuGet package (most likely privately within your organization) and referenced as a NuGet dependency by those projects that require it. For this sample, in the interest of simplicity, I've added a SharedKernel project to the solution. It contains types that would likely be shared between multiple bounded contexts (VS solutions, typically), in my experience. If you want to see an [example of a SharedKernel package, the one I use in my updated Pluralsight DDD course is on NuGet here](https://www.nuget.org/packages/PluralsightDdd.SharedKernel/)._

## The Infrastructure Project

_Most of your application's dependencies on external resources should be implemented in classes defined in the Infrastructure project. These classes should implement interfaces defined in Core. If you have a very large project with many dependencies, it may make sense to have multiple Infrastructure projects (e.g. Infrastructure.Data), but for most projects one Infrastructure project with folders works fine. The sample includes data access and domain event implementations, but you would also add things like email providers, file access, web api clients, etc. to this project so they're not adding coupling to your Core or UI projects._

_The Infrastructure project depends on `Microsoft.EntityFrameworkCore.SqlServer` and `Autofac`. The former is used because it's built into the default ASP.NET Core templates and is the least common denominator of data access. If desired, it can easily be replaced with a lighter-weight ORM like Dapper. Autofac (formerly StructureMap) is used to allow wireup of dependencies to take place closest to where the implementations reside. In this case, an InfrastructureRegistry class can be used in the Infrastructure class to allow wireup of dependencies there, without the entry point of the application even having to have a reference to the project or its types. [Learn more about this technique](https://ardalis.com/avoid-referencing-infrastructure-in-visual-studio-solutions). The current implementation doesn't include this behavior - it's something I typically cover and have students add themselves in my workshops._

- Differences between services in Infrastructure and Core???

## The Web Project

_The entry point of the application is the ASP.NET Core web project. This is actually a console application, with a public static void Main method in Program.cs. It currently uses the default MVC organization (Controllers and Views folders) as well as most of the default ASP.NET Core project template code. This includes its configuration system, which uses the default appsettings.json file plus environment variables, and is configured in Startup.cs. The project delegates to the Infrastructure project to wire up its services using Autofac._

### ProjectRecord and ContributorRecord???

### Fast Endpoints

- Inherits from the Endpoint class with optional request and body.
- Makes endpoints themselves more SOLID (each endpoint corresponds with a request and response contract object).
- Absolutely love this so far.

## The Test Projects

_Test projects could be organized based on the kind of test (unit, functional, integration, performance, etc.) or by the project they are testing (Core, Infrastructure, Web), or both. For this simple starter kit, the test projects are organized based on the kind of test, with unit, functional and integration test projects existing in this solution. In terms of dependencies, there are three worth noting:_

- _[xunit](https://www.nuget.org/packages/xunit) I'm using xunit because that's what ASP.NET Core uses internally to test the product. It works great and as new versions of ASP.NET Core ship, I'm confident it will continue to work well with it._

- _[Moq](https://www.nuget.org/packages/Moq/) I'm using Moq as a mocking framework for white box behavior-based tests. If I have a method that, under certain circumstances, should perform an action that isn't evident from the object's observable state, mocks provide a way to test that. I could also use my own Fake implementation, but that requires a lot more typing and files. Moq is great once you get the hang of it, and assuming you don't have to mock the world (which we don't in this case because of good, modular design)._

We typically want:

- 100% Test coverage for `Domain Model Objects` as they house our business logic and requirements.
- 100% Test coverage for `Specifications`.
- 100% Test coverage for `GET` endpoints.

### Builder Patterns

- Used to build your domain model objects, can be used for both testing and in other parts of the code.
- My favourite aspect is the `WithDefaultValues()` method in the builder class. Makes initialising much more standardised, reusable and easier.

### How tf is DbContext being populated during tests?

### Why aren't we testing POST(and variants) to the endpoints?

# Patterns Used

_This solution template has code built in to support a few common patterns, especially Domain-Driven Design patterns. Here is a brief overview of how a few of them work._

## Domain Events

_Domain events are a great pattern for decoupling a trigger for an operation from its implementation. This is especially useful from within domain entities since the handlers of the events can have dependencies while the entities themselves typically do not. In the sample, you can see this in action with the `ToDoItem.MarkComplete()` method. The following sequence diagram demonstrates how the event and its handler are used when an item is marked complete through a web API endpoint._

_![Domain Event Sequence Diagram](https://user-images.githubusercontent.com/782127/75702680-216ce300-5c73-11ea-9187-ec656192ad3b.png)_

## Cancellation Tokens?

- TBD

## Separation of DeleteContributor Service.

- TBD

## Separating Queries?

- TBD

## Handlers?

- Services are Mapped to handlers

## Aggregates and Entity Base

- TBD
