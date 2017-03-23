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
          mine.ProductsToShip.Add(CreateOreBox(mine.Position + new Vector2(-80, 40 + -30 * mine.ProductsToShip.Count)));
          if (mine.productsToShip.Count == 4)
          {
              mine.productsToShip = mine.productsToShip.GetRange(0, mine.productsToShip.Count - 4);
              mine.isTruckReady = true;

          }
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

    public Texture2D OreBox()
    {
        return this.oreBox;
    }

    public ITruck GetReadyTruck()
    {
        if (isTruckReady)
        {
            return new Truck(truckTexture, null, position + new Vector2(64, 32), new Vector2(2, 0));
        }
        return null;
    }
    public ITruck GetReadyOreContainer()
    {
        if (isTruckReady)
        {
            return new Truck(truckTexture, null, position + new Vector2(64, 32), new Vector2(2, 0));
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
      {
        cart.Draw(spriteBatch);
      }
        
        if(productsToShip.Count() != 3){
            waitingTruck.Draw(spriteBatch);
        }
      spriteBatch.Draw(mine, Position, Color.White);
    }
    public void Update(float dt)
    {
      foreach (var process in processes)
      {
        process.Update(dt);
      }
    }
    
  }

    class Ikea : IFactory
    {

        class AddOreBoxToMine : IAction
        {
            Ikea ikea;
            public void CreateProduct(Ikea ikea)
            {
                this.ikea = ikea;
            }
            public void Run()
            {
                ikea.ProductsToShip.Add(CreateOreBox(ikea.Position + new Vector2(-80, 40 + -30 * ikea.ProductsToShip.Count)));
                if (ikea.productsToShip.Count == 4)
                {
                    ikea.productsToShip = ikea.productsToShip.GetRange(0, ikea.productsToShip.Count - 4); 
                    //Not setting this to zero because math is cool.
                    /*
                    * TODO: Initialize a new truck here I think 
                    * ye probably
                    * 
                    * And second truck here :P
                    */
                }
            }


            //TODO: Make a product class
            Ore CreateOreBox(Vector2 position)
            {
                var box = new Ore(100, ikea.productBox);
                box.Position = position;
                return box;
            }
        }

        Texture2D ikea, product_box, product_container, truckTexture;
        List<IStateMachine> processes;
        ITruck waitingTruck;
        bool isTruckReady = false;
        Vector2 position;
        List<IContainer> productsToShip;

        public Ikea(Vector2 position, Texture2D truck_texture, Texture2D ikea, Texture2D product_box, Texture2D product_container)
        {
            processes = new List<IStateMachine>();
            ProductsToShip = new List<IContainer>();
            this.ikea = ikea;
            this.truckTexture = truck_texture;
            this.product_box = product_box;
            this.product_container = product_container;
            this.position = position;


            processes.Add(new Timer(1.0f));

            processes.Add(new Timer(1.0f));

        }

        public Texture2D productBox()
        {
            return this.product_box;
        }

        public ITruck GetReadyTruck()
        {
            if (isTruckReady)
            {
                return new Truck(truckTexture, null, position + new Vector2(64, 32), new Vector2(2, 0));
            }
            return null;
        }
        public ITruck GetReadyOreContainer()
        {
            if (isTruckReady)
            {
                return new Truck(truckTexture, null, position + new Vector2(64, 32), new Vector2(2, 0));
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
            {
                cart.Draw(spriteBatch);
            }
            spriteBatch.Draw(ikea, Position, Color.White);
        }
        public void Update(float dt)
        {
            foreach (var process in processes)
            {
                process.Update(dt);
            }
        }

    }

}
