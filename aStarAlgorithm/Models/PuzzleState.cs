namespace aStarAlgorithm.Models;

public class PuzzleState
{
    public int[,] Tiles { get; set; }
    public PuzzleState? Parent { get; set; }
    public int CostG { get; set; }
    public int CostH { get; set; }
    public int CostF => CostG + CostH;

    public PuzzleState(int[,] tiles, PuzzleState? parent = null, int costG = 0)
    {
        Tiles = (int[,])tiles.Clone();
        Parent = parent;
        CostG = costG;
        CostH = 0;
    }

    public string GetHash()
    {
        return string.Join(",", Tiles.Cast<int>());
    }

    public bool IsGoal(int[,] goal)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (Tiles[i, j] != goal[i, j])
                    return false;
        return true;
    }

    public void CalculateHeuristic(int[,] goal)
    {
        int h = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int value = Tiles[i, j];
                if (value == 0) continue;

                for (int m = 0; m < 3; m++)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        if (goal[m, n] == value)
                        {
                            h += Math.Abs(i - m) + Math.Abs(j - n);
                            goto NextTile;
                        }
                    }
                }
            NextTile:;
            }
        }
        CostH = h;
    }

    public List<PuzzleState> GenerateNextStates()
    {
        List<PuzzleState> nextStates = new();
        int row = 0, col = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Tiles[i, j] == 0)
                {
                    row = i;
                    col = j;
                    goto Found;
                }
            }
        }
    Found:

        int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

        for (int d = 0; d < 4; d++)
        {
            int newRow = row + directions[d, 0];
            int newCol = col + directions[d, 1];

            if (newRow >= 0 && newRow < 3 && newCol >= 0 && newCol < 3)
            {
                int[,] newTiles = (int[,])Tiles.Clone();
                (newTiles[row, col], newTiles[newRow, newCol]) = (newTiles[newRow, newCol], newTiles[row, col]);
                nextStates.Add(new PuzzleState(newTiles, this, this.CostG + 1));
            }
        }

        return nextStates;
    }

    public override string ToString()
    {
        return $"{Tiles[0, 0]} {Tiles[0, 1]} {Tiles[0, 2]}\n" +
               $"{Tiles[1, 0]} {Tiles[1, 1]} {Tiles[1, 2]}\n" +
               $"{Tiles[2, 0]} {Tiles[2, 1]} {Tiles[2, 2]}";
    }
}
