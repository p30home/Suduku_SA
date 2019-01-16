using System.Text;

namespace AI_PROJECT
{
    public enum SudukuType
    {
        Four_Four = 4,
        Nine_Nine = 9
    }

    public class Suduku
    {
        public SudukuType SudukuType { get; set; }
        protected int _Conflicts = -1;
        public Suduku Parent { get; set; }
        public int[,] Table { get; private set; }

        private int Hash { get; set; }

        public int Depth { get; set; }

        /// <summary>
        /// parameteres in [0,3]
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        ///  <returns>returns a new class of suduku swaped , it will return null if swap makes no change</returns>
        public virtual Suduku Swap(int x1, int y1, int x2, int y2,bool storeParent = true)
        {
            if(this.Table[x1, y1] == this.Table[x2, y2])
                return null;
            int[,] newTable = new int[(int)SudukuType, (int)SudukuType];
            for(int i = 0;i < (int)SudukuType;i++)
            {
                for(int j = 0;j < (int)SudukuType;j++)
                {
                    newTable[i, j] = this.Table[i, j];
                }
            }
            int t = newTable[x1, y1];
            newTable[x1, y1] = newTable[x2, y2];
            newTable[x2, y2] = t;
            return new Suduku(this.SudukuType, newTable) { Parent = storeParent? this : null, Depth = this.Depth + 1 };
        }

        /// <summary>
        /// Indexes must be in [0,15]
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns>returns a new class of suduku swaped , it will return null if swap makes no change</returns>
        public Suduku Swap(int index1, int index2,bool StoreParent)
        {
            int upper = (int)this.SudukuType;
            int x1 = index1 / upper;
            int y1 = index1 % upper;
            int x2 = index2 / upper;
            int y2 = index2 % upper;
            return Swap(x1, y1, x2, y2,StoreParent);
        }

        protected virtual bool CalculateConflicts(int[,] Conflicts)
        {
            int upper = (int)this.SudukuType;
            Conflicts = Conflicts ?? new int[upper, upper];
            for(int i = 0;i < upper;i++)
            {
                for(int j = 0;j < upper;j++)
                {
                    InHouseCheck(i, j, Conflicts);
                    VerticalCheck(i, j, Conflicts);
                    HorizontalCheck(i, j, Conflicts);
                }
            }

            var conf = 0;
            for(int i = 0;i < upper;i++)
            {
                for(int j = 0;j < upper;j++)
                {
                    conf += Conflicts[i, j];
                }
            }
            this._Conflicts = conf;

            return true;
        }

        protected virtual bool InHouseCheck(int x, int y, int[,] Conflicts)
        {
            bool result = false;
            var upper = this.SudukuType == SudukuType.Four_Four ? 2 : 3;
            var initI = (x / upper) * upper;
            var initJ = (y / upper) * upper;
            for(int i = initI;i < initI + upper;i++)
            {
                for(int j = initJ;j < initJ + upper;j++)
                {
                    if(this.Table[i, j] == this.Table[x, y] && !(i == x && j == y))
                    {
                        //Conflicts[i, j]++;
                        Conflicts[x, y]++;
                        result = true;
                    }
                }
            }
            return result;
        }

        protected virtual bool VerticalCheck(int x, int y, int[,] Conflicts)
        {
            bool result = false;
            int upper = (int)this.SudukuType;
            for(int i = 0;i < upper;i++)
            {
                if(this.Table[i, y] == this.Table[x, y] && x != i)
                {
                    //Conflicts[i, y]++;
                    Conflicts[x, y]++;
                    result = true;
                }
            }

            return result;
        }

        protected virtual bool HorizontalCheck(int x, int y, int[,] Conflicts)
        {
            bool result = false;
            int upper = (int)this.SudukuType;
            for(int j = 0;j < upper;j++)
            {
                if(this.Table[x, j] == this.Table[x, y] && y != j)
                {
                    //Conflicts[x, j]++;
                    Conflicts[x, y]++;
                    result = true;
                }
            }
            return result;
        }

        public virtual bool Solved
        {
            get
            {
                return ConflictCount == 0;
            }
        }

        public virtual int ConflictCount
        {
            get
            {
                return this._Conflicts;
            }
        }

        public virtual double ConflictPercent
        {
            get
            {
                double a = 3 * ((int)this.SudukuType - 1) * (int)this.SudukuType * (int)this.SudukuType*10;
                return this.ConflictCount / a;
            }
        }

        public int[,] GetConflicts()
        {
            int upper = (int)this.SudukuType;
            int[,] Conflicts = new int[upper, upper];
            for(int i = 0;i < upper;i++)
            {
                for(int j = 0;j < upper;j++)
                {
                    InHouseCheck(i, j, Conflicts);
                    VerticalCheck(i, j, Conflicts);
                    HorizontalCheck(i, j, Conflicts);
                }
            }
            return Conflicts;
        }

        private void GenerateHash(int[,] table)
        {
            var upper = (int)this.SudukuType;
            StringBuilder sb = new StringBuilder(16);
            for(int i = 0;i < upper;i++)
            {
                for(int j = 0;j < upper;j++)
                {
                    sb.Append(table[i, j]);
                }
            }
            this.Hash = sb.ToString().GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.Hash;
        }

        public Suduku(SudukuType Type)
        {
            switch(Type)
            {
                case SudukuType.Four_Four:
                    this.Table = new int[4, 4]
                      { {1,2,3,4 },
                        {1,2,3,4 },
                        {1,2,3,4 },
                        {1,2,3,4 } };
                    break;

                case SudukuType.Nine_Nine:
                    this.Table = new int[9, 9]
                    {
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 },
                        {1,2,3,4,5,6,7,8,9 }
                    };
                    break;

                default:
                    break;
            }
            this.SudukuType = Type;
            CalculateConflicts(null);
            GenerateHash(this.Table);
        }

        public Suduku(SudukuType Type, int[,] Table, int[,] Conflicts = null)
        {
            this.Table = Table;
            this.SudukuType = Type;
            GenerateHash(Table);
            CalculateConflicts(Conflicts);
        }

        public Suduku(int[,] Table) : this(Table.Length == 16 ? SudukuType.Four_Four : SudukuType.Nine_Nine, Table)
        {
        }

        public override string ToString()
        {
            var upper = (int)this.SudukuType;
            StringBuilder sb = new StringBuilder(upper * upper + upper);
            for(int i = 0;i < upper;i++)
            {
                for(int j = 0;j < upper;j++)
                {
                    sb.Append(this.Table[i, j].ToString());
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}