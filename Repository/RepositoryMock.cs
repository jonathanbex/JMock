using System.Reflection;

namespace JMock.Repository
{
  /// <summary>
  /// Repository Mock of T Type
  /// </summary>
  /// <typeparam name="T"></typeparam>
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

    /// <summary>
    /// Get Entity
    /// </summary>
    /// <param name="index">index of object in context</param>
    /// <param name="idValue">id value, looks for specific id set in repository or any property with id in it for match</param>
    /// <returns>T</returns>
    /// <exception cref="InvalidDataException"></exception>
    public T? GetEntity(int? index = null, string? idValue = null)
    {
      if (index == null && idValue == null) throw new InvalidDataException("Missing index or value of id, one must be set");
      HandleDelay();
      T? res;
      if (index != null) res = Entities[index.Value];
      else
      {
        res = Entities.FirstOrDefault(x => FindSingularMatch(x, IdPropertyName, idValue));
      }
      if (res == null) return default;
      return res;
    }
    /// <summary>
    /// Get Entity Async
    /// </summary>
    /// <param name="index">index of object in context</param>
    /// <param name="idValue">id value, looks for specific id set in repository or any property with id in it for match</param>
    /// <returns>T</returns>
    /// <exception cref="InvalidDataException"></exception>
    public async Task<T?> GetEntityAsync(int? index = null, string? idValue = null)
    {
      return GetEntity(index, idValue);
    }

    /// <summary>
    /// Create Or Update Entity
    /// </summary>
    /// <param name="obj">obj to create or update, matches via {looks for specific id set in repository or any property with id in it for match} </param>
    /// <returns>obj</returns>
    public T? CreateOrUpdateEntity(T obj)
    {
      var exists = Entities.FirstOrDefault(x => FindMatch(x, obj, IdPropertyName));
      if (exists != null) Entities.Remove(exists);
      Entities.Add(obj);
      return obj;
    }


    /// <summary>
    /// Create Or Update Entity
    /// </summary>
    /// <param name="obj">obj to create or update, matches via {looks for specific id set in repository or any property with id in it for match} </param>
    /// <returns>obj</returns>
    public async Task<T?> CreateOrUpdateEntityAsync(T obj)
    {
      return CreateOrUpdateEntity(obj);
    }

    /// <summary>
    /// Delete Entity
    /// </summary>
    /// <param name="obj">obj to delete, matches via {looks for specific id set in repository or any property with id in it for match} </param>
    /// <returns></returns>
    public bool DeleteEntity(T obj)
    {
      var exists = Entities.FirstOrDefault(x => FindMatch(x, obj, IdPropertyName));
      if (exists != null) Entities.Remove(exists);
      return true;
    }
    /// <summary>
    /// Delete Entity Async
    /// </summary>
    /// <param name="obj">obj to delete, matches via {looks for specific id set in repository or any property with id in it for match} </param>
    /// <returns></returns>
    public async Task<bool> DeleteEntityAsync(T obj)
    {
      return DeleteEntity(obj);
    }
    /// <summary>
    /// Get Entitites
    /// </summary>
    /// <returns>Entities</returns>
    public List<T> GetEntitites()
    {
      return Entities;
    }
    private void HandleDelay()
    {
      if (Delay == 0) return;
      Thread.Sleep(Delay);
    }

    private Func<T, T, string?, bool> FindMatch = (entity, otherEntity, idProperty) =>
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

    private Func<T, string?, string, bool> FindSingularMatch = (entity, idProperty, idValue) =>
    {
      var entityProperties = GetIdProperties(entity, idProperty);

      var length = entityProperties.Count();
      for (var i = 0; i < entityProperties.Count(); i++)
      {
        var entityProp = entityProperties[i];

        var entityVal = entityProp.GetValue(entity);
        if (entityVal == null) continue;
        if (entityVal.ToString() == idValue) return true;
      }
      return false;
    };

    private static List<PropertyInfo> GetIdProperties(T entity, string? idProperty = null)
    {
      var properties = entity.GetType().GetProperties().Where(x => (x.PropertyType.IsPrimitive || x.PropertyType == typeof(string))).ToList();
      if (idProperty != null) { return properties.Where(x => x.Name == idProperty).ToList(); }
      else return properties.Where(x => x.Name.ToLower().Contains("id")).OrderBy(x => x.Name).ToList();
    }

  }
}
