using Chess.Models;

public class ChessGameService
{
    private readonly ChessBoard chessBoard;
    private PieceColor currentPlayer;

    public ChessGameService()
    {
        chessBoard = new ChessBoard();
        currentPlayer = PieceColor.White;
    }

    public bool MakeMove(int sourceX, int sourceY, int targetX, int targetY)
    {
        if (!IsValidMove(sourceX, sourceY, targetX, targetY))
            return false;

        var sourcePiece = chessBoard.GetPiece(sourceX, sourceY);
        var targetPiece = chessBoard.GetPiece(targetX, targetY);

        if (targetPiece != null)
        {
        }

        chessBoard.MovePiece(sourceX, sourceY, targetX, targetY);

        currentPlayer = currentPlayer == PieceColor.White ? PieceColor.Black : PieceColor.White;

        return true;
    }

    public ChessPiece[,] GetChessBoardState()
    {
        return chessBoard.GetState();
    }

    public PieceColor GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsCheck()
    {
        var kingPosition = chessBoard.FindKing(currentPlayer);
        var opponentColor = currentPlayer == PieceColor.White ? PieceColor.Black : PieceColor.White;
        var opponentPieces = chessBoard.GetPieces(opponentColor);

        foreach (var piece in opponentPieces)
        {
            if (IsValidMove(piece.X, piece.Y, kingPosition.X, kingPosition.Y))
                return true;
        }

        return false;
    }

    public bool IsCheckmate()
    {
        if (!IsCheck())
            return false;

        var currentPlayerPieces = chessBoard.GetPieces(currentPlayer);

        foreach (var piece in currentPlayerPieces)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (IsValidMove(piece.X, piece.Y, x, y))
                        return false;
                }
            }
        }

        return true;
    }

    private bool IsValidMove(int sourceX, int sourceY, int targetX, int targetY)
    {
        var piece = chessBoard.GetPiece(sourceX, sourceY);

        if (piece == null || piece.Color != currentPlayer)
            return false;

        if (!chessBoard.IsValidPosition(targetX, targetY))
            return false;

        if (piece.Type == ChessPieceType.Pawn)
        {
            int direction = piece.Color == PieceColor.White ? -1 : 1;

            if (sourceX + direction == targetX && sourceY == targetY && chessBoard.GetPiece(targetX, targetY) == null)
                return true;

            if (sourceX + direction == targetX && Math.Abs(sourceY - targetY) == 1 && chessBoard.GetPiece(targetX, targetY) != null)
                return true;

            if (sourceX == 1 && sourceX + (2 * direction) == targetX && sourceY == targetY &&
                chessBoard.GetPiece(targetX, targetY) == null && chessBoard.GetPiece(sourceX + direction, targetY) == null)
                return true;
        }
        else if (piece.Type == ChessPieceType.Rook)
        {

            if (sourceX == targetX && sourceY != targetY)
            {
                int step = sourceY < targetY ? 1 : -1;

                for (int y = sourceY + step; y != targetY; y += step)
                {
                    if (chessBoard.GetPiece(sourceX, y) != null)
                        return false;
                }

                return true;
            }

            if (sourceX != targetX && sourceY == targetY)
            {
                int step = sourceX < targetX ? 1 : -1;

                for (int x = sourceX + step; x != targetX; x += step)
                {
                    if (chessBoard.GetPiece(x, sourceY) != null)
                        return false;
                }

                return true;
            }
        }
        else if (piece.Type == ChessPieceType.Knight)
        {
        }
        else if (piece.Type == ChessPieceType.Bishop)
        {
        }
        else if (piece.Type == ChessPieceType.Queen)
        {
        }
        else if (piece.Type == ChessPieceType.King)
        {
        }

        return false;
    }
}