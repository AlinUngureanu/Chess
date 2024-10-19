namespace Chess.Models
{
    public enum PieceColor
    {
        White,
        Black
    }
    public enum ChessPieceType
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }
    public class ChessPiece
    {
        public PieceColor Color { get; set; }
        public ChessPieceType Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
