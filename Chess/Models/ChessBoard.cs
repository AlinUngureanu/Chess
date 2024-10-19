namespace Chess.Models
{
    public class ChessBoard
    {
        private ChessPiece[,] board;

        public ChessBoard()
        {
            board = new ChessPiece[8, 8];
            InitializeBoard();
        }
        private void InitializeBoard()
        {

        }
        public bool IsValidMove(int sourceX, int sourceY, int targetX, int targetY, PieceColor currentPlayer)
        {

            if (!IsValidPosition(sourceX, sourceY) || !IsValidPosition(targetX, targetY))
                return false;


            var sourcePiece = board[sourceX, sourceY];
            if (sourcePiece == null || sourcePiece.Color != currentPlayer)
                return false;


            switch (sourcePiece.Type)
            {
                case ChessPieceType.Pawn:

                    break;
                case ChessPieceType.Rook:

                    break;
                case ChessPieceType.Bishop:

                    break;
                case ChessPieceType.Knight:

                    break;
                case ChessPieceType.Queen:

                    break;
                case ChessPieceType.King:

                    break;
            }
            return true; 
        }
        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }

        private PieceColor currentPlayer;

        public PieceColor CurrentPlayer => currentPlayer;

        public bool IsCheck => IsPlayerInCheck(currentPlayer);

        public bool IsCheckmate => IsCheck && !CanPlayerEscapeCheck(currentPlayer);

        public void MakeMove(int sourceX, int sourceY, int targetX, int targetY)
        {
            if (IsValidMove(sourceX, sourceY, targetX, targetY, currentPlayer))
            {
                var targetPiece = board[targetX, targetY];
                if (targetPiece != null)
                {
                }

                var sourcePiece = board[sourceX, sourceY];
                board[sourceX, sourceY] = null;
                board[targetX, targetY] = sourcePiece;

                currentPlayer = currentPlayer == PieceColor.White ? PieceColor.Black : PieceColor.White;
            }
            else
            {
            }
        }

        private bool IsPlayerInCheck(PieceColor playerColor)
        {
            return true;
        }

        private bool CanPlayerEscapeCheck(PieceColor playerColor)
        {
            return true;
            
        }

        public ChessPiece GetPiece(int x, int y)
        {
            return board[x, y];
        }

        public void MovePiece(int sourceX, int sourceY, int targetX, int targetY)
        {
            var piece = board[sourceX, sourceY];
            piece.X = targetX;
            piece.Y = targetY;
            board[targetX, targetY] = piece;
            board[sourceX, sourceY] = null;
        }

        public ChessPiece[,] GetState()
        {
            return board;
        }

        public ChessPiece FindKing(PieceColor color)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var piece = board[x, y];
                    if (piece != null && piece.Type == ChessPieceType.King && piece.Color == color)
                        return piece;
                }
            }

            return null;
        }

        public List<ChessPiece> GetPieces(PieceColor color)
        {
            var pieces = new List<ChessPiece>();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var piece = board[x, y];
                    if (piece != null && piece.Color == color)
                        pieces.Add(piece);
                }
            }

            return pieces;
        }
    }
}
