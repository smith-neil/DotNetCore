using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DotNetCore.Data.EntityFramework.Conventions
{
    public class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            // Identify a ForeignKey properties (including IAs)
            if (!association.IsForeignKey) return;

            // rename FK columns
            var constraint = association.Constraint;

            if (DoPropertiesHaveDefaultNames(constraint.FromProperties, constraint.ToProperties))
            {
                NormalizeForeignKeyProperties(constraint.FromProperties);
            }
            if (DoPropertiesHaveDefaultNames(constraint.ToProperties, constraint.FromProperties))
            {
                NormalizeForeignKeyProperties(constraint.ToProperties);
            }
        }

        private static bool DoPropertiesHaveDefaultNames(IReadOnlyCollection<EdmProperty> properties,
                                                         IReadOnlyList<EdmProperty> otherEndProperties)
        {
            if (properties == null) throw new ArgumentNullException("properties");
            if (otherEndProperties == null) throw new ArgumentNullException("otherEndProperties");

            if (properties.Count != otherEndProperties.Count)
            {
                return false;
            }

            return !properties.Where((t, i) => !t.Name
                                                 .EndsWith("_" + otherEndProperties[i].Name))
                              .Any();
        }

        private static void NormalizeForeignKeyProperties(IEnumerable<EdmProperty> properties)
        {
            foreach (var t in properties)
            {
                var defaultPropertyName = t.Name;
                var ichUnderscore = defaultPropertyName.IndexOf('_');

                if (ichUnderscore <= 0)
                    continue;

                var navigationPropertyName = defaultPropertyName.Substring(0, ichUnderscore);
                var targetKey = defaultPropertyName.Substring(ichUnderscore + 1);

                string newPropertyName;

                if (targetKey.StartsWith(navigationPropertyName))
                {
                    newPropertyName = targetKey;
                }
                else
                {
                    newPropertyName = navigationPropertyName + targetKey;
                }

                t.Name = newPropertyName;
            }
        }
    }
}
