using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using _2048Game.Views;

namespace _2048Game.Source
{
    public partial class GameOverCheck
    {
        public static bool Check()
        {
            var lifetime = Application.Current?.ApplicationLifetime as ClassicDesktopStyleApplicationLifetime;
            var mainWindow = lifetime?.MainWindow as MainWindow;

            if (mainWindow == null) return false;

            bool foundEmptyTile = false;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    TextBlock? textBlock = mainWindow.FindControl<TextBlock>($"label_{row}_{col}");
                    if (textBlock != null && textBlock.Text == "")
                    {
                        foundEmptyTile = true;
                        break;
                    }
                }
                if (foundEmptyTile) break;
            }

            return !foundEmptyTile;
        }
    }
}
