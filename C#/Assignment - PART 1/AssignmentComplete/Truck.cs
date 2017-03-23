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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.Magenta);
        }

        public void Update(float f)
        {
            position += Velocity;
        }

        public void AddContainer(IContainer container) {}

        public void StartEngine(){}


    }

    class OreContainer : ITruck
    {

        Texture2D texture;
        public IContainer Container { get { return Container; } }
        public Vector2 position;
        public Vector2 Position { get { return position; } }
        public Vector2 velocity;
        public Vector2 Velocity { get { return velocity; } }



        public OreContainer(Texture2D texture, IContainer container, Vector2 position, Vector2 velocity)
        {
            this.texture = texture;
            IContainer Container = container;
            this.position = position;
            this.velocity = velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.Magenta);
        }

        public void Update(float f)
        {
            position += Velocity;
        }

        public void AddContainer(IContainer container){}

        public void StartEngine(){ }
    }
}
