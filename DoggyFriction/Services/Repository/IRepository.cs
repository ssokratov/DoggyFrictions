﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoggyFriction.Models;
using Action = DoggyFriction.Models.Action;

namespace DoggyFriction.Services.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Session>> GetSessions();
        Task<Session> GetSession(string id);
        Task<Session> UpdateSession(Session model);
        Task<Session> DeleteSession(string id);
        Task<DateTime> GetLastSessionsUpdateTime();
        
        Task<IEnumerable<Action>> GetActions();
        Task<IEnumerable<Action>> GetSessionActions(string sessionId);
        Task<Action> GetAction(string sessionId, string id);
        Task<Action> UpdateAction(string sessionId, Action model);
        Task<Action> DeleteAction(string sessionId, string id);
        Task<DateTime> GetLastActionsUpdateTime();
    }
}