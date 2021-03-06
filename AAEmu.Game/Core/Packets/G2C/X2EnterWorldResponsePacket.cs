﻿using AAEmu.Commons.Network;
using AAEmu.Commons.Utils;
using AAEmu.Game.Core.Network.Connections;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.G2C
{
    public class X2EnterWorldResponsePacket : GamePacket
    {
        private readonly GameConnection _connection;
        private readonly short _reason;
        private readonly uint _token;
        private readonly ushort _port;
        private readonly bool _gm;
        private readonly byte[] _publicKey;
        private readonly int _authority;

        public X2EnterWorldResponsePacket(short reason, bool gm, uint token, ushort port, GameConnection connection) :
            base(SCOffsets.X2EnterWorldResponsePacket, 5)
        {
            _connection = connection;
            _reason = reason;
            _token = token;
            _port = port;
            _gm = gm;

        }

        public override PacketStream Write(PacketStream stream)
        {
            //stream.Write(new byte[] {
            //    0x00, 0x00, 0x00, 0x80, 0x0E, 0x57, 0xB6, 0xE2, 0x04, 0x50, 0xDA, 0x88, 0x5C, 0x00, 0x00, 0x00, 0x00, 0x4C, 0xFF, 0xFF,
            //    0xFF, 0x04, 0x01, 0x04, 0x01, 0x00, 0x04, 0x00, 0x00, 0xE6, 0x0F, 0x3F, 0x0E, 0x39, 0x0F, 0xDE, 0x4B, 0x51, 0x10, 0x2A,
            //    0xAC, 0x66, 0xFD, 0x0D, 0xDF, 0x98, 0xA2, 0x60, 0x1E, 0x1E, 0x76, 0xBC, 0x23, 0x24, 0x5A, 0x0C, 0xA4, 0x93, 0x5D, 0xA4, 0xEF, 0x74, 0x9D, 0x9F, 0xA9, 0x2A, 0x1D, 0x1B, 0x04, 0x37, 0xC0, 0x2B,
            //    0xCF, 0xBC, 0x34, 0x90, 0x35, 0x8A, 0x16, 0xE4, 0xA9, 0xA2, 0x8F, 0x49, 0xAF, 0x24, 0x64, 0xFE, 0x08, 0x25, 0xE3, 0xFA, 0x8B, 0x20, 0xFB, 0xB9, 0x28, 0xBE, 0xC0, 0x6D, 0x4B, 0x39, 0x61, 0x0B, 0xEF,
            //    0xD5, 0x83, 0x72, 0x04, 0x99, 0xA2, 0xE1, 0x65, 0xE5, 0x4D, 0x3A, 0xA1, 0x0D, 0x14, 0x2E, 0xD7, 0xD6, 0xA4, 0xB9, 0x92, 0x33, 0x74, 0x16, 0xBA, 0xAE, 0xEC,
            //    0xF0, 0x3A, 0x0C, 0x61, 0x6D, 0x51, 0x88, 0x75, 0xEA, 0x0C, 0xBE, 0x39, 0x1B, 0xE1, 0xFF,
            //    0xBD, 0x63, 0x88, 0xFC, 0x9E, 0xBF, 0x8C, 0x30, 0x16, 0x93, 0xB9, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0xEE, 0x16, 0x5C, 0x02, 0x1F, 0x63
            //}, false);

            //расшифрованные данные из снифа пакета
            //3.0.3.0
            // size hash crc idx opcode data
            //"2901 DD05 F2  00  0000   0000 00 4634FC94 E204 4D42535B00000000 4CFFFFFF 0401 0401 00040000 AFFB77BE14B5F0D8870389AE349D2ACB6AADE7426175217E2155D54A4C4D278B7B29FA00C3A1FDD8A2C7A344F111A5227E21B6F38105C7EB3C0E9748D3834EA2F0924B7B372B03ADDD41473194A7F0D5B242A15464680EC91B052334312623861051AE76E93936E462E9186A02199B6C6E16604CE5D51811A7CF75A3F35C3B390 000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010001 773F8B05 CDC9"
            // 2901 DD05 3C  00  0000   0000 00 389416E0 E204 91E6305B00000000 4CFFFFFF 0401 0401 00040000 BBC0E9659E21640C4D689287322A627C63B8FD9EEDAF0C3999D14079393F023B1D6B032D574F2F787C814D90D137DAFD93E5577EDE35E1696A40B0DC031FB1D333E038A15163D278615FEFB9275D9FBD5B99E77F6890D8DA04F226267FCDC487E1A1DCAEB23A13399699B3617BF59C9DF85A81519C5093D61C5F44B8045FEEE90 000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010001 FC73AE55 22ED
            //c пустым ключом pubkey не работает
            stream.Write(_reason);               // Reason 0
            stream.Write(_gm);                   // GM 0 поле есть в 3.0.3.0, но нет в 3.5.5.3
            stream.Write(_token);                // SC 0
            stream.Write(_port);                 // SP 1250
            stream.Write(Helpers.UnixTimeNow()); // WF 0
            stream.Write((uint)0xffffff4c);      // TZ 0
            stream.Write((short)260);            // H, Public Key Size  0401 (Should be 260)
            stream.Write((short)260);            // H, Pub key len (in pub key) 128 * 2 + 4 = 260
            stream.Write((uint)1024);            // 1024
            //----- RSA -----
            GameConnection.CryptRsa.Rsa.ImportCspBlob(GameConnection.CryptRsa.PubKey); //получить публичный ключ
            var publicKey = GameConnection.CryptRsa.Rsa.ExportParameters(false);
            GameConnection.CryptRsa.Modulus = publicKey.Modulus;
            stream.Write(GameConnection.CryptRsa.Modulus);
            //string e ="0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" + ex; //"010001";
            byte[] e = new byte[125];
            stream.Write(e);
            GameConnection.CryptRsa.Exponent = publicKey.Exponent;
            stream.Write(GameConnection.CryptRsa.Exponent);
            //----- RSA -----
            // IP Adress and Port of client??
            //stream.Write((byte)10); // nat Addr
            //stream.Write((byte)1);
            //stream.Write((byte)1);
            //stream.Write((byte)113);
            stream.Write((uint)0x025c16ee); //port
            stream.Write((ushort)25375); //port
            //stream.Write(_authority);                   // authority 1 это поле есть в 3.5.5.3, но нет в 3.0.3.0

            return stream;
        }
    }
}
