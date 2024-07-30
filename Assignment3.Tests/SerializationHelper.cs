using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            using (FileStream stream = File.Create(fileName))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(users.Count());

                    for (int i = 0; i < users.Count(); i++)
                    {
                        User user = users.GetValue(i);
                        writer.Write(user.Id);
                        writer.Write(user.Name);
                        writer.Write(user.Email);
                        writer.Write(user.Password);
                    }
                }
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            SLL users = new SLL();

            using (FileStream stream = File.OpenRead(fileName))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    int count = reader.ReadInt32();

                    for (int i = 0; i < count; i++)
                    {
                        int id = reader.ReadInt32();
                        string name = reader.ReadString();
                        string email = reader.ReadString();
                        string password = reader.ReadString();
                        users.AddLast(new User(id, name, email, password));
                    }
                }
            }

            return (ILinkedListADT)users;
        }
    }
}
