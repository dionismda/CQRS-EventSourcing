﻿global using _Shared.Domain.Events;
global using Confluent.Kafka;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using SocialMidia.Read.Domain.Consumers;
global using SocialMidia.Read.Domain.Entites;
global using SocialMidia.Read.Domain.Interfaces;
global using SocialMidia.Read.Infrastructure.Consumers;
global using SocialMidia.Read.Infrastructure.Converters;
global using SocialMidia.Read.Infrastructure.Interfaces;
global using SocialMidia.Read.Infrastructure.Persistence;
global using SocialMidia.Read.Infrastructure.Repositories;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using SocialMidiaEventHandler = SocialMidia.Read.Infrastructure.Handlers.EventHandler;
