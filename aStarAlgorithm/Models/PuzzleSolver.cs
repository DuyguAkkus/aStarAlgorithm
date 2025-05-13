using System.Collections.Generic;

namespace aStarAlgorithm.Models
{
    public class PuzzleSolver
    {
        public List<PuzzleState> Solve(int[,] start, int[,] goal)
        {
            var startState = new PuzzleState(start);
            startState.CalculateHeuristic(goal);

            // Öncelikli kuyruk: CostF değeri düşük olan en önde
            var openList = new PriorityQueue<PuzzleState, int>();
            openList.Enqueue(startState, startState.CostF);

            // Zaten kontrol edilen durumlar
            var closedSet = new HashSet<string>();

            int stepCount = 0;
            int stepLimit = 100_000; // Performans sınırı

            while (openList.Count > 0)
            {
                if (stepCount++ > stepLimit)
                {
                    // Sonsuz döngü ya da çözüm yok
                    return new List<PuzzleState>();
                }

                var current = openList.Dequeue();
                var currentHash = current.GetHash();

                if (closedSet.Contains(currentHash))
                    continue;

                closedSet.Add(currentHash);

                // Hedefe ulaşıldı mı?
                if (current.IsGoal(goal))
                    return ReconstructPath(current);

                // Komşu durumları üret
                var neighbors = current.GenerateNextStates();

                foreach (var neighbor in neighbors)
                {
                    var hash = neighbor.GetHash();

                    if (closedSet.Contains(hash))
                        continue;

                    neighbor.CalculateHeuristic(goal);
                    openList.Enqueue(neighbor, neighbor.CostF);
                }
            }

            // Eğer buraya geldiyse çözüm yok
            return new List<PuzzleState>();
        }

        private List<PuzzleState> ReconstructPath(PuzzleState goalState)
        {
            var path = new List<PuzzleState>();
            var current = goalState;

            while (current != null)
            {
                path.Add(current);
                current = current.Parent;
            }

            path.Reverse(); // Baştan sona sıralama
            return path;
        }
    }
}
