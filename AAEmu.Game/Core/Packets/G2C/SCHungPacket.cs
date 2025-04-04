﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.G2C;

public class SCHungPacket : GamePacket
{
    private readonly uint _unitObjId;
    private readonly uint _targetObjId;

    public SCHungPacket(uint unitObjId, uint targetObjId) : base(SCOffsets.SCHungPacket, 5)
    {
        _unitObjId = unitObjId;
        _targetObjId = targetObjId;
    }

    public override PacketStream Write(PacketStream stream)
    {
        stream.WriteBc(_unitObjId);
        stream.WriteBc(_targetObjId);
        return stream;
    }
}
