﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.C2G;

public class CSNaviTeleportPacket : GamePacket
{
    public CSNaviTeleportPacket() : base(CSOffsets.CSNaviTeleportPacket, 5)
    {
    }

    public override void Read(PacketStream stream)
    {
        var objId = stream.ReadBc();

        Logger.Warn("NaviTeleport, ObjId: {0}", objId);
    }
}
