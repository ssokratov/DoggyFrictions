using System;
using System.Linq;
using DoggyFriction.Models;
using DoggyFriction.Services.Repository.Models;
using Action = DoggyFriction.Models.Action;

namespace DoggyFriction.Services.Repository
{
    internal static class MongoContractMapping
    {
        public static string GetOrCreateId(string id)
            => id.IsNullOrEmpty() || id == "0" ? Guid.NewGuid().ToString() : id;

        public static Session FromModel(this SessionModel model)
        {
            return new Session
            {
                Id = model.Id,
                Name = model.Name,
                Participants = model.Participants.Select(FromModel)
            };
        }

        public static SessionModel ToModel(this Session model)
        {
            return new SessionModel
            {
                Id = GetOrCreateId(model.Id),
                Name = model.Name,
                Participants = model.Participants.Select(ToModel)
            };
        }

        public static Participant FromModel(this ParticipantModel model)
        {
            return new Participant
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static ParticipantModel ToModel(this Participant model)
        {
            return new ParticipantModel
            {
                Id = GetOrCreateId(model.Id),
                Name = model.Name
            };
        }

        public static Action FromModel(this ActionModel model)
        {
            return new Action
            {
                Id = model.Id,
                SessionId = model.SessionId,
                Description = model.Description,
                Date = model.Date,
                Payers = model.Payers.Select(FromModel),
                Consumptions = model.Consumptions.Select(FromModel)
            };
        }

        public static ActionModel ToModel(this Action model)
        {
            return new ActionModel
            {
                Id = GetOrCreateId(model.Id),
                SessionId = model.SessionId,
                Description = model.Description,
                Date = model.Date,
                Payers = model.Payers.Select(ToModel),
                Consumptions = model.Consumptions.Select(ToModel)
            };
        }

        public static Payer FromModel(this PayerModel model)
        {
            return new Payer
            {
                Amount = model.Amount,
                ParticipantId = model.ParticipantId
            };
        }

        public static PayerModel ToModel(this Payer model)
        {
            return new PayerModel
            {
                Amount = model.Amount,
                ParticipantId = model.ParticipantId
            };
        }

        public static ConsumptionModel ToModel(this Consumption model)
        {
            return new ConsumptionModel
            {
                Amount = model.Amount,
                Description = model.Description,
                Quantity = model.Quantity,
                SplittedEqually = model.SplittedEqually,
                Consumers = model.Consumers.Select(ToModel)
            };
        }

        public static Consumption FromModel(this ConsumptionModel model)
        {
            return new Consumption
            {
                Amount = model.Amount,
                Description = model.Description,
                Quantity = model.Quantity,
                SplittedEqually = model.SplittedEqually,
                Consumers = model.Consumers.Select(FromModel)
            };
        }

        public static Consumer FromModel(this ConsumerModel model)
        {
            return new Consumer
            {
                Amount = model.Amount,
                ParticipantId = model.ParticipantId
            };
        }

        public static ConsumerModel ToModel(this Consumer model)
        {
            return new ConsumerModel
            {
                Amount = model.Amount,
                ParticipantId = model.ParticipantId
            };
        }
    }
}