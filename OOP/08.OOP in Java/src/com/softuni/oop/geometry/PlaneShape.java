package com.softuni.oop.geometry;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable {

    protected PlaneShape(Point2D vertex) {
        super(vertex);
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append(String.format("Perimeter: %.2f cm\n", this.getPerimeter()));
        output.append(String.format("Area: %.2f cm2\n", this.getArea()));
        output.append(String.format("%s\n", super.toString()));

        return output.toString();
    }
}

