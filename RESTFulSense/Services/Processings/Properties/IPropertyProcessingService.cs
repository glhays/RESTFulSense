﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.Properties;

namespace RESTFulSense.Services.Processings.Properties
{
    internal interface IPropertyProcessingService
    {
        IEnumerable<PropertyValue> RetrieveProperties<T>(T @object) where T : class;
    }
}