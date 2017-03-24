using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssignmentComplete
{
    class Mine : IFactory
    {

        class AddOreBoxToMine : IAction
        {
            Mine mine;
            public AddOreBoxToMine(Mine mine)
            {
                this.mine = mine;
            }
            public void Run()
            {
                if (mine.productsToShip.Count() == 2)
                    mine.isTruckReady = true;
                if (mine.productsToShip.Count() == 3)
                    mine.productsToShip.Clear();

                mine.ProductsToShip.Add(CreateOreBox(mine.Position + new Vector2(-80, 40 + -30 * mine.ProductsToShip.Count)));
            }
            Ore CreateOreBox(Vector2 position)
            {
                var box = new Ore(100, mine.oreBox);
                box.Position = position;
                return box;
            }
        }

        Texture2D mine, oreContainer, oreBox, truckTexture;
        List<IStateMachine> processes;
        ITruck waitingTruck;
        bool isTruckReady = false;
        Vector2 position;
        List<IContainer> productsToShip;

        public Mine(Vector2 position, Texture2D truck_texture, Texture2D mine, Texture2D ore_box, Texture2D ore_container)
        {
            processes = new List<IStateMachine>();
            ProductsToShip = new List<IContainer>();
            this.mine = mine;
            this.truckTexture = truck_texture;
            this.oreContainer = ore_container;
            this.oreBox = ore_box;
            this.position = position;
            waitingTruck = new Truck(truckTexture, null, position + new Vector2(64, 32), new Vector2(0, 0));


            processes.Add(
              new Repeat(new Seq(new Timer(1.0f),
                  new Call(new AddOreBoxToMine(this)))));

            processes.Add(new Timer(1.0f));

        }

        public ITruck GetReadyTruck()
        {
            if (isTruckReady)
                return new Truck(truckTexture, null, position + new Vector2(76, 32), new Vector2(2, 0));
            
            return null;
        }
        public ITruck GetReadyOreContainer()
        {
            if (isTruckReady)
            {
                isTruckReady = false;
                return new OreContainer(oreContainer, null, position + new Vector2(64, 20), new Vector2(2, 0));
            }
            return null;
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public List<IContainer> ProductsToShip
        {
            get
            {
                return productsToShip;
            }
            set
            {
                productsToShip = value;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var cart in ProductsToShip)
                cart.Draw(spriteBatch);

            if (productsToShip.Count() < 3)
                waitingTruck.Draw(spriteBatch);
            
            spriteBatch.Draw(mine, Position, Color.White);
        }
        public void Update(float dt)
        {
            foreach (var process in processes)
                process.Update(dt);
            
        }

    }

    class Ikea : IFactory
    {

        class AddOreBoxToIkea : IAction
        {
            Ikea ikea;
            public AddOreBoxToIkea(Ikea ikea)
            {
                this.ikea = ikea;
            }
            public void Run()
            {
                if (ikea.productsToShip.Count() == 2)
                    ikea.isTruckReady = true;
                if (ikea.productsToShip.Count() == 3)
                    ikea.productsToShip.Clear();

                ikea.ProductsToShip.Add(CreateOreBox(ikea.Position - new Vector2(-80, 40 + 30 * ikea.ProductsToShip.Count)));
            }
            Ore CreateOreBox(Vector2 position)
            {
                var box = new Ore(100, ikea.oreBox);
                box.Position = position;
                return box;
            }
        }

        Texture2D ikea, oreContainer, oreBox, truckTexture;
        List<IStateMachine> processes;
        ITruck waitingTruck;
        bool isTruckReady = false;
        Vector2 position;
        List<IContainer> productsToShip;

        public Ikea(Vector2 position, Texture2D truck_texture, Texture2D ikea, Texture2D ore_box, Texture2D ore_container)
        {
            
            processes = new List<IStateMachine>();
            ProductsToShip = new List<IContainer>();
            this.ikea = ikea;
            this.truckTexture = FlipTexture(truck_texture);
            this.oreContainer = ore_container;
            this.oreBox = ore_box;
            this.position = position;
            waitingTruck = new Truck(truckTexture, null, position + new Vector2(-64, 32), new Vector2(0, 0));


            processes.Add(
              new Repeat(new Seq(new Timer(1.0f),
                  new Call(new AddOreBoxToIkea(this)))));

            processes.Add(new Timer(1.0f));

        }

        public ITruck GetReadyTruck()
        {
            if (isTruckReady)
                return new Truck(truckTexture, null, position + new Vector2(-76, 32), new Vector2(-2, 0));
            
            return null;
        }
        public ITruck GetReadyOreContainer()
        {
            if (isTruckReady)
            {
                isTruckReady = false;
                return new OreContainer(oreContainer, null, position + new Vector2(-88, 11), new Vector2(-2, 0));
            }
            return null;
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public List<IContainer> ProductsToShip
        {
            get
            {
                return productsToShip;
            }
            set
            {
                productsToShip = value;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var cart in ProductsToShip)
                cart.Draw(spriteBatch);

            if (productsToShip.Count() < 3)
                waitingTruck.Draw(spriteBatch);

            spriteBatch.Draw(ikea, Position, Color.White);
        }
        public void Update(float dt)
        {
            foreach (var process in processes)
                process.Update(dt);

        }

        public Texture2D FlipTexture(Texture2D input)
        {
            Texture2D texture = new Texture2D(input.GraphicsDevice, input.Width, input.Height);
            Color[] pic = new Color[input.Width * input.Height];
            Color[] flipPic = new Color[pic.Length];

            input.GetData<Color>(pic);

            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    flipPic[x + y*input.Width] = pic[input.Width - 1 - x + y*input.Width];
                }

            }
            texture.SetData<Color>(flipPic);

            return texture;
        }



    }


}
