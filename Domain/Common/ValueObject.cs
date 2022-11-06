namespace Domain.Common;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponent();

    public override bool Equals(object? obj)
    {
        if (!DoTypesMatch(obj)) return false;

        var valueObject = obj as ValueObject;

        return DoValuesMatch(valueObject!);
    }

    private bool DoTypesMatch(object? obj)
    {
        return obj != null && obj.GetType() == GetType();
    }

    private bool DoValuesMatch(ValueObject valueObject)
    {
        return GetEqualityComponent().SequenceEqual(valueObject.GetEqualityComponent());
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponent()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}