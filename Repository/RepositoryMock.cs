using System.Reflection;

namespace JMock.Repository
{
  public class RepositoryMock<T>
  {
    private int Delay { get; set; }
    private List<T> Entities { get; set; }
    private string? IdPropertyName { get; set; }
    public RepositoryMock(int? delay = null, string? idPropertyName = null)
    {
      Delay = delay ?? 0;
      Entities = new List<T>();
      IdPropertyName = idPropertyName;
    }

    public T? GetEntity(int index)
    {
      HandleDelay();
      var res = Entities[index];
      if (res == null) return default;
      return res;
    }
    public async Task<T?> GetEntityAsync(int index)
    {
      HandleDelay();
      var res = Entities[index];
      if (res == null) return default;
      return res;
    }
    public async Task<T?> CreateOrUpdateEntity(T obj)
    {
      var exists = Entities.FirstOrDefault(x => FindMatch(x, obj, IdPropertyName));
      if (exists != null) Entities.Remove(exists);
      Entities.Add(obj);
      return obj;
    }

    public async Task<bool> DeleteEntity(T obj)
    {
      var exists = Entities.FirstOrDefault(x => FindMatch(x, obj, IdPropertyName));
      if (exists != null) Entities.Remove(exists);
      return true;
    }
    public List<T> GetEntitites()
    {
      return Entities;
    }
    private void HandleDelay()
    {
      if (Delay == 0) return;
      Thread.Sleep(Delay);
    }

    Func<T, T, string?, bool> FindMatch = (entity, otherEntity, idProperty) =>
    {
      var entityProperties = GetIdProperties(entity, idProperty);
      var otherEntityProperties = GetIdProperties(otherEntity, idProperty);

      var length = entityProperties.Count();
      if (otherEntityProperties.Count() < length) length = otherEntityProperties.Count();
      for (var i = 0; i < entityProperties.Count(); i++)
      {
        var entityProp = entityProperties[i];
        var otherEntityProp = otherEntityProperties[i];

        var entityVal = entityProp.GetValue(entity);
        var otherEntityval = otherEntityProp.GetValue(otherEntity);
        if (entityVal == otherEntityval) return true;
      }
      return false;
    };

    public static List<PropertyInfo> GetIdProperties(T entity, string? idProperty = null)
    {
      var properties = entity.GetType().GetProperties().Where(x => (x.PropertyType.IsPrimitive || x.PropertyType == typeof(string))).ToList();
      if (idProperty != null) { return properties.Where(x => x.Name == idProperty).ToList(); }
      else return properties.Where(x => x.Name.ToLower().Contains("id")).OrderBy(x => x.Name).ToList();
    }

  }
}
