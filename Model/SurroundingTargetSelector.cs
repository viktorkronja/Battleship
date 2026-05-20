namespace Model
{
    public class SurroundingTargetSelector : ITargetSelector
    {
        private readonly ShotsGrid _grid;
        private readonly Queue<Coordinate> _candidates = new();

        public SurroundingTargetSelector(ShotsGrid grid, Square hitSquare)
        {
            _grid = grid;
            int r = hitSquare.Position.Row;
            int c = hitSquare.Position.Column;

            TryAdd(r - 1, c);
            TryAdd(r + 1, c);
            TryAdd(r, c - 1);
            TryAdd(r, c + 1);
        }

        private void TryAdd(int row, int column)
        {
            if (row >= 0 && row < _grid.Rows && column >= 0 && column < _grid.Columns)
            {
                var square = _grid.Squares.FirstOrDefault(s =>
                    s.Position.Row == row && s.Position.Column == column && s.State == SquareState.None);
                if (square != null)
                {
                    _candidates.Enqueue(new Coordinate(row, column));
                }
            }
        }

        public Square Next()
        {
            while (_candidates.Count > 0)
            {
                var coord = _candidates.Dequeue();
                var square = _grid.Squares.FirstOrDefault(s =>
                    s.Position.Row == coord.Row && s.Position.Column == coord.Column && s.State == SquareState.None);
                if (square != null)
                    return square;
            }
            throw new InvalidOperationException("No surrounding targets available.");
        }
    }
}
