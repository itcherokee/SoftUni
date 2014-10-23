package com.softuni.oop.geometry;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(Point2D center, double radius) {
        super(center);
        this.setRadius(radius);
    }

    public double getRadius() {
        return this.radius;
    }

    private void setRadius(double radius) {
        if (radius <= 0.0) {
            throw new IllegalArgumentException("Invalid radius - cannot be of negative or zero value.");
        }

        this.radius = radius;
    }

    @Override
    public double getArea() {
        return Math.PI * this.getRadius() * this.getRadius();
    }

    @Override
    public double getPerimeter() {
        return 2 * Math.PI * this.getRadius();
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Shape type: Circle\n");
        output.append(super.toString());

        return output.toString();
    }
}
