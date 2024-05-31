using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using _2048Game.Views;

namespace _2048Game.Source
{
    public partial class WinCheck
    {
        public static bool Check()
        {
            var lifetime = Application.Current?.ApplicationLifetime as ClassicDesktopStyleApplicationLifetime;
            var mainWindow = lifetime?.MainWindow as MainWindow;

            bool foundWinTile = false;

            if (mainWindow != null)
            {
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        TextBlock? textBlock = mainWindow.FindControl<TextBlock>($"label_{row}_{col}");
                        if (textBlock != null && textBlock.Text == "2048")
                        {
                            foundWinTile = true;
                            TextBlock? titleTextBlock = mainWindow.FindControl<TextBlock>("Title");
                            titleTextBlock.Text = "You Win!";
                            titleTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                            return true;
                        }
                    }
                    if (foundWinTile) break;
                }
            }

            return false;
        }
    }
}
