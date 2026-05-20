namespace Model
{
    public class Grid
    {
        public int Rows { get; }
        public int Columns { get; }

        protected readonly Square?[,] _squares;

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _squares = new Square[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    _squares[r, c] = new Square(r, c);
                }
            }
        }

        public IEnumerable<Square> Squares
        {
            get { return _squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length)
        {
            return GetHorizontalPlacements(length)
                .Concat(GetVerticalPlacements(length));
        }

        protected virtual bool IsSquareAvailable(int row, int column)
        {
            return _squares[row, column] != null;
        }

        private IEnumerable<IEnumerable<Square>> GetHorizontalPlacements(int length)
        {
            var result = new List<IEnumerable<Square>>();

            for (int r = 0; r < Rows; r++)
            {
                int count = 0;
                for (int c = 0; c < Columns; c++)
                {
                    if (IsSquareAvailable(r, c))
                    {
                        count++;
                        if (count >= length)
                        {
                            var placement = new Square[length];
                            for (int i = 0; i < length; i++)
                            {
                                placement[i] = _squares[r, c - length + 1 + i]!;
                            }
                            result.Add(placement);
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }

            return result;
        }

        private IEnumerable<IEnumerable<Square>> GetVerticalPlacements(int length)
        {
            var result = new List<IEnumerable<Square>>();

            for (int c = 0; c < Columns; c++)
            {
                int count = 0;
                for (int r = 0; r < Rows; r++)
                {
                    if (IsSquareAvailable(r, c))
                    {
                        count++;
                        if (count >= length)
                        {
                            var placement = new Square[length];
                            for (int i = 0; i < length; i++)
                            {
                                placement[i] = _squares[r - length + 1 + i, c]!;
                            }
                            result.Add(placement);
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }

            return result;
        }
    }
}
