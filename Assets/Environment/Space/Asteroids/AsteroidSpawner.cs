using Godot;
using System;

[GlobalClass]
public partial class AsteroidSpawner : Path2D
{
    PackedScene Asteroid = GD.Load<PackedScene>("res://Assets/Environment/Space/Asteroids/asteroid.tscn");

    [Export] private float _asteroidSpawnRate { get; set; }
    [Export] private bool _spawnSwitch = false;

    private PathFollow2D path;
    private Timer timer;

    public override void _Ready()
    {
        path = GetNode<PathFollow2D>("PathFollow2D");
        timer = new Timer();
        timer.Autostart = _spawnSwitch;
        timer.WaitTime = _asteroidSpawnRate;
        timer.Timeout += OnAsteroidTimeout;
        AddChild(timer);
    }

    private void OnAsteroidTimeout()
    {
        var asteroid = (Asteroid)Asteroid.Instantiate();
        path.ProgressRatio = GD.Randf();
        asteroid.GlobalPosition = path.GlobalPosition;
        GetTree().CurrentScene.AddChild(asteroid);
    }
}
