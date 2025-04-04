﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.G2C;

public class SCCharacterDeleteCanceledPacket : GamePacket
{
    private readonly uint _characterId;
    private readonly byte _deleteStatus;

    public SCCharacterDeleteCanceledPacket(uint characterId, byte deleteStatus) : base(SCOffsets.SCCharacterDeleteCanceledPacket, 5)
    {
        _characterId = characterId;
        _deleteStatus = deleteStatus;
    }

    public override PacketStream Write(PacketStream stream)
    {
        stream.Write(_characterId);
        stream.Write(_deleteStatus);
        return stream;
    }
}
