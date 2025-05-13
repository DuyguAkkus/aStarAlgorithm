using Microsoft.AspNetCore.Mvc;
using aStarAlgorithm.Models;

namespace aStarAlgorithm.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PuzzleInputViewModel());
        }
        public IActionResult Courses()
        {
            return View(new PuzzleInputViewModel());
        }

        [HttpPost]
        public IActionResult Solve(PuzzleInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var startState = ConvertToMatrix(model.Start);
            var goalState = ConvertToMatrix(model.Goal);

            var solver = new PuzzleSolver();
            var solutionPath = solver.Solve(startState, goalState);

            ViewBag.Steps = solutionPath;
            ViewBag.ErrorMessage = solutionPath.Count == 0 ? "Çözüm bulunamadı." : null;

            return View();
        }

        private int[,] ConvertToMatrix(string input)
        {
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < 9; i++)
            {
                matrix[i / 3, i % 3] = int.Parse(input[i].ToString());
            }
            return matrix;
        }
    }
}