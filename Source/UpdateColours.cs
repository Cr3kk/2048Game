using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using _2048Game.Views;

namespace _2048Game.Source
{
    public class UpdateColours
    {
        public static void UpdateTileColours()
        {
            var lifetime = Application.Current?.ApplicationLifetime as ClassicDesktopStyleApplicationLifetime;
            var mainWindow = lifetime?.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        Border? border = mainWindow.FindControl<Border>($"border_{row}_{col}");
                        TextBlock? textBlock = mainWindow.FindControl<TextBlock>($"label_{row}_{col}");

                        if (border != null && textBlock != null)
                        {
                            switch (textBlock.Text)
                            {
                                case "2":
                                    border.Background = new SolidColorBrush(Colors.Cornsilk); 
                                    break;
                                case "4":
                                    border.Background = new SolidColorBrush(Colors.LightYellow); 
                                    break;
                                case "8":
                                    border.Background = new SolidColorBrush(Colors.BurlyWood); 
                                    break;
                                case "16":
                                    border.Background = new SolidColorBrush(Colors.Orange); 
                                    break;
                                case "32":
                                    border.Background = new SolidColorBrush(Colors.Pink); 
                                    break;
                                case "64":
                                    border.Background = new SolidColorBrush(Colors.Red); 
                                    break;
                                case "128":
                                    border.Background = new SolidColorBrush(Colors.LightYellow); 
                                    break;
                                case "256":
                                    border.Background = new SolidColorBrush(Colors.Yellow); 
                                    break;
                                case "512":
                                    border.Background = new SolidColorBrush(Colors.Gold); 
                                    break;
                                case "1024":
                                    border.Background = new SolidColorBrush(Colors.Chartreuse); 
                                    break;
                                case "2048":
                                    border.Background = new SolidColorBrush(Colors.Chartreuse); 
                                    break;
                                default:
                                    border.Background = new SolidColorBrush(Colors.Gray);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}