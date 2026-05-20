namespace Model
{
    public class RandomTargetSelector : ITargetSelector
    {
        private readonly ShotsGrid _grid;
        private readonly int _shipLength;
        private readonly Random _random = new();

        public RandomTargetSelector(ShotsGrid grid, int shipLength)
        {
            _grid = grid;
            _shipLength = shipLength;
        }

        public Square Next()
        {
            var placements = _grid.GetAvailablePlacements(_shipLength);
            var candidates = placements.SelectMany(s => s).Distinct().ToList();
            return candidates[_random.Next(candidates.Count)];
        }
    }
}
