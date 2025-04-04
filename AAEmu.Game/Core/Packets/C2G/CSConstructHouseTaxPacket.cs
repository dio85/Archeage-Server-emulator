﻿using AAEmu.Commons.Network;
using AAEmu.Commons.Utils;
using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.C2G;

public class CSConstructHouseTaxPacket : GamePacket
{
    public CSConstructHouseTaxPacket() : base(CSOffsets.CSConstructHouseTaxPacket, 5)
    {
    }

    public override void Read(PacketStream stream)
    {
        var designId = stream.ReadUInt32(); // type(id)
        var x = Helpers.ConvertLongX(stream.ReadInt64());
        var y = Helpers.ConvertLongY(stream.ReadInt64());
        var z = stream.ReadSingle();

        Logger.Debug("ConstructHouseTax");
        HousingManager.Instance.ConstructHouseTax(Connection, designId, x, y, z);
    }
}
