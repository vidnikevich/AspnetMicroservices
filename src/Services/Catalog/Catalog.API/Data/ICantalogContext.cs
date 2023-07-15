﻿using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public interface ICantalogContext
    {
        IMongoCollection<Product> Products { get; }

    }
}
