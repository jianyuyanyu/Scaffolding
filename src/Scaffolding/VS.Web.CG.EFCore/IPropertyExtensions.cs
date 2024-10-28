// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore
{
    internal static class IPropertyExtensions
    {
        internal static IPropertyMetadata ToPropertyMetadata(this IProperty property, Type dbContextType)
        {
            Contract.Assert(property != null);
            Contract.Assert(property.ClrType != null); //Do we need to make sure this is not called on Shadow properties?

            var propertyMetadata = new PropertyMetadata();
            propertyMetadata.PropertyName = property.Name;
            propertyMetadata.TypeName = property.ClrType.FullName;

            propertyMetadata.IsPrimaryKey = property.IsPrimaryKey();
            // The old scaffolding has some logic for this property in an edge case which is
            // not clear if needed any more; see EntityFrameworkColumnProvider.DetermineIsForeignKeyComponent
            propertyMetadata.IsForeignKey = property.IsForeignKey();

            propertyMetadata.IsEnum = property.ClrType.GetTypeInfo().IsEnum;
            propertyMetadata.IsReadOnly = property.GetBeforeSaveBehavior() != PropertySaveBehavior.Save;

            propertyMetadata.IsAutoGenerated = property.ValueGenerated != ValueGenerated.Never || property.GetValueGeneratorFactory() != null;
            
            propertyMetadata.ShortTypeName = TypeUtil.GetShortTypeName(property.ClrType);

            propertyMetadata.Scaffold = true;
            var declaringEntityType = property.DeclaringType as IEntityType;
            var reflectionProperty = declaringEntityType?.ClrType.GetProperty(property.Name);
            if (reflectionProperty != null)
            {
                var scaffoldAttr = reflectionProperty.GetCustomAttribute(typeof(ScaffoldColumnAttribute)) as ScaffoldColumnAttribute;
                if (scaffoldAttr != null)
                {
                    propertyMetadata.Scaffold = scaffoldAttr.Scaffold;
                }

                var dataTypeAttr = reflectionProperty.GetCustomAttribute(typeof(DataTypeAttribute)) as DataTypeAttribute;
                propertyMetadata.IsMultilineText = (dataTypeAttr != null) && (dataTypeAttr.DataType == DataType.MultilineText);
                propertyMetadata.IsRequired = reflectionProperty.GetCustomAttribute(typeof(RequiredAttribute)) is not null;
            }

            propertyMetadata.IsEnumFlags = false;
            if (propertyMetadata.IsEnum)
            {
                var flagsAttr = property.ClrType.GetTypeInfo().GetCustomAttribute(typeof(FlagsAttribute)) as FlagsAttribute;
                propertyMetadata.IsEnumFlags = (flagsAttr != null);
            }

            return propertyMetadata;
        }
    }
}
