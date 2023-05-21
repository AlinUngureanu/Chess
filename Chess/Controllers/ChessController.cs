using Microsoft.AspNetCore.Mvc;

namespace Chess.Controllers
{
    public class ChessController : Controller
    {
        private readonly ChessGameService chessGameService;

        public ChessController(ChessGameService chessGameService)
        {
            this.chessGameService = chessGameService;
        }

        public IActionResult Index()
        {
            var chessBoardState = chessGameService.GetChessBoardState();

            ViewData["ChessBoardState"] = chessBoardState;
            ViewData["CurrentPlayer"] = chessGameService.GetCurrentPlayer();

            return View();
        }

        [HttpPost]
        public IActionResult MakeMove(int sourceX, int sourceY, int targetX, int targetY)
        {
            var moveResult = chessGameService.MakeMove(sourceX, sourceY, targetX, targetY);

            if (moveResult)
            {
                if (chessGameService.IsCheckmate())
                {
                    return RedirectToAction("GameOver");
                }
                else if (chessGameService.IsCheck())
                {
                    return RedirectToAction("Check");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid move.");
                return RedirectToAction("Index");
            }
        }
        public IActionResult GameOver()
        {
            return View();
        }

        public IActionResult Check()
        {
            return View();
        }
    }
}
