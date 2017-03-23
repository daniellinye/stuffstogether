package factory;

import container.IContainer;
import truck.ITruck;

import component.IComponent;
import container.IContainer;
import truck.ITruck;
import javafx.geometry.Point2D;

import java.util.List;
import java.util.List;

/**
 * Created by Daniël on 23/03/2017.
 */
public class Mine implements IFactory {

    private int x = 0;
    private int y = 0;
    private Point2D position;
    public Mine(){

    }

    public ITruck getReadyTruck(){
        return null;
    }

    public Point2D getPosition(){
        return position;
    }

    public List<IContainer> getProductsToShip(){
        return null;
    }

}
