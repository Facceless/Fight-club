using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_club
{
    class Player
    {
        string Name { get; set; }
       public enum Part_of_the_body
        {
            Head = 0,
            Body = 1,
            Legs = 2
        };
        Part_of_the_body hit;
        Part_of_the_body block;
        public Part_of_the_body Hit{ get { return hit; } }
        public Part_of_the_body Block { get { return block; } }
        public int Hp;
        //public int Hp { get; set; }
        public Player()
        {
            Name = null;
            Hp = 100;
        }
        public Player(string name)
        {
            Name = name;
            Hp = 100;
        }

        public void GetHit(int part)
        {
            hit = (Part_of_the_body)part;
        }

        public void SetBlock(int part)
        {
            block = (Part_of_the_body)part;
        }
    }
}
