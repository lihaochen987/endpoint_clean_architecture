namespace Clean.Architecture.Core;

using Autofac;
using Interfaces;
using Services;

/// <summary>
/// TODO.
/// </summary>
public class DefaultCoreModule : Module
{
  /// <summary>
  /// TODO LATER1.
  /// </summary>
  /// <param name="builder">TODO LATER2.</param>
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
      .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
      .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }
}
