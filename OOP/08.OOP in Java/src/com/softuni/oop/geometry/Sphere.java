package com.softuni.oop.geometry;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(Point3D vertex, double radius) {
        super(vertex);
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
        return 4 * Math.PI * this.getRadius() * this.getRadius();
    }

    @Override
    public double getVolume() {
        return 4 / 3 * Math.PI * Math.pow(this.getRadius(), 3);
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Shape type: Sphere\n");
        output.append(super.toString());

        return output.toString();
    }
}
