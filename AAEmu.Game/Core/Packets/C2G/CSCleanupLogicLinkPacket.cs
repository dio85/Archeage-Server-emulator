﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.C2G;

public class CSCleanupLogicLinkPacket : GamePacket
{
    public CSCleanupLogicLinkPacket() : base(CSOffsets.CSCleanupLogicLinkPacket, 5)
    {
    }

    public override void Read(PacketStream stream)
    {
        var objId = stream.ReadBc();

        Logger.Warn("CleanupLogicLink, ObjId: {0}", objId);
    }
}
