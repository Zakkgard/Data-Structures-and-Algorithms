namespace ConnectedAreas
{
    using System;

    public class Area : IComparable<Area>
    {
        public Area(int size, int row, int col)
        {
            this.Size = size;
            this.Row = row;
            this.Col = col;
        }

        public int Size { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public int CompareTo(Area other)
        {
            int compareSize = -1 * this.Size.CompareTo(other.Size);
            if (compareSize == 0)
            {
                int compareRows = this.Row.CompareTo(other.Row);
                if (compareRows == 0)
                {
                    return this.Col.CompareTo(other.Col);
                }
                else
                {
                    return compareRows;
                }
            }
            else
            {
                return compareSize;
            }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}), size: {2}", this.Row, this.Col, this.Size);
        }
    }
}
