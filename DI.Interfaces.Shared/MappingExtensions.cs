using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DI.Interfaces.Shared
{
    public static class MappingExtensions
    {
        public static TEntity MapProperties<IRequest, TEntity>(this TEntity entity, IRequest request)
        {
            if (request is null || entity is null)
                throw new NullReferenceException($"Exception into {typeof(IRequest).Name}.MapTo<{typeof(TEntity).Name}>");

            var entityProperties = entity.GetType().GetProperties().Where(e => e.IsKey() == false).ToList();
            var requestProperties = request.GetType().GetProperties().ToList();
            foreach (var requestProperty in requestProperties)
            {
                var entityProperty = entityProperties.Find(e => e.Name == requestProperty.Name);

                if (entityProperty is null)
                    continue;

                var requestValue = requestProperty.GetValue(request);

                if (requestProperty.IsReference())
                {
                    if (requestValue is null)
                        continue;

                    var entityReference = entityProperty.GetValue(entity) ?? Activator.CreateInstance(entityProperty.PropertyType);
                    entityReference.MapProperties(requestValue);
                    entityProperty.SetValue(entity, entityReference);
                    continue;
                }
                if (typeof(IEnumerable).IsAssignableFrom(requestProperty.PropertyType) && requestProperty.PropertyType != typeof(string))
                {
                    //var childRequests = requestValue as IEnumerable;
                    //var childEntities = entityProperty.GetValue(entity) as IEnumerable;
                    //var childKey = childRequests.GetType().GenericTypeArguments[0].GetType().GetProperties().Where(e => Attribute.GetCustomAttribute(e, typeof(KeyAttribute)) != null).FirstOrDefault();
                    //foreach (var requestChild in childRequests)
                    //{

                    //}
                    continue;
                }
                entityProperty.SetValue(entity, requestValue);
            }

            return entity;
        }

        public static bool IsReference(this PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(ReferenceAttribute), true).Length > 0;
        }

        public static bool IsKey(this PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0;
        }

    }

    public class ReferenceAttribute : Attribute
    {
    }
}