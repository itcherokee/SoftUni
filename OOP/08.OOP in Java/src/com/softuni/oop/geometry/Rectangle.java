package com.softuni.oop.geometry;

public class Rectangle extends PlaneShape {
    private double width;
    private double height;

    public Rectangle(Point2D vertexA, double width, double height) {
        super(vertexA);
        this.setWidth(width);
        this.setHeight(height);
    }

    public double getWidth() {
        return this.width;
    }

    public double getHeight() {
        return this.height;
    }

    private void setWidth(double width) {
        if (width <= 0.0) {
            throw new IllegalArgumentException("Invalid width - cannot be of negative or zero value.");
        }

        this.width = width;
    }

    private void setHeight(double height) {
        if (height <= 0.0) {
            throw new IllegalArgumentException("Invalid height - cannot be of negative or zero value.");
        }

        this.height = height;
    }

    @Override
    public double getArea() {
        return this.getWidth() * this.getHeight();
    }

    @Override
    public double getPerimeter() {
        return 2 * (this.getWidth() + this.getHeight());
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Shape type: Rectangle\n");
        output.append(super.toString());

        return output.toString();
    }
}
