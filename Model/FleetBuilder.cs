namespace Model
{
    public class FleetBuilder
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly int[] _shipLengths;

        public FleetBuilder(int rows, int columns, int[] shipLengths)
        {
            _rows = rows;
            _columns = columns;
            _shipLengths = shipLengths;
        }
    }
}
