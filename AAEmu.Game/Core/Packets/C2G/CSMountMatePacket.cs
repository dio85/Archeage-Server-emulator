﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Models.Game.DoodadObj.Static;

namespace AAEmu.Game.Core.Packets.C2G;

public class CSMountMatePacket : GamePacket
{
    public CSMountMatePacket() : base(CSOffsets.CSMountMatePacket, 5)
    {
    }

    public override void Read(PacketStream stream)
    {
        var tlId = stream.ReadUInt16();
        var ap = (AttachPointKind)stream.ReadByte();
        var reason = (AttachUnitReason)stream.ReadByte();

        Logger.Warn("MountMate, TlId: {0}, Ap: {1}, Reason: {2}", tlId, ap, reason);
        MateManager.Instance.MountMate(Connection, tlId, ap, reason);
    }
}
