package com.softuni.oop.geometry;

public class Cuboid extends SpaceShape {
    private double width;
    private double height;
    private double depth;

    public Cuboid(Point3D vertex, double width, double height, double depth) {
        super(vertex);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
    }

    public double getWidth() {
        return this.width;
    }

    private void setWidth(double width) {
        if (width <= 0.0) {
            throw new IllegalArgumentException("Invalid width - cannot be of negative or zero value.");
        }

        this.width = width;
    }

    public double getHeight() {
        return this.height;
    }

    private void setHeight(double height) {
        if (height <= 0.0) {
            throw new IllegalArgumentException("Invalid height - cannot be of negative or zero value.");
        }

        this.height = height;
    }

    public double getDepth() {
        return this.depth;
    }

    private void setDepth(double depth) {
        if (depth <= 0.0) {
            throw new IllegalArgumentException("Invalid depth - cannot be of negative or zero value.");
        }

        this.depth = depth;
    }

    @Override
    public double getArea() {
        return 2 * this.getWidth() + 2 * this.getHeight() + 2 * this.getDepth();
    }

    @Override
    public double getVolume() {
        return this.getWidth() * this.getHeight() * this.getDepth();
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Shape type: Cuboid\n");
        output.append(super.toString());

        return output.toString();
    }
}
