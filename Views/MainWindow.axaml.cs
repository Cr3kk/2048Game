using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Layout;
using _2048Game.Source;

namespace _2048Game.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                case Key.Down:
                case Key.Left:
                case Key.Right:
                    bool placedTile = false;

                    while (!placedTile)
                    {
                        bool gameOver = GameOverCheck.Check();
                        if (gameOver)
                        {
                            var gameOverScreen = new GameOverScreen();
                            this.Content = gameOverScreen;
                            break;
                        }
                        placedTile = SpawnNewTile.SpawnRandomTile();
                    }
                    UpdateColours.UpdateTileColours();
                    bool win = WinCheck.Check();
                    if (win)
                    {
                        this.KeyDown -= OnKeyDown;

                        var closeButton = new Button
                        {
                            Content = "Close",
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                        };
                        closeButton.Click += Close_Click;

                        var existingContent = this.Content as Panel;
                        existingContent?.Children.Add(closeButton);  
                        this.Content = existingContent;
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("HUH?");
                    break;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Close_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
