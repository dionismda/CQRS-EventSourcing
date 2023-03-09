﻿global using _Shared.Domain.Events;
global using Confluent.Kafka;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using MongoDB.Bson;
global using MongoDB.Bson.Serialization;
global using MongoDB.Bson.Serialization.Attributes;
global using MongoDB.Driver;
global using SocialMidia.Write.Domain.Aggregates;
global using SocialMidia.Write.Domain.Exceptions;
global using SocialMidia.Write.Domain.Interfaces;
global using SocialMidia.Write.Infrastructure.Configurations;
global using SocialMidia.Write.Infrastructure.Events;
global using SocialMidia.Write.Infrastructure.Handlers;
global using SocialMidia.Write.Infrastructure.Interfaces;
global using SocialMidia.Write.Infrastructure.Produces;
global using SocialMidia.Write.Infrastructure.Repositories;
global using System.Data;
global using System.Text.Json;
