namespace Model
{
    public class Fleet
    {
        private readonly List<Ship> _ships = new();

        public IReadOnlyList<Ship> Ships => _ships;
    }
}
