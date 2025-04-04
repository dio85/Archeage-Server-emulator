﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.G2C;

public class SCSchoolOfFishFinderToggledPacket : GamePacket
{
    private readonly bool _on;
    private readonly float _range;

    public SCSchoolOfFishFinderToggledPacket(bool on, float range) : base(SCOffsets.SCSchoolOfFishFinderToggledPacket, 5)
    {
        _on = on;
        _range = range;
    }

    public override PacketStream Write(PacketStream stream)
    {
        stream.Write(_on);
        stream.Write(_range);

        return stream;
    }
}
