namespace MovieFlow.Shared.Infrastructure.Serialization;

public interface IJsonSerializer
{
    string Serialize(object value);
    T Deserialize<T>(string value);
    object Deserialize(string value, Type type);
}