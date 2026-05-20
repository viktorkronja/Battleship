namespace Model
{
    public record struct Coordinate(int Row, int Column);

    public class Square
    {
        public Coordinate Position { get; }

        public Square(int row, int column)
        {
            Position = new Coordinate(row, column);
        }
    }
}
