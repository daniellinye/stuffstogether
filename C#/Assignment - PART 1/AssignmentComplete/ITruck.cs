using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AssignmentComplete;

namespace AssignmentComplete
{
  public interface ITruck : IComponent
  {
    IContainer Container { get; }
    Vector2 Position { get; }
    Vector2 Velocity { get; }
    void StartEngine();
    void AddContainer(IContainer container);
  }
}

class Truck : ITruck
{
    class DrawTruck : IAction
    {
        Mine mine;
        public DrawTruck(Mine mine)
        {
            this.mine = mine;
        }
        public void Run()
        {
            mine.ProductsToShip.Add(CreateOreBox(mine.Position + new Vector2(-80, 40 + -30 * mine.ProductsToShip.Count)));
        }
        Ore CreateOreBox(Vector2 position)
        {
            var box = new Ore(100, mine.oreBox);
            box.Position = position;
            return box;
        }
    }

    Texture2D volvo;
    List<IStateMachine> processes;
    Ore orebox;
    bool driving = false;

    public Truck()
    {
        processes = new List<IStateMachine>();

    }


    public IContainer Container { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }

    public void StartEngine()
    {

    }
    public void AddContainer(IContainer container)
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(volvo, Position, Color.Blue);
    }

    public void Update(float dt)
    {
        Position += Velocity * dt;
    }
}