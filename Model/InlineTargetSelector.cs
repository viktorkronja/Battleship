namespace Model
{
    public class InlineTargetSelector : ITargetSelector
    {
        private readonly ShotsGrid _grid;
        private readonly List<Square> _hitSquares;

        public InlineTargetSelector(ShotsGrid grid, List<Square> hitSquares)
        {
            _grid = grid;
            _hitSquares = hitSquares.OrderBy(s => s.Position.Row).ThenBy(s => s.Position.Column).ToList();
        }

        public Square Next()
        {
            var first = _hitSquares.First();
            var last = _hitSquares.Last();

            bool isHorizontal = first.Position.Row == last.Position.Row;

            if (isHorizontal)
            {
                var forward = TryGetSquare(first.Position.Row, last.Position.Column + 1);
                if (forward != null) return forward;

                var backward = TryGetSquare(first.Position.Row, first.Position.Column - 1);
                if (backward != null) return backward;
            }
            else
            {
                var down = TryGetSquare(last.Position.Row + 1, first.Position.Column);
                if (down != null) return down;

                var up = TryGetSquare(first.Position.Row - 1, first.Position.Column);
                if (up != null) return up;
            }

            throw new InvalidOperationException("No inline targets available.");
        }

        private Square? TryGetSquare(int row, int column)
        {
            if (row < 0 || row >= _grid.Rows || column < 0 || column >= _grid.Columns)
                return null;

            return _grid.Squares.FirstOrDefault(s =>
                s.Position.Row == row && s.Position.Column == column && s.State == SquareState.None);
        }
    }
}
