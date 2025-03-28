﻿using System;
using System.Collections.Concurrent;
using System.Linq;
using AAEmu.Commons.Utils;
using AAEmu.Game.Core.Network.Connections;
using NLog;

namespace AAEmu.Game.Core.Managers;

public class AccountManager : Singleton<AccountManager>
{
    private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();

    private ConcurrentDictionary<ulong, GameConnection> _accounts;

    public AccountManager()
    {
        _accounts = new ConcurrentDictionary<ulong, GameConnection>();
        TickManager.Instance.OnTick.Subscribe(RemoveDeadConnections, TimeSpan.FromSeconds(30));
    }

    public void Add(GameConnection connection)
    {
        if (_accounts.ContainsKey(connection.AccountId))
            return;
        _accounts.TryAdd(connection.AccountId, connection);
    }

    public void RemoveDeadConnections(TimeSpan delta)
    {
        foreach (var gameConnection in _accounts.Values.ToList().Where(gameConnection => gameConnection.LastPing + TimeSpan.FromSeconds(30) < DateTime.UtcNow))
        {
            if (gameConnection.ActiveChar != null)
                Logger.Trace("Disconnecting {0} due to no network activity", gameConnection.ActiveChar.Name);
            gameConnection.Shutdown();
        }
    }

    public void Remove(ulong id)
    {
        _accounts.TryRemove(id, out _);
    }

    public bool Contains(ulong id)
    {
        return _accounts.ContainsKey(id);
    }
}
