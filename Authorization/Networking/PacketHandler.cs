﻿using System;

namespace Authorization.Networking {
    public abstract class PacketHandler {
        private Core.Networking.InPacket inPacket;

        public void Handle(Core.Networking.InPacket inPacket) {
            this.inPacket = inPacket;

            object attachment = inPacket.Attachment;
            if (attachment is Entities.User) {
                this.Process((Entities.User)inPacket.Attachment);
            } else if (attachment is Entities.Server) {
                this.Process((Entities.Server)inPacket.Attachment);
            } else {
                Console.WriteLine("Unknown packet attachment!");
            }
        }

        protected virtual void Process(Entities.User u) {
            Console.WriteLine(string.Concat("No user handler for PacketID: ", this.inPacket.Id));
        }
        protected virtual void Process(Entities.Server s) {
            Console.WriteLine(string.Concat("No server handler for PacketID: ", this.inPacket.Id));
        }

        protected string GetString(byte index) {
            if (index < inPacket.Blocks.Length) {
                return inPacket.Blocks[index];
            }
            return string.Empty;
        }

        protected int GetInt(byte index) {
            if (index < inPacket.Blocks.Length) {
                return int.Parse(inPacket.Blocks[index]);
            }
            return 0;
        }

        protected uint GetuInt(byte index) {
            if (index < inPacket.Blocks.Length) {
                return uint.Parse(inPacket.Blocks[index]);
            }
            return 0;
        }

        protected byte GetByte(byte index) {
            if (index < inPacket.Blocks.Length) {
                return byte.Parse(inPacket.Blocks[index]);
            }
            return 0;
        }

        protected short GetShort(byte index) {
            if (index < inPacket.Blocks.Length) {
                return short.Parse(inPacket.Blocks[index]);
            }
            return 0;
        }

        protected ushort GetUShort(byte index) {
            if (index < inPacket.Blocks.Length) {
                return ushort.Parse(inPacket.Blocks[index]);
            }
            return 0;
        }
    }
}
