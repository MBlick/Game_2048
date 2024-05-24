using System;

namespace Game_2048
{
    public enum ColorOfTile
    {
        white, green, yellow, magenta, red
    }
    internal class Tile
    {
        private uint position_x, position_y;
        public uint Value { get; set; }
        private ColorOfTile color;
        public Tile() : this(0, ColorOfTile.white) { }
        private Tile(uint Value, ColorOfTile color)
        {
            this.Value = Value;
            this.color = color;
        }

        public int Position_x
        {
            get { return (int)position_x; }
            set 
            {
                if (value < 0 || 5 < value)
                {
                    Console.WriteLine("Wrong input!");
                    return;
                } else
                {
                    position_x = (uint)value;
                }
            }
        }
        public int Position_y
        {
            get { return (int)position_y; }
            set
            {
                if (value < 0 || 5 < value)
                {
                    Console.WriteLine("Wrong input!");
                    return;
                }
                else
                {
                    position_y = (uint)value;
                }
            }
        }
        public ColorOfTile Color
        {
            get { return this.color; }
            //    set
            //    {
            //        if (this.Value > 128)
            //        {
            //            this.color = ColorOfTile.red;
            //        }
            //        else if (this.Value > 64)
            //        {
            //            this.color = ColorOfTile.magenta;
            //        }
            //        else if (this.Value > 16)
            //        {
            //            this.color = ColorOfTile.yellow;
            //        }
            //    }
        }
        public void SetColorOfTile()
        {
            {
                if (this.Value >= 256)
                {
                    this.color = ColorOfTile.red;
                    return;
                }
                else if (this.Value >= 128)
                {
                    this.color = ColorOfTile.magenta;
                    return;
                }
                else if (this.Value >= 64)
                {
                    this.color = ColorOfTile.yellow;
                    return;
                }
                else if (this.Value >= 16)
                {
                    this.color = ColorOfTile.green;
                    return;
                }
                else if (this.Value >= 0)
                {
                    this.color = ColorOfTile.white;
                    return;
                }
            }
        }
    }
}
