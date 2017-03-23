using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssignmentComplete
{
    class Truck : ITruck
    {

        Texture2D texture;
        public IContainer Container { get { return Container; } }
        public Vector2 position;
        public Vector2 Position { get { return position; } }
        public Vector2 velocity;
        public Vector2 Velocity { get { return velocity; } }



        public Truck(Texture2D texture, IContainer container, Vector2 position, Vector2 velocity)
        {
            this.texture = texture;
            IContainer Container = container;
            this.position = position;
            this.velocity = velocity;

        }

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
                var box = new Ore(100, mine.OreBox());
                box.Position = position;
                return box;
            }
        }

        Texture2D volvo;
        List<IStateMachine> processes;
        Ore orebox;
        bool driving = false;

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
            position += velocity * dt;
        }
    }
}
