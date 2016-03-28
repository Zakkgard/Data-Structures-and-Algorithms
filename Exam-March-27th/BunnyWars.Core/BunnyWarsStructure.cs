namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        OrderedDictionary<string, int> bunnyByRoom = new OrderedDictionary<string, int>();
        OrderedSet<int> rooms = new OrderedSet<int>();
        OrderedDictionary<int, HashSet<Bunny>[]> roomsBunnies = new OrderedDictionary<int, HashSet<Bunny>[]>();
        Dictionary<int, OrderedSet<Bunny>> bunniesByTeam = new Dictionary<int, OrderedSet<Bunny>>();
        OrderedDictionary<string, Bunny> bunnySuffix = new OrderedDictionary<string, Bunny>(new BunnySuffixComparer());
        
        public int BunnyCount { get { return this.bunnySuffix.Count; } }

        public int RoomCount { get { return this.rooms.Count; } }

        public void AddRoom(int roomId)
        {
            if (this.roomsBunnies.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }

            this.roomsBunnies.Add(roomId, new HashSet<Bunny>[5]);
            this.rooms.Add(roomId);
        }

        public void AddBunny(string name, int team, int roomId)
        {
            var bunny = new Bunny(name, team, roomId);

            if (team < 0 || team > 4)
            {
                throw new IndexOutOfRangeException();
            }

            if (this.bunnyByRoom.ContainsKey(name) || !this.roomsBunnies.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }

            if (this.roomsBunnies[roomId][team] == null)
            {
                this.roomsBunnies[roomId][team] = new HashSet<Bunny>();
            }
            
            this.bunnyByRoom.Add(name, roomId);
            this.roomsBunnies[roomId][team].Add(bunny);
            this.bunnySuffix.Add(name, bunny);

            if (!this.bunniesByTeam.ContainsKey(team))
            {
                this.bunniesByTeam.Add(team, new OrderedSet<Bunny>());
                this.bunniesByTeam[team].Add(bunny);
            }
            else
            {
                this.bunniesByTeam[team].Add(bunny);
            }
        }

        public void Remove(int roomId)
        {
            if (!this.roomsBunnies.ContainsKey(roomId))
            {
                throw new ArgumentException();
            }

            var bunnies = this.roomsBunnies[roomId];

            foreach (var team in bunnies)
            {
                if (team == null)
                {
                    continue;
                }

                foreach (var bunny in team)
                {
                    this.bunnyByRoom.Remove(bunny.Name);
                    this.bunniesByTeam[bunny.Team].Remove(bunny);
                    this.bunnySuffix.Remove(bunny.Name);
                }
            }

            this.roomsBunnies.Remove(roomId);
            this.rooms.Remove(roomId);
        }

        public void Next(string bunnyName)
        {
            if (!this.bunnyByRoom.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var bunny = this.bunnySuffix[bunnyName];
            var roomId = bunny.RoomId;
            int nextRoom;
            if (this.rooms.IndexOf(roomId) + 1 >= this.rooms.Count)
            {
                if (this.rooms.Count != 1)
                {
                    nextRoom = this.rooms[0];
                }
                else
                {
                    nextRoom = roomId;
                }
            }
            else
            {
                nextRoom = this.rooms[this.rooms.IndexOf(roomId) + 1];
            }
            
            bunny.RoomId = nextRoom;
        }

        public void Previous(string bunnyName)
        {
            if (!this.bunnyByRoom.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var bunny = this.bunnySuffix[bunnyName];
            var roomId = bunny.RoomId;
            int prevRoom;
            if (this.rooms.IndexOf(roomId) - 1 < 0)
            {
                if (this.rooms.Count != 1)
                {
                    prevRoom = this.rooms[this.rooms.Count - 1];
                }
                else
                {
                    prevRoom = roomId;
                }
            }
            else
            {
                prevRoom = this.rooms[this.rooms.IndexOf(roomId) - 1];
            }
            
            bunny.RoomId = prevRoom;
        }

        public void Detonate(string bunnyName)
        {
            if (!this.bunnyByRoom.ContainsKey(bunnyName))
            {
                throw new ArgumentException();
            }

            var detonatingBunny = this.bunnySuffix[bunnyName];
            var room = this.roomsBunnies[detonatingBunny.RoomId];
            var bunniesToRemove = new HashSet<Bunny>();
            
            for (int i = 0; i < 5; i++)
            {
                if (detonatingBunny.Team == i || room[i] == null)
                {
                    continue;
                }

                foreach (Bunny enemy in room[i])
                {
                    enemy.Health -= 30;
                    if (enemy.Health <= 0)
                    {
                        bunniesToRemove.Add(enemy);
                    }
                }
            }

            foreach (var bunny in bunniesToRemove)
            {
                this.roomsBunnies[bunny.RoomId][bunny.Team].Remove(bunny);
                this.bunniesByTeam[bunny.Team].Remove(bunny);
                this.bunnySuffix.Remove(bunny.Name);
                detonatingBunny.Score++;
            }
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            if (team < 0 || team > 4)
            {
                throw new IndexOutOfRangeException();
            }

            return this.bunniesByTeam[team];
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            return this.bunnySuffix.Range(suffix, true, char.MaxValue + suffix, true).Values;
        }
    }
}
