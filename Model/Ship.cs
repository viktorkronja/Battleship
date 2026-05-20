namespace Model
{
    public class Ship
    {
        private readonly Square[] _squares;

        public Ship(IEnumerable<Square> squares)
        {
            _squares = squares.ToArray();
        }

        public int Length => _squares.Length;
    }
}
