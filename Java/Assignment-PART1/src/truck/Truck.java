package truck;

import com.sun.javafx.geom.Vec2d;
import container.IContainer;
import javafx.geometry.Point2D;
import javafx.scene.canvas.GraphicsContext;

/**
 * Created by Daniël on 23/03/2017.
 */
public class Truck implements ITruck{

    public IContainer container;
    public Vec2d Position;
    public Vec2d Velocity; //in C# public Vector2 Position {get; set;}

    public void draw(GraphicsContext gc){

    }
    public void update(float dt){
        Position += Velocity * dt;

    }

    public void startEngine(){

    }

    public void addContainer(IContainer container){

    }

    public IContainer getContainer(){

    }

    public Point2D getPosition(){

    }

    public Point2D getVelocity(){

    }

}
/*
* private Texture2D truck_texture;
* public TRuck(Texture2d truck_texture){
*
* from factory.cs
*
* process.Add{
* new Timer (10.0f)
* }
* process.Add{
* new Seq(new Timer(1.0f))
*
*
* }
*
*
*
* */