﻿using System;

using AAEmu.Commons.Network;

namespace AAEmu.Game.Models.Game.Units.Movements;

public class ShipMoveType : MoveType
{
    public new short RotationX { get; set; }
    public new short RotationY { get; set; }
    public new short RotationZ { get; set; }
    public float AngVelX { get; set; }
    public float AngVelY { get; set; }
    public float AngVelZ { get; set; }
    public sbyte Steering { get; set; }
    public sbyte Throttle { get; set; }
    public sbyte Rpm { get; set; }
    public ushort ZoneId { get; set; }
    public bool Stuck { get; set; }

    public override void Read(PacketStream stream)
    {
        base.Read(stream);
        (X, Y, Z) = stream.ReadPosition();
        VelX = stream.ReadInt16();
        VelY = stream.ReadInt16();
        VelZ = stream.ReadInt16();
        RotationX = stream.ReadInt16();
        RotationY = stream.ReadInt16();
        RotationZ = stream.ReadInt16();

        AngVelX = stream.ReadSingle();
        AngVelY = stream.ReadSingle();
        AngVelZ = stream.ReadSingle();
        Steering = stream.ReadSByte();
        Throttle = stream.ReadSByte();
        Rpm = stream.ReadSByte();
        ZoneId = stream.ReadUInt16();
        Stuck = stream.ReadBoolean();
    }

    public override PacketStream Write(PacketStream stream)
    {
        base.Write(stream);
        stream.WritePosition(X, Y, Z);

        stream.Write(VelX);
        stream.Write(VelY);
        stream.Write(VelZ);

        stream.Write(RotationX);
        stream.Write(RotationY);
        stream.Write(RotationZ);

        stream.Write(AngVelX);
        stream.Write(AngVelY);
        stream.Write(AngVelZ);

        stream.Write(Steering);
        stream.Write(Throttle);
        stream.Write(Rpm);

        stream.Write(ZoneId);
        stream.Write(Stuck);

        return stream;
    }

    public void UseSlaveBase(Slave slave)
    {
        X = slave.Transform.World.Position.X;
        Y = slave.Transform.World.Position.Y;
        Z = slave.Transform.World.Position.Z;
        (RotationX, RotationY, RotationZ) = slave.Transform.World.ToRollPitchYawShorts();
        VelX = 0;
        VelY = 0;
        VelZ = 0;
        AngVelX = 0;
        AngVelY = 0;
        AngVelZ = 0;
        ZoneId = (ushort)slave.Transform.ZoneId;
        Time = (uint)(DateTime.UtcNow - slave.SpawnTime).TotalMilliseconds;
        Stuck = false;
        Throttle = slave.ThrottleRequest;
        Rpm = slave.Rpm;
        Steering = slave.SteeringRequest;
    }
}
