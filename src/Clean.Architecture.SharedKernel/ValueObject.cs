namespace Clean.Architecture.SharedKernel;

/// <summary>
/// TODO.
/// See: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/.
/// </summary>
[Serializable]
public abstract class ValueObject : IComparable, IComparable<ValueObject>
{
  /// <summary>
  /// TODO.
  /// </summary>
  private int? _cachedHashCode;

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="a">TODO LATER2.</param>
  /// <param name="b">TODO LATER3.</param>
  /// <returns>TODO LATER4.</returns>
  public static bool operator ==(ValueObject? a, ValueObject? b)
  {
    if (a is null && b is null)
    {
      return true;
    }

    if (a is null || b is null)
    {
      return false;
    }

    return a.Equals(b);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="a">TODO LATER.</param>
  /// <param name="b">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  public static bool operator !=(ValueObject a, ValueObject b)
  {
    return !(a == b);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="obj">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public override bool Equals(object? obj)
  {
    if (obj == null)
    {
      return false;
    }

    if (GetUnproxiedType(this) != GetUnproxiedType(obj))
    {
      return false;
    }

    var valueObject = (ValueObject)obj;

    return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  public override int GetHashCode()
  {
    _cachedHashCode ??= GetEqualityComponents()
      .Aggregate(1, (current, obj) =>
      {
        unchecked
        {
          return (current * 23) + obj.GetHashCode();
        }
      });

    return _cachedHashCode.Value;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="obj">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public int CompareTo(object? obj)
  {
    if (obj == null)
    {
      return 1;
    }

    var thisType = GetUnproxiedType(this);
    var otherType = GetUnproxiedType(obj);

    if (thisType != otherType)
    {
      return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);
    }

    var other = (ValueObject)obj;

    var components = GetEqualityComponents().ToArray();
    var otherComponents = other.GetEqualityComponents().ToArray();

    for (var i = 0; i < components.Length; i++)
    {
      var comparison = CompareComponents(components[i], otherComponents[i]);
      if (comparison != 0)
      {
        return comparison;
      }
    }

    return 0;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="other">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  public int CompareTo(ValueObject? other)
  {
    return CompareTo(other as object);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="obj">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  internal static Type GetUnproxiedType(object obj)
  {
    ArgumentNullException.ThrowIfNull(obj);

    const string efCoreProxyPrefix = "Castle.Proxies.";
    const string nHibernateProxyPostfix = "Proxy";

    var type = obj.GetType();
    var typeString = type.ToString();

    if (typeString.Contains(efCoreProxyPrefix) || typeString.EndsWith(nHibernateProxyPostfix))
    {
      return type.BaseType!;
    }

    return type;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  protected abstract IEnumerable<object> GetEqualityComponents();

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="object1">TODO LATER.</param>
  /// <param name="object2">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  private static int CompareComponents(object? object1, object? object2)
  {
    if (object1 is null && object2 is null)
    {
      return 0;
    }

    if (object1 is null)
    {
      return -1;
    }

    if (object2 is null)
    {
      return 1;
    }

    if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
    {
      return comparable1.CompareTo(comparable2);
    }

    return object1.Equals(object2) ? 0 : -1;
  }
}
