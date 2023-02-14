namespace Clean.Architecture.Core;

using Autofac;
using Interfaces;
using Services;

/// <summary>
/// Dependency injections using autofac.
/// </summary>
public class DefaultCoreModule : Module
{
  /// <summary>
  /// Build dependencies into the container.
  /// </summary>
  /// <param name="builder">The container-builder from autofac.</param>
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
      .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
      .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }
}
