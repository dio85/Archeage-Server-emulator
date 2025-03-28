﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Managers.World;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Core.Packets.G2C;
using AAEmu.Game.Models.Game.DoodadObj;

namespace AAEmu.Game.Core.Packets.C2G;

public class CSHangPacket : GamePacket
{
    public CSHangPacket() : base(CSOffsets.CSHangPacket, 5)
    {
    }

    public override void Read(PacketStream stream)
    {
        var unitObjId = stream.ReadBc();
        var targetObjId = stream.ReadBc();

        Logger.Trace($"Hang, unitObjId: {unitObjId}, targetObjId: {targetObjId}");
        var character = WorldManager.Instance.GetBaseUnit(unitObjId);
        var target = WorldManager.Instance.GetGameObject(targetObjId);
        if (character != null && target != null)
            character.Transform.StickyParent = target.Transform;
        Connection.ActiveChar.BroadcastPacket(new SCHungPacket(unitObjId, targetObjId), false);
        if (target is Doodad doodad)
        {
            doodad.Use(character);
        }
    }
}
