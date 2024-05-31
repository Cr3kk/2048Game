using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using _2048Game.Views;

namespace _2048Game.Source
{
    public partial class SpawnNewTile
    {
        public static int RandomNewTileNumber()
        {
            Random random = new Random();
            int weight = 90;
            int randomWeight = random.Next(0, 101);

            return weight < randomWeight ? 4 : 2;
        }

        public static bool SpawnRandomTile()
        {
            Random random = new Random();
            int randomTile = RandomNewTileNumber();
            int randomRow = random.Next(0, 4);
            int randomCol = random.Next(0, 4);

            var lifetime = Application.Current?.ApplicationLifetime as ClassicDesktopStyleApplicationLifetime;
            var mainWindow = lifetime?.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                TextBlock? textBlock = mainWindow.FindControl<TextBlock>($"label_{randomRow}_{randomCol}");
                if (textBlock != null && textBlock.Text == "")
                {
                    textBlock.Text = randomTile.ToString();
                    return true;
                }
            }
            return false;
        }
    }
}
