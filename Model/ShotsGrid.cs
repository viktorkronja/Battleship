namespace Model
{
    public class ShotsGrid : Grid
    {
        public ShotsGrid(int rows, int columns) : base(rows, columns)
        {
        }

        public void ChangeSquareState(int row, int column, SquareState state)
        {
            _squares[row, column]?.ChangeState(state);
        }

        protected override bool IsSquareAvailable(int row, int column)
        {
            return _squares[row, column] != null && _squares[row, column]!.State == SquareState.None;
        }
    }
}
