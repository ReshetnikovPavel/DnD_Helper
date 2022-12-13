using System.Reflection;

namespace DndHelper.Infrastructure;

public class ValueType<T>
	where T : ValueType<T>
{
	private static IReadOnlyCollection<PropertyInfo> Properties => typeof(T)
		.GetProperties(BindingFlags.Instance | BindingFlags.Public)
		.OrderBy(p => p.Name)
		.ToArray();

	public bool Equals(T? other)
	{
		foreach (var property in Properties)
		{
			if (other == null)
				return false;
			if (!Equals(property.GetValue(this), property.GetValue(other)))
				return false;
		}

		return true;
	}

	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((T) obj);
	}

	public override int GetHashCode()
	{
		unchecked
		{
			return Properties
				.Select(property => property.GetValue(this))
				.Where(value => value != null)
				.Aggregate(17, (current, value) => current * 23 + value!.GetHashCode());
		}
	}

	public override string ToString()
	{
		return $"{typeof(T).Name}({string.Join("; ", Properties.Select(p => $"{p.Name}: {p.GetValue(this)}"))})";
	}
}